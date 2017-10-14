using MockWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MockWebApi.Controllers
{
    public class TaskWAController : ApiController
    {
        private static List<TaskWA> taskWAList = new List<TaskWA>()
        {
            
            
            new TaskWA()
            {
                IdTask = 0,
                UserIssue = "tarea0",
                UserResp = "Oscar",
                UserCopy = "copia",
                UserCategory = "categoria",
                UserAprob = true,
                UserPriority = "prioridad",
                UserDescription = "descripcion",
                UserRecurrence = "recurrencia",
                UserBeforeDays = "5 días",
                UserCancelRecurrence = false,
                UserContractDate = new DateTime(2010, 8, 10)
            },

            new TaskWA()
            {
                IdTask = 1,
                UserIssue = "tarea1",
                UserResp = "Oscar",
                UserCopy = "copia",
                UserCategory = "categoria",
                UserAprob = true,
                UserPriority = "prioridad",
                UserDescription = "descripcion",
                UserRecurrence = "recurrencia",
                UserBeforeDays = "5 días",
                UserCancelRecurrence = false,
                UserContractDate = new DateTime(2010, 8, 10)
            },

            new TaskWA()
            {
                IdTask = 2,
                UserIssue = "tarea2",
                UserResp = "Oscar",
                UserCopy = "copia",
                UserCategory = "categoria",
                UserAprob = true,
                UserPriority = "prioridad",
                UserDescription = "descripcion",
                UserRecurrence = "recurrencia",
                UserBeforeDays = "5 días",
                UserCancelRecurrence = false,
                UserContractDate = new DateTime(2010, 8, 10)
            }
        };

        // GET: api/TaskWS
        public IEnumerable<TaskWA> Get()
        {
            return taskWAList;
        }

        // GET: api/TaskWS/5
        public TaskWA Get(string key)
        {
            return taskWAList.FirstOrDefault(x => x.UserIssue == key);
        }

        // POST: api/TaskWS
        public IHttpActionResult Post([FromBody]TaskWA value)
        {
            if (true)
            {
                if (taskWAList.FirstOrDefault(x => x.UserIssue == value.UserIssue) == null)
                {
                    try
                    {
                        value.IdTask = taskWAList.Count();
                        taskWAList.Add(value);
                        return Ok();
                    }
                    catch
                    {
                        return InternalServerError();
                    }
                }
            }
            return InternalServerError();
        }

        // PUT: api/TaskWS/5
        public IHttpActionResult Put(string key, [FromBody]TaskWA value)
        {
            if (true)
            {
                if (taskWAList.FirstOrDefault(x => x.IdTask == value.IdTask) == null)
                {
                    if (taskWAList.FirstOrDefault(x => x.UserIssue == key) != null)
                    {
                        try
                        {
                            TaskWA temp = Get(key);

                            temp.IdTask = value.IdTask;
                            temp.UserResp = value.UserResp;
                            temp.UserCopy = value.UserCopy;
                            temp.UserCategory = value.UserCategory;
                            temp.UserAprob = value.UserAprob;
                            temp.UserPriority = value.UserPriority;
                            temp.UserRecurrence = value.UserRecurrence;
                            temp.UserBeforeDays = value.UserBeforeDays;
                            temp.UserCancelRecurrence = value.UserCancelRecurrence;
                            temp.UserContractDate = value.UserContractDate;

                            return Ok();
                        }
                        catch
                        {
                            return InternalServerError();
                        }
                    }
                }
            }
            return InternalServerError();
        }

        // DELETE: api/TaskWS/5
        public IHttpActionResult Delete(int key)
        {
            try
            {
                if (taskWAList.RemoveAll(x => x.IdTask == key) != 0)
                {
                    return Ok();
                }
            }
            catch
            {
                return InternalServerError();
            }
            return InternalServerError();
        }

        public IEnumerable<string> GetSelect(char select)
        {
            List<string> temp = new List<string>();

            foreach (TaskWA element in taskWAList)
            {
                temp.Add(element.UserIssue);
            }

            return temp;
        }
    }
}
