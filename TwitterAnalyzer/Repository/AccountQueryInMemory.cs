using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Domain;
using TwitterAnalyzer.Interfaces;

namespace TwitterAnalyzer.Repository
{
    public class AccountQueryInMemory : AccountQuery
    {
        public Domain.Account GetAccount(ulong accountId)
        {
            return new Account() { AccountId = accountId,
                                   AccountDescription = "Test InMemory Account",
                                   AccountName="TestInMemory",
                                   IFollow = false,
                                   IsFollower = true};
        }

        public ReadOnlyCollection<Domain.Account> GetFollowers()
        {
            List<Domain.Account> accountsThatIFollow = new List<Domain.Account>();
            accountsThatIFollow.Add(new Account()
            {
                AccountId = 2,
                IsFollower = false,
                IFollow = true,
                AccountName = "TestInMemory2",
                AccountDescription = "Test InMemory Account"
            });

            return new ReadOnlyCollection<Account>(accountsThatIFollow);
        }

        public ReadOnlyCollection<Domain.Account> GetFollowing()
        {
            List<Domain.Account> accountsThatIFollow = new List<Domain.Account>();
            accountsThatIFollow.Add(new Account()
            {
                AccountId = 3,
                IsFollower = true,
                IFollow = false,
                AccountName = "TestInMemory3",
                AccountDescription = "Test InMemory Account"
            });

            return new ReadOnlyCollection<Account>(accountsThatIFollow);
        }
    }
}
