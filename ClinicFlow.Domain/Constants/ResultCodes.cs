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

        public const string GenericNameEnExists = "GenericNameEnExists";
        public const string GenericNameArExists = "GenericNameArExists";

        public const string InvalidVisitDate = "InvalidVisitDate";
        public const string InvalidVisitStatus = "InvalidVisitStatus";
        public const string InvalidAppointment = "InvalidAppointment";
        public const string AppointmentAlreadyUsed = "AppointmentAlreadyUsed";
        public const string InvalidWaitingQueue = "InvalidWaitingQueue";

        public const string VisitNotFound = "VisitNotFound";
        public const string VisitAlreadyCompleted = "VisitAlreadyCompleted";
        public const string VisitAlreadyCancelled = "VisitAlreadyCancelled";
        public const string InvalidPrescriptionDate = "InvalidPrescriptionDate";
        public const string PrescriptionItemsRequired = "PrescriptionItemsRequired";
        public const string InvalidMedicine = "InvalidMedicine";
        public const string InvalidPrescriptionQuantity = "InvalidPrescriptionQuantity";
        public const string InvalidPrescriptionDosage = "InvalidPrescriptionDosage";
        public const string InvalidPrescriptionFrequency = "InvalidPrescriptionFrequency";
        public const string InvalidPrescriptionDuration = "InvalidPrescriptionDuration";
        public const string DuplicateDiagnosis = "DuplicateDiagnosis";
        public const string InvalidDiagnosis = "InvalidDiagnosis";
        public const string AppointmentPatientMismatch = "AppointmentPatientMismatch";
        public const string AppointmentDoctorMismatch = "AppointmentDoctorMismatch";
        public const string AppointmentClinicMismatch = "AppointmentClinicMismatch";
        
        public const string InvalidPriceRange = "InvalidPriceRange";

        public const string InvalidDateRange = "InvalidDateRange";
        public const string LabOrderMustHaveItems = "LabOrderMustHaveItems";
        public const string InvalidVisit = "InvalidVisit";
        public const string LabOrderDuplicateItems = "LabOrderDuplicateItems";
        public const string LabOrderInvalidItem = "LabOrderInvalidItem";
        public const string LabTestRequired = "LabTestRequired";
        public const string PatientRequired = "PatientRequired";

        public const string OrderItemRequired = "OrderItemRequired";
        public const string DuplicateResultExists = "DuplicateResultExists";
        public const string ValuesRequired = "ValuesRequired";
        public const string DuplicateParameters = "DuplicateParameters";
        public const string InvalidParameter = "InvalidParameter";
        public const string ParameterRequired = "ParameterRequired";

        public const string InvoiceNumberRequired = "InvoiceNumberRequired";
        public const string InvoiceMustHaveItems = "InvoiceMustHaveItems";
        public const string InvoiceDuplicateItems = "InvoiceDuplicateItems";
        public const string InvoiceInvalidItem = "InvoiceInvalidItem";
        public const string InvoiceItemQuantityInvalid = "InvoiceItemQuantityInvalid";
        public const string InvoiceItemUnitPriceInvalid = "InvoiceItemUnitPriceInvalid";
        public const string InvalidAmountRange = "InvalidAmountRange";

    }
}
