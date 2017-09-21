using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MockWebApi.Controllers
{
    public class CategoryWAController : ApiController
    {
        private static List<string> categoryWAList = new List<string>()
        {
            "Programación",
            "Base de Datos",
            "Diseño",
            "Otro"
        };

        // GET: api/BeforeDaysWS
        public IEnumerable<string> Get()
        {
            return categoryWAList;
        }

        // GET: api/UserWS
        public string Get(string key)
        {
            return categoryWAList.FirstOrDefault(x => x == key);
        }

        // POST: api/UserWS
        public IHttpActionResult Post([FromBody]string value)
        {
            if (value != null)
            {
                if (categoryWAList.FirstOrDefault(x => x == value) == null)
                {
                    try
                    {
                        categoryWAList.Add(value);
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
                if (categoryWAList.FirstOrDefault(x => x == value) == null)
                {
                    if (categoryWAList.FirstOrDefault(x => x == key) != null)
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
                if (categoryWAList.RemoveAll(x => x == key) != 0)
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
