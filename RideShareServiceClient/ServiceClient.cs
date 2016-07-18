using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RideShareServiceClient
{
    public class ServiceClient
    {

        //POST request
        public Task<string> SendRequest(Uri uri, object item)
        {

            var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = uri;
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            request.Content = content;
            
            try
            {
                var response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    //string res = response.Content.ReadAsStringAsync().Result;
                    //object m = JsonConvert.DeserializeObject<object>(res);
                    //return m;
                    return response.Content.ReadAsStringAsync();
                    //return JsonConvert.DeserializeObject<TResult>(resultJson);
                }
                else
                {
                    throw new Exception("Not success");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //if (response.IsSuccessStatusCode)
            //{
            //    content = response.Content.ReadAsStringAsync();
            //    return Task.Run(() = > JsonObject.Parse(content));
            //}

        }

        // GET request
        public Task<string> SendRequest(Uri uri)
        {

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = uri;

            try
            {
                var response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync();
                    //return JsonConvert.DeserializeObject<TResult>(resultJson);
                }
                else
                {
                    throw new Exception("Not success");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
