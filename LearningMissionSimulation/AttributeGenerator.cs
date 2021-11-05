using System;
using System.Collections.Generic;
using System.Text;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class AttributeGenerator : SimulationConstants
    { 
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
                    name += AlphabetVocalLetterPool[random.Next(0, AlphabetVocalLetterPool.Length)];                                                                 
                }
                else
                {
                    name += AlphabetConsonantLetterPool[random.Next(0, AlphabetConsonantLetterPool.Length)];
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
            string phoneNumberCode = PhoneOperatorCode[random.Next(0, PhoneOperatorCode.Length)];
            string mobileNumber = Convert.ToString(random.Next(100000, 1000000));
            var phoneNumber = (CountryCode + phoneNumberCode + mobileNumber);
            return phoneNumber;
        }

        public static string GetEmail()
        {
            int emailLength =random.Next(5, 12);
            int domainIndex = random.Next(0, DomainPool.Count);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= emailLength; i++)
            {
                int letterIndex = random.Next(0, LetterPool.Length);
                stringBuilder.Append(LetterPool[letterIndex]);
            }
            return stringBuilder.Append(DomainPool[domainIndex]).ToString();
        }

        public static string GetStreetAddress()
        {
            //not implemented yet!
            return "";
        }

        public static string GetPostalCode()
        {
            return "";
        }

        public static string GetCity(string postalCode)
        {
            if (CityDictionary.ContainsKey(postalCode)) 
            {
                string cityName;

                CityDictionary.TryGetValue(postalCode, out cityName);

                Console.WriteLine($"City Name: {cityName}");

                return cityName;
            }
            
            return null;
        }

        public static string GetProvince(string postalCode)
        {
            if (SimulationConstants.ProvinceDictionary.ContainsKey(postalCode.Substring(0, 2)))
            {
                string provinceName;

                ProvinceDictionary.TryGetValue(postalCode.Substring(0, 2), out provinceName);

                Console.WriteLine($"Province Name: {provinceName}");

                return provinceName;
            }

            return null;
        }

        public static string GetCountry()
        {
            //not implemented yet!
            return "";
        }

        public static string GetUsername()
        {
            string username = GetFirstName();
            int endOfusername = random.Next(0, 10000);
            return username + "-" + Convert.ToString(endOfusername);
        }
        public static string GetPassword(int minLength, int maxLength)
        {
            int count = random.Next(minLength, maxLength);
            int i = random.Next(0, minLength);
            string password = "";
            while (i < count)
            {
                if (i % 2 == 0)
                {
                    password += AlphabetVocalLetterPool[random.Next(0, AlphabetVocalLetterPool.Length)];
                }
                else
                {
                    password += AlphabetConsonantLetterPool[random.Next(0, AlphabetConsonantLetterPool.Length)];
                }
                i++;
            }
            password += CharacterPool[random.Next(0, CharacterPool.Length)];
            return char.ToUpper(password[0]) + password.Substring(1);
        }

        public static string GetCoverLetter()
        {
            //not implemented yet!
            return "";
        }

        public static int GetBuildingNumber()
        {
            return random.Next(1, 100);
        }

        public static int GetApartmentNumber()
        {
            return random.Next(1, 100);
        }
    }
}
