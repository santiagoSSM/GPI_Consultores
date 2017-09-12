using MockWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MockWebApi.Controllers
{
    public class UserWSController : ApiController
    {
        private static List<UserWS> userList = new List<UserWS>()
        {
            new UserWS()
            {
                UserId = "user",
                UserPassword = "pass"
            },

            new UserWS()
            {
                UserId = "user1",
                UserPassword = "pass"
            },

            new UserWS()
            {
                UserId = "user2",
                UserPassword = "pass"
            }
        };

        // GET: api/UserWS
        public IEnumerable<UserWS> Get()
        {
            return userList;
        }

        // GET: api/UserWS
        public UserWS Get(int id)
        {
            return userList.ElementAtOrDefault(id);
        }

        // POST: api/UserWS
        public IHttpActionResult Post([FromBody]UserWS value)
        {
            if (value.UserId != null && value.UserPassword != null)
            {
                if (userList.FirstOrDefault(x => x.UserId == value.UserId) == null)
                {
                    try
                    {
                        userList.Add(value);
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
        public IHttpActionResult Put(string key, [FromBody]UserWS value)
        { 
            if (value.UserId != null && value.UserPassword != null)
            {
                if (userList.FirstOrDefault(x => x.UserId == value.UserId) == null)
                {
                    if (userList.FirstOrDefault(x => x.UserId == key) != null)
                    {
                        try
                        {
                            UserWS temp = GetSearch(key);

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
            }
            return InternalServerError();
        }

        // DELETE: api/UserWS/5
        public IHttpActionResult Delete(string key)
        {
            try
            {
                if (userList.RemoveAll(x => x.UserId == key) != 0)
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

        // Search user
        public UserWS GetSearch(string key)
        {
            return userList.FirstOrDefault(x => x.UserId == key);
        }

        // Login method
        public bool PutLogin(char select, [FromBody]UserWS value)
        {
            return userList.FirstOrDefault(x => x.UserId == value.UserId && x.UserPassword == value.UserPassword)!=null;
        }
    }
}
