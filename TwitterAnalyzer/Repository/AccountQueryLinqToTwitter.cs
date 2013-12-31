using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Interfaces;
using LinqToTwitter;
using System.Collections.ObjectModel;
using MoreLinq;

namespace TwitterAnalyzer.Repository
{
    public class AccountQueryLinqToTwitter : LinkToTwitterBase, AccountQuery
    {

        public AccountQueryLinqToTwitter(): base()
        {
        }

        public Domain.Account GetAccount(ulong accountId)
        {
            using (var twitterCtx = new TwitterContext(this.GetAuthKey()))
            {

                var response =
                    (from user in twitterCtx.User
                     where user.Type == UserType.Show &&
                           user.UserID == accountId.ToString()
                     select new Domain.Account()
                     {
                         AccountId = ulong.Parse(user.UserID),
                         AccountDescription = user.Description,
                         AccountName = user.Name
                     }).SingleOrDefault();
                    
                var friendships =
                    (from friend in twitterCtx.Friendship
                     where friend.Type == FriendshipType.Show &&
                           friend.SourceUserID == MyTwitterId &&
                           friend.TargetUserID == accountId.ToString()
                     select friend).SingleOrDefault();

                response.IFollow = friendships.SourceRelationship.FollowedBy;
                response.IsFollower = friendships.TargetRelationship.FollowedBy;

                return response;
            }
        }

        public ReadOnlyCollection<Domain.Account> GetFollowers()
        {
            return GetAccounts(SocialGraphType.Followers);
        }

        public ReadOnlyCollection<Domain.Account> GetFollowing()
        {
            return GetAccounts(SocialGraphType.Friends);
        }

        private ReadOnlyCollection<Domain.Account> GetAccounts(SocialGraphType accountType)
        {
            ReadOnlyCollection<Domain.Account> response;
            using (var twitterCtx = new TwitterContext(this.GetAuthKey()))
            {
                var Ids = GetIDs(twitterCtx, accountType, "-1");
                response = new ReadOnlyCollection<Domain.Account>(GetUsers(twitterCtx, Ids));
            }

            return response;
        }


        private List<Domain.Account> GetUsers(TwitterContext twitterctx, List<string> Ids)
        {
            List<Domain.Account> response = new List<Domain.Account>();

            foreach (var batch in Ids.Batch(100))
            {
                var lookupQuery = string.Join(",", batch);

                var relationships =
                    (from friendship in twitterctx.Friendship
                     where friendship.Type == FriendshipType.Lookup &&
                            friendship.UserID == lookupQuery
                     select friendship).SingleOrDefault().Relationships;

                var users =
                    (from user in twitterctx.User
                     where user.Type == UserType.Lookup &&
                            user.UserID == lookupQuery
                     select user).ToList();

                var joinedUserData =
                    (from user in users
                     join rel in relationships
                     on user.Identifier.ID equals rel.ID
                     select new Domain.Account() {
                        AccountId = ulong.Parse(user.Identifier.ID),
                        AccountName = user.Identifier.ScreenName,
                        AccountDescription = user.Description,
                        IsFollower = rel.Connections.Contains("followed_by"),
                        IFollow = rel.Connections.Contains("following")
                     }).ToList();

                response.AddRange(joinedUserData);
            }
            return response;
        }


        private List<String> GetIDs(TwitterContext twitterCtx, SocialGraphType apiType, string cursor)
        {
            var Ids =
                (from friendShip in twitterCtx.SocialGraph
                 where friendShip.Type == apiType &&
                       friendShip.UserID == ulong.Parse(MyTwitterId) &&
                       friendShip.Count == 200 &&
                       friendShip.Cursor == cursor
                 select friendShip).SingleOrDefault();

            string nextCursor = Ids.CursorMovement.Next;
            var response = Ids.IDs;

            if (nextCursor != "0")
            {
                response.AddRange(GetIDs(twitterCtx, apiType, nextCursor));
            }

            return response;
        }




    
    }
}
