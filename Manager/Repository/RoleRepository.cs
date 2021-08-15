using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager.Repository
{
    public class RoleRepository
    {
        public Dictionary<int, string> roles = new Dictionary<int, string>
        {
         { 1, "ADMIN" },
         { 2, "OP" },
        };
        public virtual string GetRoleName(int id)
        {
            //連DB
            var dbFindSingle = roles.Where(m => m.Key == id).FirstOrDefault();
            return dbFindSingle.Value;
        }
    }
}
