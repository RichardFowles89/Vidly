using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VidlyTakeTwo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
//There are situations when the default route is not enough, and we need others with 
//different/multiple parameters. When adding these new routes, you have to put them ABOVE 
//the default route because, like catch statements, they have to be from the most specific 
//to the most generic. Note the parameters {year}/{month} in the url.

//THIS IS CUSTOM ROUTING. IT IS THE *OLD* WAY OF DOING THINGS AND MOSH SUGGESTS USING
//ATTRIBUTE ROUTING INSTEAD WHICH YOU WILL FIND BELOW

           /* routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new {controller = "Movies", action = "ByReleaseDate" },
                //new { year = @"2015|2016", month = @"\d{2}" }); - 2015 OR 2016
                new { year = @"\d{4}", month = @"\d{2}" }); //This method is overloaded -
            //the fourth parameter is the constraints on year and month.
            */
            //The last line of code forces the year and month parameters to be 4 and 2
            //digits respectively. 'd' represents digits and the {4} next to it represents
            //the number of digits.
            //Once this route is made, we need to make a corresponding action called
            //"ByReleaseDate" like the default action. 

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //****************************ATTRIBUTE ROUTING*************************************
            routes.MapMvcAttributeRoutes();// The rest of this is found in the controller
            //We are initialising the ability to use attribute routing here, but the rest 
            //of the work is done in the controller. 
        }
    }
}
