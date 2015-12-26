using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace damacanawebapi.Models
{
    public class Purchase
    {
        [Required]
        public int Id { get; set; }
        public decimal totalprice { get; set; }
        public DateTime datetime { get; set; }
       ICollection<productpurchased> product_purchased { get; set; }

    }
}