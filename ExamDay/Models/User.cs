#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
namespace ExamDay.Models;
public class User
{
    [Key]
    public int UserID { get; set; }
    [Required(ErrorMessage ="UserName is Required")]
    [MinLength(3, ErrorMessage ="UserName must be longer than 3 characters")]
    [Display(Name = "User Name:")]
    public string UserName { get; set; }
    [EmailAddress]
    [UniqueEmail]
    [Display(Name = "Email Address:")]
    public string EmailAddr { get; set; }
    [Required(ErrorMessage ="Password is Required")]
    [DataType(DataType.Password)]
    [MinLength(8,ErrorMessage ="Password must be longer than 8 characters")]
    [StrongPassword]
    [Display(Name = "Password:")]
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [NotMapped]
    [Compare("Password")]
    [Required(ErrorMessage ="Password Confirmation is required")]
    [Display(Name = "Confirm Password:")]
    public string ConfirmPWD { get; set; }

    public List<ActiveUserCoupon> SubmittedCoupons {get; set;} = new();
    public List<ExpiredUserCoupon> CouponsMarkedExpired { get; set; } = new();


}

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
    	// Though we have Required as a validation, sometimes we make it here anyways
    	// In which case we must first verify the value is not null before we proceed
        if(value == null)
        {
    	    // If it was, return the required error
            return new ValidationResult("Email is required!");
        }

    	// This will connect us to our database since we are not in our Controller
        MyContext? _context = (MyContext)validationContext.GetService(typeof(MyContext));
        // Check to see if there are any records of this email in our database
    	if(_context.Users.Any(e => e.EmailAddr == value.ToString()))
        {
    	    // If yes, throw an error
            return new ValidationResult("Email must be unique!");
        } else {
    	    // If no, proceed
            return ValidationResult.Success;
        }
    }
}

public class StrongPasswordAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
    	// Though we have Required as a validation, sometimes we make it here anyways
    	// In which case we must first verify the value is not null before we proceed
        if(value == null)
        {
    	    // If it was, return the required error
            return new ValidationResult("Password");
        }
        string password = value.ToString();

        bool isStrongPassword = Regex.IsMatch(password, "^(?=.*[A-Z])(?=.*[!@#$&*])(?=.*[0-9])(?=.*[a-z]).{8},$");

    	if(isStrongPassword == false)
        {
    	    // If yes, throw an error
            return new ValidationResult("Password must be a strong password");
        } else {
    	    // If no, proceed
            return ValidationResult.Success;
        }
    }
}

