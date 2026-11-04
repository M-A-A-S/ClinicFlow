using ClinicFlow.Domain.Resources.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.DTOs.Identity.Role
{
    public class RoleDTO
    {
        public string Id { get; set; } = string.Empty;
        [Display(
            Name = nameof(SharedResource.Name),
            ResourceType = typeof(SharedResource)
        )]
        [Required(
            ErrorMessageResourceName = nameof(SharedResource.Required),
            ErrorMessageResourceType = typeof(SharedResource)
        )]
        public string Name { get; set; }
        //[Display(
        //    Name = nameof(SharedResource.UserCount),
        //    ResourceType = typeof(SharedResource)
        //)]
        //public int UserCount { get; set; }

    }
}
