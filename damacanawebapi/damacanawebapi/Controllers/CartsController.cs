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
        [ResponseType(typeof(Cart))]
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
            cartdetail.cart_products = new List<Product>();
            foreach (cartproducts cp in cart.cart_products)
            {
                KeyValuePair<Product, int> b = new KeyValuePair<Product, int>(cp.product, cp.price);
                cartdetail.cart_products.Add(b);
            }


            return Ok(cartdetail);
        }

        // PUT: api/Carts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCart(int id, Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.Id)
            {
                return BadRequest();
            }

            db.Entry(cart).State = EntityState.Modified;

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

        // POST: api/Carts
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> PostCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carts.Add(cart);
            await db.SaveChangesAsync();

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