﻿using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Services.Models
{
    // Models used as parameters to AccountController actions.

    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int CityId { get; set; }

        [MaxLength(500000)]
        public string ProfilePicture { get; set; }

        [MinLength(3)]
        [MaxLength(60)]
        public string Facebook { get; set; }

        [MinLength(3)]
        [MaxLength(60)]
        public string Skype { get; set; }

        [MinLength(4)]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }

    public class AccountEditBindingModel
    {
        [MaxLength(30)]
        public string Username { get; set; }

        [MaxLength(500000)]
        public string ProfilePicture { get; set; }

        [MinLength(6)]
        public string OldPassword { get; set; }

        [MinLength(6)]
        public string NewPassword { get; set; }

        [Required]
        public string Email { get; set; }

        [MinLength(4)]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MinLength(3)]
        [MaxLength(60)]
        public string Facebook { get; set; }

        [MinLength(3)]
        [MaxLength(60)]
        public string Skype { get; set; }

        [Required]
        public int CityId { get; set; }
    }

    public class RegisterExternalBindingModel
    {
        [Required]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
