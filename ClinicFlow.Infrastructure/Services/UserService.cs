using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.Identity.ResetPassword;
using ClinicFlow.Domain.DTOs.Identity.Role;
using ClinicFlow.Domain.DTOs.Identity.User;
using ClinicFlow.Domain.Resources.Shared;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.Infrastructure.Data;
using ClinicFlow.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure.Services
{
    public class UserService : IUserService
    {
        #region ========================= Fields & Properties =========================
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<UserService> _logger;
        private readonly IAppDbContext _appDbContext;

        #endregion

        #region ========================= Constructors =========================
        public UserService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<UserService> logger,
            IAppDbContext appDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _appDbContext = appDbContext;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<string>> AddAsync(UserDTO DTO)
        {

            try
            {

                var validationResult = await ValidateUserDTO(DTO);

                if (!validationResult.IsSuccess)
                {
                    return Result<string>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var user = new ApplicationUser
                {
                    UserName = DTO.Email,
                    Email = DTO.Email,
                    FullName = DTO.FullName,
                    PhoneNumber = DTO.PhoneNumber,
                    //EmailConfirmed = DTO.EmailConfirmed
                };

                var result = await _userManager.CreateAsync(user, DTO.Password);

                if (!result.Succeeded)
                {
                    var errorCode = GetIdentityErrorCode(result);

                    return Result<string>.Failure(
                        errorCode,
                        HttpStatusCodes.BadRequest,
                        SharedResource.BadRequest);
                }

                // Assign selected roles
                if (DTO.Roles?.Any() == true)
                {
                    var assignResult = await _userManager.AddToRolesAsync(user, DTO.Roles); 

                    if(!assignResult.Succeeded)
                    {
                        await _userManager.DeleteAsync(user);

                        _logger.LogWarning("Failed to assign roles to user {Email}: {Errors}",
                            DTO.Email, string.Join(", ", assignResult.Errors.Select(e => e.Description)));

                        var errorCode = GetIdentityErrorCode(assignResult);

                        return Result<string>.Failure(
                            errorCode,
                            HttpStatusCodes.BadRequest,
                            SharedResource.BadRequest);
                    }

                }

                //var createdUser = await _userManager.FindByEmailAsync(DTO.Email);

                //if (createdUser == null)
                //{
                //    return Result<string>.Failure(ResultCodes.ServerError, HttpStatusCodes.InternalServerError);
                //}

                return Result<string>.Success(user.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(UserService),
                   nameof(AddAsync));

                return Result<string>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<UserDTO>>> GetAllAsync()
        {
            try
            {

                var items = await _userManager.Users.AsNoTracking().Select(x => new UserDTO
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email
                }).ToListAsync();



                return Result<IEnumerable<UserDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(UserService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<UserDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<UserDTO>> GetByIdAsync(string id)
        {
            try
            {
                var item = await _userManager.FindByIdAsync(id);

                if (item == null)
                {
                    return Result<UserDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                var result = new UserDTO
                {
                    Id = item.Id,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email,
                    FullName = item.FullName
                };

                var userRoles = await _userManager.GetRolesAsync(item);

                result.Roles = userRoles.ToList();

                return Result<UserDTO>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(UserService),
                   nameof(GetByIdAsync));

                return Result<UserDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<UserDTO>> GetByEmailAsync(string email)
        {
            try
            {
                var item = await _userManager.FindByEmailAsync(email);



                if (item == null)
                {
                    return Result<UserDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                var result = new UserDTO
                {
                    Id = item.Id,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email,
                    FullName = item.FullName
                };

                var userRoles = await _userManager.GetRolesAsync(item);

                result.Roles = userRoles.ToList();

                return Result<UserDTO>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(UserService),
                   nameof(GetByIdAsync));

                return Result<UserDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(string id, UserDTO DTO)
        {

            try
            {
                var validationResult = await ValidateUserDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _userManager.FindByIdAsync(id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.Email = DTO.Email;
                item.UserName = DTO.Email;
                item.FullName = DTO.FullName;
                item.PhoneNumber = DTO.PhoneNumber;
                //item.EmailConfirmed = DTO.EmailConfirmed;

                var updateResult = await _userManager.UpdateAsync(item);
                if (!updateResult.Succeeded)
                {
                    var errorCode = GetIdentityErrorCode(updateResult);

                    return Result<bool>.Failure(
                        errorCode,
                        HttpStatusCodes.BadRequest,
                        SharedResource.BadRequest);
                }

                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(UserService),
                    nameof(UpdateAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError, "An unexpected error occurred.");
            }
        }
        
        public async Task<Result<bool>> UpdateRolesAsync(string userId, List<string> selectedRoles)
        {
            try
            {

                var item = await _userManager.FindByIdAsync(userId);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                var currentRoles = await _userManager.GetRolesAsync(item);
                var rolesToAdd = selectedRoles.Except(currentRoles, StringComparer.OrdinalIgnoreCase).ToList();
                var rolesToRemove = currentRoles.Except(selectedRoles, StringComparer.OrdinalIgnoreCase).ToList();

                if (rolesToRemove.Any())
                {
                    var removeResult = await _userManager.RemoveFromRolesAsync(item, rolesToRemove);
                    if (!removeResult.Succeeded)
                    {
                        var errorCode = GetIdentityErrorCode(removeResult);

                        return Result<bool>.Failure(
                            errorCode,
                            HttpStatusCodes.BadRequest,
                            SharedResource.BadRequest);
                    }
                }

                if (rolesToAdd.Any())
                {
                    var addResult = await _userManager.AddToRolesAsync(item, rolesToAdd);
                    if (!addResult.Succeeded)
                    {
                        var errorCode = GetIdentityErrorCode(addResult);

                        return Result<bool>.Failure(
                            errorCode,
                            HttpStatusCodes.BadRequest,
                            SharedResource.BadRequest);
                    }
                }

                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(UserService),
                    nameof(UpdateAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError, "An unexpected error occurred.");
            }
        }
        
        public async Task<Result<bool>> ResetPasswordAsync(ResetPasswordDTO dto)
        {

            try
            {

                var item = await _userManager.FindByIdAsync(dto.UserId);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(item);
                var result = await _userManager.ResetPasswordAsync(
                    item, 
                    token, 
                    dto.NewPassword);

                if (!result.Succeeded)
                {
                    //var error = result.Errors.FirstOrDefault();

                    //var message = error != null
                    //    ? GetPasswordErrorMessage(error.Code)
                    //    : SharedResource.PasswordResetFailed;

                    //var errorCode = error == null ? ResultCodes.PasswordResetFailed : error.Code;

                    var errorCode = GetIdentityErrorCode(result);

                    return Result<bool>.Failure(
                        errorCode,
                        HttpStatusCodes.BadRequest,
                        SharedResource.BadRequest);
                }

                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(UserService),
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
                var item = await _userManager.FindByIdAsync(id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                // Prevent deletion of the last admin
                var roles = await _userManager.GetRolesAsync(item);
                if (roles.Contains("Admin") || roles.Contains("SuperAdmin"))
                {
                    var admins = await _userManager.GetUsersInRoleAsync("Admin");
                    var superAdmins = await _userManager.GetUsersInRoleAsync("SuperAdmin");

                    // Get unique count of admin users
                    var uniqueAdminIds = admins.Select(a => a.Id)
                        .Union(superAdmins.Select(x => x.Id))
                        .Count();

                    if (uniqueAdminIds <= 1)
                    {
                        return Result<bool>.Failure(
                            ResultCodes.CannotDeleteLastAdmin,
                            HttpStatusCodes.BadRequest,
                            "Cannot delete the last administrator.");
                    }



                }

                var deleteResult = await _userManager.DeleteAsync(item);
                if (!deleteResult.Succeeded)
                {
                    var errorCode = GetIdentityErrorCode(deleteResult);

                    return Result<bool>.Failure(
                        errorCode,
                        HttpStatusCodes.BadRequest,
                        SharedResource.BadRequest);
                }

                return Result<bool>.Success(true, ResultCodes.DeletedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(UserService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================
        private async Task<Result<bool>> ValidateUserDTO(UserDTO DTO, string? excludedId = null)
        {
            if (DTO == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }

            // Check if email changed and is already taken
            var existingUser = await _userManager.FindByEmailAsync(DTO.Email);
            bool emailExists = existingUser != null && (excludedId == null || existingUser.Id != excludedId);
            if (emailExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.EmailExists,
                    HttpStatusCodes.Conflict);
            }

            return Result<bool>.Success(true);

        }

        //private string GetPasswordErrorMessage(string errorCode)
        //{
        //    return errorCode switch
        //    {
        //        "PasswordTooShort" =>
        //            ResultCodes.PasswordTooShort,

        //        "PasswordRequiresNonAlphanumeric" =>
        //            ResultCodes.PasswordRequiresNonAlphanumeric,

        //        "PasswordRequiresLower" =>
        //            ResultCodes.PasswordRequiresLower,

        //        "PasswordRequiresUpper" =>
        //            ResultCodes.PasswordRequiresUpper,

        //        _ => ResultCodes.PasswordResetFailed
        //    };
        //}

        //private string GetIdentityErrorMessage(string errorCode)
        //{
        //    return errorCode switch
        //    {
        //        // User errors
        //        "DuplicateEmail" =>
        //            ResultCodes.DuplicateEmail,

        //        "DuplicateUserName" =>
        //            ResultCodes.DuplicateUserName,

        //        "InvalidEmail" =>
        //            ResultCodes.InvalidEmail,

        //        "InvalidUserName" =>
        //            ResultCodes.InvalidUserName,

        //        // Password errors
        //        "PasswordTooShort" =>
        //            ResultCodes.PasswordTooShort,

        //        "PasswordRequiresNonAlphanumeric" =>
        //            ResultCodes.PasswordRequiresNonAlphanumeric,

        //        "PasswordRequiresDigit" =>
        //            ResultCodes.PasswordRequiresDigit,

        //        "PasswordRequiresLower" =>
        //            ResultCodes.PasswordRequiresLower,

        //        "PasswordRequiresUpper" =>
        //            ResultCodes.PasswordRequiresUpper,

        //        "PasswordRequiresUniqueChars" =>
        //            ResultCodes.PasswordRequiresUniqueChars,

        //        // Role errors
        //        "DuplicateRoleName" =>
        //            ResultCodes.DuplicateRoleName,

        //        "InvalidRoleName" =>
        //            ResultCodes.InvalidRoleName,

        //        "RoleNotFound" =>
        //            ResultCodes.RoleNotFound,

        //        "UserAlreadyInRole" =>
        //            ResultCodes.UserAlreadyInRole,

        //        "UserNotInRole" =>
        //            ResultCodes.UserNotInRole,

        //        // Other Identity errors
        //        "ConcurrencyFailure" =>
        //            ResultCodes.ConcurrencyFailure,

        //        "LoginAlreadyAssociated" =>
        //            ResultCodes.LoginAlreadyAssociated,

        //        "UserAlreadyHasPassword" =>
        //            ResultCodes.UserAlreadyHasPassword,

        //        "UserLockoutNotEnabled" =>
        //            ResultCodes.UserLockoutNotEnabled,

        //        "InvalidToken" =>
        //            ResultCodes.InvalidToken,

        //        "RecoveryCodeRedemptionFailed" =>
        //            ResultCodes.RecoveryCodeRedemptionFailed,

        //        _ =>
        //            ResultCodes.IdentityOperationFailed
        //    };
        //}


        private string GetIdentityErrorCode(IdentityResult result, string defaultCode = "IdentityOperationFailed")
        {
            if (result.Succeeded || result.Errors == null || !result.Errors.Any())
            {
                return defaultCode;
            }

            var error = result.Errors.FirstOrDefault();
            
            var errorCode = error?.Code ?? defaultCode;

            return errorCode;
        }

        #endregion
    }
}
