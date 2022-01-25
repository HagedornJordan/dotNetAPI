using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoomMonitor.Models
{
    public class SensorReading
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime MeasureDate { get; set; }

        [Range(-200, 200)]
        public double Temp { get; set; }


    }
}
