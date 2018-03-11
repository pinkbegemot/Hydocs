using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Hydocs.Areas.AdWorks.Models.DB;
using System.Collections.Generic;


namespace Hydocs.Areas.AdWorks.Controllers
{
    [OutputCache(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class CustomersMVController : Controller
    {
        private AdventureWorks db = new AdventureWorks();

        /// <summary>
        /// Default Index() action, wchich takes only 25 top rows
        /// </summary>
        /// <returns>View</returns>
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(db.Customers.Take(25).ToList());
        }

        public IEnumerable<Customer> GetCustomers() {
            return db.Customers.Take(25).ToList();
        }
        // GET: Adworks/Customers/Details/5
        public ActionResult CustomerDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer dimCustomer = db.Customers.Find(id);
            if (dimCustomer == null)
            {
                return HttpNotFound();
            }
            return View(dimCustomer);
        }
        public Customer GetCustomer(int? id)
        {
            if (id == null)
            {
                return null;
            }
            Customer dimCustomer = db.Customers.Find(id);
            if (dimCustomer == null)
            {
                return null;
            }
            return dimCustomer;
        }

        // GET: adworks/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MVCarea/Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerKey,GeographyKey,CustomerAlternateKey,Title,FirstName,MiddleName,LastName,NameStyle,BirthDate,MaritalStatus,Suffix,Gender,EmailAddress,YearlyIncome,TotalChildren,NumberChildrenAtHome,EnglishEducation,SpanishEducation,FrenchEducation,EnglishOccupation,SpanishOccupation,FrenchOccupation,HouseOwnerFlag,NumberCarsOwned,AddressLine1,AddressLine2,Phone,DateFirstPurchase,CommuteDistance")] Customer dimCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(dimCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dimCustomer);
        }

        // GET: MVCarea/Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer dimCustomer = db.Customers.Find(id);
            if (dimCustomer == null)
            {
                return HttpNotFound();
            }
            return View(dimCustomer);
        }

        // POST: MVCarea/Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerKey,GeographyKey,CustomerAlternateKey,Title,FirstName,MiddleName,LastName,NameStyle,BirthDate,MaritalStatus,Suffix,Gender,EmailAddress,YearlyIncome,TotalChildren,NumberChildrenAtHome,EnglishEducation,SpanishEducation,FrenchEducation,EnglishOccupation,SpanishOccupation,FrenchOccupation,HouseOwnerFlag,NumberCarsOwned,AddressLine1,AddressLine2,Phone,DateFirstPurchase,CommuteDistance")] Customer dimCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dimCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dimCustomer);
        }

        // GET: MVCarea/Customers/Delete/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer dimCustomer = db.Customers.Find(id);
            if (dimCustomer == null)
            {
                return HttpNotFound();
            }
            return View(dimCustomer);
        }
        // GET: MVCarea/Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer dimCustomer = db.Customers.Find(id);
            if (dimCustomer == null)
            {
                return HttpNotFound();
            }
            return View(dimCustomer);
        }

        // POST: MVCarea/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer dimCustomer = db.Customers.Find(id);
            db.Customers.Remove(dimCustomer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
