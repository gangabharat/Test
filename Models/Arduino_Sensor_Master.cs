using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Arduino.Models
{
    public class Arduino_Sensor_Master
    {
        [Key]
        public int SensorID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string SensorName { get; set; }

        [Display(Name = "Location")]
        public string SensorLocation { get; set; }

        [Required]
        [Display(Name = "IP")]
        public string SensorIP { get; set; }

        [Display(Name = "Active")]
        public Nullable<bool> isActive { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> CreatedDateTime { get; set; }

        public Nullable<int> Createdby { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }

        public Nullable<int> Updatedby { get; set; }
    }
}