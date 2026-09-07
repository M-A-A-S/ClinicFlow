
using ClinicFlow.Domain.DTOs.ClinicDoctor;
using ClinicFlow.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Application.Services
{
    public interface IClinicDoctorService
    {
        Task<Result<IEnumerable<ClinicDoctorSearchDTO>>> GetForSelectAsync();
    }
}
