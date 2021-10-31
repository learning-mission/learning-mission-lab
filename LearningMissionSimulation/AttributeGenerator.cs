using System;
using LearningMissionLab;
namespace LearningMissionSimulation
{
    public class AttributeGenerator
    {
        // Minimum valid applicant age
        static readonly byte APPLICANT_MIN_AGE = 18;
        // Maximum valid applicant age
        static readonly byte APPLICANT_MAX_AGE = 70;
        static readonly string[] syllables = { "Ab", "Saa", "Levo", "Pari", "Rub", "Ask",
            "Mam", "Ket", "Zar", "Luci", "Ter", "Ova", "Sar", "Vol", "Ver" };

        static readonly string[] maleNames = { "Sevak", "Mher", "Arevshat",
            "Garush", "Karen", "Smbat", "Rouben", "Garegin", "Vahe", "Eduard",
            "Gavril", "Suren", "Arkadij" };

        static readonly string[] femaleNames = { "Nina", "Karine", "Margarita",
            "Narine", "Nane", "Marina", "Lilit", "Yelena" };

        /// <summary>Generates random date of birth values within the specified age range./>
        /// <param name="minAge">The minimum age.</param>
        /// <param name="maxAge">The maximum age.</param>
        /// <returns>The DateTime value within specified range.</returns>
        public static DateTime GetDateOfBirth(byte minAge, byte maxAge)
        {
            // input's validation: check age limits, make sure their within
            // the allowed range

            minAge = Math.Max(APPLICANT_MIN_AGE, minAge);
            maxAge = Math.Min(APPLICANT_MAX_AGE, maxAge);

            //not implemented yet!

            return DateTime.Now;
        }

        public static string GetLastName()
        {
            //not implemented yet!
            return "";
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
            //not implemented yet!
            return Gender.Unspecified;
        }

        public static DepartmentType GetDepartmentType()
        {
            //not implemented yet!
            return DepartmentType.Unspecified;
        }

        public static Role GetRole()
        {
            //not implemented yet!
            return Role.Unspecified;
        }

        public static Status GetStatus()
        {
            //not implemented yet!
            return Status.Unspecified;
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
