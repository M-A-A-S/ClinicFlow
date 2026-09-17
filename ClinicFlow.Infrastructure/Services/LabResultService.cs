using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.LabOrder;
using ClinicFlow.Domain.DTOs.LabOrderItem;
using ClinicFlow.Domain.DTOs.LabResult;
using ClinicFlow.Domain.DTOs.LabResultValue;
using ClinicFlow.Domain.DTOs.LabTest;
using ClinicFlow.Domain.DTOs.LabTestParameter;
using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.Entities;
using ClinicFlow.Domain.Enums;
using ClinicFlow.Domain.Extensions;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.Infrastructure.Data;
using ClinicFlow.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure.Services
{
    public class LabResultService : ILabResultService
    {
        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<LabResultService> _logger;

        #endregion

        #region ========================= Constructors =========================
        public LabResultService(
            IAppDbContext appDbContext,
            ILogger<LabResultService> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        #endregion

        #region ========================= Add =========================
        public async Task<Result<int>> AddAsync(LabResultDTO DTO)
        {
            try
            {
                var existingResult = await _appDbContext.LabResults
                    .FirstOrDefaultAsync(x => x.LabOrderItemId == DTO.LabOrderItemId);

                if (existingResult != null)
                {
                    var updateResult = await UpdateAsync(existingResult.Id, DTO);

                    if (!updateResult.IsSuccess)
                    {
                        return Result<int>.Failure(updateResult.Code, updateResult.StatusCode);
                    }

                    return Result<int>.Success(existingResult.Id, ResultCodes.UpdatedSuccessfully);
                }

                var validationResult = await ValidateLabResultDTO(DTO);

                if (!validationResult.IsSuccess)
                {
                    return Result<int>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var entity = DTO.ToEntity();

                _appDbContext.LabResults.Add(entity);

                // Update associated order item status
                var orderItem = await _appDbContext.LabOrderItems
                    .FirstOrDefaultAsync(x => x.Id == DTO.LabOrderItemId);

                if (orderItem != null)
                {
                    orderItem.Status = LabStatus.Completed;
                    orderItem.UpdatedAt = DateTime.Now;
                }

                await _appDbContext.SaveChangesAsync();
                return Result<int>.Success(entity.Id, ResultCodes.CreatedSuccessfully);

            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(LabResultService),
                   nameof(AddAsync));

                return Result<int>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");

            }
        }
        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<LabResultDTO>>> GetAllAsync()
        {
            try
            {
                var items = await _appDbContext.LabResults
                    .AsNoTracking()
                    .Select(LabResultExtensions.ToDTOExpression)
                    .ToListAsync();

                return Result<IEnumerable<LabResultDTO>>.Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(LabResultService),
                   nameof(GetAllAsync));

                return Result<IEnumerable<LabResultDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<PagedResult<LabResultDTO>>> GetAllAsync(LabResultFilterDTO filter)
        {
            try
            {
                var validationResult = ValidateFilter(filter);

                if (!validationResult.IsSuccess)
                {
                    return Result<PagedResult<LabResultDTO>>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode,
                        validationResult.Message);
                }

                var query = _appDbContext.LabResults.AsNoTracking();

                query = ApplyFilters(query, filter);

                query = ApplySorting(query, filter);

                var pagedResult = await ProjectToDTO(query)
                    .ToPagedListAsync(filter.PageNumber, filter.PageSize);

                return Result<PagedResult<LabResultDTO>>.Success(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(LabResultService),
                   nameof(GetAllAsync));

                return Result<PagedResult<LabResultDTO>>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<LabResultDTO>> GetByIdAsync(int id)
        {
            try
            {
                var item = await _appDbContext.LabResults
                    .AsNoTracking()
                    .Include(x => x.OrderItem)
                        .ThenInclude(x => x.LabTest)
                            .ThenInclude(x => x.Parameters)
                    .Include(x => x.Values)
                        .ThenInclude(x => x.Parameter)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<LabResultDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }
                return Result<LabResultDTO>.Success(item.ToDTO());
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(LabResultService),
                   nameof(GetByIdAsync));

                return Result<LabResultDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        public async Task<Result<LabResultDTO>> GetByOrderItemIdAsync(int orderItemId)
        {
            try
            {
                var labResult = await _appDbContext.LabResults
                    .AsNoTracking()
                    .Include(x => x.OrderItem)
                        .ThenInclude(x => x.LabTest)
                    .Include(x => x.OrderItem)
                        .ThenInclude(x => x.LabOrder)
                            .ThenInclude(x => x.Patient)
                    .Include(x => x.Values)
                        .ThenInclude(x => x.Parameter)
                    .FirstOrDefaultAsync(x => x.LabOrderItemId == orderItemId);

                if (labResult != null)
                {
                    return Result<LabResultDTO>.Success(labResult.ToDTO());
                }

                var orderItem = await _appDbContext.LabOrderItems
                    .AsNoTracking()
                    .Include(x => x.LabTest)
                        .ThenInclude(x => x.Parameters)
                    .Include(x => x.LabOrder)
                        .ThenInclude(x => x.Patient)
                    .FirstOrDefaultAsync(x => x.Id == orderItemId);

                if (orderItem == null || orderItem.LabTest == null)
                {
                    return Result<LabResultDTO>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound,
                        "Lab order item or associated lab test was not found");
                }

                var parameters = orderItem.LabTest.Parameters ?? Enumerable.Empty<LabTestParameter>();

                var newDTO = new LabResultDTO
                {
                    LabOrderItemId = orderItem.Id,
                    ResultDate = DateTime.Now,

                    OrderItem = new LabOrderItemDTO
                    {
                        Id = orderItem.Id,

                        LabTest = new LabTestDTO
                        {
                            Id = orderItem.LabTest.Id,
                            NameEn  = orderItem.LabTest.NameEn,
                            NameAr = orderItem.LabTest.NameAr,
                        },

                        LabOrder = orderItem.LabOrder == null ? null : new LabOrderDTO
                        {
                            Id = orderItem.LabOrder.Id,
                            OrderDate = orderItem.LabOrder.OrderDate,

                            Patient = orderItem.LabOrder.Patient == null ? null : new PatientDTO
                            {
                                Id = orderItem.LabOrder.Patient.Id,
                                FullName = orderItem.LabOrder.Patient.FullName,
                                PhoneNumber = orderItem.LabOrder.Patient.PhoneNumber,
                            }
                        }
                    },

                    Values = parameters.Select(x => new LabResultValueDTO
                    {
                        ParameterId = x.Id,
                        Unit = x.Unit,
                        NormalRange = x.NormalRange,
                        Value = string.Empty,

                        Parameter = new LabTestParameterDTO
                        {
                            Id = x.Id,
                            NameEn = x.NameEn,
                            NameAr = x.NameAr
                        }
                    }).ToList()
                };


                return Result<LabResultDTO>.Success(newDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                   ex,
                   "Error in Type : {Type}, Method: {Method},",
                   nameof(LabResultService),
                   nameof(GetByOrderItemIdAsync));

                return Result<LabResultDTO>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }
        }


        #endregion

        #region ========================= Update =========================
        public async Task<Result<bool>> UpdateAsync(int id, LabResultDTO DTO)
        {
            try
            {
                var validationResult = await ValidateLabResultDTO(DTO, id);

                if (!validationResult.IsSuccess)
                {
                    return Result<bool>.Failure(
                        validationResult.Code,
                        validationResult.StatusCode);
                }

                var item = await _appDbContext.LabResults
                    .Include(x => x.Values)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.NotFound,
                        HttpStatusCodes.NotFound);
                }

                item.UpdateEntity(DTO);

                UpdateLabResultValues(item, DTO);

                await _appDbContext.SaveChangesAsync();
                return Result<bool>.Success(true,
                    ResultCodes.UpdatedSuccessfully);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error in Type : {Type}, Method: {Method},",
                    nameof(LabResultService),
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
                var item = await _appDbContext.LabResults
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
                    nameof(LabResultService),
                    nameof(DeleteAsync));

                return Result<bool>.Failure(
                    ResultCodes.UnexpectedError,
                    HttpStatusCodes.InternalServerError,
                    "An unexpected error occurred.");
            }

        }
        #endregion

        #region ========================= Helpers =========================


        private void UpdateLabResultValues(LabResult entity, LabResultDTO dto)
        {
            entity.Values ??= new List<LabResultValue>();

            var incomingValues = dto.Values
                ?? new List<LabResultValueDTO>();

            /// IDs of existing items submitted from the form
            var incomingIds = incomingValues
                .Where(x => x.Id > 0)
                .Select(x => x.Id)
                .ToHashSet();

            // Remove existing items that were deleted from the form
            var valuesToRemove = entity.Values
                .Where(x => !incomingIds.Contains(x.Id))
                .ToList();

            if (valuesToRemove.Count > 0)
            {
                _appDbContext.LabResultValues.RemoveRange(valuesToRemove);
            }

            // Add / Update items
            foreach (var dtoValue in incomingValues)
            {
                // Existing item
                if (dtoValue.Id > 0)
                {
                    var entityValue = entity.Values
                        .FirstOrDefault(x => x.Id == dtoValue.Id);

                    if (entityValue != null)
                    {
                        UpdateLabResultValue(entityValue, dtoValue);
                    }
                }
                // New item
                else
                {
                    var entityValue = new LabResultValue();
                    UpdateLabResultValue(entityValue, dtoValue);
                    entity.Values.Add(entityValue);

                }
            }

        }

        private static void UpdateLabResultValue(
            LabResultValue entity,
            LabResultValueDTO dto)
        {
            entity.ParameterId = dto.ParameterId;
            entity.Value = dto.Value;
            entity.NumericValue = dto.NumericValue;
            entity.Unit = dto.Unit;
            entity.NormalRange = dto.NormalRange;
            entity.Flag = dto.Flag;
        }

        private async Task<Result<bool>> ValidateLabResultDTO(
            LabResultDTO dto, int? excludedId = null)
        {
            // ========================== Required DTO ==========================
            if (dto == null)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidData,
                    HttpStatusCodes.BadRequest);
            }

            // ========================== LabOrderItem ==========================
            if (dto.LabOrderItemId <= 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.OrderItemRequired,
                    HttpStatusCodes.BadRequest);
            }

            // ========================== Uniqueness Check ==========================
            var existingResult = await _appDbContext.LabResults
                .AsNoTracking()
                .AnyAsync(x => x.LabOrderItemId == dto.LabOrderItemId &&
                    (!excludedId.HasValue || x.Id != excludedId.Value));

            if (existingResult)
            {
                return Result<bool>.Failure(
                    ResultCodes.DuplicateResultExists,
                    HttpStatusCodes.BadRequest);
            }


            // ========================== Values ==========================
            var values = dto.Values ?? new List<LabResultValueDTO>();

            if (values.Count == 0)
            {
                return Result<bool>.Failure(
                    ResultCodes.ValuesRequired,
                    HttpStatusCodes.BadRequest);
            }
            // ========================== Duplicate Items ==========================
            var hasDuplicateParameters = values
                .Where(x => x != null && x.ParameterId > 0)
                .GroupBy(x => x.ParameterId)
                .Any(g => g.Count() > 1);

            if (hasDuplicateParameters)
            {
                return Result<bool>.Failure(
                    ResultCodes.DuplicateParameters,
                    HttpStatusCodes.BadRequest);
            }

            // ========================== Item Validation ==========================
            foreach (var value in values)
            {
                if (value == null)
                {
                    return Result<bool>.Failure(
                        ResultCodes.InvalidParameter,
                        HttpStatusCodes.BadRequest);
                }

                if (value.ParameterId <= 0)
                {
                    return Result<bool>.Failure(
                        ResultCodes.ParameterRequired,
                        HttpStatusCodes.BadRequest);
                }


            }

            return Result<bool>.Success(true);

        }

        private Result<bool> ValidateFilter(LabResultFilterDTO filter)
        {
            // ========================== Date Range ==========================
            if (filter.FromDate.HasValue &&
                filter.ToDate.HasValue &&
                filter.FromDate.Value > filter.ToDate.Value)
            {
                return Result<bool>.Failure(
                    ResultCodes.InvalidDateRange,
                    HttpStatusCodes.BadRequest);
            }

            return Result<bool>.Success(true);
        }

        private IQueryable<LabResult> ApplyFilters(
            IQueryable<LabResult> query,
            LabResultFilterDTO filter)
        {
            // ========================== Search ==========================
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var search = filter.Search.Trim();

                query = query.Where(x =>
                    (x.OrderItem.LabOrder.Visit != null && x.OrderItem.LabOrder.Visit.VisitNumber.Contains(search)) ||
                    (x.OrderItem.LabOrder.Patient != null && (
                        (x.OrderItem.LabOrder.Patient.FullName != null && x.OrderItem.LabOrder.Patient.FullName.Contains(search)) ||
                        (x.OrderItem.LabOrder.Patient.PhoneNumber != null && x.OrderItem.LabOrder.Patient.PhoneNumber.Contains(search))
                    )));
            }

            // ========================== Patient ==========================
            if (filter.PatientId.HasValue)
            {
                query = query.Where(x =>
                    x.OrderItem.LabOrder.PatientId == filter.PatientId.Value);
            }

            // ========================== Order Date ==========================
            if (filter.FromDate.HasValue)
            {
                var fromDate = filter.FromDate.Value.Date;

                query = query.Where(x =>
                    x.ResultDate >= fromDate);
            }

            if (filter.ToDate.HasValue)
            {
                var toDateExclusive =
                    filter.ToDate.Value.Date.AddDays(1);

                query = query.Where(x =>
                    x.ResultDate < toDateExclusive);
            }

            return query;
        }

        private IQueryable<LabResult> ApplySorting(
            IQueryable<LabResult> query,
            LabResultFilterDTO filter)
        {
            bool desc = filter.Descending;

            var currentLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            var isArabic = currentLanguage.Equals("ar", StringComparison.OrdinalIgnoreCase);

            return filter.SortBy switch
            {


                "PatientId" => desc
                        ? query.OrderByDescending(x =>
                            x.OrderItem.LabOrder.Patient != null
                                ? x.OrderItem.LabOrder.Patient.FullName
                                : null)
                        : query.OrderBy(x =>
                            x.OrderItem.LabOrder.Patient != null
                                ? x.OrderItem.LabOrder.Patient.FullName
                                : null),

                _ => query.OrderByProperty(filter.SortBy, desc)
            };

        }

        private IQueryable<LabResultDTO> ProjectToDTO(
            IQueryable<LabResult> query)
        {
            return query.Select(LabResultExtensions.ToDTOExpression);
        }

        #endregion

    }
}
