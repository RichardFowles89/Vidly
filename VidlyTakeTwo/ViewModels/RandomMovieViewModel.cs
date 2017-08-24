using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyTakeTwo.Models;

namespace VidlyTakeTwo.ViewModels
{
    public class RandomMovieViewModel
    {
        //As a convention, we use the ViewModel suffix for viewModels.
        
        //It appears that ViewModels are objects that allow you to bind together Models
        // into one object that can then be passed as a parameter. A ViewModel can be an 
        //object composed of Models. It's called ViewModel because it is the model for/that
        //goes to the View. Note: it doesn't have to be composed of Models ->
//THE KEY THING TO REMEMBER IS THAT THE VIEWMODEL REPRESENTS THE DATA THAT YOU WANT TO
//USE IN THE VIEW

        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}