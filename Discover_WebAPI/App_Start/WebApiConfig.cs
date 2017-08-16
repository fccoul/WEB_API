using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Discover_WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // --route avec un controller particuleier avec control typde de parameters
        /*
            config.Routes.MapHttpRoute(
                name: "PostByDate",
                routeTemplate: "api/{controller}/{year}/{month}/{day}",
                defaults: new {
                    controller="Posts",
                    month=RouteParameter.Optional,day=RouteParameter.Optional }
                ,//----contraintes afin de s'assusrer qu les parametrs passe sont des entiers
                constraints:new{
                    month=@"\d{0,2}",
                    day=@"\d{0,2}"

                }
                );
            */
            
            

            //---Afin de specifier une action specifique ne commencantpar acun verbs{get,post,put,delete}
            config.Routes.MapHttpRoute(
                name: "PostCustomAction",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new {id=RouteParameter.Optional}                 
                );
            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
