using System;
using System.Collections.Generic;
using System.Text;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class AttributeGenerator  
    {
        public static Random Random = new Random();

        public static DateTime GetDateOfBirth(byte minAge, byte maxAge)
        {
            // input's validation: check age limits, make sure their within
            // the allowed range
            while (minAge < SimulationConstants.ApplicantMinAge || maxAge > SimulationConstants.ApplicantMaxAge)
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

            minAge = Math.Max(SimulationConstants.ApplicantMinAge, minAge);
            maxAge = Math.Min(SimulationConstants.ApplicantMaxAge, maxAge);

            byte age = (byte)Random.Next(minAge, maxAge + 1);
            int year = DateTime.Now.Year - age;
            byte month = (byte)Random.Next(1, 13);
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
                    day = (byte)Random.Next(1, 32); //for months with 31 days
                    break;
                case 2:
                    day = year % 4 == 0 ? (byte)Random.Next(1, 30) : (byte)Random.Next(1, 29); // February
                    break;
                default:
                    day = (byte)Random.Next(1, 31); // for months with 30 days
                    break;
            }

            Console.WriteLine($"Age: {age}");

            return new DateTime(year, month, day);
        }

        // Returns a Random first name
        public static string GetFirstName(int lengthLimit)
        {
            int count = Random.Next(2, lengthLimit);
            int i = Random.Next(0, 2);
            string name = "";
            while (i < count)
            {
                if (i % 2 == 0)
                {
                    name += SimulationConstants.AlphabetVocalLetterPool[Random.Next(0, SimulationConstants.AlphabetVocalLetterPool.Length)];                                                                 
                }
                else
                {
                    name += SimulationConstants.AlphabetConsonantLetterPool[Random.Next(0, SimulationConstants.AlphabetConsonantLetterPool.Length)];
                }
                i++;
            }
            return char.ToUpper(name[0]) + name.Substring(1); 
        }

        public static string GetFirstName()
        {
            return GetFirstName(8);
        }

        // Returns a Random last name
        public static string GetLastName(int lengthLimit)
        { 
            return GetFirstName(lengthLimit) + "yan";
        }

        public static string GetLastName()
        {
            return GetLastName(10);
        }

        // Returns a Random value from LanguageLevel, LanguageLevel.Unspecified
        // is excluded
        public static LanguageLevel GetLanguageLevel()
        {
            var levelCount = Enum.GetNames(typeof(LanguageLevel)).Length;
            return (LanguageLevel)Random.Next(1, levelCount);
        }

        // Returns a Random value from LanguageName, LanguageName.Unspecified
        // is excluded
        public static LanguageName GetLanguageName()
        {
            var nameCount = Enum.GetNames(typeof(LanguageName)).Length;
            return (LanguageName)Random.Next(1, nameCount);
        }

        // Returns a Random value from ModuleLevel, ModuleLevel.Unspecified
        // is excluded
        public static ModuleLevel GetModuleLevel()
        {                        
            var levelCount = Enum.GetValues(typeof(ModuleLevel)).Length;
            return (ModuleLevel)Random.Next(0, levelCount);
            
        }

        // Returns a Random value from SubjectType, SubjectType.Unspecified
        // is excluded
        public static SubjectType GetSubjecType()
        {
           var levelCount = Enum.GetValues(typeof(SubjectType)).Length;
            return (SubjectType)Random.Next(0, levelCount);
        }

        // Returns a Random value from Gender, Gender.Unspecified
        // is excluded
        public static Gender GetGender()
        {
            var genderCount = Enum.GetValues(typeof(Gender)).Length;
            return (Gender)Random.Next(1, genderCount); 
        }

        // Returns a Random value from DepartmentType, DepartmentType.Unspecified
        // is excluded
        public static DepartmentType GetDepartmentType()
        {
            var departmentTypeCount = Enum.GetValues(typeof(DepartmentType)).Length;
            return (DepartmentType)Random.Next(1, departmentTypeCount);
        }

        // Returns a Random value from Role, Role.Unspecified
        // is excluded
        public static Role GetRole()
        {
            var roleCount = Enum.GetValues(typeof(Role)).Length;
            return (Role)Random.Next(1, roleCount); ;
        }

        // Returns a Random value from Status, Status.Unspecified
        // is excluded
        public static Status GetStatus()
        {
            var statusCount = Enum.GetValues(typeof(Status)).Length;
            return (Status)Random.Next(1, statusCount);
        }

        // Returns a Random phone number
        public static string GetPhoneNumber()
        {
            string phoneNumberCode = SimulationConstants.PhoneOperatorCode[Random.Next(0, SimulationConstants.PhoneOperatorCode.Length)];
            string mobileNumber = Convert.ToString(Random.Next(100000, 1000000));
            var phoneNumber = (SimulationConstants.CountryCode + phoneNumberCode + mobileNumber);
            return phoneNumber;
        }

        // Returns a Random email address
        public static string GetEmail()
        {            
            int emailLength = Random.Next(5, 12);
            int domainIndex = Random.Next(0, SimulationConstants.DomainPool.Count);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= emailLength; i++)
            {
                int letterIndex = Random.Next(0, SimulationConstants.LetterPool.Length);
                stringBuilder.Append(SimulationConstants.LetterPool[letterIndex]);
            }
            return stringBuilder.Append(SimulationConstants.DomainPool[domainIndex]).ToString();
        }

        // Returns a Random street address
        public static string GetStreetName()
        {
            //not implemented yet
            return "";
        }

        public static string GetTwoDigitCode(int maxLimit)
        {
            string postalCode = "";
            int range = Random.Next(0, maxLimit);

            postalCode = range < 10 ? "0" + range.ToString() : range.ToString();

            return postalCode;
        }

        // Returns a Random postal code
        public static string GetPostalCode()
        {
            string postalCode = GetTwoDigitCode(43) + GetTwoDigitCode(20);

            while (!SimulationConstants.CityDictionary.ContainsKey(postalCode))
            {
                postalCode = GetTwoDigitCode(43) + GetTwoDigitCode(20);
            }

            return postalCode;
        }

        // Returns a Random city name
        public static string GetCity(string postalCode)
        {
            if (SimulationConstants.CityDictionary.ContainsKey(postalCode)) 
            {
                string cityName;

                SimulationConstants.CityDictionary.TryGetValue(postalCode, out cityName);

                Console.WriteLine($" City Name: {cityName}");

                return cityName;
            }  
            
            return null;
        }

        // Returns a Random province name
        public static string GetProvince(string postalCode)
        {
            if (SimulationConstants.ProvinceDictionary.ContainsKey(postalCode.Substring(0, 2)))
            {
                string provinceName;

                SimulationConstants.ProvinceDictionary.TryGetValue(postalCode.Substring(0, 2), out provinceName);

                Console.WriteLine($" Province Name: {provinceName}\n Postal Code: {postalCode}");

                return provinceName;
            }

            return null;
        }

        // Returns a Random country name
        public static string GetCountry()
        {
            //not implemented yet!
            return "";
        }

        // Returns a Random username
        public static string GetUsername()
        {
            string username = GetFirstName();
            int endOfusername = Random.Next(0, 10000);
            return username + "-" + Convert.ToString(endOfusername);
        }

        // Returns a Random password
        public static string GetPassword(int minLength, int maxLength)
        {
            int count = Random.Next(minLength, maxLength);
            int i = Random.Next(0, minLength);
            string password = "";
            while (i < count)
            {
                if (i % 2 == 0)
                {
                    password += SimulationConstants.AlphabetVocalLetterPool[Random.Next(0, SimulationConstants.AlphabetVocalLetterPool.Length)];
                }
                else
                {
                    password += SimulationConstants.AlphabetConsonantLetterPool[Random.Next(0, SimulationConstants.AlphabetConsonantLetterPool.Length)];
                }
                i++;
            }
            password += SimulationConstants.CharacterPool[Random.Next(0, SimulationConstants.CharacterPool.Length)];
            return char.ToUpper(password[0]) + password.Substring(1);
        }

        public static string GetPassword()
        {
            return GetPassword(SimulationConstants.PasswordMinLength, SimulationConstants.PasswordMaxLength);
        }

        // Returns a Random cover letter
        public static string GetCoverLetter()
        {
            //not implemented yet!
            return "";
        }

        // Returns a Random building number
        public static int GetBuildingNumber(byte minBuildingNumber, byte maxBuildingNumber)
        {
            minBuildingNumber = Math.Max(SimulationConstants.MinBuildingNumber, minBuildingNumber);
            maxBuildingNumber = Math.Min(SimulationConstants.MaxBuildingNumber, maxBuildingNumber);

            return (byte)Random.Next(minBuildingNumber, maxBuildingNumber + 1);
        }

        // Returns a Random apartment number
        public static int GetApartmentNumber(byte minApartmentNumber, byte maxApartmentNumber)
        {
            minApartmentNumber = Math.Max(SimulationConstants.MinApartmentNumber, minApartmentNumber);
            maxApartmentNumber = Math.Min(SimulationConstants.MaxApartmentNumber, maxApartmentNumber);

            return (byte)Random.Next(minApartmentNumber, maxApartmentNumber + 1);
        }
    }
}
