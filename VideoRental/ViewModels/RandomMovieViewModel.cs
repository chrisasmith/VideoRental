using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRental.Models;

namespace VideoRental.ViewModels
{
    public class RandomMovieViewModel
    {
        public IEnumerable<Movie> Movie { get; set; }
    }
}   