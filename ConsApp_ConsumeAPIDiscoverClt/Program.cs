using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsApp_ConsumeAPIDiscoverClt
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            //consommer les données au format json d'une API Web en utilisant la méthode GetAsync.
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //consommer les données au format xml d'une API Web en utilisant la méthode GetAsync.
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
            /*
             * La procédure asynchrone GetAsync() de la classe HttpClient() prend en paramètre une URI ou une chaîne de caractères qui 
             * représente l'URL de l'API Web. GetAsync effectue une requête HTTP GET en utilisant l'URL passée en paramètre, puis retourne
             * directement une tâche dont la propriété Result (Task.Result) contient la réponse HTTP (HttpResponseMessage).
             * */
            var response = client.GetAsync("http://localhost:41737/api/customer").Result;
            Console.WriteLine("Recuperation de tous les clients !");
            if (response.IsSuccessStatusCode)
            {
               // ReadAsAsync() lit et déserialise automatiquement le corps de la réponse HTTP qui contient la liste des clients.
                var Customers=response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                foreach (var item in Customers)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", item.FirstName, item.LastName, item.Email);
                }
            }
            else
                Console.WriteLine("{0}", "{1}", (int)response.StatusCode, response.ReasonPhrase);

            Console.ReadLine();
        }
    }
}
