using MockWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MockWebApi.Controllers
{
    public class TaskWSController : ApiController
    {
        private static List<TaskWS> listTask = new List<TaskWS>();

        // GET: api/TaskWS
        public IEnumerable<TaskWS> Get()
        {
            return listTask;
        }

        // GET: api/TaskWS/5
        public TaskWS Get(int id)
        {
            return listTask.ElementAtOrDefault(id);
        }

        // GET: api/TaskWS/5
        public TaskWS GetSearch(int key)
        {
            return listTask.FirstOrDefault(x => x.IdTask == key);
        }

        // POST: api/TaskWS
        public IHttpActionResult Post([FromBody]TaskWS value)
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
        public IHttpActionResult Put(int key, [FromBody]TaskWS value)
        {
            if (true)
            {
                if (listTask.FirstOrDefault(x => x.IdTask == value.IdTask) == null)
                {
                    if (listTask.FirstOrDefault(x => x.IdTask == key) != null)
                    {
                        try
                        {
                            TaskWS temp = GetSearch(key);

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
