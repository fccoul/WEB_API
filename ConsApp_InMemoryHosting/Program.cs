using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsApp_InMemoryHosting
{
    class Program
    {
        //le mode hebergement In-Memory , cette configuration est parfaite dans un monde de test...(pout les TIF par ex)
        static void Main(string[] args)
        {
            Console.WriteLine("Web API - Hebergement en mode In-Memory");
            var config = new HttpConfiguration();
            /*
            config.Routes.MapHttpRoute("default",
                                       "api/v1/{controller}/{action}/{id}",
                                       new { id = RouteParameter.Optional });
            */
            
            config.Routes.MapHttpRoute("default",
                                      "api/{controller}/{id}",
                                      new { id = RouteParameter.Optional });
             
            HttpServer server = new HttpServer(config);

            HttpClient client = new HttpClient(server);
            var reponse = client.GetAsync("http://localhost:3008/api/memory").Result;            
            String content = reponse.Content.ReadAsStringAsync().Result;
            Console.WriteLine("le resultat est : "+ content);
            Console.ReadLine();
        }
    }
}
