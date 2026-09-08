using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Domain.Constants
{
    public static partial class ResultCodes
    {
        public const string ServerError = "ServerError";
        public const string NotFound = "NotFound";
        public const string InvalidData = "InvalidData";
        public const string InvalidDate = "InvalidDate";

        public const string CreatedSuccessfully = "CreatedSuccessfully";
        public const string UpdatedSuccessfully = "UpdatedSuccessfully";
        public const string DeletedSuccessfully = "DeletedSuccessfully";

        public const string AlreadyExists = "AlreadyExists";
        public const string ValidationError = "ValidationError";
        public const string UnexpectedError = "UnexpectedError";

        public const string NameEnExists = "NameEnExists";
        public const string NameArExists = "NameArExists";
        public const string PhoneNumberAlreadyExists = "PhoneNumberAlreadyExists";
        public const string EmailAlreadyExists = "EmailAlreadyExists";
        public const string NationalIdAlreadyExists = "NationalIdAlreadyExists";
        public const string DuplicateAllergy = "DuplicateAllergy";
        public const string InvalidAllergy = "InvalidAllergy";
        public const string DuplicateChronicCondition = "DuplicateChronicCondition";
        public const string InvalidChronicCondition = "InvalidChronicCondition";

        public const string DuplicateSpecialty = "DuplicateSpecialty";
        public const string InvalidSpecialty = "InvalidSpecialty";

        public const string DuplicateClinicDoctor = "DuplicateClinicDoctor";
        public const string InvalidClinicDoctor = "InvalidClinicDoctor";

        public const string DuplicateDoctor = "DuplicateDoctor";
        public const string InvalidDoctor = "InvalidDoctor";

        public const string InvalidAppointmentNumber = "InvalidAppointmentNumber";
        public const string AppointmentNumberAlreadyExists = "AppointmentNumberAlreadyExists";
        public const string PleaseSelectPatient = "PleaseSelectPatient";
        public const string InvalidPatient = "InvalidPatient";
        public const string PleaseSelectClinic = "PleaseSelectClinic";
        public const string InvalidClinic = "InvalidClinic";
        public const string PleaseSelectDoctor = "PleaseSelectDoctor";
        public const string DoctorNotAssignedToClinic = "DoctorNotAssignedToClinic";
        public const string InvalidAppointmentTime = "InvalidAppointmentTime";
        public const string AppointmentInPast = "AppointmentInPast";
        public const string InvalidAppointmentStatus = "InvalidAppointmentStatus";
        public const string AppointmentTimeAlreadyBooked = "AppointmentTimeAlreadyBooked";
        
        public const string InvalidWaitingQueueStatus = "InvalidWaitingQueueStatus";
        public const string WaitingQueueDateInPast = "WaitingQueueDateInPast";
        public const string PatientAlreadyInWaitingQueue = "PatientAlreadyInWaitingQueue";

    }
}
