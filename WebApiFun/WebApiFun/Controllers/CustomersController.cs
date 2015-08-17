using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiFun.Data;
using WebApiFun.Models;

namespace WebApiFun.Controllers
{
    public class CustomersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllCustomers()
        {
            WebApiFunContext db = new WebApiFunContext();
            var customers = db.Customers.ToList();
            return Ok(customers);
        }

        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            WebApiFunContext db = new WebApiFunContext();
            var customer = db.Customers.Where(x => x.Id == id);
            if (customer != null)
                return Ok(customer);
            else
                return NotFound();
        }

        [HttpPost]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            WebApiFunContext db = new WebApiFunContext();
            db.Customers.Add(customer);
            db.SaveChanges();
            return Ok(customer);
        }

        [HttpPut]
        public IHttpActionResult PutCustomer(Customer customer)
        {
            WebApiFunContext db = new WebApiFunContext();
            db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(customer);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            WebApiFunContext db = new WebApiFunContext();
            var customer = db.Customers.Where(x => x.Id == id).FirstOrDefault();
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
