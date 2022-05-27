using Domotics.DataAccessLayer.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domotics.DataAccessLayer.Entities
{
   public class Measure : ADataObject
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public SensorType Type { get; set; }
        public decimal Value { get; set; }
       
    }
}
