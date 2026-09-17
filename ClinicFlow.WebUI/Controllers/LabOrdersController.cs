using ClinicFlow.Application.Services;
using ClinicFlow.Domain.DTOs.LabOrder;
using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.Resources.Shared;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.WebUI.ViewModels.LabOrder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace ClinicFlow.WebUI.Controllers
{
    public class LabOrdersController : BaseController
    {

        #region ========================= Fields & Properties =========================
        private readonly ILabOrderService _service;
        private readonly ILabTestService _labTestService;
        private readonly IPatientService _patientService;

        #endregion

        #region ========================= Constructors =========================
        public LabOrdersController(
            ILabOrderService service,
            IStringLocalizer<SharedResource> localizer,
            ILabTestService labTestService,
            IPatientService patientService

            ) : base(localizer)
        {
            _service = service;
            _labTestService = labTestService;
            _patientService = patientService;
        }
        #endregion

        #region ========================= Get =========================
        public async Task<IActionResult> Index(LabOrderFilterDTO filter)
        {
            var getAllResult = await _service.GetAllAsync(filter);

            if (!getAllResult.IsSuccess)
            {
                Error(getAllResult.Code);
            }

            var viewModel = new LabOrderIndexVM
            {
                PagedResult = getAllResult.Data ?? new PagedResult<LabOrderDTO>(),
                Filter = filter,
            };

            await LoadLabOrderFilterData();

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

        #endregion

        #region ========================= Create =========================
        public async Task<IActionResult> Create()
        {
            await LoadLabOrderFormData();

            return View(new LabOrderDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LabOrderDTO DTO)
        {
            if (InvalidModel())
            {
                await LoadLabOrderFormData();

                return View(DTO);
            }

            var addResult = await _service.AddAsync(DTO);

            if (!addResult.IsSuccess)
            {
                Error(addResult.Code);
                await LoadLabOrderFormData();
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

            await LoadLabOrderFormData();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LabOrderDTO DTO)
        {
            if (InvalidModel())
            {
                await LoadLabOrderFormData();
                return View(DTO);
            }

            var updateResult = await _service.UpdateAsync(DTO.Id, DTO);
            if (!updateResult.IsSuccess)
            {
                Error(updateResult.Code);
                await LoadLabOrderFormData();
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

        private async Task LoadLabOrderFilterData()
        {
            var patientsResult = await _patientService.GetForSelectAsync();

            var patients = patientsResult.Data
                ?? Enumerable.Empty<PatientSearchDTO>();

            ViewBag.Patients = patients.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FullName
            });
        }

        private async Task LoadLabOrderFormData()
        {
            var labTestsResult = await _labTestService.GetForSelectAsync();
            var patientsResult = await _patientService.GetForSelectAsync();

            var isArabic =
                CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ar";

            var labTests = labTestsResult.Data
                ?? Enumerable.Empty<LabTestSearchDTO>();

            var patients = patientsResult.Data
                ?? Enumerable.Empty<PatientSearchDTO>();

            ViewBag.LabTests = labTests.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = isArabic ? x.NameAr : x.NameEn
            });

            ViewBag.Patients = patients.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FullName
            });

        }

        #endregion

    }
}
