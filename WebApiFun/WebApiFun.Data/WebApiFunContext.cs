using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFun.Models;

namespace WebApiFun.Data
{
    public class WebApiFunContext : DbContext
    {
        public WebApiFunContext() : base ("WebApiFunContext")
        {
            Database.SetInitializer(new WebApiFunInitializer());
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
