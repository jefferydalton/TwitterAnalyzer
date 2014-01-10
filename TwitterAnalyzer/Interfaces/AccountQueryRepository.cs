using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Application;

namespace TwitterAnalyzer.Interfaces
{
    public interface AccountQueryRepository
    {
        Account GetAccount(ulong accountId);
        ReadOnlyCollection<Application.Account> GetFollowers();
        ReadOnlyCollection<Application.Account> GetFollowing();
    }
}
