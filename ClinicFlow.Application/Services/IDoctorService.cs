using ClinicFlow.Domain.DTOs.Doctor;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IDoctorService
    {
        Task<Result<int>> AddAsync(DoctorDTO dto);
        Task<Result<bool>> UpdateAsync(int id, DoctorDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<DoctorDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<DoctorDTO>>> GetAllAsync();
        Task<Result<IEnumerable<DoctorSearchDTO>>> SearchAsync(string search);
        Task<Result<PagedResult<DoctorDTO>>> GetAllAsync(DoctorFilterDTO filter);
        Task<Result<IEnumerable<DoctorSearchDTO>>> GetForSelectAsync();

    }
}
