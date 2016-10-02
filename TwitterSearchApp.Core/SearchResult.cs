using System;
using System.Globalization;
using TwitterSearchApp.Models;

namespace TwitterSearchApp.Core
{
    public class SearchResult
    {
        public string TwittId { get; set;}

        public string UserId { get; set;}

        public string ImageUrl { get; set; }

        public string TwitterText { get; set; }

        public DateTime? DatePosted { get; set;}

        public SearchResult ()
        {
        }

        public static SearchResult FromTwitt (Twitt twitt)
        {
            DateTime date;

            var searchResult= new SearchResult
            {
                TwittId = twitt.Id,
                ImageUrl = twitt.User?.ImageUrl,
                TwitterText = twitt.Text,
                UserId = twitt?.User?.ScreenName
            };


            var provider = CultureInfo.InvariantCulture;
            var format = "ddd dd MMM yyyy h:mm tt zzz";

            if (DateTime.TryParseExact (twitt.CreatedOn, format, provider, DateTimeStyles.None, out date ))
            {
                searchResult.DatePosted = date;
            }

            return searchResult;
        }
    }
}
