using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace House.Core.Dto
{
    public class BuildingDto
    {
        public Guid? Id { get; set; }
        public string Street { get; set; }
        public double ApartmentNumber { get; set; } // int
        public double Floor { get; set; } // int
        public string Typeofheating { get; set; } // str
        public double Area { get; set; }
        public double Parking { get; set; } // int
        public DateTime CreatedAT { get; set; }
        public DateTime ModifiedAT { get; set; }

    }
}
