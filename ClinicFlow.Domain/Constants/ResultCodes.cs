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

    }
}
