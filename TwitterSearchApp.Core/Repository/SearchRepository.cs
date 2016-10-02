using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace TwitterSearchApp.Core
{
    public class SearchRepository : ISearchRepository
    {
        readonly IApiClient _apiClient;

        public SearchRepository (IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IEnumerable<SearchResult>> SearchTwitts (string search, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var twitts = await _apiClient.GetResults (search, cancellationToken);

                return twitts.Select (a => SearchResult.FromTwitt (a)).ToList ();

            }
            catch (TaskCanceledException taskCancelled)
            {
                System.Diagnostics.Debug.WriteLine ("User cancelled {0}", taskCancelled);
                return new List<SearchResult> ();
            }
            catch (OperationCanceledException operationCancelled)
            {
                System.Diagnostics.Debug.WriteLine ("User cancelled {0}", operationCancelled);
                return new List<SearchResult> ();
            }
        }
    }
}
