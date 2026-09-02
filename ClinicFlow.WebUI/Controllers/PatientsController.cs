using ClinicFlow.Application.Services;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.Resources.Shared;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.WebUI.ViewModels.Patient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace ClinicFlow.WebUI.Controllers
{
    public class PatientsController : BaseController
    {

        #region ========================= Fields & Properties =========================
        private readonly IPatientService _service;
        private readonly IAllergyService _allergyService;
        private readonly IChronicConditionService _chronicConditionService;
        #endregion

        #region ========================= Constructors =========================
        public PatientsController(
            IPatientService service,
            IStringLocalizer<SharedResource> localizer,
            IAllergyService allergyService,
            IChronicConditionService chronicConditionService

            ) : base(localizer)
        {
            _service = service;
            _allergyService = allergyService;
            _chronicConditionService = chronicConditionService;
        }
        #endregion

        #region ========================= Get =========================
        public async Task<IActionResult> Index(PatientFilterDTO filter)
        {
            var getAllResult = await _service.GetAllAsync(filter);

            if (!getAllResult.IsSuccess)
            {
                Error(getAllResult.Code);
            }

            var viewModel = new PatientIndexVM
            {
                PagedResult = getAllResult.Data ?? new PagedResult<PatientDTO>(),
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
            return Json(result.Data ?? Enumerable.Empty<PatientSearchDTO>());
        }
        #endregion

        #region ========================= Create =========================
        public async Task<IActionResult> Create()
        {
            await LoadPatientFormData();

            return View(new PatientDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientDTO DTO)
        {
            if (InvalidModel())
            {
                await LoadPatientFormData();

                return View(DTO);
            }

            var addResult = await _service.AddAsync(DTO);

            if (!addResult.IsSuccess)
            {
                Error(addResult.Code);
                await LoadPatientFormData();
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

            await LoadPatientFormData();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientDTO DTO)
        {
            if (InvalidModel())
            {
                await LoadPatientFormData();
                return View(DTO);
            }

            var updateResult = await _service.UpdateAsync(DTO.Id, DTO);
            if (!updateResult.IsSuccess)
            {
                Error(updateResult.Code);
                await LoadPatientFormData();
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

        private async Task LoadPatientFormData()
        {
            var allergiesResult = await _allergyService.GetForSelectAsync();
            var chronicConditionsResult = await _chronicConditionService.GetForSelectAsync();

            var isArabic =
                CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ar";

            ViewBag.Allergies = allergiesResult.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = isArabic ? x.NameAr : x.NameEn
            });

            ViewBag.ChronicConditions = chronicConditionsResult.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = isArabic ? x.NameAr : x.NameEn
            });
        }

        #endregion

    }
}
