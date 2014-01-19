using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Domain.Model;
using TwitterAnalyzer.Domain;
using TwitterAnalyzer.Infrastructure;

namespace TwitterAnalyzer.Domain
{
    public class AccountQueryService
    {
        private AccountQueryRepository accountQueryRepository;

        public AccountQueryService()
        {
            this.accountQueryRepository = new AccountQueryRepositoryLinqToTwitter();
        }

        public AccountQueryService(AccountQueryRepository accountQueryRepository)
        {
            this.accountQueryRepository = accountQueryRepository;
        }

        public AccountQueryRepository AccountQueryRepository()
        {
            return accountQueryRepository;
        }

        public APIQueryServiceRepository RepositoryInformation()
        {
            return (APIQueryServiceRepository)accountQueryRepository;
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
