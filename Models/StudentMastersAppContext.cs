using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
namespace ASPNET5WEBAPIAngularJS.Models
{
    public class StudentMastersAppContext : DbContext
	{
		public DbSet<StudentMasters> Students { get; set; }
	}
}
