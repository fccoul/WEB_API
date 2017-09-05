using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;


namespace ConsoleApp_WebAPI
{
    public class HelloController : ApiController 
    {

        public string[] Get()
        {
            return new[] { "Wow", "this", "is" };
        }

        /*
        [HttpGet]
        [ActionName("all")]
        public string[] DisplayAll()
        {
            return new[] { "Wow", "this", "is", "a", "real", "Web", "App" };
        }
        */
        

        /*
        [HttpGet]
        //[ActionName("ActionObtenir")]
        public string GetObtenir(int id)
        {
            return "called from Hsiting In-Mmeory";
        }
        */
        [HttpGet]
        public int DisplayCode()//ex appel :http://localhost:3005/api/v1/hello/displaycode
        {
            return 4001;
        }

        [NonAction]
        public string GetPrivateData()
        {
            return "ceci n'est pas une action Web API";
        }
    }
}
