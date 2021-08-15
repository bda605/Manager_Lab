using Manager.Repository;
using Manager.Service;
using Manager.ViewModel;
using NUnit.Framework;
using FluentAssertions;
namespace ManagerTest
{
    public class UserServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoginSuccess()
        {
            var expected = SetExpected(true, "老大", "ADMIN");
            var userService = new FakeUserService();
            var result = userService.Login("ADMIN", "ADMIN");
            expected.Should().BeEquivalentTo(result);
        }

        [Test]
        public void LoginFail()
        {
            var expected = SetExpected(false, null, null);
            var userService = new FakeUserService();
            var result = userService.Login("ADMIN", "ADMIN1");
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
    class FakeUserService:UserService
    {
        protected override UserRepository GetUserRepository()
        {
            return new StubUserRepository();
        }
        protected override RoleRepository GetRoleRepository()
        {
            return new RoleRepository();
        }
    }

    class StubUserRepository:UserRepository
    {
        public override UserViewModel GetUser(string id, string pwd)
        {
            if (id == "ADMIN" && pwd == "ADMIN") 
            {
                return new UserViewModel { Name = "老大", RoleId = 1 };
            }
            return null;
        }

    }
    class StubRoleRepository:RoleRepository
    {
        public override string GetRoleName(int id)
        {
            return "ADMIN";
        }
    }
}
