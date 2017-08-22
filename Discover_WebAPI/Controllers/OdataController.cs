using Discover_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace Discover_WebAPI.Controllers
{
    public class OdataController : EntitySetController<Post,int>
    {
       private readonly IPostRepository _repository;

       public OdataController()
       {
           _repository = new PostRepository();
       }
       public OdataController(IPostRepository repository)
       {
           _repository = repository;
       }

       public override IQueryable<Post> Get()
       {
           IEnumerable<Post> posts = _repository.GetAll();
           return posts.AsQueryable();
       }
    }
}
