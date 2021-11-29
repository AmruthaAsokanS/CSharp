using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccination
{
    class Vaccination
    {
        private static List<BeneficiaryDetails> BeneficiaryDetailsList = new List<BeneficiaryDetails>();
        public static string UserChoice = "";

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine(" 1.Beneficiary Registration \n 2.Vaccination \n 3.Exit");
                Console.WriteLine("Enter Your Choice : ");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddBeneficiaryDetails();
                        break;
                    case 2:
                        TakeVaccination();
                        break;
                    case 3:
                        Environment.Exit(-1);
                        break;
                    default:
                        Console.WriteLine("Enter Valid Input");
                        break;
                }
                do
                {
                    Console.Write("Do You Want to go to Main Menu (Yes or No?) : ");
                    UserChoice = Console.ReadLine().ToUpper();

                    if (UserChoice != "YES" && UserChoice != "NO")
                    {
                        Console.WriteLine("Invalid data please enter Yes or No");
                    }
                } while (UserChoice == "YES" && UserChoice == "NO");
            } while (UserChoice == "YES");
            Console.ReadKey();
        }
        public static void AddBeneficiaryDetails()
        {
            do
            {
                Console.Write("Enter Your Name : ");
                string BeneficiaryName = Console.ReadLine();
                Console.Write("Enter Your Phone Number : ");
                long PhoneNumber = Convert.ToInt64(Console.ReadLine());
                Console.Write("Enter Your City : ");
                string City = Console.ReadLine();
                Console.Write("Enter Your Age : ");
                int Age = int.Parse(Console.ReadLine());
                Console.Write("Enter Your Gender {1.Male, 2.Female, 3.Others} : ");
                string gender1 = Console.ReadLine();
                int gender = int.Parse(gender1);
                if(Age > 18)
                {
                    BeneficiaryDetails beneficiaryDetails = new BeneficiaryDetails(BeneficiaryName, PhoneNumber, City, Age, gender);
                    BeneficiaryDetailsList.Add(beneficiaryDetails);
                    Console.WriteLine("Registered Successfully");
                    Console.WriteLine($"Your Register Number is {beneficiaryDetails.RegNo}");
                }
                else
                {
                    Console.WriteLine("You are not Eligible");
                }
                do
                {
                    Console.Write("Do You Want to Enter again (Yes or No?) : ");
                    UserChoice = Console.ReadLine().ToUpper();

                    if (UserChoice != "YES" && UserChoice != "NO")
                    {
                        Console.WriteLine("Invalid data please enter Yes or No");
                    }
                } while (UserChoice == "YES" && UserChoice == "NO");
            } while (UserChoice == "YES");
        }
        public static void TakeVaccination()
        {
            Console.Write("Enter Your Register Number : ");
            string RegNo = Console.ReadLine();
            if (ValidateUser(RegNo))
            {
                do
                {
                    Console.WriteLine(" 1.Take Vaccination \n 2.Vaccination History \n 3.Next Due Date \n 4.Exit");
                    Console.WriteLine("Enter Your Choice : ");
                    int input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("Enter Vaccination Type {1.Covaccine ,2.Covidshield, 3.Sputnik} :");
                            string vaccineType1 = Console.ReadLine();
                            int vaccineType = int.Parse(vaccineType1);
                            DateTime VaccinatedDate = DateTime.Now;
                            VaccineDetails vaccineDetails = new VaccineDetails(vaccineType,VaccinatedDate);
                            foreach (BeneficiaryDetails i in BeneficiaryDetailsList)
                            {
                                i.vaccineDetailsList.Add(vaccineDetails);
                            }
                            Console.WriteLine("Vaccinated Successfully");
                            break;
                        case 2:
                            GetVaccinationDetails(RegNo);
                            break;
                        case 3:
                            NextDoseDueDate(RegNo);
                            break;
                        case 4:
                            Environment.Exit(-1);
                            break;
                        default:
                            Console.WriteLine("Enter Valid Input");
                            break;
                    }
                    do
                    {
                        Console.Write("Do You Want to go to Options (Yes or No?) : ");
                        UserChoice = Console.ReadLine().ToUpper();

                        if (UserChoice != "YES" && UserChoice != "NO")
                        {
                            Console.WriteLine("Invalid data please enter Yes or No");
                        }
                    } while (UserChoice == "YES" && UserChoice == "NO");
                } while (UserChoice == "YES");
            }
            else
            {
                Console.WriteLine("Invalid Registration Number. Please Enter the Valid One");
            }
        }
        public static bool ValidateUser(string UserId)
        {
            bool valid = false;
            foreach (BeneficiaryDetails i in BeneficiaryDetailsList)
            {
                if (UserId == i.RegNo)
                {
                    valid = true;
                    break;
                }
            }
            return valid;
        }
        public static void GetVaccinationDetails(string RegNo)
        {
            foreach (BeneficiaryDetails i in BeneficiaryDetailsList)
            {
                foreach (VaccineDetails j in i.vaccineDetailsList)
                {
                    if (RegNo == i.RegNo)
                    {
                        if (i.vaccineDetailsList != null)
                        {
                            DateTime VaccinatedDate = j.VaccinatedDate;
                            Console.WriteLine("\n Vaccination Details -->");
                            Console.WriteLine($" Reg No : {RegNo} \n Name : {i.BeneficiaryName} \n Vaccine Type : {j.vaccineType} \n Vaccinated Date : {j.VaccinatedDate} ");

                        }
                    }
                }
            }
        }
        public static void NextDoseDueDate(string RegNo)
        {
            foreach (BeneficiaryDetails i in BeneficiaryDetailsList)
            {
                foreach (VaccineDetails j in i.vaccineDetailsList)
                {
                    if (RegNo == i.RegNo)
                    {
                        if (i.vaccineDetailsList != null)
                        {
                            if (i.vaccineDetailsList.Count == 1)
                            {
                                DateTime VaccinatedDate = j.VaccinatedDate;
                                DateTime date = VaccinatedDate.AddDays(30);
                                string DueDate = date.ToShortDateString();
                                Console.WriteLine("Your Next Dose Due Date is by", DueDate);

                            }
                            else if (i.vaccineDetailsList.Count == 2)
                            {
                                Console.WriteLine("You have completed the vaccination course. Thanks for your participation in the vaccination drive.");
                            }
                        }
                    }
                }
            }
        }
    }
}
