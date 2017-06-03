using System;
using System.Collections.Generic;

namespace Services.Models
{
    // Models returned by AccountController actions.

    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }

    public class ProfileViewModel
    {
        public string Username { get; set; }

        public string ProfilePicture { get; set; }

        public string PhoneNumber { get; set; }

        public string Facebook { get; set; }

        public string Skype { get; set; }

        public string City { get; set; }

    }

    public class UserEditViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string ProfilePicture { get; set; }

        public string PhoneNumber { get; set; }

        public string Facebook { get; set; }

        public string Skype { get; set; }

        public int CityId { get; set; }

    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
