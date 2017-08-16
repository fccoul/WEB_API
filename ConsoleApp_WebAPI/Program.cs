using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net.Http;

namespace ConsoleApp_WebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client=new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var reponse=client.GetAsync("http://localhost:64773/api/customer").Result;
            if(reponse.IsSuccessStatusCode)
            {
                //ReadAsAsync : lit et deserialise automatiquement le corps de la reponse HTTP
                var Customer=reponse.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                foreach (var c in Customer)
	                    {
		                     Console.WriteLine("{0}\t{1}\t{2}",c.FirstName,c.LastName,c.Email);
	                    }
            }
            else
            {
                Console.WriteLine("{0},{1}",reponse.StatusCode,reponse.ReasonPhrase);
            }

            Console.ReadLine();
        }
    }
}
