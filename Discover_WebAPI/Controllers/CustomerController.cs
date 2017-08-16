using Discover_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Discover_WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        Customer[] Customers = new Customer[]
        {
           new Customer{Id=1,FirstName="Hinault",LastName="Romaric",Email="hr@gmail.com"},
           new Customer{Id=2,FirstName="Thomas",LastName="Perrin",Email="thomas@outlook.com"},
           new Customer{Id=3,FirstName="Allan",LastName="Croft",Email="allan.croft@crt.com"},
           new Customer{Id=4,FirstName="Sahra",LastName="Parker",Email="sahra@yahoo.com"}
          
        };

        //xxxx/api/namecontroleur : retourne toutes les données comme un Ienumerable
        public IEnumerable<Customer> GetAllCustomers()  
        {
            return Customers;
        }

        public Customer GetCustomerById(int id)
        {
            var _cutomer = Customers.FirstOrDefault(c => c.Id == id);
            if (_cutomer == null)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            return _cutomer;
        }
    }
}
