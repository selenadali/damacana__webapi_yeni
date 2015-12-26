using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace damacanawebapi.Models
{
    class Product
    {
        [Required]
        public int Id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
    }
}
