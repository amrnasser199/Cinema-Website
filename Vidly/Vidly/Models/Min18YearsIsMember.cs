using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly.Models;

namespace Vidly.Models
{
    public class Min18YearsIsMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||
                 customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return  ValidationResult.Success;
            
            if (customer.BirthDate==null)
               return new ValidationResult("Birthdate Is Required");
            
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer Should Be At Least  18 Years Old");

        }
    }
}