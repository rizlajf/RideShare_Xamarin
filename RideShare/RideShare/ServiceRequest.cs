using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideShareServiceClient;
using RideShare.Models;

namespace RideShare
{
    public static class ServiceRequest
    {
        private const string SERVER = "http://172.28.40.252:8089"; //http://localhost:8089/
        private const string LOGIN_USER_URL = SERVER + "/users/rider/auth";
        private const string REGISTER_USER_URL = SERVER + "/authapp/accesstoken";
        private const string USER_INFO_URL = SERVER + "/authapp/userinfo";

        //test urls
        private const string TEST_SERVERJS_URL = SERVER + "/";
        private const string TEST_routerconfig_URL = SERVER + "/users";

        private const string TEST_Fetch_userd_URL = SERVER + "/users/Riders";

        public static string GetUsers()
        {
            ServiceClient sc = new ServiceClient();
            Uri uri = new Uri(TEST_Fetch_userd_URL);
            Task<string> result = sc.SendRequest(uri);
            return result.Result;

        }

        public static string Login(User user)
        {
            ServiceClient sc = new ServiceClient();
            Uri uri = new Uri(LOGIN_USER_URL);
            Task<string> result = sc.SendRequest(uri, user);
            return result.Result;

        }

        //test GET 
        public static string gettestResponse(User user)
        {
            ServiceClient sc = new ServiceClient();
            Uri uri = new Uri(TEST_routerconfig_URL);
            Task<string> result = sc.SendRequest(uri);
            return result.Result;

        }

    }
}
