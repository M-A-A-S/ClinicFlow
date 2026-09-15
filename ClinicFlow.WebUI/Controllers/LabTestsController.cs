using ClinicFlow.Application.Services;
using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.Resources.Shared;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.WebUI.ViewModels.LabTest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace ClinicFlow.WebUI.Controllers
{
    public class LabTestsController : BaseController
    {

        #region ========================= Fields & Properties =========================
        private readonly ILabTestService _service;
        private readonly ILabCategoryService _labCategoryService;

        #endregion

        #region ========================= Constructors =========================
        public LabTestsController(
            ILabTestService service,
            IStringLocalizer<SharedResource> localizer,
            ILabCategoryService labCategoryService

            ) : base(localizer)
        {
            _service = service;
            _labCategoryService = labCategoryService;
        }
        #endregion

        #region ========================= Get =========================
        public async Task<IActionResult> Index(LabTestFilterDTO filter)
        {
            var getAllResult = await _service.GetAllAsync(filter);

            if (!getAllResult.IsSuccess)
            {
                Error(getAllResult.Code);
            }

            var viewModel = new LabTestIndexVM
            {
                PagedResult = getAllResult.Data ?? new PagedResult<LabTestDTO>(),
                Filter = filter,
            };

            await LoadLabTestFormData();

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
            await LoadLabTestFormData();

            return View(new LabTestDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LabTestDTO DTO)
        {
            if (InvalidModel())
            {
                await LoadLabTestFormData();

                return View(DTO);
            }

            var addResult = await _service.AddAsync(DTO);

            if (!addResult.IsSuccess)
            {
                Error(addResult.Code);
                await LoadLabTestFormData();
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

            await LoadLabTestFormData();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LabTestDTO DTO)
        {
            if (InvalidModel())
            {
                await LoadLabTestFormData();
                return View(DTO);
            }

            var updateResult = await _service.UpdateAsync(DTO.Id, DTO);
            if (!updateResult.IsSuccess)
            {
                Error(updateResult.Code);
                await LoadLabTestFormData();
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

        private async Task LoadLabTestFormData()
        {
            var labCategoriesResult = await _labCategoryService.GetForSelectAsync();

            var isArabic =
                CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ar";

            ViewBag.LabCategories = labCategoriesResult.Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = isArabic ? x.NameAr : x.NameEn
            });

        }

        #endregion

    }
}
