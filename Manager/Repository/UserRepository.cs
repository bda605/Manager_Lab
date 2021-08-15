using Manager.Entities;
using Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager.Repository
{
    public class UserRepository
    {
        public List<User> users = new List<User>()
        {
             new User{Id="ADMIN",Pwd="ADMIN",Name = "老大",RoleId =1 },
             new User{Id="EDDIE",Pwd="EDDIE",Name = "老二",RoleId =2 },
        };

        public virtual UserViewModel GetUser(string id, string pwd)
        {
            //連DB
            var dbFindSingle = users.Where(m => m.Id == id && m.Pwd == pwd).FirstOrDefault();
            if (dbFindSingle != null)
            {
                return new UserViewModel
                {
                    Name = dbFindSingle.Name,
                    RoleId = dbFindSingle.RoleId
                };
            }
            return null;
        }
    }
}
