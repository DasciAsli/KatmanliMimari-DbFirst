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
    public class CategoriesController : Controller
    {
        private Context db = new Context();
        CategoryManager cmanager = new CategoryManager(new EFCategoryDAL());

        // GET: ManagementPanel/Categories
        public ActionResult Index()
        {
            return View(cmanager.GetAll());
        }

        // GET: ManagementPanel/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = cmanager.GetDetail(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: ManagementPanel/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                cmanager.Add(categories);
                return RedirectToAction("Index");
            }

            return View(categories);
        }

        // GET: ManagementPanel/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = cmanager.GetDetail(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: ManagementPanel/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                cmanager.Update(categories);
                return RedirectToAction("Index");
            }
            return View(categories);
        }

        // GET: ManagementPanel/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = cmanager.GetDetail(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: ManagementPanel/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = cmanager.GetDetail(id);
            cmanager.Delete(model);
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
