using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyTakeTwo.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the customer's name.")]//This attribute makes Name non-nullale
        [StringLength(255)]//Makes Name max length 255
        public string Name { get; set; }
       
        [Display(Name = "Date of Birth")] //This is one way to change the name of Birthdate in the View
        [Min18YearsIfAMember]//We made this attribute manually! Look in Models
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }//Navigation Property!
                                                          //Navigation Properties allow us to navigate from one type to another, in this case, from Customer to
                                                          //its Membership Type

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } //foreign key
    }
}