using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Application;
using TwitterAnalyzer.Interfaces;
using TwitterAnalyzer.Repository;

namespace TwitterAnalyzer.Application
{
    public class AccountQuery
    {
        private AccountQueryRepository accountQueryRepository;

        public AccountQuery()
        {
            this.accountQueryRepository = new AccountQueryRepositoryLinqToTwitter();
        }

        public AccountQuery(AccountQueryRepository accountQueryRepository)
        {
            this.accountQueryRepository = accountQueryRepository;
        }

        public AccountQueryRepository AccountQueryRepository()
        {
            return accountQueryRepository;
        }

        public ReadOnlyCollection<Account> GetAccountsThatDoNotFollowMeBack()
        {
            return new ReadOnlyCollection<Account>(accountQueryRepository.GetFollowing()
                                                    .Where(c => c.IsFollower == false)
                                                    .Select(c => c).ToList());
        }

        public ReadOnlyCollection<Account> GetAccountsIDoNotFollowBack()
        {
            return new ReadOnlyCollection<Account>(accountQueryRepository.GetFollowers()
                                                    .Where(c => c.IFollow == false)
                                                    .Select(c => c).ToList());
        }
    }
}
