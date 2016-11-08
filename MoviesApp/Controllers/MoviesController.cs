using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class MoviesController : Controller
    {
        private IUnitOfWork unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Movies
        public async Task<ActionResult> Index()
        {
            var movies = await unitOfWork.MovieRepository.Get(includeProperties: nameof(Movie.Director));
            return View(movies);
        }

        // GET: Movies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await unitOfWork.MovieRepository.GetByID(id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        // GET: Movies/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.DirectorId = new SelectList(await unitOfWork.DirectorRepository.Get(), nameof(Director.DirectorID), "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Tile,DirectorId,DateRealeased,Description")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.MovieRepository.Insert(movie);
                await unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DirectorId = new SelectList(await unitOfWork.DirectorRepository.Get(), nameof(Director.DirectorID), "Name", movie.DirectorId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await unitOfWork.MovieRepository.GetByID(id);
            if (movie == null)
                return HttpNotFound();
            ViewBag.DirectorId = new SelectList(await unitOfWork.DirectorRepository.Get(), nameof(Director.DirectorID), "Name", movie.DirectorId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Tile,DirectorId,DateRealeased,Description")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.MovieRepository.Update(movie);
                await unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.DirectorId = new SelectList(await unitOfWork.DirectorRepository.Get(), nameof(Director.DirectorID), "Name", movie.DirectorId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await unitOfWork.MovieRepository.GetByID(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Movie movie = await unitOfWork.MovieRepository.GetByID(id);
            unitOfWork.MovieRepository.Delete(movie);
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
