using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Discover_WebAPI.Common
{
 
    public class BasicAuthenticationHandler : DelegatingHandler
    {
        private IAuthenticationService _service;

        public BasicAuthenticationHandler(IAuthenticationService service)
        {
            _service = service;
        }

        /* Basic Authentication : The credentials, username, and password are sent to the server using the Authorization header, 
         * and they are prefixed with the keyword Basic and encoded in Base64
         */
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken cancellationToken )
        {


            /* When a request arrives to the handler, it analyzes the header by searching for the Authentication value. 
             * If it is not present, it sends a 401 Unauthorized message to the client. 
                If the Authentication header is present, it decodes its value from Base64 and extracts the value of the username and password: 
            */

            AuthenticationHeaderValue authHeader = request.Headers.Authorization;
            if(authHeader==null || authHeader.Scheme!="Basic")
            {
                return Unauthorized(request);
            }

            string encodedCredentials = authHeader.Parameter;
            /*les credentials sont prefixés avec le mot clé "Basic" et encode en base64 le couple " login:password"
             * par ex Authorization: Basic ZW1hOnB3ZA==  
             * ici ZW1hOnB3ZA== represente la valeur user:password encodeé en Base64
             ex de site pour genration value en base 64:https://www.base64encode.org/*/
            byte[] credientialBytes = Convert.FromBase64String(encodedCredentials);
            string[] credentials = Encoding.ASCII.GetString(credientialBytes).Split(':');

            if (!_service.Authenticate(credentials[0], credentials[1]))//--chek en BDD pa rex si les credentials sont connus
            {
                return Unauthorized(request);
            }

            string []roles = null; //--habilitations TODO
            IIdentity identity = new GenericIdentity(credentials[0], "Basic");
            IPrincipal user = new GenericPrincipal(identity, roles);
            HttpContext.Current.User = user;

            return base.SendAsync(request, cancellationToken);
        }

        private Task<HttpResponseMessage> Unauthorized(HttpRequestMessage request)
        {
            var reponse = request.CreateResponse(HttpStatusCode.Unauthorized);
            reponse.Headers.Add("WWW-Authenticate","Basic");

            System.Threading.Tasks.TaskCompletionSource<HttpResponseMessage> task = new TaskCompletionSource<HttpResponseMessage>();
            task.SetResult(reponse);
            return task.Task;
        }


    }
}
