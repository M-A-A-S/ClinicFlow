using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.Identity.ResetPassword
{
    public class ResetPasswordDTO
    {
        public string UserId { get; set; }

        [Display(
            Name = nameof(SharedResource.NewPassword),
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
        public string NewPassword { get; set; }

        [Display(
            Name = nameof(SharedResource.ConfirmPassword),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        [Compare(
        nameof(NewPassword),
        ErrorMessageResourceName = nameof(SharedResource.PasswordMismatch),
        ErrorMessageResourceType = typeof(SharedResource))]
        public string ConfirmPassword { get; set; }
    }
}
