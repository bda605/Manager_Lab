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
            var user = userRepository.GetUser(id, pwd);
            if (user != null )
            {
                var roleName = roleRepository.GetRoleName(user.RoleId);
                if (!string.IsNullOrEmpty(roleName)) 
                {
                    userResponseViewModel.IsSuccess = true;
                    userResponseViewModel.Name = user.Name;
                    userResponseViewModel.RoleName = roleName;
                    return userResponseViewModel;
                }
            }
            return userResponseViewModel;
        }
    }
}
