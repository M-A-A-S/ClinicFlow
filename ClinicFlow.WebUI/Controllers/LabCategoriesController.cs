using ClinicFlow.Application.Services;
using ClinicFlow.Domain.DTOs.LabCategory;
using ClinicFlow.Domain.Resources.Shared;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.WebUI.ViewModels.LabCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ClinicFlow.WebUI.Controllers
{
    public class LabCategoriesController : BaseController
    {
        #region ========================= Fields & Properties =========================
        private readonly ILabCategoryService _service;
        #endregion

        #region ========================= Constructors =========================
        public LabCategoriesController(
            ILabCategoryService service,
            IStringLocalizer<SharedResource> localizer
            ) : base(localizer)
        {
            _service = service;
        }
        #endregion

        #region ========================= Get =========================
        public async Task<IActionResult> Index(LabCategoryFilterDTO filter)
        {
            var getAllResult = await _service.GetAllAsync(filter);

            if (!getAllResult.IsSuccess)
            {
                Error(getAllResult.Code);
            }

            var viewModel = new LabCategoryIndexVM
            {
                PagedResult = getAllResult.Data ?? new PagedResult<LabCategoryDTO>(),
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
            return Json(result.Data ?? Enumerable.Empty<LabCategorySearchDTO>());
        }
        #endregion

        #region ========================= Create =========================
        public async Task<IActionResult> Create()
        {
            return View(new LabCategoryDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LabCategoryDTO DTO)
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
        public async Task<IActionResult> Edit(LabCategoryDTO DTO)
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

    }
}
