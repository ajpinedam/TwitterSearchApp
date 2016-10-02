using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TwitterSearchApp.Models;

namespace TwitterSearchApp.Core
{
    public class ApiClient : IApiClient
    {
        public string ApiUrl { get; private set; } = "https://morning-wildwood-22288.herokuapp.com/";

        const string SearchEndPoint = "search";

        public async Task<IList<Twitt>> GetResults (string searchTerms, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = new List<Twitt> ();

            using (var client = new HttpClient ())
            {
                client.BaseAddress = new Uri (ApiUrl);
                var response  = await client.GetAsync ($"{SearchEndPoint}/{searchTerms}", cancellationToken);

                if (!response.IsSuccessStatusCode)
                    return result;

                var data = await response?.Content?.ReadAsStringAsync ();

                if (!string.IsNullOrWhiteSpace (data))
                    result = JsonConvert.DeserializeObject<List<Twitt>> (data);

                return result;
            }
        }

    }
}
