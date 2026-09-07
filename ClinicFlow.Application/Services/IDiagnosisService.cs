using ClinicFlow.Domain.DTOs.Diagnosis;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IDiagnosisService
    {
        Task<Result<int>> AddAsync(DiagnosisDTO dto);
        Task<Result<bool>> UpdateAsync(int id, DiagnosisDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<DiagnosisDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<DiagnosisDTO>>> GetAllAsync();
        Task<Result<IEnumerable<DiagnosisSearchDTO>>> SearchAsync(string search);
        Task<Result<PagedResult<DiagnosisDTO>>> GetAllAsync(DiagnosisFilterDTO filter);
        Task<Result<IEnumerable<DiagnosisSearchDTO>>> GetForSelectAsync();

    }
}
