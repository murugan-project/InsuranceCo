using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShadyInsurance.Models;

namespace ShadyInsurance.Controllers
{
    public class QuotesController : Controller
    {
        private ShadyInsuranceEntities db = new ShadyInsuranceEntities();

        // GET: Quotes
        public ActionResult Index()
        {
            return View(db.Quote.ToList());
        }

        // GET: Quotes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quote.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // GET: Quotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Age,ZipCode,AnnualMilage,Make,Model,Year,Rate")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                quote.Id = Guid.NewGuid();
                db.Quote.Add(quote);
                db.SaveChanges();
                return RedirectToAction("Result", quote);
            }

            return View(quote);
        }

        // GET: Quotes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quote.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Age,ZipCode,AnnualMilage,Make,Model,Year,Rate")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quote);
        }

        // GET: Quotes/Result/5
        public ActionResult Result(Guid? id)
        {
            Quote quote = db.Quote.Find(id);

            quote.Rate = (int)quote.Age;
            quote.Rate += (int)quote.ZipCode;
            quote.Rate += (int)quote.AnnualMilage;
            quote.Rate += quote.Make.Length;
            quote.Rate += quote.Model.Length;
            quote.Rate += int.Parse(quote.Year);
            db.SaveChanges();

            return View(quote);
        }

        // GET: Quotes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quote.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Quote quote = db.Quote.Find(id);
            db.Quote.Remove(quote);
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
