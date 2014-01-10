using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Application;
using TwitterAnalyzer.Interfaces;

namespace TwitterAnalyzer.Repository
{
    public class AccountQueryRepositoryInMemory : AccountQueryRepository, RepositoryInformation
    {
        public Application.Account GetAccount(ulong accountId)
        {
            return new Account() { AccountId = accountId,
                                   AccountDescription = "Test InMemory Account",
                                   AccountName="TestInMemory",
                                   IFollow = false,
                                   IsFollower = true};
        }

        public ReadOnlyCollection<Application.Account> GetFollowers()
        {
            List<Application.Account> accountsThatIFollow = new List<Application.Account>();
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

        public ReadOnlyCollection<Application.Account> GetFollowing()
        {
            List<Application.Account> accountsThatIFollow = new List<Application.Account>();
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

        public List<APIRateLimit> GetRateLimits()
        {
            return new List<APIRateLimit>() { new APIRateLimit() { Resource = "null", Limit = int.MaxValue, NextReset = DateTime.MinValue, RemainingCalls = int.MaxValue } };
        }
    }
}
