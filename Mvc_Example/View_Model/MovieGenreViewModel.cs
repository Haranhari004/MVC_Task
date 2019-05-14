using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc_Example.Models;

namespace Mvc_Example.View_Model
{
    public class MovieGenreViewModel
    {
        public Movie movie { get; set; }
        public List<Genre>  Genres { get; set; }
    }
}