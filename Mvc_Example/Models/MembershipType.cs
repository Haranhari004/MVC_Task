using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Example.Models
{
    public class MembershipType
    {
        public int id { get; set; }
        public string MembershipTypeName { get; set; }
        public float Amount { get; set; }
        public int DurationInMonth { get; set; }
        public float Discount { get; set; }
    }
}