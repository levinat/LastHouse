using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace House.Core.Domain
{
    public class Building
    {
        public Guid? Id { get; set; }
        public string Street { get; set; }
        public double ApartmentNumber { get; set; } 
        public double Floor { get; set; }
        public string Typeofheating { get; set; }
        public double Area { get; set; }
        public double Parking { get; set; }
        public DateTime CreatedAT { get; set; }
        public DateTime ModifiedAT { get; set; }

    }
}
