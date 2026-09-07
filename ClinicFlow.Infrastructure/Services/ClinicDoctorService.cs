using ClinicFlow.Application.Services;
using ClinicFlow.Domain.Constants;
using ClinicFlow.Domain.DTOs.ClinicDoctor;
using ClinicFlow.Domain.Extensions;
using ClinicFlow.Domain.Utilities;
using ClinicFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure.Services
{
    public class ClinicDoctorService : IClinicDoctorService
    {

        #region ========================= Fields & Properties =========================
        private readonly IAppDbContext _appDbContext;
        private readonly ILogger<ClinicDoctorService> _logger;
        private readonly IMemoryCache _cache;

        #endregion

        #region ========================= Constructors =========================
        public ClinicDoctorService(
            IAppDbContext appDbContext,
            ILogger<ClinicDoctorService> logger,
            IMemoryCache cache)
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _cache = cache;
        }

        #endregion

        #region ========================= Get =========================
        public async Task<Result<IEnumerable<ClinicDoctorSearchDTO>>> GetForSelectAsync()
        {
            try
            {
                if (_cache.TryGetValue(
                    CacheKeys.ClinicDoctorSelect,
                    out IEnumerable<ClinicDoctorSearchDTO>? items))
                {
                    return Result<IEnumerable<ClinicDoctorSearchDTO>>
                        .Success(items);
                }


                items = await _appDbContext.ClinicDoctors
                    .AsNoTracking()
                    .OrderBy(x => x.DoctorId)
                    .Select(x => new ClinicDoctorSearchDTO
                    {
                        Id = x.Id,
                        DoctorId = x.DoctorId,
                        ClinicId = x.ClinicId,
                    })
                    .ToListAsync();


                _cache.Set(
                    CacheKeys.ClinicDoctorSelect,
                    items,
                    new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(30),
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(2)
                    });


                return Result<IEnumerable<ClinicDoctorSearchDTO>>
                    .Success(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error loading items for select");

                return Result<IEnumerable<ClinicDoctorSearchDTO>>
                    .Failure(
                        ResultCodes.UnexpectedError,
                        HttpStatusCodes.InternalServerError,
                        "An unexpected error occurred.");
            }
        }

        #endregion


    }
}
