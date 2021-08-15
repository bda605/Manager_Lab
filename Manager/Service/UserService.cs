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
            UserRepository userRepository = GetUserRepository();
            RoleRepository roleRepository = GetRoleRepository();
            var member = userRepository.GetUser(id, pwd);
            if (member != null)
            {
                var roleName = roleRepository.GetRoleName(member.RoleId);
                if (!string.IsNullOrEmpty(roleName))
                {
                    userResponseViewModel.IsSuccess = true;
                    userResponseViewModel.Name = member.Name;
                    userResponseViewModel.RoleName = roleName;
                    return userResponseViewModel;
                }
            }
            return userResponseViewModel;
        }

        protected virtual RoleRepository GetRoleRepository()
        {
            return new RoleRepository();
        }

        protected virtual UserRepository GetUserRepository()
        {
            return new UserRepository();
        }
    }
}
