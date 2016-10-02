using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TwitterSearchApp.Core
{
    public interface ISearchRepository
    {
        Task<IEnumerable<SearchResult>> SearchTwitts (string search, CancellationToken cancellationToken = default (CancellationToken));
    }
}
