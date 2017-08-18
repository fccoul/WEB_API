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

        private readonly IPostRepository _repository;

        public PostsController (IPostRepository repository)
	        {
                _repository=repository;
	        }

        public PostsController()
        {
            _repository = new PostRepository();
        }


        //params year is mandotory(required)
       /*
        public IQueryable<Customer> Get(int year, int month = 0, int day = 0)
        {
            // Do something to load the posts that match the date. 
            return null;
        }
        */
        

        //---attribut ajouté vu la route prise :PostCustom {precision sur un action specifique ne comment pas par un verb post,get,put,delete}
        /*
        [HttpGet]
        public string Category(int id)
        {
            return string.Format("l'année {0} a été saisie !", id);
        }
        */
        #region repository


        public IQueryable<Post> Get()
        {
            return _repository.GetAll();
        }

        
        public Post Get(int id)
        {
            return _repository.Get(id);
        }

        //-create
        public HttpResponseMessage Post(Post post)
        {
            _repository.Create(post);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.StatusCode = HttpStatusCode.Created;
            string uri = Url.Link("DefaultApi", new { id = post.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        //-update
        public HttpResponseMessage Put(int id,Post post)
        {
            post.Id = id;
            _repository.Update(post);
           // var response = Request.CreateResponse(HttpStatusCode.NoContent);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            string uri = Url.Link("DefaultApi", new { id = id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        //delete
        public HttpResponseMessage Delete(int id)
        {
            _repository.Delete(id);
            var reponse = Request.CreateResponse(HttpStatusCode.NoContent);
            return reponse;
        }

        [HttpGet]
        public IQueryable<Post> Archive(int year, int month = 0, int day = 0)
        {
            var _val= _repository.Search(year, month, day);
            if (_val.Count() > 0)
                return _val;
            else
            {
                var customMsg = "Oopss ! element non trouvé";

                /*
                var reponse= Request.CreateResponse(HttpStatusCode.NotFound,customMsg);
                reponse.StatusCode = HttpStatusCode.NotFound;
                 *      return null;
                 */

                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound) { Content=new StringContent(customMsg)});

            }
        }
        #endregion


    }
}
