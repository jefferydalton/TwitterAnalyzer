using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Domain;

namespace TwitterAnalyzer.Interfaces
{
    public interface AccountQueryRepository
    {
        Account GetAccount(ulong accountId);
        ReadOnlyCollection<Domain.Account> GetFollowers();
        ReadOnlyCollection<Domain.Account> GetFollowing();
    }
}
