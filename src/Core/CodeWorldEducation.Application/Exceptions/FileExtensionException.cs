using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Exceptions
{
	public class FileExtensionException : Exception
	{
		string Propertyname { get; set; }
		public FileExtensionException(string? message,string propertyname) : base(message)
		{
			Propertyname = propertyname;
		}

		

		
	}
}
