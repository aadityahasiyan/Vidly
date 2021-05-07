using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MemberShipTypeId == MembershipType.Unknown || customer.MemberShipTypeId == MembershipType.FreeUser)
            {
                return ValidationResult.Success;
            }
            else if(customer.BirthDate == null)
            {
                return new ValidationResult("Birth Date is required");
            }
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age>=18)? ValidationResult.Success : new ValidationResult("Customer should be atleast 18 years old to have a membership");
        }
    }
}