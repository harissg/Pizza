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
using HotStuffPizzaAPI.DAL.Models;
using HotStuffPizzaAPI.DAL;

namespace HotStuffPizzaAPI.Controllers
{
    public class ProductController : ApiController
    {
        private HotStuffPizzaContext db = new HotStuffPizzaContext();

        // GET api/Product
        //[Route("api/GetProducts")]
        public IHttpActionResult GetProducts(int type)
        {
            return Json(db.Products.Where(p => p.ProductTypeID == type));
        }


        public IHttpActionResult GetProductIngredients(int productId)
        {
            //another approach is to create  DTO(aka viewmodel really) object and return directly a list of that
            var list = new List<Ingredient>();
            var result = (from pr in db.ProductReciepes
                          join i in db.Ingredients on pr.IngredientID equals i.IngredientID
                          where pr.ProductID == productId
                          select new
                          {
                              Description = i.Description,
                              ImageUrl = i.ImageUrl
                          }).ToList();
            foreach (var item in result)
            {
                list.Add(new Ingredient { ImageUrl = item.ImageUrl, Description = item.Description });
            }
            return Json(list);
        }

        // GET api/Product/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT api/Product/5
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST api/Product
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE api/Product/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}