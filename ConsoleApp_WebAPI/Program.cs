using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;


namespace ConsoleApp_WebAPI
{
    //--hebergement en mode Self-hosting
    class Program
    {
        static void Main(string[] args)
        {
            string url="http://localhost:3005";
            var config = new HttpSelfHostConfiguration(url);
            config.Routes.MapHttpRoute("default",
                                        "api/{controller}/{id}",
                                         new { id = RouteParameter.Optional });
            var server = new HttpSelfHostServer(config);
            Console.WriteLine("demarrage du serveur sur {0}", url);
            server.OpenAsync().Wait();
            Console.WriteLine("Serveur demarré");
            Console.ReadLine();
        }
    }
}
