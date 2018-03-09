using System.Collections.Generic;

namespace Exercise_2.Models
{
    public class AppData
    {
        public bool LoggedStatus { get; set; }

        public string FirebaseToken { get; set; }

        public string UserName { get; set; }

        public List<string> Messages { get; set; }
    }
}