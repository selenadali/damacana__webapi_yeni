using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace damacanawebapi.Models
{
    public class CartDTO
    {
       [Required]
        public int Id { get; set; }
       public decimal totalprice { get; set; }
    }
}