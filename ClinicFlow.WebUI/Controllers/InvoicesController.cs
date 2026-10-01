using ClinicFlow.Application.Services;
using ClinicFlow.Domain.DTOs.Doctor;
using ClinicFlow.Domain.DTOs.Invoice;
using ClinicFlow.Domain.DTOs.InvoiceItem;
using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.DTOs.Medicine;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.DTOs.PaymentMethod;
using ClinicFlow.Domain.Entities;
using ClinicFlow.Domain.Enums;
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
        private readonly IWaitingQueueService _waitingQueueService;
        private readonly IAppointmentService _appointmentService;
        private readonly IVisitService _visitService;
        private readonly ILabOrderService _labOrderService;

        #endregion

        #region ========================= Constructors =========================
        public InvoicesController(
            IInvoiceService service,
            IStringLocalizer<SharedResource> localizer,
            IMedicineService medicineService,
            IPatientService patientService,
            IDoctorService doctorService,
            ILabTestService labTestService,
            IPaymentMethodService paymentMethodService,
            IWaitingQueueService waitingQueueService,
            IAppointmentService appointmentService,
            IVisitService visitService,
            ILabOrderService labOrderService

            ) : base(localizer)
        {
            _service = service;
            _medicineService = medicineService;
            _patientService = patientService;
            _doctorService = doctorService;
            _labTestService = labTestService;
            _paymentMethodService = paymentMethodService;
            _waitingQueueService = waitingQueueService;
            _appointmentService = appointmentService;
            _visitService = visitService;
            _labOrderService = labOrderService;
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
        public async Task<IActionResult> Create(
            int? waitingQueueId,
            int? labOrderId,
            int? appointmentId,
            int? visitId)
        {
            await LoadInvoiceFormData();


            InvoiceDTO? invoice;


            if (waitingQueueId.HasValue)
            {
                invoice = await BuildFromWaitingQueueAsync(waitingQueueId.Value);
            }
            else if (labOrderId.HasValue)
            {
                invoice = await BuildFromLabOrderAsync(labOrderId.Value);
            }
            else if (appointmentId.HasValue)
            {
                invoice = await BuildFromAppointmentAsync(appointmentId.Value);
            }
            else if (visitId.HasValue)
            {
                invoice = await BuildFromVisitAsync(visitId.Value);
            }
            else
            {
                invoice = new InvoiceDTO();
            }

            if (invoice is null)
            {
                return NotFound();
            }

            return View(invoice);

            //await LoadInvoiceFormData();

            //return View(new InvoiceDTO());
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

        private async Task<InvoiceDTO?> BuildFromAppointmentAsync(int id)
        {
            var result = await _appointmentService.GetByIdAsync(id);

            if (!result.IsSuccess || result.Data == null)
            {
                return null;
            }

            var appointment = result.Data;

            if (appointment.InvoiceId.HasValue)
            {
                return null;
            }

            var fee = appointment.Doctor.ConsultationFee;

            var invoice = new InvoiceDTO
            {
                PatientId = appointment.PatientId,
                Patient = appointment.Patient,
                InvoiceDate = DateTime.Now,
                AppointmentId = appointment.Id,
            };

            invoice.Items.Add(new InvoiceItemDTO
            {
                ItemType = InvoiceItemType.Visit,
                ReferenceId = appointment.Doctor.Id,
                ReferenceName = appointment.Doctor.FullName,
                Description = $"Consultation with Dr. {appointment.Doctor.FullName}",
                UnitPrice = fee,
                Quantity = 1,
                Total = fee
            });

            return invoice;
        }

        private async Task<InvoiceDTO?> BuildFromWaitingQueueAsync(int id)
        {
            var result = await _waitingQueueService.GetByIdAsync(id);

            if (!result.IsSuccess || result.Data == null)
            {
                return null;
            }

            var queue = result.Data;

            if (queue.InvoiceId.HasValue)
            {
                return null;
            }

            var fee = queue.Doctor.ConsultationFee;

            var invoice = new InvoiceDTO
            {
                PatientId = queue.PatientId,
                Patient = queue.Patient,
                InvoiceDate = DateTime.Now,
                WaitingQueueId = queue.Id,
            };

            invoice.Items.Add(new InvoiceItemDTO
            {
                ItemType = InvoiceItemType.Visit,
                ReferenceId = queue.Doctor.Id,
                ReferenceName = queue.Doctor.FullName,
                Description = $"Consultation with Dr. {queue.Doctor.FullName}",
                UnitPrice = fee,
                Quantity = 1,
                Total = fee
            });

            return invoice;

        }
 
        private async Task<InvoiceDTO?> BuildFromVisitAsync(int id)
        {
            var result = await _visitService.GetByIdAsync(id);

            if (!result.IsSuccess || result.Data == null)
            {
                return null;
            }

            var visit = result.Data;

            if (visit.InvoiceId.HasValue)
            {
                return null;
            }

            var fee = visit.Doctor.ConsultationFee;

            var invoice = new InvoiceDTO
            {
                PatientId = visit.PatientId,
                Patient = visit.Patient,
                InvoiceDate = DateTime.Now,
                VisitId = visit.Id,
            };

            invoice.Items.Add(new InvoiceItemDTO
            {
                ItemType = InvoiceItemType.Visit,
                ReferenceId = visit.Doctor.Id,
                ReferenceName = visit.Doctor.FullName,
                Description = $"Consultation with Dr. {visit.Doctor.FullName}",
                UnitPrice = fee,
                Quantity = 1,
                Total = fee
            });

            return invoice;
        }

        private async Task<InvoiceDTO?> BuildFromLabOrderAsync(int id)
        {
            var result = await _labOrderService.GetByIdAsync(id);

            if (!result.IsSuccess || result.Data == null)
            {
                return null;
            }

            var labOrder = result.Data;

            if (labOrder.InvoiceId.HasValue)
            {
                return null;
            }

            bool isArabic = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ar";

            var invoice = new InvoiceDTO
            {
                PatientId = labOrder.PatientId,
                Patient = labOrder.Patient,
                InvoiceDate = DateTime.Now,
                LabOrderId = labOrder.Id,
            };

            foreach (var item in labOrder.Items)
            {
                var test = item.LabTest;

                if (test == null)
                {
                    continue;
                }

                var testName = isArabic
                    ? test.NameAr
                    : test.NameEn;

                invoice.Items.Add(new InvoiceItemDTO
                {
                    ItemType = InvoiceItemType.Lab,
                    ReferenceId = item.LabTestId,
                    ReferenceName = testName,
                    Description = testName,
                    UnitPrice = test.Price,
                    Quantity = 1,
                    Total = test.Price
                });
            }

            return invoice;
        }

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
