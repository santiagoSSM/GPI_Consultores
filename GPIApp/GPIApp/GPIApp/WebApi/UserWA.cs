﻿using GPIApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiConector;

namespace GPIApp.WebApi
{
    class RestClientImplemented<T> : RestClient<T>
    {
        public RestClientImplemented(string url) : base(url)
        {
        }

        // GET: api/{ModelName}/{var}
        public async Task<T> GetSearch<X>(string serverVarName, X key)
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

        public async Task<bool> PutLogin<X>(string serverVarName, X key, T value)
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
                else
                {
                    return JsonConvert.DeserializeObject<bool>(
                        await response.Content.ReadAsStringAsync()  //Get the json
                    );
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class UserWA
    {
        RestClientImplemented<UserAPP> client = new RestClientImplemented<UserAPP>(ConstantsWA.WebApiServer + "UserWS/");

        public async Task<List<UserAPP>> Get()
        {
            try
            {
                return await client.Get();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UserAPP> Get(int id)
        {
            try
            {
                return await client.Get("id", id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Post(UserAPP value)
        {
            try
            {
                await client.Post(value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Put(string key, UserAPP value)
        {
            try
            {
                await client.Put("key", key, value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Delete(string key)
        {
            try
            {
                await client.Delete("key", key);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: api/{ModelName}/{var}
        public async Task<UserAPP> GetSearch(string key)
        {
            try
            {
                return await client.GetSearch("key", key);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> PutLogin(UserAPP value)
        {
            try
            {
                return await client.PutLogin<char>("select", 'l', value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}