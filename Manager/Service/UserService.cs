using Manager.Repository;
using Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Service
{
    public class UserService
    {
        public UserResponseViewModel Login(string id, string pwd)
        {
            var userResponseViewModel = new UserResponseViewModel();
            var userRepository = new UserRepository();
            var roleRepository = new RoleRepository();
            var member = userRepository.GetUser("ADMIN", "ADMIN");
            var roleName = roleRepository.GetRoleName(member.RoleId);
            if (member != null && !string.IsNullOrEmpty(roleName))
            {
                userResponseViewModel.IsSuccess = true;
                userResponseViewModel.Name = member.Name;
                userResponseViewModel.RoleName = roleName;
                return userResponseViewModel;
            }
            return userResponseViewModel;
        }
    }
}
