using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Hydocs.Areas.AdWorks.Models.DB;

namespace Hydocs.Areas.AdWorks.Controllers
{
    /// <summary>
    /// Represents an Adventure Works Customers API. 
    /// Use the /customers resource to create, read, update, and delete customers.
    /// </summary>


    public class CustomersController : ApiController
    {
        private AdventureWorks db = new AdventureWorks(); //TODO: change for USING as in GetCustomers()
        private IQueryable<Customer> Users = null;


        /// <summary>
        ///  Gets all Adventure Works customers. 
        ///   </summary>
        ///   <returns> List of 25 customer objects (limited for demo), </returns>
        ///   <remarks>EF can occasionally throw exception "DBcontext is disposed" on this method</remarks>
        ///   <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        /// <see cref="2sharp.today/api/swagger,"/>
        public IEnumerable<Customer> Get()
        {
            return db.Customers.Take(25).ToList();
        }

        /// <summary>
        /// Returns the customer with the given ID.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <returns>A customer record or null with a corresponding HTTP code.</returns>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>


        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            // Default implementation changed by TKJ with USING
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="customer">The Customer object.</param>
        /// <returns>void</returns>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request</response>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerKey)
            {
                return BadRequest();
            }

            db.Entry(customer).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        /// <summary>
        /// Creates a new customer (the ID is generated)
        /// </summary>
        /// <param name="customer">The Customer object.</param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerKey }, customer);
        }


        /// <summary>
        /// Deletes the specified customer.
        /// </summary>
        /// <param name="id">The ID of the customer,</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not found</response>
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// Verifies if a given custome exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true or false</returns>
        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.CustomerKey == id) > 0;
        }
    }
}