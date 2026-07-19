using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Domain.Entities
{
	
		public class Cv
		{
			public int Id { get; set; }
			public string FullName { get; set; } = null!;
			public string CourseOrField { get; set; } = null!;
			public bool IsOnline { get; set; } 

			public string CvFileName { get; set; } = null!;
			public string CvFilePath { get; set; } = null!;
			public long CvFileSize { get; set; }
			public string CvContentType { get; set; } = null!;
		}
	
}
