using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlusUltra.DataAccess;
using PlusUltraDB.Entities;
using PlusUltra.DataAccess.Repositories;

namespace PlusUltra.Controllers
{
    public class OrganizationsController : Controller
    {
        private PlusUltraDbContext db = new PlusUltraDbContext();
        private readonly UnitOfWork uow;

        public OrganizationsController()
        {
            uow = new UnitOfWork(new PlusUltraDbContext());
        }

        public OrganizationsController(PlusUltraDbContext context)
        {
            uow = new UnitOfWork(context);
        }

        // GET: Organizations
        public ActionResult Index()
        {
            return View(uow.OrganizationRepository.GetAll());
        }

        // GET: Organizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = uow.OrganizationRepository.GetById((int)id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrganizationId,Name")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                uow.OrganizationRepository.Create(organization);
                uow.OrganizationRepository.Save(organization);
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        // GET: Organizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = uow.OrganizationRepository.GetById((int)id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrganizationId,Name")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                uow.OrganizationRepository.PromoteOrDemote(organization);
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        // GET: Organizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = uow.OrganizationRepository.GetById((int)id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = uow.OrganizationRepository.GetById((int)id);
            uow.OrganizationRepository.DeleteByID(id);
            uow.OrganizationRepository.Save(organization);
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
