using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Exceptions
{
	public class FileNotFound : Exception
	{
		string Propertyname { get; set; }

		public FileNotFound(string propertyname,string? message) : base(message)
		{
			Propertyname = propertyname;
		}
	}
}
