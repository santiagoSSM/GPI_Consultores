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

        public async Task<ObservableCollection<TaskListItemModel>> GetSelect<X>(string serverVarName, X key)
        {
            var uri = new Uri(string.Format(url, string.Format("?{0}=", serverVarName), key));

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ObservableCollection<TaskListItemModel>>(
                    await response.Content.ReadAsStringAsync()  //Get the json
                );
            }

            return default(ObservableCollection<TaskListItemModel>);
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
            await client.Post(value);
        }

        public async Task Put(string key, TaskModel value)
        {
            await client.Put("key", key, value);
        }

        public async Task Delete(int key)
        {
            await client.Delete("key", key);
        }

        public async Task<ObservableCollection<TaskListItemModel>> GetSelect(char select)
        {
            return await client.GetSelect<char>("select", select);
        }
    }
}
