using System;
using Newtonsoft.Json;

namespace TwitterSearchApp.Models
{
    public class User
    {
        [JsonProperty("id_str")]
        public string Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }


        public string Description { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("friends_count")]
        public int FriendsCount { get; set; }

        [JsonProperty("profile_image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("created_at")]
        public string MemberSince { get; set; }

        public User ()
        {
        }
    }
}
