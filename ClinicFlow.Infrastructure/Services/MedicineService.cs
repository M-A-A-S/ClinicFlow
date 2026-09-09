using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.Medicine;
using ClinicFlow.Domain.Entities;
using ClinicFlow.Domain.Extensions;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.Infrastructure.Data;
using ClinicFlow.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace ClinicFlow.Infrastructure.Services
{
    public class MedicineService : IMedicineService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<MedicineService> _logger;

        #endregion

        #region ========================= Constructors =========================
        public MedicineService(
            IAppDbContext appDbContext,
            ILogger<MedicineService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(MedicineDTO DTO)
        {

            try
            {
                var validationResult = await ValidateMedicineDTO(DTO);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var entity = DTO.ToEntity();

                _appDbContext.Medicines.Add(entity);
                await _appDbContext.SaveChangesAsync();
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(MedicineService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<MedicineDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.Medicines
                    .AsNoTracking()
                    .Select(MedicineExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<MedicineDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(MedicineService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<MedicineDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<MedicineDTO>>> GetAllAsync(MedicineFilterDTO filter)
        {
            try
            {

                var query = _appDbContext.Medicines.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<MedicineDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(MedicineService),
                   nameof(GetAllAsync));

                return Result<PagedResult<MedicineDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<MedicineDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.Medicines
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<MedicineDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<MedicineDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(MedicineService),
                   nameof(GetByIdAsync));

                return Result<MedicineDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<IEnumerable<MedicineSearchDTO>>> SearchAsync(string search)
        {
            try
            {
                var query = _appDbContext.Medicines
                .AsNoTracking();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var term = search.Trim();
                    query = query.Where(x =>
                        x.NameEn.Contains(term) ||
                        x.NameAr.Contains(term));
                }

                var items = await query
                    .Take(20)
                    .Select(x => new MedicineSearchDTO
                    {
                        Id = x.Id,
                        NameEn = x.NameEn,
                        NameAr = x.NameAr,
                    })
                    .ToListAsync();

                return Result<IEnumerable<MedicineSearchDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Type: {Type}, Method: {Method}", nameof(MedicineService), nameof(SearchAsync));
                return Result<IEnumerable<MedicineSearchDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }

        public async Task<Result<IEnumerable<MedicineSearchDTO>>> GetForSelectAsync()
        {
            try
            {

                var items = await _appDbContext.Medicines
                    .AsNoTracking()
                    .OrderBy(x => x.NameEn)
                    .Select(x => new MedicineSearchDTO
                    {
                        Id = x.Id,
                        NameEn = x.NameEn,
                        NameAr = x.NameAr,
                    })
                    .ToListAsync();

                return Result<IEnumerable<MedicineSearchDTO>>
                    .Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error loading items for select");

                return Result<IEnumerable<MedicineSearchDTO>>
                    .Failure(
                        ResultCodes.UnexpectedError,
                        HttpStatusCodes.InternalServerError,
                        "An unexpected error occurred.");
            }
        }

        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, MedicineDTO DTO)
        {
            try
            {
                var validationResult = await ValidateMedicineDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.Medicines
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.UpdateEntity(DTO);

                await _appDbContext.SaveChangesAsync();
                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(MedicineService),
                    nameof(UpdateAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError, "An unexpected error occurred.");
            }
        }
        #endregion

        #region ========================= Delete =========================
        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                var item = await _appDbContext.Medicines
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.IsDeleted = true;
                item.UpdatedAt = DateTime.UtcNow;
                item.DeletedAt = DateTime.UtcNow;

                await _appDbContext.SaveChangesAsync();
                return Result<bool>.Success(true, ResultCodes.DeletedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(MedicineService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================
        private async Task<Result<bool>> ValidateMedicineDTO(MedicineDTO DTO, int? excludedId = null)
        {
            if (DTO == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }

            // ================= NameEn =================
            bool nameEnExists =
                await _appDbContext.Medicines
                .AnyAsync(x => x.NameEn.ToLower() == DTO.NameEn.ToLower() &&
                (excludedId == null || x.Id != excludedId));

            if (nameEnExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.NameEnExists,
                    HttpStatusCodes.Conflict);
            }

            // ================= NameAr =================
            bool nameArExists =
                await _appDbContext.Medicines
                .AnyAsync(x => x.NameAr == DTO.NameAr && (excludedId == null || x.Id != excludedId));

            if (nameArExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.NameArExists,
                    HttpStatusCodes.Conflict);
            }

            // ================= GenericNameEn =================
            bool genericNameEnExists =
                await _appDbContext.Medicines
                .AnyAsync(x => x.GenericNameEn.ToLower() == DTO.GenericNameEn.ToLower() &&
                (excludedId == null || x.Id != excludedId));

            if (genericNameEnExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.GenericNameEnExists,
                    HttpStatusCodes.Conflict);
            }

            // ================= GenericNameAr =================
            bool genericNameArExists =
                await _appDbContext.Medicines
                .AnyAsync(x => x.GenericNameAr.ToLower() == DTO.GenericNameAr.ToLower() &&
                (excludedId == null || x.Id != excludedId));

            if (genericNameArExists)
            {
                return Result<bool>.Failure(
                    ResultCodes.GenericNameArExists,
                    HttpStatusCodes.Conflict);
            }

            return Result<bool>.Success(true);

        }

        private IQueryable<Medicine> ApplyFilters(
            IQueryable<Medicine> query,
            MedicineFilterDTO filter)
        {
            // ========================== Search ==========================
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();
                query = query.Where(x =>
                    x.NameEn.Contains(search) ||
                    x.NameAr.Contains(search));
            }
            return query;
        }

        private IQueryable<Medicine> ApplySorting(
            IQueryable<Medicine> query,
            MedicineFilterDTO filter)
        {
            bool desc = filter.Descending;

            return query.OrderByProperty(filter.SortBy, desc);
        }

        private IQueryable<MedicineDTO> ProjectToDTO(
            IQueryable<Medicine> query)
        {
            return query.Select(MedicineExtensions.ToDTOExpression);
        }

        #endregion

    }
}
