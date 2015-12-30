using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace damacanawebapi.Models
{
    public class Cart
    {
        [Required]
        public int Id { get; set; }
      
        public DateTime DateTime { get; set; }
        public decimal totalprice { get; set; }
        public virtual ICollection<cartproducts> cart_products{ get; set; }


    }
}


