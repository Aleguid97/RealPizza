using RealPizza.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace RealPizza.Controllers.ControlloCampi
{
    public class Username : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string Username = value?.ToString();

            // Check if the username is already taken in the database
            if (IsUsernameTaken(Username))
            {
                return new ValidationResult("Lo username è già stato scelto");
            }

            if (Username == null || Username.Length < 5 || !Regex.IsMatch(Username, "^[a-zA-Z0-9]+$"))
            {
                return new ValidationResult("Lo username deve contenere almeno 5 caratteri e non deve contenere caratteri speciali");
            }
            else
            {
                return ValidationResult.Success;
            }
        }

        private bool IsUsernameTaken(string username)
        {
            using (var db = new ModelDbContext())
            {
                return db.Users.Any(u => u.Username == username);
            }
        }
    }
}