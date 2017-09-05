using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsApp_InMemoryHosting
{
    public class MemoryController : ApiController
    {
        
        public string[] Get()
        {
            return new[] { "Wow", "this", "is", "a", "real", "Web", "App" };
        }
         
        /*
        public string Get()
        {
            return "call in Hosting Memory !";
        }
        */
    }
}
