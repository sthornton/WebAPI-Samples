using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebApiFun.Models;

namespace WebApiFun.Data
{
    public class WebApiFunInitializer : DropCreateDatabaseIfModelChanges<WebApiFunContext>
    {
        protected override void Seed(WebApiFunContext context)
        {
            Customer c = new Customer { Name = "Customer One" };
            WebApiFunContext db = new WebApiFunContext();
            db.Customers.Add(c);
            db.SaveChanges();
        }
    }
}
