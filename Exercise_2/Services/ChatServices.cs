using System.Net;
using Exercise_2.Models;
using RestSharp;

namespace Exercise_2.Services
{
    public class ChatServices
    {
        private const string RootUrl = "localhost:56301";

        private readonly RestClient client = new RestClient(RootUrl);

        public bool SignUp(SignUpForm signUpForm)
        {
            var request = new RestRequest("/api/chats/signup", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(signUpForm);
            var response = client.Execute(request);
            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}