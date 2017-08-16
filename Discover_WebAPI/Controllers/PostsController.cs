using Discover_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Discover_WebAPI.Controllers
{
    public class PostsController : ApiController
    {
        
        //params year is mandotory(required)
        public IQueryable<Customer> Get(int year, int month = 0, int day = 0)
        {
            // Do something to load the posts that match the date. 
            return null;
        }
        

        //---attribut ajouté vu la route prise :PostCustom {precision sur un action specifique ne comment pas par un verb post,get,put,delete}
        
        [HttpGet]
        public string Category(int id)
        {
            return string.Format("l'année {0} a été saisie !", id);
        }
        

    }
}
