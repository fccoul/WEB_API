using Discover_WebAPI.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ValueProviders;

namespace Discover_WebAPI.Controllers
{
    /// <summary>
    /// Controller pour les differents posts effectués...
    /// </summary>
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

        ///<summary>
        /// Recupère toutes  les values FCO..
        /// </summary>
        /// <returns></returns>
        //[ApiExplorerSettings(IgnoreApi = true)]
        [SwaggerResponse(HttpStatusCode.Forbidden, Type = typeof(IQueryable<Post>))]       
        public IQueryable<Post> Get()
        {
            return _repository.GetAll();
        }


        /// <summary>
        /// recupère le post concerné selon son identifiant
        /// </summary>
        /// <param name="id">la valeur Id su Post</param>
        /// <remarks>ce Get est recupéré suite à lintervention du RT sur un contrôle</remarks>
        /// <returns>retourne le sule et unique post de cet Id</returns>      
        /// <exception cref="IndexOutOfRangeException">Exception déclenchée quand la tille du tab est depassée</exception>
        ////// <response code="201" cref="CreatedResponse" examplesProvider="CreatedResponseBuilder" examplesMethod="GetExamples">kpleus Returns the id  FCO of the created object</response>
        [SwaggerResponse(HttpStatusCode.NotFound, Type = typeof(Post))]
        [SwaggerResponse(HttpStatusCode.ProxyAuthenticationRequired)]
        [SwaggerResponse(HttpStatusCode.Forbidden, "Acces non autorisé,seul FCO !", null)]
        public Post Get(int id)
        {
            /* \if matriculeconnecte
             * \a b  vrai
             * endif  
          * */
            Post _p = null;
            _p= _repository.Get(id);
            if(_p!=null)
                return _p;
            else
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        //-create
        /// <summary>
        /// crée un nouveau Post
        /// </summary>
        /// <param name="post">la valeur du Post a crée !</param>
        /// <returns></returns>
        public HttpResponseMessage Post(Post post)
        {
             if (ModelState.IsValid)
            {
            _repository.Create(post);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.StatusCode = HttpStatusCode.Created;
            string uri = Url.Link("DefaultApi", new { id = post.Id });
            response.Headers.Location = new Uri(uri);
            return response;
            }
             else
                 throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
        }
        

        //-update
        /// <summary>
        /// modifie le post selectionné
        /// </summary>
        /// <param name="id">la valeur Id de l'identifiant</param>
        /// <param name="post">l'objet post modifié</param>
        /// <returns></returns>
        /// <response code="204">Aucun contenu a retourner !</response>
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
        /// <summary>
        /// supprime le post selectionné
        /// </summary>
        /// <param name="id">la valeur Id du post à supprimé</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            _repository.Delete(id);
            var reponse = Request.CreateResponse(HttpStatusCode.NoContent);
            return reponse;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
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

        #region get value header,params
        //---par defaut les types complex sont toujours lu depuis le body
        //void Action([FromUri] Customer c1, Customer c2)  
           //---ex :c1 is from the URI and c2 is from the body 
        //---If your action needs multiple complex types, only one should come from the body.
        // If you need to get multiple values from the request body, define a complex type
        /*
        public HttpResponseMessage Post([ValueProvider(typeof(HeaderValueFactory))] String username)
        {
            var reponse = Request.CreateResponse(HttpStatusCode.NotImplemented);
            return reponse;
        }
        */

        //-the attribute FromBody to specify that the value came from the body: 
        //The FromUri attribute forces the parsing of the user from the URI instead of the body
        /*
        public HttpResponseMessage Post([FromBody] String username)
        {
            var reponse = Request.CreateResponse(HttpStatusCode.NotImplemented);
            return reponse;
        }
        */
        #endregion






    }
}
