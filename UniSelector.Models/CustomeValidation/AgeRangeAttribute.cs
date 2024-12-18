namespace UniSelector.Models.CustomeValidation;

using System;
using System.ComponentModel.DataAnnotations;

public class AgeRangeAttribute : ValidationAttribute
{
    private readonly int _minAge;
    private readonly int _maxAge;

    public AgeRangeAttribute(int minAge, int maxAge)
    {
        _minAge = minAge;
        _maxAge = maxAge;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateTime birthDate) 
            return ValidationResult.Success;
        
        var today = DateTime.Today;
        var minDate = today.AddYears(-_maxAge); // 100 years ago
        var maxDate = today.AddYears(-_minAge); // 15 years ago

        if (birthDate >= minDate && birthDate <= maxDate)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult($"The date must be between {minDate.ToShortDateString()} and {maxDate.ToShortDateString()}.");
    }
}
