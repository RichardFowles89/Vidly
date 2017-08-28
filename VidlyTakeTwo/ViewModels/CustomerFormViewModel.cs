using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyTakeTwo.Models;

namespace VidlyTakeTwo.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        //IEnumerable is preferable to List here because we don't need any of the List methods like Add, Remove...
        //Using IEnumerable also makes our code more loosely coupled.
        public Customer Customer { get; set; }
    }
}