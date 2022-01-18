using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL.Concrete;
using DAL.Concrete;
using Entities.Model.EntityFramework;

namespace UI.Areas.ManagementPanel.Controllers
{
    public class ProductsController : Controller
    {
        private Context db = new Context();
        ProductManager pmanager = new ProductManager(new EFProductDAL());
        CategoryManager cmanager = new CategoryManager(new EFCategoryDAL());

        // GET: ManagementPanel/Products
        public ActionResult Index()
        {            
            return View(pmanager.GetAll());
        }

        // GET: ManagementPanel/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = pmanager.Get(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: ManagementPanel/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(cmanager.GetAll(), "CategoryId", "CategoryName");
            return View();
        }

        // POST: ManagementPanel/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,CategoryId")] Products products)
        {
            if (ModelState.IsValid)
            {
                pmanager.Add(products);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(cmanager.GetAll(), "CategoryId", "CategoryName", products.CategoryId);
            return View(products);
        }

        // GET: ManagementPanel/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = pmanager.Get(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(cmanager.GetAll(), "CategoryId", "CategoryName", model.CategoryId);
            return View(model);
        }

        // POST: ManagementPanel/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,CategoryId")] Products products)
        {
            if (ModelState.IsValid)
            {
                pmanager.Update(products);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(cmanager.GetAll(), "CategoryId", "CategoryName", products.CategoryId);
            return View(products);
        }

        // GET: ManagementPanel/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = pmanager.Get(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: ManagementPanel/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = pmanager.GetDetail(id);
            pmanager.Delete(model);
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
