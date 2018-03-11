using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Hydocs.Areas.AdWorks.Models;
using Hydocs.Areas.AdWorks.Models.DB;

namespace Hydocs.Areas.AdWorks.Controllers
{
    /// <summary>
    /// Represents an Adventure Works Products API. 
    /// </summary>
    /// <remarks>The description is inserted in the ProductesController class, wchich derives from <see cref="https://msdn.microsoft.com/en-us/library/system.web.http.apicontroller(v=vs.118).aspx"/>ApiController.</remarks>
    public class ProductsController : ApiController
    {
        private AdventureWorks db = new AdventureWorks();

        /// <summary>
        ///  Gets the Adventure Works products. 
        ///   </summary>
        ///   <returns> List of product objects (limited to 25 for demo), </returns>
        ///   <remarks>Returns a list of "light" DTOs, mapped with AutoMapper from the Product table</remarks>
        ///   <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        /// <see cref="2sharp.today/api/swagger"/>

        //[ResponseType(typeof(Product))]
        public IHttpActionResult GetProducts()
        {
            using (var db = new AdventureWorks()) {
                var products = db.Products.Take(25).ToList();
                var model = Mapper.Map<IEnumerable<Product>, List<ProductDTO>>(products);
            return Ok(model);
            }
        }

        // GET: api/Products/5

        /// <summary>
        ///  Gets the given Adventure Works product. 
        ///   </summary>
        ///   <param name="id" type="int"></param>
        ///   <returns> The specified product. </returns>
        ///   <remarks>Returns a DTO, mapped with AutoMapper from the Product table</remarks>
        ///   <response code="200">OK</response>
        /// <response code="404">Not Found</response>

        [ResponseType(typeof(ProductDTO))]
        public IHttpActionResult GetProduct(int id)
        {
            using (var db = new AdventureWorks())
            {
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                var response = Mapper.Map<Product, ProductDTO>(product);
                return Ok(response);
            }
        }
        /// <summary>
        /// Updates the existing product.
        /// </summary>
        /// <param name="product">The Product object.</param>
        /// <returns>void</returns>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request</response>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductKey)
            {
                return BadRequest();
            }
            using (var db = new AdventureWorks())
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;

                try
                {
                    db.SaveChanges();
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
        }

        // POST: api/Products
        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The Product object.</param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var db = new AdventureWorks())
            {
                db.Products.Add(product);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = product.ProductKey }, product);
            }
        }

        // DELETE: api/Products/5

        /// <summary>
        /// Removes a specified product.
        /// </summary>
        /// <param name="id">The ID of the product,</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not found</response>
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {

            using (var db = new AdventureWorks())
            {
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }

                db.Products.Remove(product);
                db.SaveChanges();

                return Ok(product);
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool ProductExists(int id)
        {
            using (var db = new AdventureWorks())
            
                return db.Products.Count(e => e.ProductKey == id) > 0;
        }
    }
}