using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Domain;
using TwitterAnalyzer.Interfaces;
using TwitterAnalyzer.Repository;

namespace TwitterAnalyzer.Application
{
    public class AccountAnalyzer
    {
        private AccountQuery accountQueryCtx;

        public AccountAnalyzer()
        {
            this.accountQueryCtx = new AccountQueryLinqToTwitter();
        }

        public AccountAnalyzer(AccountQuery accountQueryCtx)
        {
            this.accountQueryCtx = accountQueryCtx;
        }

        public AccountQuery AccountQueryRepository()
        {
            return accountQueryCtx;
        }

        public ReadOnlyCollection<Account> GetFollowingThatAreNotFollowers()
        {
            return new ReadOnlyCollection<Account>(accountQueryCtx.GetFollowing()
                                                    .Where(c => c.IsFollower == false)
                                                    .Select(c => c).ToList());
        }

        public ReadOnlyCollection<Account> GetFollowersThatAreNotFollowing()
        {
            return new ReadOnlyCollection<Account>(accountQueryCtx.GetFollowers()
                                                    .Where(c => c.IsFollowing == false)
                                                    .Select(c => c).ToList());
        }
    }
}
