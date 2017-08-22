using Discover_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Discover_WebAPI.Controllers
{
    public class OtherController : ApiController
    {

        //--par defaut les types Complex sont lu dans le corps de la requete
        //[FromUri] :To force Web API to read a complex type from the 
        
        public HttpResponseMessage Get([FromUri]GeoPoint Location) //ex:http://localhost:64773/api/other?Latitude=47.678558&Longitude=-122.130989
        {
            return new HttpResponseMessage(HttpStatusCode.NotImplemented);
        }
        
        
        //--par defaut les types simpels(int,string,etc) sont lu dans l'uri
        //[FromBody] :To force Web API to read a simple type from the request body
        public HttpResponseMessage Post([FromBody] string name)
        {
            return new HttpResponseMessage(HttpStatusCode.ProxyAuthenticationRequired);
        }

        
        [HttpGet]
        public GeoPoint checkPosition(double latitude,double longitude)
        {
            IEnumerable<string> headervalues;
            var _myVal = string.Empty;
            if (Request.Headers.TryGetValues(_myVal, out headervalues))
            {
                _myVal = headervalues.FirstOrDefault();
            }
            //return new GeoPoint { Latitude = 47.678558, Longitude = -122.130989 };
            return new GeoPoint { Latitude = latitude, Longitude = longitude };
        }
        
        //---Type Converters...  A revoir later ! 
        /*
        [HttpGet]
        public HttpResponseMessage Convertor([FromUri] GPConverter location)//ex:http://localhost:64773/api/other?Latitude=47.678558&Longitude=-122.130989
       // public HttpResponseMessage Convertor(string complexType)
        {
            return new HttpResponseMessage(HttpStatusCode.PartialContent);
        }
        */

        //------Note !!!!
        //void Action(int id, Post p)  
           //id will be taken from the URI, and Post from the body, since it is a complex type. 
        /*If we have an action that takes two complex types, one must come from the body while the other must come from another source: 
            void Action([FromUri] Customer c1, Customer c2)  
            c1 is from the URI and c2 is from the body */
        
    }
}
