using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WinSce_API
{
    public class ServiceController : ApiController
    {
        public string GetString(Int32 id)
        {
            return "Acces Control ! pfff -this is a test - value returned through the windows service ";
        }
    }
}
