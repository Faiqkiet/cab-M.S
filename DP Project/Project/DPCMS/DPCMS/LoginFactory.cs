using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPCMS
{
    class LoginFactory
    {
        public login getLogin(string loginType)
        {
            if (loginType == "User")
            {
                return new User();
            }
            else if (loginType == "Staff")
            {
                return new Staff();
            }
            else if (loginType == "Cabi")
            {
                return new Cabi();
            }
            else 
            { 
            return null;
            }
        }

    }
}
