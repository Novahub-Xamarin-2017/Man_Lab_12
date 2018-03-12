using System.Net;
using Android.Util;
using Exercise_2.Models;
using RestSharp;

namespace Exercise_2.Services
{
    public class ChatServices
    {
        public ChatServices()
        {
            SimpleJson.SimpleJson.CurrentJsonSerializerStrategy = new CamelCaseSerializerStrategy();
        }
        
        private readonly RestClient client = new RestClient("http://192.168.1.108");
        
        public bool SignUp(SignUpForm signUpForm)
        {
            var request = new RestRequest("/api/chats/signup", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(signUpForm);
            var response = client.Execute(request);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public bool SignIn(SignInForm signInForm)
        {
            var request = new RestRequest("/api/chats/signin", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(signInForm);
            var response = client.Execute(request);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public void Send(string message, string userName)
        {
            var request = new RestRequest("api/chats/send", Method.POST);
            request.AddHeader("user", userName);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new
            {
                message
            });
            var response = client.Execute(request);
            Log.Info("Statuscode", response.StatusCode.ToString());
        }
    }
}