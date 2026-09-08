using ClinicFlow.Application.Services;
using ClinicFlow.Domain.DTOs.WaitingQueue;
using ClinicFlow.Domain.Resources.Shared;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.WebUI.ViewModels.WaitingQueue;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace ClinicFlow.WebUI.Controllers
{
    public class WaitingQueuesController : BaseController
    {

        #region ========================= Fields & Properties =========================
        private readonly IWaitingQueueService _service;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IClinicService _clinicService;
        private readonly IClinicDoctorService _clinicDoctorService;

        #endregion

        #region ========================= Constructors =========================
        public WaitingQueuesController(
            IWaitingQueueService service,
            IStringLocalizer<SharedResource> localizer,
            IPatientService patientService,
            IDoctorService doctorService,
            IClinicService clinicService,
            IClinicDoctorService clinicDoctorService

            ) : base(localizer)
        {
            _service = service;
            _patientService = patientService;
            _doctorService = doctorService;
            _clinicService = clinicService;
            _clinicDoctorService = clinicDoctorService;
        }
        #endregion

        #region ========================= Get =========================
        public async Task<IActionResult> Index(WaitingQueueFilterDTO filter)
        {
            var getAllResult = await _service.GetAllAsync(filter);

            if (!getAllResult.IsSuccess)
            {
                Error(getAllResult.Code);
            }

            var viewModel = new WaitingQueueIndexVM
            {
                PagedResult = getAllResult.Data ?? new PagedResult<WaitingQueueDTO>(),
                Filter = filter,
            };

            await LoadWaitingQueueFormData();

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
            await LoadWaitingQueueFormData();

            return View(new WaitingQueueDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WaitingQueueDTO DTO)
        {
            if (InvalidModel())
            {
                await LoadWaitingQueueFormData();

                return View(DTO);
            }

            var addResult = await _service.AddAsync(DTO);

            if (!addResult.IsSuccess)
            {
                Error(addResult.Code);
                await LoadWaitingQueueFormData();
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

            await LoadWaitingQueueFormData();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WaitingQueueDTO DTO)
        {
            if (InvalidModel())
            {
                await LoadWaitingQueueFormData();
                return View(DTO);
            }

            var updateResult = await _service.UpdateAsync(DTO.Id, DTO);
            if (!updateResult.IsSuccess)
            {
                Error(updateResult.Code);
                await LoadWaitingQueueFormData();
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

        private async Task LoadWaitingQueueFormData()
        {
            var patientsResult = await _patientService.GetForSelectAsync();
            var doctorsResult = await _doctorService.GetForSelectAsync();
            var clinicsResult = await _clinicService.GetForSelectAsync();
            var clinicDoctorsResult = await _clinicDoctorService.GetForSelectAsync();

            var isArabic =
                CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ar";

            ViewBag.Patients = patientsResult.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FullName + " - " + x.PhoneNumber
            });

            ViewBag.Doctors = doctorsResult.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FullName + " - " + x.PhoneNumber
            });

            ViewBag.Clinics = clinicsResult.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = isArabic ? x.NameAr : x.NameEn
            });

            ViewBag.ClinicDoctors = clinicDoctorsResult.Data;

        }

        #endregion


    }
}
