using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RoomMonitor.Models
{
    public class RoomMonitorContext : DbContext
    {
        public RoomMonitorContext (DbContextOptions<RoomMonitorContext> options)
            : base(options)
        {
        }

        public DbSet<RoomMonitor.Models.SensorReading> SensorReading { get; set; }
    }
}
