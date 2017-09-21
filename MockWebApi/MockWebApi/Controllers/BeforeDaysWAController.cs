using MockWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MockWebApi.Controllers
{
    public class BeforeDaysWAController : ApiController
    {
        private static List<string> beforeDaysWAList = new List<string>()
        {
            "5 días",
            "10 días",
            "15 días"
        };

        // GET: api/BeforeDaysWS
        public IEnumerable<string> Get()
        {
            return beforeDaysWAList;
        }

        // GET: api/UserWS
        public string Get(string key)
        {
            return beforeDaysWAList.FirstOrDefault(x => x == key);
        }

        // POST: api/UserWS
        public IHttpActionResult Post([FromBody]string value)
        {
            if (value != null)
            {
                if (beforeDaysWAList.FirstOrDefault(x => x == value) == null)
                {
                    try
                    {
                        beforeDaysWAList.Add(value);
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

        // PUT: api/UserWS/5
        public IHttpActionResult Put(string key, [FromBody]string value)
        {
            if (value != null)
            {
                if (beforeDaysWAList.FirstOrDefault(x => x == value) == null)
                {
                    if (beforeDaysWAList.FirstOrDefault(x => x == key) != null)
                    {
                        try
                        {
                            string temp = Get(key);

                            temp = value;

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

        // DELETE: api/UserWS/5
        public IHttpActionResult Delete(string key)
        {
            try
            {
                if (beforeDaysWAList.RemoveAll(x => x == key) != 0)
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
