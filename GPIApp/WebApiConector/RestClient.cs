using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiConector
{
    public class RestClient<T>
    {
        protected HttpClient client = new HttpClient();
        protected string url;

        public RestClient(string url)
        {
            this.url = url + "{0}{1}";
        }

        // GET: api/{ModelName}/
        public async Task<List<T>> Get()
        {
            var uri = new Uri(string.Format(url, string.Empty, string.Empty));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<T>>(
                        await response.Content.ReadAsStringAsync()  //Get the json
                    );
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return default(List<T>);
        }

        // GET: api/{ModelName}/{var}
        public async Task<T> Get<X>(string serverVarName, X key)
        {
            var uri = new Uri(string.Format(url, string.Format("?{0}=", serverVarName), key));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(
                        await response.Content.ReadAsStringAsync()  //Get the json
                    );
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return default(T);
        }

        // GET: api/{ModelName}/
        public async Task Post(T value)
        {
            var uri = new Uri(string.Format(url, string.Empty, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(value);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error " + response.StatusCode.GetHashCode() + " " + response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: api/{ModelName}/{var}
        public async Task Put<X>(string serverVarName, X key, T value)
        {
            var uri = new Uri(string.Format(url, string.Format("?{0}=", serverVarName), key));

            try
            {
                var json = JsonConvert.SerializeObject(value);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error " + response.StatusCode.GetHashCode() + " " + response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: api/{ModelName}/{var}
        public async Task Delete<X>(string serverVarName, X key)
        {
            var uri = new Uri(string.Format(url, string.Format("?{0}=", serverVarName), key));

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error " + response.StatusCode.GetHashCode() + " " + response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
