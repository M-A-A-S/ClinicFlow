using ClinicFlow.Domain.DTOs.Appointment;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IAppointmentService
    {
        Task<Result<int>> AddAsync(AppointmentDTO dto);
        Task<Result<bool>> UpdateAsync(int id, AppointmentDTO dto);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<AppointmentDTO>> GetByIdAsync(int id);
        Task<Result<IEnumerable<AppointmentDTO>>> GetAllAsync();
        Task<Result<PagedResult<AppointmentDTO>>> GetAllAsync(AppointmentFilterDTO filter);

    }
}
