using ClinicFlow.Application.Services;
using ClinicFlow.Domain.DTOs.Doctor;
using ClinicFlow.Domain.DTOs.Invoice;
using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.DTOs.Medicine;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.DTOs.PaymentMethod;
using ClinicFlow.Domain.Resources.Shared;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.WebUI.ViewModels.Invoice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace ClinicFlow.WebUI.Controllers
{
    public class InvoicesController : BaseController
    {
        #region ========================= Fields & Properties =========================
        private readonly IInvoiceService _service;
        private readonly IMedicineService _medicineService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly ILabTestService _labTestService;
        private readonly IPaymentMethodService _paymentMethodService;

        #endregion

        #region ========================= Constructors =========================
        public InvoicesController(
            IInvoiceService service,
            IStringLocalizer<SharedResource> localizer,
            IMedicineService medicineService,
            IPatientService patientService,
            IDoctorService doctorService,
            ILabTestService labTestService,
            IPaymentMethodService paymentMethodService

            ) : base(localizer)
        {
            _service = service;
            _medicineService = medicineService;
            _patientService = patientService;
            _doctorService = doctorService;
            _labTestService = labTestService;
            _paymentMethodService = paymentMethodService;
        }
        #endregion

        #region ========================= Get =========================
        public async Task<IActionResult> Index(InvoiceFilterDTO filter)
        {
            var getAllResult = await _service.GetAllAsync(filter);

            if (!getAllResult.IsSuccess)
            {
                Error(getAllResult.Code);
            }

            var viewModel = new InvoiceIndexVM
            {
                PagedResult = getAllResult.Data ?? new PagedResult<InvoiceDTO>(),
                Filter = filter,
            };

            await LoadInvoiceFilterData();

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
            await LoadInvoiceFormData();

            return View(new InvoiceDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceDTO DTO)
        {
            if (InvalidModel())
            {
                await LoadInvoiceFormData();

                return View(DTO);
            }

            var addResult = await _service.AddAsync(DTO);

            if (!addResult.IsSuccess)
            {
                Error(addResult.Code);
                await LoadInvoiceFormData();
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

            await LoadInvoiceFormData();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InvoiceDTO DTO)
        {
            if (InvalidModel())
            {
                await LoadInvoiceFormData();
                return View(DTO);
            }

            var updateResult = await _service.UpdateAsync(DTO.Id, DTO);
            if (!updateResult.IsSuccess)
            {
                Error(updateResult.Code);
                await LoadInvoiceFormData();
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

        private async Task LoadInvoiceFilterData()
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

        private async Task LoadInvoiceFormData()
        {
            var labTestsResult = await _labTestService.GetForSelectAsync();
            var patientsResult = await _patientService.GetForSelectAsync();
            var medicinesResult = await _medicineService.GetForSelectAsync();
            var doctorsResult = await _doctorService.GetForSelectAsync();
            var paymentMethodsResult = await _paymentMethodService.GetForSelectAsync();

            var isArabic =
                CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ar";

            var labTests = labTestsResult.Data
                ?? Enumerable.Empty<LabTestSearchDTO>();

            var patients = patientsResult.Data
                ?? Enumerable.Empty<PatientSearchDTO>();

            var medicines = medicinesResult.Data
                ?? Enumerable.Empty<MedicineSearchDTO>();

            var doctors = doctorsResult.Data
                ?? Enumerable.Empty<DoctorSearchDTO>();

            var paymentMethods = paymentMethodsResult.Data
                ?? Enumerable.Empty<PaymentMethodSearchDTO>();


            ViewBag.Doctors = doctors.Select(x => new
            {
                Id = x.Id,
                Name = x.FullName,
                UnitPrice = x.ConsultationFee
            });

            ViewBag.Medicines = medicines.Select(x => new
            {
                Id = x.Id,
                Name = isArabic ? x.NameAr : x.NameEn,
                UnitPrice = x.Price
            });

            ViewBag.LabTests = labTests.Select(x => new
            {
                Id = x.Id,
                Name = isArabic ? x.NameAr : x.NameEn,
                UnitPrice = x.Price
            });


            //ViewBag.LabTests = labTests.Select(x => new SelectListItem
            //{
            //    Value = x.Id.ToString(),
            //    Text = isArabic ? x.NameAr : x.NameEn
            //});

            ViewBag.Patients = patients.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FullName
            });

            ViewBag.PaymentMethods = paymentMethods.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = isArabic ? x.NameAr : x.NameEn
            });

            //ViewBag.Medicines = medicines.Select(x => new SelectListItem
            //{
            //    Value = x.Id.ToString(),
            //    Text = isArabic ? x.NameAr : x.NameEn
            //});

            //ViewBag.Doctors = doctors.Select(x => new SelectListItem
            //{
            //    Value = x.Id.ToString(),
            //    Text = x.FullName
            //});

        }

        #endregion
    }
}
