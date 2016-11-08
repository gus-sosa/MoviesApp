﻿using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class DirectorsController : Controller
    {
        private IUnitOfWork unitOfWork;

        public DirectorsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Directors
        public async Task<ActionResult> Index()
        {
            return View(await unitOfWork.DirectorRepository.Get());
        }

        // GET: Directors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = await unitOfWork.DirectorRepository.GetByID(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // GET: Directors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DirectorID,Name,Birthday,Biography")] Director director)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.DirectorRepository.Insert(director);
                await unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(director);
        }

        // GET: Directors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = await unitOfWork.DirectorRepository.GetByID(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // POST: Directors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DirectorID,Name,Birthday,Biography")] Director director)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.DirectorRepository.Update(director);
                await unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        // GET: Directors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Director director = await unitOfWork.DirectorRepository.GetByID(id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Director director = await unitOfWork.DirectorRepository.GetByID(id);
            unitOfWork.DirectorRepository.Delete(director);
            await unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
