using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterAnalyzer.Application;
using TwitterAnalyzer.Domain.Model;

namespace TwitterAnalyzer.Domain
{
    public interface APIRateLimitRepository
    {
        List<APIRateLimit> GetRateLimits();
    }
}
