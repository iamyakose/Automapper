using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapperApp.Models.DTOs.Outgoing
{
	public class DriverForResponseDtos
	{
		public Guid Id { get; set; }		
		public string FullName { get; set; }		
		public int DriverNumber { get; set; }        
		public int WorldChampionships { get; set; }  
		
	}
}