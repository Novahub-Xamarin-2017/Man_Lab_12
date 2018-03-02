﻿using System.Runtime.Serialization;

namespace Exercise_2.Models
{
    [DataContract]
    public class SignUpForm
    {
        [DataMember(Name = "full_name")]
        public string FullName { get; set; }

        [DataMember(Name = "user_name")]
        public string UserName { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}