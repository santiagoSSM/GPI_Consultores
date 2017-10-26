using MockWebApi.Models;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Http;

namespace MockWebApi.Controllers
{
    public class UserController : ApiController
    {
        [HttpPut]
        [ActionName("Put")]
        public UserWA Put([FromBody]UserPassWA user)
        {
            try
            {
                var temp = InfoListsWA.ListUserPass.FirstOrDefault(x => x.IdUser == user.IdUser && x.PassUser == user.PassUser);

                if (temp != null)
                {
                    return new UserWA
                    {
                        IdUser = temp.IdUser,
                        NameUser = temp.NameUser
                    };
                }
                else
                {
                    return default(UserWA);
                }
            }
            catch
            {
                return default(UserWA);
            }
        }
    }
}
