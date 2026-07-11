using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Abstraction.Services
{
	public interface IWhatsAppService
	{
		
			string GenerateStudentLink(string fullName, string course, bool isOnline);
			string GenerateInternLink(string fullName, string field);
		
	}
}
