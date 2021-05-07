using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private MovieRentalDBContext _context;
        public MoviesController()
        {
            _context = new MovieRentalDBContext();
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole("CanManageMovies"))
            {
                return View("ReadOnlyList", movies);
            }
            
            return View("Index",movies);
        }
        public ActionResult Details(int id)
        {
            Movie mov = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (mov == null)
            {
                return HttpNotFound();
            }
            return View(mov);
        }

        [Authorize(Roles ="CanManageMovies")]
        public ActionResult New()
        {
            var movie = new NewMovieViewModel { Genres = _context.Genres.ToList() };
            
            return View("MovieForm", movie);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.DateAdded =  movie.DateAdded;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null) { return HttpNotFound(); }
            var vm = new NewMovieViewModel
            {
                Genres = _context.Genres.ToList(), Movie = movie
                
            };
            return View("MovieForm", vm);
        }
    }
}