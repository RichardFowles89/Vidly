using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyTakeTwo.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {//This is a custom validation (attribute). If the input in the view does not pass this validation
        //the validation message will show
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {//ObjectInstance refers to the object to which this attribute is applied - but it has to be cast
            var customer = (Customer)validationContext.ObjectInstance;
            //Once we have the object, we can run validation checks against it.
            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)//0 = no type selected. 1 = Pay as You Go
                return ValidationResult.Success;//...then validation is passed

            if (customer.Birthdate == null)//If no age given tell the user it is required
                return new ValidationResult("Birthdate is required.");
            //This is an overly simplified way of figuring out if the user is over 18 - but it will do for the purposes of this app
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}