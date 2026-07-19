using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Exceptions
{
	public class FileSizeException : Exception
	{
		string Propertyname { get; set; }

		public FileSizeException(string propertyname,string? message) : base(message)
		{
		  Propertyname = propertyname;
		}
	}
}
