using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Application;
using TwitterAnalyzer.Domain.Model;

namespace TwitterAnalyzer.Domain
{
    public interface AccountQueryRepository
    {
        Account GetAccount(ulong accountId);
        ReadOnlyCollection<Account> GetFollowers();
        ReadOnlyCollection<Account> GetFollowing();
    }
}
