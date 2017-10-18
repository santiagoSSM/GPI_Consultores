using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MockWebApi.Controllers
{
    public class RecurrenceWAController : ApiController
    {
        private static List<string> recurrenceWAList = new List<string>()
        {
            "Ninguna",
            "Diaria",
            "Semanal",
            "Mensual",
            "Anual"
        };

        // GET: api/BeforeDaysWS
        public IEnumerable<string> Get()
        {
            return recurrenceWAList;
        }

        // GET: api/UserWS
        public string Get(string key)
        {
            return recurrenceWAList.FirstOrDefault(x => x == key);
        }

        // POST: api/UserWS
        public IHttpActionResult Post([FromBody]string value)
        {
            if (value != null)
            {
                if (recurrenceWAList.FirstOrDefault(x => x == value) == null)
                {
                    try
                    {
                        recurrenceWAList.Add(value);
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
                if (recurrenceWAList.FirstOrDefault(x => x == value) == null)
                {
                    if (recurrenceWAList.FirstOrDefault(x => x == key) != null)
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
                if (recurrenceWAList.RemoveAll(x => x == key) != 0)
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
