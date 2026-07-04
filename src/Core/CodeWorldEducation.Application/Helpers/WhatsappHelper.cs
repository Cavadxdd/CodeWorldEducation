using CodeWorldEducation.Application.Common.Application;
using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Helpers
{
    public static class WhatsAppHelper
    {
        private const string PhoneNumber = "994XXXXXXXXX";

        public static string GenerateMessage(CreateApplicationDto dto)
        {
            if (dto.ApplicantType == ApplicantType.Student)
            {
                return $"Salam, mən {dto.FirstName} {dto.LastName}. " +
                       $"{dto.TeachingMode} tələbə olaraq müraciət etdim. " +
                       $"Məlumatlarım sistemə yükləndi.";
            }
            else
            {
                return $"Salam, mən {dto.FirstName} {dto.LastName}. " +
                       $"{dto.Field} üzrə təcrübə proqramına müraciət etdim. " +
                       $"CV və portfolio linklərim sistemə uğurla yükləndi.";
            }
        }

        public static string GenerateUrl(string message)
        {
            var encodedMessage = Uri.EscapeDataString(message);
            return $"https://wa.me/{PhoneNumber}?text={encodedMessage}";
        }
    }
}
