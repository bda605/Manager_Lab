using Manager.Repository.Interface;
using Manager.Service;
using Manager.ViewModel;
using NSubstitute;
using NUnit.Framework;
using FluentAssertions;
namespace ManagerTest
{
    public class UserServiceTest
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private UserService _userService;
        [SetUp]
        public void Setup()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _roleRepository = Substitute.For<IRoleRepository>();
            _userService = new UserService(_userRepository,_roleRepository);
        }

        [Test]
        public void LoginSuccess()
        {
            var expected = SetExpected(true, "老大", "ADMIN");
            string id = "ADMIN";
            string pwd = "ADMIN";
            int roleId = 1;
            _userRepository.GetUser(id, pwd).Returns(new UserViewModel
            {
                Name = "老大",
                RoleId = roleId
            });
            _roleRepository.GetRoleName(roleId).Returns("ADMIN");
            var result = _userService.Login(id, pwd);
            expected.Should().BeEquivalentTo(result);
        }

        [Test]
        public void LoginFail()
        {
            var expected = SetExpected(false, null, null);
            string id = "ADMIN";
            string pwd = "ADMIN";
            int roleId = 1;
            _userRepository.GetUser(id, pwd).Returns(x=> null);
            var result = _userService.Login(id, pwd);
            expected.Should().BeEquivalentTo(result);
        }
        private UserResponseViewModel SetExpected(bool isSuccess, string name, string roleName)
        {
            return new UserResponseViewModel()
            {
                IsSuccess = isSuccess,
                Name = name,
                RoleName = roleName
            };
        }
    }
}