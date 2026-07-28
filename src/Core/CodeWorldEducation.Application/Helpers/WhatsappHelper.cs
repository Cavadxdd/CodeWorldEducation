using CodeWorldEducation.Application.Common.Applications;
using CodeWorldEducation.Domain.Enums;
    
namespace CodeWorldEducation.Application.Helpers
{
    public static class WhatsAppHelper
    {
        private const string PhoneNumber = "994XXXXXXXXX";

        public static string GenerateMessage(CreateApplicationDto dto)
        {
            if (dto.ApplicantType == ApplicantType.Student)
            {
                var mode = dto.EducationMode == TeachingMode.Online ? "Onlayn" : "Əyani";
                return $"Salam, mən {dto.FullName}. Kurs müraciəti ({mode}) göndərdim.";
            }
            else
            {
                return $"Salam, mən {dto.FullName}. Təcrübə proqramına müraciət etdim. CV və portfolio linklərim sistemə yükləndi.";
            }
        }

        public static string GenerateUrl(string message)
        {
            var encoded = Uri.EscapeDataString(message);
            return $"https://wa.me/{PhoneNumber}?text={encoded}";
        }
    }
}