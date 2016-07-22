using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideShareServiceClient;
using RideShare.Models;
using Newtonsoft.Json;

namespace RideShare
{
    public static class ServiceRequest
    {
        private const string SERVER = "http://172.28.40.252:8089"; //http://localhost:8089/
        private const string LOGIN_USER_URL = SERVER + "/users/rider/auth";
        private const string REGISTER_USER_URL = SERVER + "/users/newRider";
        private const string USER_INFO_URL = SERVER + "/authapp/userinfo";

        //test urls
        private const string TEST_SERVERJS_URL = SERVER + "/";
        private const string TEST_routerconfig_URL = SERVER + "/users";

        private const string TEST_Fetch_userd_URL = SERVER + "/users/Riders";

        public static UserJson GetUsers()
        {
            ServiceClient sc = new ServiceClient();
            Uri uri = new Uri(TEST_Fetch_userd_URL);
            string result = sc.SendRequest(uri);
            return JsonConvert.DeserializeObject<UserJson>(result.ToString());

        }

        public static Response Login(User user)
        {
            ServiceClient sc = new ServiceClient();
            Uri uri = new Uri(LOGIN_USER_URL);
            string result = sc.SendRequest(uri, user);
            Response res = JsonConvert.DeserializeObject<Response>(result);
            return res;

        }

        public static Response Register(User user)
        {
            ServiceClient sc = new ServiceClient();
            Uri uri = new Uri(REGISTER_USER_URL);
            string result = sc.SendRequest(uri, user);
            Response res = JsonConvert.DeserializeObject<Response>(result);
            return res;
        }

        //test GET 
        public static string gettestResponse(User user)
        {
            ServiceClient sc = new ServiceClient();
            Uri uri = new Uri(TEST_routerconfig_URL);
            string result = sc.SendRequest(uri);
            return result;

        }

    }
}
