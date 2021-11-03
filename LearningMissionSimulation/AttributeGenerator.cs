using System;
using System.Collections.Generic;
using System.Text;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class AttributeGenerator
    {
        // Minimum valid applicant age
        static readonly byte ApplicantMinAge = 18;
        // Maximum valid applicant age
        static readonly byte ApplicantMaxAge = 70;
        static readonly string[] syllablepool = { "Ab", "Saa", "Levo", "Pari", "Rub", "Ask",
            "Mam", "Ket", "Zar", "Luci", "Ter", "Ova", "Sar", "Vol", "Ver" };

        static readonly string[] maleNamePool = { "Sevak", "Mher", "Arevshat",
            "Garush", "Karen", "Smbat", "Rouben", "Garegin", "Vahe", "Eduard",
            "Gavril", "Suren", "Arkadij" };

        static readonly string[] femaleNamePool = { "Nina", "Karine", "Margarita",
            "Narine", "Nane", "Marina", "Lilit", "Yelena" };
        static readonly string[] lastNamePool = new string[] { "Lalazryan", "Mkhrtchyan",
            "Hakobyan", "Vardanyan", "Lobyan", "Levonyan", "Sahakyan", "Gevorgyan" };

        static readonly string[] alphabetVocalLetterPool = new string[] { "a", "e", "i", "o", "u", "y" };

        static readonly string[] alphabetConsonantLetterPool = new string[] { "b", "c", "d", "f", "g", 
            "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z" };
         

        static readonly string countryCode = "+374";
        static readonly string[] phoneOperatorCode = { "10", "11", "33", "44", "47", "55", "77", "91", "93", "94", "95", "96", "97", "98", "99" };

        static readonly char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                                           'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        static readonly List<string> domainPool = new List<string>()
            {"@email.ru", "@gmail.com", "@yahoo.com", "@yandex.ru"};
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

            switch (month)
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
        public static string GetFirstName(int lengthLimit)
        {
            int count = random.Next(2, lengthLimit);
            int i = random.Next(0, 2);
            string name = "";
            while (i < count)
            {
                if (i % 2 == 0)
                {
                    name += alphabetVocalLetterPool[random.Next(0, alphabetVocalLetterPool.Length)];                                                                 
                }
                else
                {
                    name += alphabetConsonantLetterPool[random.Next(0, alphabetConsonantLetterPool.Length)];
                }
                i++;
            }
            return char.ToUpper(name[0]) + name.Substring(1); 
        }
        public static string GetFirstName()
        {
            return GetFirstName(8);
        }
        public static string GetLastName(int lengthLimit)
        { 
            return GetFirstName(lengthLimit) + "yan";
        }
        public static string GetLastName()
        {
            return GetLastName(10);
        }
        

        public static LanguageLevel GetLanguageLevel()
        {
            var levelCount = Enum.GetNames(typeof(LanguageLevel)).Length;
            return (LanguageLevel)random.Next(1, levelCount);
        }

        public static LanguageName GetLanguageName()
        {
            var nameCount = Enum.GetNames(typeof(LanguageName)).Length;
            return (LanguageName)random.Next(1, nameCount);
        }

        public static ModuleLevel GetModuleLevel()
        {                        
            var levelCount = Enum.GetValues(typeof(ModuleLevel)).Length;
            return (ModuleLevel)random.Next(0, levelCount);
            
        }
        public static SubjectType GetSubjecType()
        {
           var levelCount = Enum.GetValues(typeof(SubjectType)).Length;
           return (SubjectType)random.Next(0, levelCount);           
        }

        public static Gender GetGender()
        {
            var genderCount = Enum.GetValues(typeof(Gender)).Length;
            return (Gender)random.Next(1, genderCount); 
        }

        public static DepartmentType GetDepartmentType()
        {
            var departmentTypeCount = Enum.GetValues(typeof(DepartmentType)).Length;
            return (DepartmentType)random.Next(1, departmentTypeCount);
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
            string phoneNumberCode = phoneOperatorCode[random.Next(0, phoneOperatorCode.Length)];
            string mobileNumber = Convert.ToString(random.Next(100000, 1000000));
            var phoneNumber = (countryCode + phoneNumberCode + mobileNumber);
            return phoneNumber;
        }

        public static string GetEmail()
        {            
            int emailLength =random.Next(5, 12);
            int domainIndex = random.Next(0, domainPool.Count);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= emailLength; i++)
            {
                int letterIndex = random.Next(0, letters.Length);
                stringBuilder.Append(letters[letterIndex]);
            }
            return stringBuilder.Append(domainPool[domainIndex]).ToString();
        }

        public static string GetStreetAddress()
        {
            //not implemented yet!
            return "";
        }

        public static string GetPostalCode()
        {
            Dictionary<string, string> postalCodeDictionary = new Dictionary<string, string>()
            {
                { "03", "Aparan" },
                { "04", "Aragac" },
                { "02", "Ashtarak" },
                { "05", "Talin" },
                { "06", "Ararat" },
                { "07", "Artashat" },
                { "08", "Masis" },
                { "09", "Armavir" },
                { "10", "Baghramyan" },
                { "11", "Vagharshapat" },
                { "12", "Gavar" },
                { "14", "Martuni" },
                { "15", "Sevan" },
                { "13", "Tshambarak" },
                { "16", "Vardenis" },
                { "22", "Abovyan" },
                { "25", "Charencavan" },
                { "23", "Hrazdan" },
                { "24", "Nairi" },
                { "18", "Spitak" },
                { "19", "Stepanavan" },
                { "17", "Tumanyan"},
                { "20", "Vanadzor"},
                { "21", "Vanadzor"},
                { "26", "Akhuryan"},
                { "27", "Amasia" },
                { "29", "Ani" },
                { "30", "Artik" },
                { "31", "Gyumri" },
                { "32", "Gyumri" },
                { "33", "Kapan" },
                { "34", "Meghri" },
                { "35", "Sisian" },
                { "39", "Dilijan" },
                { "40", "Ijevan" },
                { "41", "Noyemberyan" },
                { "42", "Tavush" },
                { "36", "Eghegnadzor" },
                { "37", "Jermuk" },
                { "38", "Vayq" },
                { "00", "Yerevan" }
            };

            foreach (var keyValuePair in postalCodeDictionary)
            {
                Console.WriteLine($"Key: {keyValuePair.Key} Value: {keyValuePair.Value}");
            }

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
        public static string GetUsername()
        {
            //not implemented yet!
            return "";
        }
        public static string GetPassword()
        {
            //not implemented yet!
            return "";
        }
        public static string GetCoverLetter()
        {
            //not implemented yet!
            return "";
        }
        public static int GetBuildingNumber()
        {
            //not implemented yet!
            return 0;
        }
        public static int GetApartmentNumber()
        {
            //not implemented yet!
            return 0;
        }
    }
}
