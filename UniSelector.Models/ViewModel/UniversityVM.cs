using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using UniSelector.Models;
using System.ComponentModel.DataAnnotations;

public class UniversityVM
{
    [ValidateNever]
    public ApplicationUser ApplicationUser { get; set; }

}