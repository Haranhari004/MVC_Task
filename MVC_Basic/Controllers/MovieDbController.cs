using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Basic.Models;
using MVC_Basic.ViewModel;
namespace MVC_Basic.Controllers
{
    public class MovieDbController : Controller
    {

        // GET: MovieDb
        public ActionResult Index()
        {
            return View();
        }

        public string Test()
        {   
            return "This is the Test";
        }


        // We can Give view() Content() HttpNOTFound( ) JsonResult()
        public ActionResult Example()
        {
            //MovieDbTask obj = new MovieDbTask();
            //obj.Name = "End Game";

            List<MovieDbTask> movies = GetMovies();
            return View(movies);
            //return new HttpNotFoundResult("Please Try later");
        }

        public ActionResult GetMovieByName(int? id,string name)
        {
            if (!id.HasValue)
            {

            }
            return Content($"Id :{id}<br/> Name: {name}");
        }

        

        public  List<MovieDbTask> GetMovies()
        {
            List<MovieDbTask> movies = new List<MovieDbTask>
            {
                new MovieDbTask{Name="Captain Marvel" },
                new MovieDbTask{Name="End Game"},
                new MovieDbTask{Name="2.O"}

            };
            return movies;
        }


        public ActionResult MyRentedMovies()
        {
            Customer cust = new Customer();
            cust.name = "Haran";
            //var Movies = GetMovies();

            CustomerViewModel customerView = new CustomerViewModel();
            customerView.Customer = cust;
            customerView.Mymovies = GetMovies();
            return View(customerView);
        }
    }
}