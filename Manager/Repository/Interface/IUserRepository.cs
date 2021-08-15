using Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Repository.Interface
{
    public interface IUserRepository
    {
        UserViewModel GetUser(string id, string pwd);
    }
}
