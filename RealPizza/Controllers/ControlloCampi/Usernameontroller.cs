using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace RealPizza.Controllers.ControlloCampi
{
    public class Password : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Password is required");
            }

            string password = value.ToString();

            if (password.Length >= 8 && Regex.IsMatch(password, @"[a-z]") && Regex.IsMatch(password, @"[A-Z]") && Regex.IsMatch(password, @"[0-9]") && Regex.IsMatch(password, @"[!@#$%^&*()_+}{:|>?<]"))
            {
                return new ValidationResult("La password deve essere lunga almeno 8 caratteri");
            }

            return ValidationResult.Success;
        }
    }
}