using GPIApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GPIApp.WebApi
{
    public static class TaskWACtrl
    {
        public static async Task<TaskPickersModel> GetTaskPickers()
        {
            var uri = new Uri(ConstantsWA.WebApiServer + "Task/GetTP/");

            try
            {
                using (var client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<TaskPickersModel>(
                            await response.Content.ReadAsStringAsync()  //Get the json
                        );
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return default(TaskPickersModel);
        }

        public static async Task<TaskSeeModel> GetSeeTask(int idTask)
        {
            return null;
        }

        public static async Task<TaskBindingModel> GetEditTask(int idTask)
        {
            return null;
        }

        public static async Task<ObservableCollection<TaskListItemModel>> PutTaskListItem(int idUser, FiltersParamModel filters)
        {
            try
            {
                var uri = new Uri(ConstantsWA.WebApiServer + "Task/Put/?idUser="+idUser);
                var json = JsonConvert.SerializeObject(filters);

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
                        return JsonConvert.DeserializeObject<ObservableCollection<TaskListItemModel>>(
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

        public static async Task<bool> Post(TaskUserDraftModel value)
        {
            return false;
        }
    }
}
