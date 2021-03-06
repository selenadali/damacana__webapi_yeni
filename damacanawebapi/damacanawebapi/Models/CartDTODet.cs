﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace damacanawebapi.Models
{
    public class CartDTODet_GET
    {
        [Required]
        public int Id { get; set; }
        public decimal totalprice { get; set; }
        public List<KeyValuePair<Product, int>> cart_products { get; set; }

    }

    public class CartDTODet_PUT
    {
        [Required]
        public int Id { get; set; }
        public decimal totalprice { get; set; }
        public virtual ICollection<cartproducts> cart_products { get; set; }

    }

}