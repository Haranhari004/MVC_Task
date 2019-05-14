using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Mvc_Example.Models
{
    public class Movie
    {

        public int id { get; set; }
        [Required]
        public string Moviename { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Enter a number above 0")]
        public int Stock { get; set; }

        //Referance a table
        public Genre Genre { get; set; }

        //Referance a column
        public int Genreid { get; set; }
    }
}