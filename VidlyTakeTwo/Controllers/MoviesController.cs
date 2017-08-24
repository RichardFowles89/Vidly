﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyTakeTwo.Models;
using VidlyTakeTwo.ViewModels;

namespace VidlyTakeTwo.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        //ActionResult is the base class for all action results in MVC. It is often good pratice 
        //to change it to a more specific subclass (like ViewResult) as this saves us an extra 
        //cast in our unit tests.
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1" },
                new Customer {Name = "Customer 2" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            /* ViewData["Movie"] = movie;
             return View();*/
            //return View(movie);
            /*Where does the movie actually go in the View? Here:
             var viewResult = new ViewResult();
             viewResult.ViewData.Model <<<<========== HERE. The argument (movie) is 
             assigned to the Model property.
            */

            //The are 3 ways to pass data/models to views. 1) pass it as an argument (like above). 
            //2) ViewData - Every controller has a property called 'ViewData' which is of type 
            //ViewDataDictionary. 3) MS then tried to improve ViewData with ViewBag. Mosh says they
            //are a bit shit and you should stick to the first way. 

            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
            //In RedirectToAction the first argument is the action we are redirecting to,
            //the second is the controller. Sometimes, we need to pass arguments to the
            //new target action; that is the third argument. It is an annoymous object.


            /* This action gets called when the url is searched for. If you look in the View/Movies
           folder you will see that Random is contained in it, so that page is being called. The 
           Movies/Random url is generated BECAUSE this action is called "Random" and it can be found 
           in "Movies". What this url is basically saying is "look in MoviesController and call the
           Random action"; this is done by the MVC router (I think this is a virtual thing in VS, not
           the physical router). This action creates a Movie object. Then, it passes this Movie object
           to the Random View and returns it to the caller. By passing the movie object, the 
           Random.cshtml file can be populated with the information contained in the Movie object. 
                        */
        }
        //GET Movies/Edit/1 (or 2 or 3 or 4...)
        public ActionResult Edit(int id)
        {
            return Content("id= " + id);
        }
        //GET Movies  (imagine this page returns a list of movies in the database)
       /* public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        */


        //*********ATTRIBUTE ROUTING***********
        //We apply the route attribute above the relevant action and pass the url template.
        //To apply constraints, we write :regex (to apply a regular (reg) expression (ex)
        //regex is like a method that we call. In parenthesis we pass the actual regular
        //expression. The regular expression in not a string so we cannot do a verbatim
        //string (@). We have to do \\ instead. As well as 'range', we can also do things
        //like min, max, minlength, maxlength etc. If you want to know more google "ASP.NET
        //MVC Attribute Route Constraints".
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Index()
        {
            var movies = GetMovies();
 
             return View(movies); 
        }

        private IEnumerable<Movie> GetMovies() //This basically mimics a database
         {
             return new List<Movie>
             {
                 new Movie { Id = 1, Name = "Shrek" },
                 new Movie { Id = 2, Name = "Wall-e" }
             };
         }
    } 
}