using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TwitterSearchApp.Models;

namespace TwitterSearchApp.Core
{
    public interface IApiClient 
    {
        string ApiUrl { get;}

        Task<IList<Twitt>> GetResults (string searchTerms, CancellationToken cancellationToken = default (CancellationToken));
    }
}
