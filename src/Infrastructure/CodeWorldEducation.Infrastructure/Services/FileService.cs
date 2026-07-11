using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Infrastructure.Services
{
	public class FileService : IFileService
	{
		private readonly IWebHostEnvironment _env;

		private readonly IConfiguration _configuration;
		public FileService(IWebHostEnvironment env, IConfiguration configuration)
		{
			_env = env;
			_configuration = configuration;
		}

		

		public async Task<(string fileName, string filePath)> UploadCvAsync(IFormFile file)
		{
			if (file == null || file.Length == 0) throw new FileNotFound("file", "File not found");
			//if (file.Length > 5242880) throw new FileSizeException("file", "File size error");
			var maxUploadSize = long.Parse(_configuration["FileSettings:MaxUploadSizeInBytes"] ?? "5242880");
			if (file.Length > maxUploadSize)
				throw new FileSizeException("file", "File size error");
			var allowedExtensions = new[] { ".pdf", ".doc", ".docx" };
			var Extension = Path.GetExtension(file.FileName).ToLower();
			if (!allowedExtensions.Contains(Extension))
			{
				throw new FileExtensionException("file", "Invalid file extension");
			}
			var folderPath = _configuration["FileSettings:UploadPath"] ?? "uploads/cv";
			var uploadDirectory = Path.Combine(_env.WebRootPath, folderPath);

			if (!Directory.Exists(uploadDirectory))
			{
				Directory.CreateDirectory(uploadDirectory);
			}
			var uniqueFileName = $"{Guid.NewGuid()}{Extension}";
			var fullPath = Path.Combine(uploadDirectory, uniqueFileName);

			using (var stream = new FileStream(fullPath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}
			var relativePath = Path.Combine(folderPath, uniqueFileName).Replace("\\", "/");
			return (uniqueFileName, relativePath);
		}
	}
}
