using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MockWebApi.Controllers
{
    public class AfterDayWAController : ApiController
    {
        private static List<string> afterDayWAList = new List<string>()
        {
            "4 recurrencias",
            "8 recurrencias",
            "12 recurrencias"
        };

        // GET: api/BeforeDaysWS
        public IEnumerable<string> Get()
        {
            return afterDayWAList;
        }

        // GET: api/UserWS
        public string Get(string key)
        {
            return afterDayWAList.FirstOrDefault(x => x == key);
        }

        // POST: api/UserWS
        public IHttpActionResult Post([FromBody]string value)
        {
            if (value != null)
            {
                if (afterDayWAList.FirstOrDefault(x => x == value) == null)
                {
                    try
                    {
                        afterDayWAList.Add(value);
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
                if (afterDayWAList.FirstOrDefault(x => x == value) == null)
                {
                    if (afterDayWAList.FirstOrDefault(x => x == key) != null)
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
                if (afterDayWAList.RemoveAll(x => x == key) != 0)
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
