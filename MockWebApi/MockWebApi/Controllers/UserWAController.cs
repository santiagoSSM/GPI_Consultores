using MockWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MockWebApi.Controllers
{
    public class UserWAController : ApiController
    {
        private static List<UserWA> userWAList = new List<UserWA>()
        {
            new UserWA()
            {
                UserId = "user",
                UserPassword = "pass"
            },

            new UserWA()
            {
                UserId = "user1",
                UserPassword = "pass"
            },

            new UserWA()
            {
                UserId = "user2",
                UserPassword = "pass"
            }
        };

        // GET: api/UserWS
        public IEnumerable<UserWA> Get()
        {
            return userWAList;
        }

        // GET: api/UserWS
        public UserWA Get(string key)
        {
            return userWAList.FirstOrDefault(x => x.UserId == key);
        }

        // POST: api/UserWS
        public IHttpActionResult Post([FromBody]UserWA value)
        {
            if (value.UserId != null && value.UserPassword != null)
            {
                if (userWAList.FirstOrDefault(x => x.UserId == value.UserId) == null)
                {
                    try
                    {
                        userWAList.Add(value);
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
        public IHttpActionResult Put(string key, [FromBody]UserWA value)
        { 
            if (value.UserId != null && value.UserPassword != null)
            {
                if (userWAList.FirstOrDefault(x => x.UserId == key) != null)
                {
                    try
                    {
                        UserWA temp = Get(key);

                        temp.UserId = value.UserId;
                        temp.UserPassword = value.UserPassword;

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

        // DELETE: api/UserWS/5
        public IHttpActionResult Delete(string key)
        {
            try
            {
                if (userWAList.RemoveAll(x => x.UserId == key) != 0)
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

        // Login method
        public bool PutSelect(char select, [FromBody]UserWA value)
        {
            return userWAList.FirstOrDefault(x => x.UserId == value.UserId && x.UserPassword == value.UserPassword)!=null;
        }
    }
}
