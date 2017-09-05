using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDiscover_forClt.Models;

namespace WebAPIDiscover_forClt.Controllers
{
    public class CustomerController : ApiController
    {
        Customer[] Customers = new Customer[] 
        { 
            new Customer { Id = 1, FirstName = "Hinault", LastName = "Romaric", Email = "hr@gmail.com"}, 
            new Customer { Id = 2, FirstName = "Thomas", LastName = "Perrin", Email = "thomas@outlook.com"}, 
            new Customer { Id = 3, FirstName = "Allan", LastName = "Croft", Email = "allan.croft@crt.com"},
            new Customer { Id = 3, FirstName = "Sahra", LastName = "Parker", Email = "sahra@yahoo.com"}
        };

        public IEnumerable<Customer> GetAllCustomer()
        {
            return Customers;
        }

        public Customer GetCustomerById(int id)
        {
            var Customer = Customers.FirstOrDefault(c => c.Id == id);
            if (Customer == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return Customer;
        }


    }
}
