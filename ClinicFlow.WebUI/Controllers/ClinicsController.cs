using ClinicFlow.Application.Services;
using ClinicFlow.Domain.DTOs.Clinic;
using ClinicFlow.Domain.Resources.Shared;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.WebUI.ViewModels.Clinic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace ClinicFlow.WebUI.Controllers
{
    public class ClinicsController : BaseController
    {

        #region ========================= Fields & Properties =========================
        private readonly IClinicService _service;
        private readonly IDoctorService _doctorService;

        #endregion

        #region ========================= Constructors =========================
        public ClinicsController(
            IClinicService service,
            IStringLocalizer<SharedResource> localizer,
            IDoctorService doctorService

            ) : base(localizer)
        {
            _service = service;
            _doctorService = doctorService;
        }
        #endregion

        #region ========================= Get =========================
        public async Task<IActionResult> Index(ClinicFilterDTO filter)
        {
            var getAllResult = await _service.GetAllAsync(filter);

            if (!getAllResult.IsSuccess)
            {
                Error(getAllResult.Code);
            }

            var viewModel = new ClinicIndexVM
            {
                PagedResult = getAllResult.Data ?? new PagedResult<ClinicDTO>(),
                Filter = filter,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {

            var item = await GetEntityOrNull(_service.GetByIdAsync(id));

            if (item is null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string search)
        {
            var result = await _service.SearchAsync(search);
            return Json(result.Data ?? Enumerable.Empty<ClinicSearchDTO>());
        }
        #endregion

        #region ========================= Create =========================
        public async Task<IActionResult> Create()
        {
            await LoadClinicFormData();

            return View(new ClinicDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClinicDTO DTO)
        {
            if (InvalidModel())
            {
                await LoadClinicFormData();

                return View(DTO);
            }

            var addResult = await _service.AddAsync(DTO);

            if (!addResult.IsSuccess)
            {
                Error(addResult.Code);
                await LoadClinicFormData();
                return View(DTO);
            }

            Success(addResult.Code);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region ========================= Update =========================
        public async Task<IActionResult> Edit(int id)
        {
            var item = await GetEntityOrNull(_service.GetByIdAsync(id));

            if (item is null)
            {
                return NotFound();
            }

            await LoadClinicFormData();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClinicDTO DTO)
        {
            if (InvalidModel())
            {
                await LoadClinicFormData();
                return View(DTO);
            }

            var updateResult = await _service.UpdateAsync(DTO.Id, DTO);
            if (!updateResult.IsSuccess)
            {
                Error(updateResult.Code);
                await LoadClinicFormData();
                return View(DTO);
            }

            Success(updateResult.Code);
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region ========================= Delete =========================
        public async Task<IActionResult> Delete(int id)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
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

        private async Task LoadClinicFormData()
        {
            var doctorsResult = await _doctorService.GetForSelectAsync();

            ViewBag.Doctors = doctorsResult.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FullName + " " + x.PhoneNumber
            });
        }

        #endregion

    }
}
