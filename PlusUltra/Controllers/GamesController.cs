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
    public class GamesController : Controller
    {
        private PlusUltraDbContext db = new PlusUltraDbContext();
        private readonly UnitOfWork uow;

        public GamesController()
        {
            uow = new UnitOfWork(new PlusUltraDbContext());
        }

        public GamesController(PlusUltraDbContext context)
        {
            uow = new UnitOfWork(context);
        }

        // GET: Games
        public ActionResult Index()
        {
            return View(uow.GameRepository.GetAll());
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = uow.GameRepository.GetById((int)id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrganizationId,GameNumber,GameName")] Game game)
        {
            if (ModelState.IsValid)
            {
                uow.GameRepository.Create(game);
                uow.GameRepository.Save(game);
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = uow.GameRepository.GetById((int)id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrganizationId,GameNumber,GameName")] Game game)
        {
            if (ModelState.IsValid)
            {
                uow.GameRepository.PromoteOrDemote(game);
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = uow.GameRepository.GetById((int)id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = uow.GameRepository.GetById((int)id);
            uow.GameRepository.DeleteByID(id);
            uow.GameRepository.Save(game);
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
