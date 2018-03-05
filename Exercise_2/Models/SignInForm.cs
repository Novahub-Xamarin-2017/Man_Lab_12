using System.Runtime.Serialization;

namespace Exercise_2.Models
{
    [DataContract]
    public class SignInForm
    {
        [DataMember(Name = "user_name")]
        public string UserName { get; set; }
        
        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "firebase_token")]
        public string FirebaseToken { get; set; }
    }
}