using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Repository.Interface
{
    public interface IRoleRepository
    {
        string GetRoleName(int id);
    }
}
