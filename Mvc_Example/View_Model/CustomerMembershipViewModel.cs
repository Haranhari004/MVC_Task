using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc_Example.Models;

namespace Mvc_Example.View_Model
{
    public class CustomerMembershipViewModel
    {
        public Customer Customer { get; set; }
        public List<MembershipType> MembershipTypes { get; set; }
    }
}