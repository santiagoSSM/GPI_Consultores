using GPIApp.Models;
using GPIApp.Models.Recurrence;
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
                var temp = await client.Get();

                foreach (TaskModel element in temp)
                {
                    //Deserialise ObjRecurrence

                    switch (element.UserRecurrence)
                    {
                        case "Ninguna":
                            {
                                element.ObjRecurrence = JsonConvert.DeserializeObject<NoneTaskModel>(
                                    element.ObjRecurrence.ToString()
                                    );
                                break;
                            }
                        case "Diaria":
                            {
                                element.ObjRecurrence = JsonConvert.DeserializeObject<DailyTaskModel>(
                                    element.ObjRecurrence.ToString()
                                    );
                                break;
                            }
                        case "Semanal":
                            {
                                element.ObjRecurrence = JsonConvert.DeserializeObject<WeeklyTaskModel>(
                                    element.ObjRecurrence.ToString()
                                    );
                                break;
                            }
                        case "Mensual":
                            {
                                element.ObjRecurrence = JsonConvert.DeserializeObject<MonthlyTaskModel>(
                                    element.ObjRecurrence.ToString()
                                    );
                                break;
                            }
                        case "Anual":
                            {
                                element.ObjRecurrence = JsonConvert.DeserializeObject<AnnualTaskModel>(
                                    element.ObjRecurrence.ToString()
                                    );
                                break;
                            }
                    }
                }

                return temp;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<TaskModel> Get(int key)
        {
            try
            {
                var temp = await client.Get("key", key);

                //Deserialise ObjRecurrence

                switch (temp.UserRecurrence)
                {
                    case "Ninguna":
                        {
                            temp.ObjRecurrence = JsonConvert.DeserializeObject<NoneTaskModel>(
                                temp.ObjRecurrence.ToString()
                                );
                            break;
                        }
                    case "Diaria":
                        {
                            temp.ObjRecurrence = JsonConvert.DeserializeObject<DailyTaskModel>(
                                temp.ObjRecurrence.ToString()
                                );
                            break;
                        }
                    case "Semanal":
                        {
                            temp.ObjRecurrence = JsonConvert.DeserializeObject<WeeklyTaskModel>(
                                temp.ObjRecurrence.ToString()
                                );
                            break;
                        }
                    case "Mensual":
                        {
                            temp.ObjRecurrence = JsonConvert.DeserializeObject<MonthlyTaskModel>(
                                temp.ObjRecurrence.ToString()
                                );
                            break;
                        }
                    case "Anual":
                        {
                            temp.ObjRecurrence = JsonConvert.DeserializeObject<AnnualTaskModel>(
                                temp.ObjRecurrence.ToString()
                                );
                            break;
                        }
                }

                return temp;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Post(TaskModel value)
        {
            await client.Post(value);
        }

        public async Task Put(int key, TaskModel value)
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
