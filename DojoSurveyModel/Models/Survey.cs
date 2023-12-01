#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveyModel.Models;

public class Survey
{
    [Required(ErrorMessage ="Name is Required")]
    [MinLength(2, ErrorMessage ="Name must be longer than 2 characters")]
    public string Name {get;set;}
    [Required(ErrorMessage ="Please choose a location")]
    public string Location {get;set;}
    [Required(ErrorMessage ="Please choose a Programming Language")]
    public string Language {get;set;}
    [MinLength(20, ErrorMessage ="At least 20 characters are required for a valid comment")]
    public string? Comments {get;set;}
}