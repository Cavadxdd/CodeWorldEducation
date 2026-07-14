using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Abstraction.Services
{
	public interface IFileService
	{
		Task<(string fileName, string filePath)> UploadCvAsync(IFormFile file);
		
	}
}

