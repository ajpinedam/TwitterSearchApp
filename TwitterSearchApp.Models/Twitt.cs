using System;
using Newtonsoft.Json;

namespace TwitterSearchApp.Models
{
    public class Twitt
    {
        [JsonProperty("id_str")]
        public string Id { get; set;}

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("created_at")]
        public string CreatedOn { get; set; }

        public User User { get; set;}

        public Twitt ()
        {
        }
    }
}
