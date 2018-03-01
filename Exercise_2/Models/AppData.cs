using Newtonsoft.Json;

namespace Exercise_2.Models
{
    public class AppData
    {
        [JsonProperty("is_logged_in")]
        public bool IsLoggedIn { get; set; }
    }
}