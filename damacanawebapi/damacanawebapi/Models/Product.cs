using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace damacanawebapi.Models
{
   public class Product
    {
        [Required]
        public int Id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }
}
