using ClinicFlow.Application.Services;
using ClinicFlow.Domain.DTOs.Bond;
using ClinicFlow.Domain.DTOs.BondCategory;
using ClinicFlow.Domain.DTOs.Doctor;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.DTOs.PaymentMethod;
using ClinicFlow.Domain.Resources.Shared;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.WebUI.ViewModels.Bond;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace ClinicFlow.WebUI.Controllers
{
    public class BondsController : BaseController
    {
        #region ========================= Fields & Properties =========================
        private readonly IBondService _service;
        private readonly IBondCategoryService _bondCategoryService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IPaymentMethodService _paymentMethodService;
        #endregion

        #region ========================= Constructors =========================
        public BondsController(
            IBondService service,
            IStringLocalizer<SharedResource> localizer,
            IBondCategoryService bondCategoryService,
            IDoctorService doctorService,
            IPatientService patientService,
            IPaymentMethodService paymentMethodService
            ) : base(localizer)
        {
            _service = service;
            _bondCategoryService = bondCategoryService;
            _doctorService = doctorService;
            _patientService = patientService;
            _paymentMethodService = paymentMethodService;
        }
        #endregion

        #region ========================= Get =========================
        public async Task<IActionResult> Index(BondFilterDTO filter)
        {
            var getAllResult = await _service.GetAllAsync(filter);

            if (!getAllResult.IsSuccess)
            {
                Error(getAllResult.Code);
            }

            var viewModel = new BondIndexVM
            {
                PagedResult = getAllResult.Data ?? new PagedResult<BondDTO>(),
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

        #endregion

        #region ========================= Create =========================
        public async Task<IActionResult> Create()
        {
            return View(new BondDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BondDTO DTO)
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
        public async Task<IActionResult> Edit(int id)
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
        public async Task<IActionResult> Edit(BondDTO DTO)
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
        private async Task LoadBondFormData()
        {
            var paymentMethodsResult = await _paymentMethodService.GetForSelectAsync();
            var bondCategoriesResult = await _bondCategoryService.GetForSelectAsync();
            var doctorsResult = await _doctorService.GetForSelectAsync();
            var patientsResult = await _patientService.GetForSelectAsync();

            var paymentMethods = paymentMethodsResult.Data
                ?? Enumerable.Empty<PaymentMethodSearchDTO>();

            var bondCategories = bondCategoriesResult.Data
                ?? Enumerable.Empty<BondCategorySearchDTO>();

            var doctors = doctorsResult.Data
                ?? Enumerable.Empty<DoctorSearchDTO>();

            var patients = patientsResult.Data
                ?? Enumerable.Empty<PatientSearchDTO>();

            var isArabic =
                CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ar";

            ViewBag.BondCategories = bondCategories.Select(x => new
            {
                Id = x.Id,
                Name = isArabic ? x.NameAr : x.NameEn,
                Type = x.Type,
            });

            ViewBag.PaymentMethods = paymentMethods.Select(x => new 
            {
                Id = x.Id,
                Name = isArabic ? x.NameAr : x.NameEn,
                Type = x.Type,
            });

            ViewBag.Doctors = doctors.Select(x => new
            {
                Id = x.Id,
                FullName = x.FullName
            });

            ViewBag.Patients = patients.Select(x => new
            {
                Id = x.Id,
                FullName = x.FullName,
            });

        }


        private async Task LoadBondFilterData()
        {
            var paymentMethodsResult = await _paymentMethodService.GetForSelectAsync();
            var bondCategoriesResult = await _bondCategoryService.GetForSelectAsync();

            var paymentMethods = paymentMethodsResult.Data
                ?? Enumerable.Empty<PaymentMethodSearchDTO>();

            var bondCategories = bondCategoriesResult.Data
                ?? Enumerable.Empty<BondCategorySearchDTO>();

            var isArabic =
                CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ar";

            ViewBag.BondCategories = bondCategories.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = isArabic ? x.NameAr : x.NameEn,
            });

            ViewBag.PaymentMethods = paymentMethods.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = isArabic ? x.NameAr : x.NameEn,
            });

        }

        #endregion

    }
}
