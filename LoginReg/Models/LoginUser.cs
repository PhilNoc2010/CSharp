#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;
namespace LoginReg.Models;
public class LoginUser
{
    // No other fields!
    [Required(ErrorMessage ="Email Address is required")]
    public string LoginEmail { get; set; }
    [Required(ErrorMessage ="Password is Required")]
    public string LoginPassword { get; set; }
}