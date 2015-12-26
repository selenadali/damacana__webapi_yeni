using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using damacanawebapi.Models;

namespace damacanawebapi.Controllers
{
    public class CartsController : ApiController
    {
        private damacanawebapiContext db = new damacanawebapiContext();

        // GET: api/Carts
        public IQueryable<CartDTO> GetCarts()
        {


            var carts = from a in db.Carts
                        select new CartDTO()
                        {
                            Id = a.Id,
                            totalprice = a.totalprice
                        };

            return carts;
        }

        // GET: api/Carts/5
        [ResponseType(typeof(CartDTODet_GET))]
        public async Task<IHttpActionResult> GetCart(int id)
        {
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            CartDTODet_GET cartdetail = new CartDTODet_GET();
            cartdetail.Id = cart.Id;
            cartdetail.totalprice = cart.totalprice;
            cartdetail.cart_products = new List<KeyValuePair<Product, int>>();
            foreach (cartproducts c in cart.cart_products)
            {
                KeyValuePair<Product, int> k = new KeyValuePair<Product, int>(c.product, c.price);
                cartdetail.cart_products.Add(k);
            }


            return Ok(cartdetail);
        }

        // PUT: api/Carts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCart(int id, CartDTODet_PUT cartd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartd.Id)
            {
                return BadRequest();
            }

            Cart newcart = new Cart();
            newcart.cart_products = cartd.cart_products;

            foreach (cartproducts c in newcart.cart_products)
                c.Id = cartd.Id;

            newcart.totalprice = this.totalprice(newcart);

            db.Entry(cartd).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }



        protected Decimal totalprice(Cart cart)
        {
            Decimal totalprice = (Decimal)0.0;
            foreach (cartproducts c in cart.cart_products)
            {
                Product p = db.Products.Single(a => a.Id == c.ProductId);
                totalprice += p.price * c.price;
            }

            return totalprice;
        }

        // POST: api/Carts
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> PostCart(Cart cart)
        {
             
            // set dates to now
            cart.DateTime = DateTime.Now;
          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carts.Add(cart);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateEx)
            {
                Console.WriteLine(dbUpdateEx.Message);
                if (CartExists(cart.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cart.Id }, cart);
        }

        // DELETE: api/Carts/5
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> DeleteCart(int id)
        {
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            db.Carts.Remove(cart);
            await db.SaveChangesAsync();

            return Ok(cart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(int id)
        {
            return db.Carts.Count(e => e.Id == id) > 0;
        }
    }
}