using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discover_WebAPI.Common
{
    public interface IAuthenticationService
    {
        bool Authenticate(string user, string password);
    }
}
