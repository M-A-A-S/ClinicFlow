using ClinicFlow.Application.Services;
using ClinicFlow.Domain.DTOs.LabResult;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.Resources.Shared;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.Infrastructure.Services;
using ClinicFlow.WebUI.ViewModels.LabResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace ClinicFlow.WebUI.Controllers
{
    public class LabResultsController : BaseController
    {

        #region ========================= Fields & Properties =========================
        private readonly ILabResultService _service;
        private readonly IPatientService _patientService;

        #endregion

        #region ========================= Constructors =========================
        public LabResultsController(
            ILabResultService service,
            IStringLocalizer<SharedResource> localizer,
            IPatientService patientService

            ) : base(localizer)
        {
            _service = service;
            _patientService = patientService;
        }
        #endregion

        #region ========================= Get =========================
        public async Task<IActionResult> Index(LabResultFilterDTO filter)
        {
            var getAllResult = await _service.GetAllAsync(filter);

            if (!getAllResult.IsSuccess)
            {
                Error(getAllResult.Code);
            }

            var viewModel = new LabResultIndexVM
            {
                PagedResult = getAllResult.Data ?? new PagedResult<LabResultDTO>(),
                Filter = filter,
            };

            await LoadLabResultFilterData();

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
        public async Task<IActionResult> Create([FromQuery]int labOrderItemId)
        {
            var result = await _service.GetByOrderItemIdAsync(labOrderItemId);

            if (!result.IsSuccess || result.Data == null)
            {
                return NotFound();
            }

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LabResultDTO DTO)
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
        public async Task<IActionResult> Edit([FromQuery] int labOrderItemId)
        {
            var result = await _service.GetByOrderItemIdAsync(labOrderItemId);

            if (!result.IsSuccess || result.Data == null)
            {
                return NotFound();
            }

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LabResultDTO DTO)
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

        private async Task LoadLabResultFilterData()
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
        #endregion

    }
}
