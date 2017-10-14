using GPIApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiConector;

namespace GPIApp.WebApi
{
    internal class RestTaskImplemented<T> : RestClient<T>
    {
        public RestTaskImplemented(string url) : base(url)
        {
        }

        public async Task<ObservableCollection<string>> GetSelect<X>(string serverVarName, X key)
        {
            var uri = new Uri(string.Format(url, string.Format("?{0}=", serverVarName), key));

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ObservableCollection<string>>(
                    await response.Content.ReadAsStringAsync()  //Get the json
                );
            }

            return default(ObservableCollection<string>);
        }

        public async Task<T> GetS<X>(string serverVarName, X key)
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
    }

    public class TaskWA
    {
        RestTaskImplemented<TaskModel> client = new RestTaskImplemented<TaskModel>(ConstantsWA.WebApiServer + "TaskWA/");

        public async Task<ObservableCollection<TaskModel>> Get()
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

        public async Task<TaskModel> Get(string key)
        {
            return await client.Get("key", key);
        }

        public async Task Post(TaskModel value)
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

        public async Task Put(string key, TaskModel value)
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

        public async Task Delete(int key)
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

        public async Task<ObservableCollection<TaskListItemModel>> GetSelect()
        {
            ObservableCollection<TaskListItemModel> temp = new ObservableCollection<TaskListItemModel>();

            try
            {
                foreach (string element in await client.GetSelect<char>("select", 'l'))
                {
                    temp.Add(
                        new TaskListItemModel()
                        {
                            Title = element
                        }
                        );
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return temp;
        }
    }
}
