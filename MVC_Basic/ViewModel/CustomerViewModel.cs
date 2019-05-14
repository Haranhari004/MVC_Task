using System;
using System.Collections.Generic;
using MVC_Basic.Models;
using System.Linq;
using System.Web;

namespace MVC_Basic.ViewModel
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public List<MovieDbTask> Mymovies { get; set; }
    }
}