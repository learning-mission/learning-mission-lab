using System;
using System.Collections.Generic;
using System.Text;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class AttributeGenerator  
    {
        public static Random random = new Random();
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

        // Returns a random first name
        public static string GetFirstName(int lengthLimit)
        {
            int count = random.Next(2, lengthLimit);
            int i = random.Next(0, 2);
            string name = "";
            while (i < count)
            {
                if (i % 2 == 0)
                {
                    name += SimulationConstants.AlphabetVocalLetterPool[random.Next(0, SimulationConstants.AlphabetVocalLetterPool.Length)];                                                                 
                }
                else
                {
                    name += SimulationConstants.AlphabetConsonantLetterPool[random.Next(0, SimulationConstants.AlphabetConsonantLetterPool.Length)];
                }
                i++;
            }
            return char.ToUpper(name[0]) + name.Substring(1);
        }

        public static string GetFirstName()
        {
            return GetFirstName(8);
        }

        // Returns a random last name
        public static string GetLastName(int lengthLimit)
        {
            return GetFirstName(lengthLimit) + "yan";
        }

        public static string GetLastName()
        {
            return GetLastName(10);
        }

        // Returns a random value from LanguageLevel, LanguageLevel.Unspecified
        // is excluded
        public static LanguageLevel GetLanguageLevel()
        {
            var levelCount = Enum.GetNames(typeof(LanguageLevel)).Length;
            return (LanguageLevel)random.Next(1, levelCount);
        }

        // Returns a random value from LanguageName, LanguageName.Unspecified
        // is excluded
        public static LanguageName GetLanguageName()
        {
            var nameCount = Enum.GetNames(typeof(LanguageName)).Length;
            return (LanguageName)random.Next(1, nameCount);
        }

        // Returns a random value from ModuleLevel, ModuleLevel.Unspecified
        // is excluded
        public static ModuleLevel GetModuleLevel()
        {
            var levelCount = Enum.GetValues(typeof(ModuleLevel)).Length;
            return (ModuleLevel)random.Next(0, levelCount);      
        }

        // Returns a random value from SubjectType, SubjectType.Unspecified
        // is excluded
        public static SubjectType GetSubjecType()
        {
           var levelCount = Enum.GetValues(typeof(SubjectType)).Length;
           return (SubjectType)random.Next(0, levelCount);           
        }

        // Returns a random value from Gender, Gender.Unspecified
        // is excluded
        public static Gender GetGender()
        {
            var genderCount = Enum.GetValues(typeof(Gender)).Length;
            return (Gender)random.Next(1, genderCount); 
        }

        // Returns a random value from DepartmentType, DepartmentType.Unspecified
        // is excluded
        public static DepartmentType GetDepartmentType()
        {
            var departmentTypeCount = Enum.GetValues(typeof(DepartmentType)).Length;
            return (DepartmentType)random.Next(1, departmentTypeCount);
        }

        // Returns a random value from Role, Role.Unspecified
        // is excluded
        public static Role GetRole()
        {
            var roleCount = Enum.GetValues(typeof(Role)).Length;
            return (Role)random.Next(1, roleCount);
        }

        // Returns a random value from Status, Status.Unspecified
        // is excluded
        public static Status GetStatus()
        {
            var statusCount = Enum.GetValues(typeof(Status)).Length;
            return (Status)random.Next(1, statusCount);
        }

        // Returns a random value from EducationalInstitution, EducationalInstitution.Unspecified
        // is excluded
        public static EducationalInstitution GetEducationalInstitution()
        {
            var institutionCount = Enum.GetValues(typeof(EducationalInstitution)).Length;
            return (EducationalInstitution)random.Next(1, institutionCount);
        }

        // Returns a random value from EducationDegree, EducationDegree.Unspecified
        // is excluded
        public static EducationDegree GetEducationDegree()
        {
            var degreeCount = Enum.GetValues(typeof(EducationDegree)).Length;
            return (EducationDegree)random.Next(1, degreeCount);
        }

        // Returns a random value from FieldOfStudy, FieldOfStudy.Unspecified
        // is excluded
        public static FieldOfStudy GetFieldOfStudy()
        {
            var studyCount = Enum.GetValues(typeof(FieldOfStudy)).Length;
            return (FieldOfStudy)random.Next(1, studyCount);
        }

        // Returns a random phone number
        public static string GetPhoneNumber()
        {
            string phoneNumberCode = SimulationConstants.PhoneOperatorCode[random.Next(0, SimulationConstants.PhoneOperatorCode.Length)];
            string mobileNumber = Convert.ToString(random.Next(100000, 1000000));
            var phoneNumber = (SimulationConstants.CountryCode + phoneNumberCode + mobileNumber);
            return phoneNumber;
        }

        // Returns a random email address
        public static string GetEmail()
        {            
            int emailLength = random.Next(5, 12);
            int domainIndex = random.Next(0, SimulationConstants.DomainPool.Count);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= emailLength; i++)
            {
                int letterIndex = random.Next(0, SimulationConstants.LetterPool.Length);
                stringBuilder.Append(SimulationConstants.LetterPool[letterIndex]);
            }
            return stringBuilder.Append(SimulationConstants.DomainPool[domainIndex]).ToString();
        }

        // Returns a random street address
        public static string GetStreetName()
        {
            //not implemented yet!
            return "";
        }

        public static string GetTwoDigitCode(int maxLimit)
        {
            string postalCode = "";
            int range = random.Next(0, maxLimit);

            postalCode = range < 10 ? "0" + range.ToString() : range.ToString();

            return postalCode;
        }

        // Returns a random postal code
        public static string GetPostalCode()
        {
            string postalCode = GetTwoDigitCode(43) + GetTwoDigitCode(20);

            while (!SimulationConstants.CityDictionary.ContainsKey(postalCode))
            {
                postalCode = GetTwoDigitCode(43) + GetTwoDigitCode(20);
            }

            Console.WriteLine($"Postal Code: {postalCode}");

            return postalCode;
        }

        // Returns a random city name
        public static string GetCity(string postalCode)
        {
            if (SimulationConstants.CityDictionary.ContainsKey(postalCode))
            {
                string cityName;

                SimulationConstants.CityDictionary.TryGetValue(postalCode, out cityName);

                Console.WriteLine($"City Name: {cityName}");

                return cityName;
            }

            return null;
        }

        // Returns a random province name
        public static string GetProvince(string postalCode)
        {
            if (SimulationConstants.ProvinceDictionary.ContainsKey(postalCode.Substring(0, 2)))
            {
                string provinceName;

                SimulationConstants.ProvinceDictionary.TryGetValue(postalCode.Substring(0, 2), out provinceName);

                Console.WriteLine($"Province Name: {provinceName}");

                return provinceName;
            }

            return null;
        }

        // Returns a random country name
        public static string GetCountry()
        {
            //not implemented yet!
            return "";
        }

        // Returns a random username
        public static string GetUsername()
        {
            string username = GetFirstName();
            int endOfusername = random.Next(0, 10000);
            return username + "-" + Convert.ToString(endOfusername);
        }

        // Returns a random password
        public static string GetPassword(int minLength, int maxLength)
        {
            int count = random.Next(minLength, maxLength);
            int i = 0;
            string password = "";
            while (i < count)
            {
                if (i % 2 == 0)
                {
                    password += SimulationConstants.AlphabetVocalLetterPool[random.Next(0, SimulationConstants.AlphabetVocalLetterPool.Length)];
                }
                else
                {
                    password += SimulationConstants.AlphabetConsonantLetterPool[random.Next(0, SimulationConstants.AlphabetConsonantLetterPool.Length)];
                }
                i++;
            }
            password += SimulationConstants.CharacterPool[random.Next(0, SimulationConstants.CharacterPool.Length)];
            return char.ToUpper(password[0]) + password.Substring(1);
        }

        public static string GetPassword()
        {
            return GetPassword(SimulationConstants.PasswordMinLength, SimulationConstants.PasswordMaxLength);
        }

        // Returns a random cover letter
        public static string GetCoverLetter()
        {
            //not implemented yet!
            return "";
        }
        public static string GetUnitName(UnitType unitType)
        {
            return  unitType + "Name" + random.Next(1000, 10000);            
        }
        public static string GetUnitDescprition(UnitType unitType)
        {          
            return unitType + "Description" + random.Next(1000, 10000);
        }

        // Returns a random building number
        public static int GetBuildingNumber()
        {
            return (byte)random.Next(SimulationConstants.MinBuildingNumber, SimulationConstants.MaxBuildingNumber + 1);
        }

        // Returns a random apartment number
        public static int GetApartmentNumber()
        {
            return (byte)random.Next(SimulationConstants.MinApartmentNumber, SimulationConstants.MaxApartmentNumber + 1);
        }
    }
}
