using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CustomersAndOrders.Areas.Customers.Data;
using CustomersAndOrders.Areas.Orders.Data;
using CustomersAndOrders.Data;

namespace CustomersAndOrders.Areas.Orders.Controllers
{
    [RouteArea]
    [RoutePrefix("Order")]
    public class OrdersController : Controller
    {
        private CustomersAndOrdersContext db = new CustomersAndOrdersContext();

        // GET: Orders/Orders
        [SearchFilter(View = "ErrorPage")]
        [Route("")]
        public ActionResult Index(int? Id = null)
        {
            

            ViewBag.Customers = db.Customers;
            List<Order> orders;
            if (Id == null)
                orders = db.Orders.ToList();

            else
            {
                if (db.Customers.Find(Id) == null)
                    throw new Exception("Customer doesn't exist");

                orders = db.Orders.Where(e => e.CustomerId == Id).ToList();
            }


            return View(orders);
        }

        // GET: Orders/Orders/Details/5
        [Route("Details/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Include(o => o.Customer).FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Orders/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            return View();
        }

        // POST: Orders/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create([Bind(Include = "Id,Date,ItemCount,TotalPrice,CustomerId")] Order order)
        {
            if (order.Date < DateTime.Today)
            {
                ModelState.AddModelError("Date", "Order date can't be before today");
            }

            if (order.TotalPrice <= 0)
            {
                ModelState.AddModelError("TotalPrice", "Total Price can't be negative");
            }

            

            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Orders/Edit/5
        [Route("Edit/{id:int}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id:int}")]
        public ActionResult Edit([Bind(Include = "Id,Date,ItemCount,TotalPrice,CustomerId")] Order order)
        {
            if (order.Date < DateTime.Today)
            {
                ModelState.AddModelError("Date", "Order date can't be before today");
            }

            if (order.TotalPrice <= 0)
            {
                ModelState.AddModelError("TotalPrice", "Total Price can't be negative");
            }

            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Orders/Delete/5
        [Route("Delete/{id:int}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id:int}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
