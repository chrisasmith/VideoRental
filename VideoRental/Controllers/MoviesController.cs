using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VideoRental.Models;
using VideoRental.ViewModels;

namespace VideoRental.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movies = _context.Movies.Include(m => m.MovieGenre);  // GetMovies();

            var viewModel = new RandomMovieViewModel
            {
                Movie = GetMovies()
            };

            return View(movies);
        }
        public ViewResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.MovieGenres.ToList()
            };

            return View("MovieForm", viewModel);
        }
        
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.MovieGenre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)

            {
                Genres = _context.MovieGenres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)

                {
                    Genres = _context.MovieGenres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0) {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);


                //TryUpdateModel(customerInDb, "", new string[] {"", ""}); can be a security issue and uses magic strings
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.MovieGenreId  = movie.MovieGenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Random", "Movies");
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>{
                new Movie() { Id = 1, Name = "Notebook" },
                new Movie() { Id = 2, Name = "You Got Mail" },
                new Movie() { Id = 2, Name = "Open Range" },
                new Movie() { Id = 4, Name = "Toobstone" }
            };
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}@sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}