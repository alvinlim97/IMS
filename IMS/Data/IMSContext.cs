using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IMS.Models;

namespace IMS.Models
{
    public class IMSContext : DbContext
    {
        public IMSContext (DbContextOptions<IMSContext> options)
            : base(options)
        {
        }

        public DbSet<IMS.Models.Staff> Staff { get; set; }

        public DbSet<IMS.Models.Login> Login { get; set; }

        public DbSet<IMS.Models.Incident> Incident { get; set; }

        public DbSet<IMS.Models.IncidentTask> IncidentTask { get; set; }
        
        
        
    }
}
