using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.CustomValidations
{
    public class Customer18YearsOld : ValidationAttribute
    {
        private string membershipName(int id)
        {
            return (id == 3) ? "Quarterly" : "Annual";
            }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years old to go on a "
                + membershipName(customer.MembershipTypeId) + " membership");
        }
    }
}