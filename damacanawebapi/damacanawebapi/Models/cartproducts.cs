using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace damacanawebapi.Models
{
    public class cartproducts
    {
        [Required]
        public int Id { get; set; }
        public int price { get; set; }

        public int ProductId { get; set; }
        public virtual Product product { get; set; }

        public int CartId { get; set; }
        public virtual Cart cart { get; set; }
    }
}
