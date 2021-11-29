using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccination
{ 
    class VaccineDetails
    {
        public enum VaccineType
        {
            COVACCINE = 1,
            COVIDSHIELD,
            SPUTNIK
        }
        public VaccineType vaccineType { get; set; }
        public string DoseCount { get;set; }
        public DateTime VaccinatedDate { get; set; }
        public VaccineDetails(int vaccineType,DateTime VaccinatedDate)
        {
            this.vaccineType = (VaccineType)vaccineType;
            this.VaccinatedDate = VaccinatedDate;
        }
    }
}
