using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapperApp.Models.DTOs.Incoming
{
	public class DriverForCreationDto
	{
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DriverNumber { get; set; }       
        
        public int WorldChampionships { get; set; }
		
	}
}