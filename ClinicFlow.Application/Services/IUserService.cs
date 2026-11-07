using ClinicFlow.Domain.DTOs.Identity.ResetPassword;
using ClinicFlow.Domain.DTOs.Identity.User;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IUserService
    {
        Task<Result<IEnumerable<UserDTO>>> GetAllAsync();
        Task<Result<UserDTO>> GetByIdAsync(string id);
        Task<Result<UserDTO>> GetByEmailAsync(string email);
        Task<Result<string>> AddAsync(UserDTO dto);
        Task<Result<bool>> UpdateAsync(string id, UserDTO dto);
        Task<Result<bool>> DeleteAsync(string id);
        Task<Result<bool>> UpdateRolesAsync(string userId, List<string> selectedRoles);
        Task<Result<bool>> ResetPasswordAsync(ResetPasswordDTO dto);
    }
}
