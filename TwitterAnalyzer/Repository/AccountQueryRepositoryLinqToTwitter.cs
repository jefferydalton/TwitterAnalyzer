using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Interfaces;
using LinqToTwitter;
using System.Collections.ObjectModel;
using MoreLinq;
using TwitterAnalyzer.Extensions;
using TwitterAnalyzer.Application;

namespace TwitterAnalyzer.Repository
{
    public class AccountQueryRepositoryLinqToTwitter : LinkToTwitterBase, AccountQueryRepository, RepositoryInformation
    {
        public AccountQueryRepositoryLinqToTwitter(): base()
        {
        }

        public Application.Account GetAccount(ulong accountId)
        {
            using (var twitterCtx = new TwitterContext(this.GetAuthKey()))
            {
                var accountIdList = new List<string>() { accountId.ToString() };
                return GetUsers(twitterCtx, accountIdList).FirstOrDefault();
            }
        }

        public ReadOnlyCollection<Application.Account> GetFollowers()
        {
            return GetAccounts(SocialGraphType.Followers);
        }

        public ReadOnlyCollection<Application.Account> GetFollowing()
        {
            return GetAccounts(SocialGraphType.Friends);
        }

        private ReadOnlyCollection<Application.Account> GetAccounts(SocialGraphType accountType)
        {
            ReadOnlyCollection<Application.Account> response;
            using (var twitterCtx = new TwitterContext(this.GetAuthKey()))
            {
                var Ids = GetIDs(twitterCtx, accountType, "-1");
                response = new ReadOnlyCollection<Application.Account>(GetUsers(twitterCtx, Ids));
            }

            return response;
        }


        private List<Application.Account> GetUsers(TwitterContext twitterctx, List<string> Ids)
        {
            List<Application.Account> response = new List<Application.Account>();

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
                     select new Application.Account() {
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


        public List<Application.APIRateLimit> GetRateLimits()
        {
            string[] apiList = new string [] {"/users/lookup", "/friends/ids", "/followers/ids", "/friendships/lookup"}; 

            return this.RateLimits()
                        .Where(x => apiList.Contains(x.Resource))
                        .Select(x => new APIRateLimit()
                        {
                            Limit = x.Limit,
                            NextReset = x.Reset.ToDateTimeFromUnixTime(),
                            RemainingCalls = x.Remaining,
                            Resource = x.Resource
                        }).ToList();
        }
    }
}
