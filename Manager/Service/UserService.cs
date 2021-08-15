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
            var member = _userRepository.GetUser(id, pwd);
            if (member != null )
            {
                var roleName = _roleRepository.GetRoleName(member.RoleId);
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
    }
}
