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
        ///le routing :l'on tient compte de l'order de creation/alignmelent dans le code
        //qd la requete arrive , elle compare la syntaxe de l'url avec la route en tête de liste si ko elle passe à la suivant jusqu'a tomber sur la route par defaut
        static void Main(string[] args)
        {
            string url="http://localhost:3005";
            var config = new HttpSelfHostConfiguration(url);
            /*
            config.Routes.MapHttpRoute("custom1",
                                      "api/{controller}/{action}",
                                      new { controller = "Hello", action = "DisplayAll" });
            config.Routes.MapHttpRoute("custom2",
                                      "api/{controller}/{action}",
                                      new {controller="Hello",action="DisplayCode" });
            */
            config.Routes.MapHttpRoute("custom",
                                     "api/v1/{controller}/{action}");


            
            //---Default route
            //----si plusieurs routes existes, la positionner toujours en fin...
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
