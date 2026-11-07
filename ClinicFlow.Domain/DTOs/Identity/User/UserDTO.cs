using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.Identity.User
{
    public class UserDTO
    {
        public string Id { get; set; } = string.Empty;

        [Display(
            Name = nameof(SharedResource.FullName),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public string FullName { get; set; }

        [Display(
            Name = nameof(SharedResource.Email),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        [EmailAddress(
            ErrorMessageResourceName = nameof(SharedResource.EmailInvalid),
            ErrorMessageResourceType = typeof(SharedResource))]
        public string Email { get; set; }

        [Display(
            Name = nameof(SharedResource.PhoneNumber),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public string PhoneNumber { get; set; }

        //[Display(
        //    Name = nameof(SharedResource.EmailConfirmed),
        //    ResourceType = typeof(SharedResource)
        //)]
        public bool EmailConfirmed { get; set; }

        [Display(
            Name = nameof(SharedResource.IsActive),
            ResourceType = typeof(SharedResource)
        )]
        public bool IsActive { get; set; } = true;

        // Password fields (only used for Create)
        [Display(
            Name = nameof(SharedResource.Password),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        [MinLength(
            8,
            ErrorMessageResourceName = nameof(SharedResource.PasswordTooShort),
            ErrorMessageResourceType = typeof(SharedResource))]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).+$",
            ErrorMessageResourceName = nameof(SharedResource.PasswordRequirements),
            ErrorMessageResourceType = typeof(SharedResource))]
        public string Password { get; set; }

        [Display(
            Name = nameof(SharedResource.ConfirmPassword),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        [Compare(
        nameof(Password),
        ErrorMessageResourceName = nameof(SharedResource.PasswordMismatch),
        ErrorMessageResourceType = typeof(SharedResource))]
        public string ConfirmPassword { get; set; }

        //[Display(
        //    Name = nameof(SharedResource.AvailableRoles),
        //    ResourceType = typeof(SharedResource)
        //)]
        public List<string> AvailableRoles { get; set; } = new();

        [Display(
            Name = nameof(SharedResource.Roles),
            ResourceType = typeof(SharedResource)
        )]
        public List<string> Roles { get; set; } = new();

        // To control password section
        public bool IsEditMode { get; set; }
    }
}
