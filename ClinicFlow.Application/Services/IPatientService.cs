using ClinicFlow.Domain.DTOs.Patient;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IPatientService
    {
        Task<Result<int>> AddAsync(PatientDTO dto);
        Task<Result<bool>> UpdateAsync(int id, PatientDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<PatientDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<PatientDTO>>> GetAllAsync();
        Task<Result<IEnumerable<PatientSearchDTO>>> SearchAsync(string search);
        Task<Result<PagedResult<PatientDTO>>> GetAllAsync(PatientFilterDTO filter);
        Task<Result<IEnumerable<PatientSearchDTO>>> GetForSelectAsync();

    }
}
