using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Example.Models;
using System.Data.Entity;
using Mvc_Example.View_Model;

namespace Mvc_Example.Controllers
{
    [RequireHttps]
    [Authorize]
    public class MoviesController : Controller
    {
        ApplicationDbContext dbContext = null;

        public MoviesController()
        {
            dbContext = new ApplicationDbContext();                       
        }
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();    
        }
        // GET: Movies
        public ActionResult Index()
        {

            var val = dbContext.movies.Include(m =>m.Genre).ToList();
            return View(val);
        }

        public ActionResult Details(int id)
        {
            var movie =dbContext.movies.Include(m => m.Genre).SingleOrDefault(c => c.id == id);
            if (movie == null)
            {
                return HttpNotFound("Movie Id is Not Found");
            }
            return View(movie);
        }

        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie{id=1,Moviename="End Game",ReleaseDate=Convert.ToDateTime("25-04-2019"),DateAdded=Convert.ToDateTime("24-04-2019")},
                new Movie{id=2,Moviename="2.O",ReleaseDate=Convert.ToDateTime("25-12-2018"),DateAdded=Convert.ToDateTime("24-12-2018")}
            };
            return movies;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            MovieGenreViewModel movieGenreViewModel = new MovieGenreViewModel();
            Movie movie = new Movie();
            var genresname = dbContext.genres.ToList();
            movieGenreViewModel.movie = movie;
            movieGenreViewModel.Genres = genresname;
            return View(movieGenreViewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                dbContext.movies.Add(movie);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                MovieGenreViewModel movieGenreViewModel = new MovieGenreViewModel();
                Movie movie1 = new Movie();
                var genresname = dbContext.genres.ToList();
                movieGenreViewModel.movie = movie1;
                movieGenreViewModel.Genres = genresname;
                return View(movieGenreViewModel);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var Movie = dbContext.movies.SingleOrDefault(c => c.id == id);
            var genid = dbContext.genres.ToList();

            MovieGenreViewModel movieGenreViewModel = new MovieGenreViewModel()
            {
                movie = Movie,
                Genres = genid
            };
            return View(movieGenreViewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var movietbl = dbContext.movies.SingleOrDefault(c => c.id == movie.id);
                if (movietbl == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    movietbl.Moviename = movie.Moviename;
                    movietbl.ReleaseDate = movie.ReleaseDate;
                    movietbl.DateAdded = movie.DateAdded;
                    movietbl.Stock = movie.Stock;
                    movietbl.Genreid = movie.Genreid;
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                var Movie = dbContext.movies.SingleOrDefault(c => c.id == movie.id);
                var genid = dbContext.genres.ToList();

                MovieGenreViewModel movieGenreViewModel = new MovieGenreViewModel()
                {
                    movie = Movie,
                    Genres = genid
                };
                return View(movieGenreViewModel);
            }
        }


    }
}