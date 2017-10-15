using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyTakeTwo.Models;

namespace VidlyTakeTwo.Dtos
{
    //Data Transfer Objects are plain data structures that are used to transfer data from the client
    //to the server, or vis versa. Dtos reduce the chance of our API breaking as we refactor our domain
    //model. Using domain objects is also a security risk. YOUR APIS SHOULD NEVER RETURN OR RECEIVE 
    //DOMAIN OBJECTS.
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        public byte MembershipTypeId { get; set; } 
    }
}