using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace damacanawebapi.Models
{
    class productpurchased
    {
        [Required]
        public int Id { get; set; }
        public decimal price { get; set; }
        public int ProductId { get; set; }
        public virtual Product product { get; set; }
        public int PurchaseId { get; set; }
        public virtual Purchase purchase { get; set; }
    }
}
