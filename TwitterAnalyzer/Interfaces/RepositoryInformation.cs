using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Domain;

namespace TwitterAnalyzer.Interfaces
{
    public interface RepositoryInformation
    {
        List<APIRateLimit> GetRateLimits();
    }
}
