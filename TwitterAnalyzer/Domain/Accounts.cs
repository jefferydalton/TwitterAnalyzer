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
    public class Accounts
    {
        private AccountQuery accountQueryRepository;

        public Accounts()
        {
            this.accountQueryRepository = new AccountQueryLinqToTwitter();
        }

        public Accounts(AccountQuery accountQueryRepository)
        {
            this.accountQueryRepository = accountQueryRepository;
        }

        public AccountQuery AccountQueryRepository()
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
