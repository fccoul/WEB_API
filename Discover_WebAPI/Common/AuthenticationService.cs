using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discover_WebAPI.Common
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool Authenticate(string user, string password)
        {
            //---check here en BDD par ex
            return true;
        }
    }
}
