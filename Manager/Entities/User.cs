using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Pwd { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
    }
}
