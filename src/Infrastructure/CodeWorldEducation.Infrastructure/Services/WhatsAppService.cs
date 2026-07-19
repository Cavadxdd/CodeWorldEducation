using CodeWorldEducation.Application.Abstraction.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CodeWorldEducation.Infrastructure.Services
{
	public class WhatsAppService : IWhatsAppService
	{
		private readonly string _phoneNumber;
		private const string BaseUrl = "https://wa.me/";
		public WhatsAppService(IConfiguration configuration)
		{
			_phoneNumber = configuration["WhatsAppSettings:WhatsAppNumber"] ?? "994XXXXXXXXX";
		}
		public string GenerateStudentLink(string fullName, string course, bool isOnline)
		{
			string mode = isOnline ? "Onlayn" : "Əyani";
			string message = $"Salam, mən {fullName}.\n{course} kursuna\n{mode}\ntələbə olaraq müraciət etdim.\nMəlumatlarım sistemə yükləndi.";

			return BuildUrl(message);
		}

		public string GenerateInternLink(string fullName, string field)
		{
			string message = $"Salam, mən {fullName}.\n{field}\nüzrə təcrübə proqramına müraciət etdim.\nCV və portfolio linklərim sistemə uğurla yükləndi.";

			return BuildUrl(message);
		}
		private string BuildUrl(string message)
		{
			// URL-safe olması üçün mətn encode edilir (UrlHelper rolu)
			var encodedText = HttpUtility.UrlEncode(message);
			return $"{BaseUrl}{_phoneNumber}?text={encodedText}";
		}
	}
}
