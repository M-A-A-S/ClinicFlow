using ClinicFlow.Application.Services;
using ClinicFlow.Domain.DTOs.Bond;
using ClinicFlow.Domain.DTOs.Identity.Role;
using ClinicFlow.Domain.Resources.Shared;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.WebUI.ViewModels.Bond;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ClinicFlow.WebUI.Controllers
{
    //[Authorize(Roles = "Admin,SuperAdmin")]
    public class RolesController : BaseController
    {

        #region ========================= Fields & Properties =========================
        private readonly IRoleService _service;
        #endregion

        #region ========================= Constructors =========================
        public RolesController(
            IRoleService service,
            IStringLocalizer<SharedResource> localizer) : base(localizer)
        {
            _service = service;
        }
        #endregion

        #region ========================= Get =========================
        public async Task<IActionResult> Index()
        {
            var getAllResult = await _service.GetAllAsync();

            if (!getAllResult.IsSuccess)
            {
                Error(getAllResult.Code);
            }

            return View(getAllResult.Data);
        }

        public async Task<IActionResult> Details(string id)
        {

            var item = await GetEntityOrNull(_service.GetByIdAsync(id));

            if (item is null)
            {
                return NotFound();
            }

            return View(item);
        }
        #endregion

        #region ========================= Create =========================
        public async Task<IActionResult> Create()
        {

            return View(new RoleDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleDTO DTO)
        {
            if (InvalidModel())
            {

                return View(DTO);
            }

            var addResult = await _service.AddAsync(DTO);

            if (!addResult.IsSuccess)
            {
                Error(addResult.Code);
                return View(DTO);
            }

            Success(addResult.Code);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region ========================= Update =========================
        public async Task<IActionResult> Edit(string id)
        {
            var item = await GetEntityOrNull(_service.GetByIdAsync(id));

            if (item is null)
            {
                return NotFound();
            }


            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoleDTO DTO)
        {
            if (InvalidModel())
            {

                return View(DTO);
            }

            var updateResult = await _service.UpdateAsync(DTO.Id, DTO);
            if (!updateResult.IsSuccess)
            {
                Error(updateResult.Code);
                return View(DTO);
            }

            Success(updateResult.Code);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region ========================= Delete =========================
        public async Task<IActionResult> Delete(string id)
        {
            var item = await GetEntityOrNull(_service.GetByIdAsync(id));

            if (item is null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            var deleteResult = await _service.DeleteAsync(id);

            if (!deleteResult.IsSuccess)
            {
                Error(deleteResult.Code);
                var item = await GetEntityOrNull(_service.GetByIdAsync(id));
                if (item is null)
                {
                    return NotFound();
                }
                return View(item);
            }

            Success(deleteResult.Code);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region ========================= Helpers =========================
        #endregion
    }
}
