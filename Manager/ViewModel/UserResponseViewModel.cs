using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.ViewModel
{
    public class UserResponseViewModel
    {
        public bool IsSuccess { get; set; } = false;
        public string Name { get; set; }
        public string RoleName { get; set; }
    }
}
