using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccination
{
    class BeneficiaryDetails
    {
        private static int AutoIncrementRegNo = 1000;
        public string RegNo { get; }
        public string BeneficiaryName { get; set; }
        public long PhoneNumber { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public enum Gender
        {
            MALE = 1 ,
            FEMALE,
            OTHERS
        }
        public Gender gender { get; set; }
        public List<VaccineDetails> vaccineDetailsList = new List<VaccineDetails>();
        public  BeneficiaryDetails(string BeneficiaryName, long PhoneNumber, string City, int Age, int gender)
        {
            AutoIncrementRegNo++;
            this.RegNo = AutoIncrementRegNo.ToString();
            this.BeneficiaryName = BeneficiaryName;
            this.PhoneNumber = PhoneNumber;
            this.City = City;
            this.Age = Age;
            this.gender = (Gender)gender;
            
        }
    }
}
