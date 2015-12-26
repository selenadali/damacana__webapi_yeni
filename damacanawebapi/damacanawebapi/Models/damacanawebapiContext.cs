using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace damacanawebapi.Models
{
    public class damacanawebapiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public damacanawebapiContext() : base("name=damacanawebapiContext")
        {
        }

        public System.Data.Entity.DbSet<damacanawebapi.Models.Cart> Carts { get; set; }

        public System.Data.Entity.DbSet<damacanawebapi.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<damacanawebapi.Models.Purchase> Purchases { get; set; }
    
    }
}
