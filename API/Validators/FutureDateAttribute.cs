using System;
using System.ComponentModel.DataAnnotations;

namespace API.Validators
{
    public class FutureDateAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dueDate)
            {
                if (dueDate <= DateTime.Today)
                {
                    return new ValidationResult("The request due date must be in the future.");
                }

                if (dueDate > DateTime.Today.AddYears(1))
                {
                    return new ValidationResult("The request due date cannot be more than a year from today.");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Date is not a valid date.");
        }
    }
}