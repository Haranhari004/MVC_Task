using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc_Example.Models
{
    public class Customer
    {

        public int id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Customer Name")]
        public string name { get; set; }
        [Display(Name ="Birth Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime? DateOfBirth { get; set; }


        //Referene the table
        public MembershipType MembershipType { get; set; }


        //Reference a Column
        [Display(Name ="Membership Type")]
        public int MembershipTypeid { get; set; }
    }
}