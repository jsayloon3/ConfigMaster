using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.BLL.Session
{
    public class UserSession : IUserSession
    {
        public string UserName { get; private set; }
        public UserSession(string userName)
        {
            UserName = userName;
        }
    }
}
