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
        private static List<TaskWA> listTask = new List<TaskWA>()
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
            return listTask;
        }

        // GET: api/TaskWS/5
        public TaskWA Get(int key)
        {
            return listTask.FirstOrDefault(x => x.IdTask == key);
        }

        // POST: api/TaskWS
        public IHttpActionResult Post([FromBody]TaskWA value)
        {
            if (true)
            {
                try
                {
                    value.IdTask = listTask.Count();
                    listTask.Add(value);
                    return Ok();
                }
                catch
                {
                    return InternalServerError();
                }
            }
            return InternalServerError();
        }

        // PUT: api/TaskWS/5
        public IHttpActionResult Put(int key, [FromBody]TaskWA value)
        {
            if (true)
            {
                if (listTask.FirstOrDefault(x => x.IdTask == value.IdTask) == null)
                {
                    if (listTask.FirstOrDefault(x => x.IdTask == key) != null)
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
                if (listTask.RemoveAll(x => x.IdTask == key) != 0)
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
    }
}
