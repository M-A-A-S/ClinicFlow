using ClinicFlow.Application.Services;
using ClinicFlow.Domain.DTOs.Identity.ResetPassword;
using ClinicFlow.Domain.DTOs.Identity.Role;
using ClinicFlow.Domain.DTOs.Identity.User;
using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.Entities;
using ClinicFlow.Domain.Resources.Shared;
using ClinicFlow.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace ClinicFlow.WebUI.Controllers
{
    //[Authorize(Roles = "Admin,SuperAdmin")]
    public class UsersController : BaseController
    {
        #region ========================= Fields & Properties =========================
        private readonly IUserService _service;
        private readonly IRoleService _roleService;
        #endregion

        #region ========================= Constructors =========================
        public UsersController(
            IUserService service,
            IRoleService roleService,
            IStringLocalizer<SharedResource> localizer) : base(localizer)
        {
            _service = service;
            _roleService = roleService;
        }
        #endregion

        #region ========================= Get =========================
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAllAsync();
            if (!result.IsSuccess)
            {
                Error(result.Code);
                return View(Enumerable.Empty<UserDTO>());
            }
            return View(result.Data);
        }

        public async Task<IActionResult> Details(string id)
        {
            var item = await GetEntityOrNull(_service.GetByIdAsync(id));
            if (item is null) return NotFound();
            return View(item);
        }
        #endregion

        #region ========================= Create =========================
        public async Task<IActionResult> Create()
        {
            await LoadUserFormData();

            var dto = new UserDTO();
        
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDTO dto)
        {
            if (InvalidModel())
            {
                await LoadUserFormData();

                return View(dto);
            }

            var result = await _service.AddAsync(dto);
            if (!result.IsSuccess)
            {
                Error(result.Code);
                await LoadUserFormData();
                return View(dto);
            }

            Success(result.Code);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region ========================= Update =========================
        public async Task<IActionResult> Edit(string id)
        {
            var item = await GetEntityOrNull(_service.GetByIdAsync(id));
            if (item is null) return NotFound();

            await LoadUserFormData();

            item.IsEditMode = true;

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserDTO dto)
        {
            // Remove password validation in Edit mode
            ModelState.Remove("Password");
            ModelState.Remove("ConfirmPassword");

            if (InvalidModel())
            {
                await LoadUserFormData();

                return View(dto);
            }

            var result = await _service.UpdateAsync(dto.Id, dto);
            if (!result.IsSuccess)
            {
                Error(result.Code);
                return View(dto);
            }

            // Update roles separately
            if (dto.Roles != null)
            {
                await _service.UpdateRolesAsync(dto.Id, dto.Roles);
            }

            Success(result.Code);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region ========================= Delete =========================
        public async Task<IActionResult> Delete(string id)
        {
            var item = await GetEntityOrNull(_service.GetByIdAsync(id));
            if (item is null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                Error(result.Code);
                var item = await GetEntityOrNull(_service.GetByIdAsync(id));
                if (item is null) return NotFound();
                return View(item);
            }

            Success(result.Code);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region ========================= Password Reset =========================
        public async Task<IActionResult> ResetPassword(string id)
        {
            var item = await GetEntityOrNull(_service.GetByIdAsync(id));
            if (item is null) return NotFound();

            var dto = new ResetPasswordDTO
            {
                UserId = id,
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> ResetPassword(string id, string newPassword, string confirmPassword)
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO dto)
        {
            if (dto.NewPassword != dto.ConfirmPassword)
            {
                Error("PasswordMismatch");
                var item = await GetEntityOrNull(_service.GetByIdAsync(dto.UserId));
                if (item is null) return NotFound();
                return View(dto);
            }

            var result = await _service.ResetPasswordAsync(dto);
            if (!result.IsSuccess)
            {
                Error(result.Code);
                ModelState.AddModelError(nameof(dto.NewPassword), _localizer[result.Code]);
                var item = await GetEntityOrNull(_service.GetByIdAsync(dto.UserId));
                if (item is null) return NotFound();
                return View(dto);
            }

            Success(result.Code);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region ========================= Helpers =========================
        private async Task LoadUserFormData()
        {
            var rolesResult = await _roleService.GetAllAsync();

            var roles = rolesResult.Data
                ?? Enumerable.Empty<RoleDTO>();

            //ViewBag.Roles = roles.ToList();

            ViewBag.Roles = roles;

        }
        #endregion

    }
}
