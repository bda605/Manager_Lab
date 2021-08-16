using Manager.Repository.Interface;
using Manager.ViewModel;

namespace Manager.Service
{
    public class UserService
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository) 
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public UserResponseViewModel Login(string id, string pwd)
        {
            var userResponseViewModel = new UserResponseViewModel();
            var user = _userRepository.GetUser(id, pwd);
            if (user != null )
            {
                var roleName = _roleRepository.GetRoleName(user.RoleId);
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
