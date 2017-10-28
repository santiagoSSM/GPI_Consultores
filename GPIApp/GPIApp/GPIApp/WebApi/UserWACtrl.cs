using GPIApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.WebApi
{
    public static class UserWACtrl
    {
        public static async Task<UserModel> Put(UserPassModel user)
        {
            try
            {
                var uri = new Uri(ConstantsWA.WebApiServer + "User/Put");
                var json = JsonConvert.SerializeObject(user);

                using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                using (var client = new HttpClient())
                using (HttpResponseMessage response = await client.PutAsync(uri, content))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Error " + response.StatusCode.GetHashCode() + " " + response.ReasonPhrase);
                    }
                    else
                    {
                        return JsonConvert.DeserializeObject<UserModel>(
                            await response.Content.ReadAsStringAsync()  //Get the json
                        );
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
