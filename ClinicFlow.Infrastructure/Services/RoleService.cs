using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.Identity.Role;
using ClinicFlow.Domain.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicFlow.Application.Services;

namespace ClinicFlow.Infrastructure.Services
{
    public class RoleService : IRoleService
    {
        #region ========================= Fields & Properties =========================
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RoleService> _logger;

        #endregion

        #region ========================= Constructors =========================
        public RoleService(
            RoleManager<IdentityRole> roleManager,
            ILogger<RoleService> logger)
        {
            _roleManager = roleManager;
            _logger = logger;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<string>> AddAsync(RoleDTO DTO)
        {

            try
            {

                var validationResult = await ValidateRoleDTO(DTO);

                if (!validationResult.IsSuccess)
                {
                    return Result<string>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var result = await _roleManager.CreateAsync(new IdentityRole(DTO.Name));

                if (!result.Succeeded)
                {
                    return Result<string>.Failure();
                }

                var createdRole = await _roleManager.FindByNameAsync(DTO.Name);

                if (createdRole == null)
                {
                    return Result<string>.Failure(ResultCodes.ServerError, HttpStatusCodes.InternalServerError);
                }

                return Result<string>.Success(createdRole.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(RoleService),
                   nameof(AddAsync));

                return Result<string>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<RoleDTO>>> GetAllAsync()
        {
            try
            {

                var items = await _roleManager.Roles.Select(x => new RoleDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

                

                return Result<IEnumerable<RoleDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(RoleService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<RoleDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<RoleDTO>> GetByIdAsync(string id)
        {
            try
            {
                var item = await _roleManager.FindByIdAsync(id);
                


                if (item == null)
                {
                    return Result<RoleDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                var result = new RoleDTO
                {
                    Id = item.Id,
                    Name = item.Name
                };

                return Result<RoleDTO>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(RoleService),
                   nameof(GetByIdAsync));

                return Result<RoleDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(string id, RoleDTO DTO)
        {

            try
            {
                var validationResult = await ValidateRoleDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _roleManager.FindByIdAsync(id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.Name = DTO.Name;

                var updateResult = await _roleManager.UpdateAsync(item);
                if (!updateResult.Succeeded)
                {
                    return Result<bool>.Failure(
                        ResultCodes.ServerError,
                        HttpStatusCodes.InternalServerError);
                }

                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(RoleService),
                    nameof(UpdateAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError, "An unexpected error occurred.");
            }
        }
        #endregion

        #region ========================= Delete =========================
        public async Task<Result<bool>> DeleteAsync(string id)
        {
            try
            {
                var item = await _roleManager.FindByIdAsync(id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                // Prevent deletion of critical roles
                if (item.Name == "Admin" || item.Name == "SuperAdmin")
                {
                    return Result<bool>.Failure(
                        ResultCodes.CannotDeleteCriticalRole,
                        HttpStatusCodes.BadRequest,
                        $"Cannot delete critical role '{item.Name}'.");


                }

                var deleteResult = await _roleManager.DeleteAsync(item);
                if (!deleteResult.Succeeded)
                {
                    return Result<bool>.Failure(
                        ResultCodes.ServerError, 
                        HttpStatusCodes.InternalServerError);
                }

                return Result<bool>.Success(true, ResultCodes.DeletedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(RoleService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================
        private async Task<Result<bool>> ValidateRoleDTO(RoleDTO DTO, string? excludedId = null)
        {
            if (DTO == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }

            //bool nameExists = await _roleManager.RoleExistsAsync(DTO.Name);

            var role = await _roleManager.FindByNameAsync(DTO.Name);

            bool nameExists = role != null && (excludedId == null || role.Id != excludedId);

            if (nameExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.NameExists,
                    HttpStatusCodes.Conflict);
            }


            return Result<bool>.Success(true);

        }

        #endregion

    }
}
