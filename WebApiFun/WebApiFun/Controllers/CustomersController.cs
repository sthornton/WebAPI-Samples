using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiFun.Data;
using WebApiFun.Models;
using System.Web.Http.OData;

namespace WebApiFun.Controllers
{
    public class CustomersController : ApiController
    {
        //public IHttpActionResult GetAllCustomers()
        //{
        //    WebApiFunContext db = new WebApiFunContext();
        //    var customers = db.Customers.ToList();
        //    return Ok(customers);
        //}

       
        /// <summary>
        /// Shows how to use OData with standard ApiController.  Works
        /// great if you just need it for one entity.
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        public IQueryable<Customer> GetAllCustomers()
        {
            WebApiFunContext db = new WebApiFunContext();
            return db.Customers.AsQueryable();
        }

        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            WebApiFunContext db = new WebApiFunContext();
            var customer = db.Customers.Where(x => x.Id == id);
            if (customer != null)
                return Ok(customer);
            else
                return NotFound();
        }

        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            WebApiFunContext db = new WebApiFunContext();
            db.Customers.Add(customer);
            db.SaveChanges();
            return Ok(customer);
        }

        [ResponseType(typeof(Customer))]
        public IHttpActionResult PutCustomer(Customer customer)
        {
            WebApiFunContext db = new WebApiFunContext();
            db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(customer);
        }

        [ResponseType(typeof(void))]
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
