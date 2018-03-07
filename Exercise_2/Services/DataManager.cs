using Exercise_2.Models;
using Firebase.Iid;

namespace Exercise_2.Services
{
    public class DataManager
    {
        private static DataManager instance;

        public AppData AppData { get; set; }

        private DataManager()
        {
            AppData = new AppData()
            {
                LoggedStatus = false,
                FirebaseToken = FirebaseInstanceId.Instance.Token
            };
        }

        public static DataManager GetInstance => instance ?? (instance = new DataManager());
    }
}