using Discover_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Discover_WebAPI.Controllers
{
    public class AuthorController : ApiController
    {
        public IQueryable<Author> Get()
        {
            return new PostRepository().GetAllAuthor();
        }

        public Author Get(int id)
        {
            return new PostRepository().GetAuhtor(id);
        }
    }
}
