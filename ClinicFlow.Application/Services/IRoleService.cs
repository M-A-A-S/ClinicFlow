using ClinicFlow.Domain.DTOs.Allergy;
using ClinicFlow.Domain.DTOs.Identity.Role;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IRoleService
    {
        Task<Result<string>> AddAsync(RoleDTO dto);
        Task<Result<bool>> UpdateAsync(string id, RoleDTO dto);
        Task<Result<bool>> DeleteAsync(string id);
        Task<Result<RoleDTO>> GetByIdAsync(string id);
        Task<Result<IEnumerable<RoleDTO>>> GetAllAsync();
    }
}
