using System;
using LearningMissionLab;
namespace LearningMissionSimulation
{
    public class AttributeGenerator
    {
        // Minimum valid applicant age
        static readonly byte ApplicantMinAge = 18;
        // Maximum valid applicant age
        static readonly byte ApplicantMaxAge = 70;
        static readonly string[] syllables = { "Ab", "Saa", "Levo", "Pari", "Rub", "Ask",
            "Mam", "Ket", "Zar", "Luci", "Ter", "Ova", "Sar", "Vol", "Ver" };

        static readonly string[] maleNames = { "Sevak", "Mher", "Arevshat",
            "Garush", "Karen", "Smbat", "Rouben", "Garegin", "Vahe", "Eduard",
            "Gavril", "Suren", "Arkadij" };

        static readonly string[] femaleNames = { "Nina", "Karine", "Margarita",
            "Narine", "Nane", "Marina", "Lilit", "Yelena" };
        static readonly string[] lastNamePool = new string[] { "Lalazryan", "Mkhrtchyan",
            "Hakobyan", "Vardanyan", "Lobyan", "Levonyan", "Sahakyan", "Gevorgyan" };

        static readonly string[] alphabetVocalLetters = new string[] { "a", "e", "i", "o", "u", "y" };

        static readonly string[] alphabetConsonantLetters = new string[] { "b", "c", "d", "f", "g", 
            "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z" };
         

        static Random random = new Random();

        /// <summary>Generates random date of birth values within the specified age range./>
        /// <param name="minAge">The minimum age.</param>
        /// <param name="maxAge">The maximum age.</param>
        /// <returns>The DateTime value within specified range.</returns>
        public static DateTime GetDateOfBirth(byte minAge, byte maxAge)
        {
            // input's validation: check age limits, make sure their within
            // the allowed range
            while (minAge < ApplicantMinAge || maxAge > ApplicantMaxAge)
            {
                Console.WriteLine(
                    "Inconsistent values. The minimum age must be big or equal to 18 " +
                    "and maximum age must be less or equal to 70.\n" +
                    "Please fill consistent values\n"
                );
                Console.WriteLine("Please input minimum age.");

                minAge = (byte)Convert.ToUInt16(Console.ReadLine());

                Console.WriteLine("Please input maximum age.");

                maxAge = (byte)Convert.ToUInt16(Console.ReadLine());
            }

            minAge = Math.Max(ApplicantMinAge, minAge);
            maxAge = Math.Min(ApplicantMaxAge, maxAge);

            byte age = (byte)random.Next(minAge, maxAge + 1);
            int year = DateTime.Now.Year - age;
            byte month = (byte)random.Next(1, 13);
            byte day;

            switch(month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    day = (byte)random.Next(1, 32); //for months with 31 days
                    break;
                case 2:
                    day = year % 4 == 0 ? (byte)random.Next(1, 30) : (byte)random.Next(1, 29); // February
                    break;
                default: 
                    day = (byte)random.Next(1, 31); // for months with 30 days
                    break;
            }

            Console.WriteLine($"Age: {age}");

            return new DateTime(year, month, day);
        }

        public static string GetLastName()
        {
            int count = random.Next(2, 10);
            int i = random.Next(0,2);
            string name = "";
            while (i < count )
            {
                if (i % 2 == 0)
                {
                    name += alphabetVocalLetters[random.Next(0, alphabetVocalLetters.Length)];                                                                 
                }
                else
                {
                    name += alphabetConsonantLetters[random.Next(0, alphabetConsonantLetters.Length)];
                }
                i++;
            }
            name = char.ToUpper(name[0]) + name.Substring(1);
            string lastName = name + "yan" ;
            return lastName;
        }

        public static string GetFirstName()
        {
            //not implemented yet!
            return "";
        }

        public static LanguageLevel GetLanguageLevel()
        {
            //not implemented yet!
            return LanguageLevel.Unspecified;
        }

        public static LanguageName GetLanguageName()
        {
            //not implemented yet!
            return LanguageName.Unspecified;
        }

        public static ModuleLevel GetModuleLevel()
        {
            //not implemented yet!
            return ModuleLevel.Unspecified;
        }

        public static Gender GetGender()
        {
            var genderCount = Enum.GetValues(typeof(Gender)).Length;
            return (Gender)random.Next(1, genderCount); 
        }

        public static DepartmentType GetDepartmentType()
        {
            //not implemented yet!
            return DepartmentType.Unspecified;
        }

        public static Role GetRole()
        {
            var roleCount = Enum.GetValues(typeof(Role)).Length;
            return (Role)random.Next(1, roleCount); ;
        }

        public static Status GetStatus()
        {
            var statusCount = Enum.GetValues(typeof(Status)).Length;
            return (Status)random.Next(1, statusCount);
        }

        public static string GetPhoneNumber()
        {
            Random r = new Random();
            string countryCode = "+374";
            string[] phoneOperatorCode = { "10", "11", "33", "44", "47", "55", "77", "91", "93", "94", "95", "96", "97", "98", "99" };
            string phoneNumberCode = phoneOperatorCode[r.Next(0, phoneOperatorCode.Length)];
            string mobileNumber = Convert.ToString(r.Next(100000, 1000000));
            var phoneNumber = (countryCode + phoneNumberCode + mobileNumber);
            return phoneNumber;
        }

        public static string GetEmail()
        {
            //not implemented yet!
            return "";
        }

        public static string GetStreetAddress()
        {
            //not implemented yet!
            return "";
        }

        public static string GetPostalCode()
        {
            //not implemented yet!
            return "";
        }

        public static string GetCity()
        {
            //not implemented yet!
            return "";
        }

        public static string GetProvince()
        {
            //not implemented yet!
            return "";
        }

        public static string GetCountry()
        {
            //not implemented yet!
            return "";
        }

    }
}
