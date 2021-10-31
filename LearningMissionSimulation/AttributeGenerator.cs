using System;
using System.Collections.Generic;
using System.Text;
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

        static readonly char[] alphabets = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
                                             'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

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
            //not implemented yet!
            return "";
        }
        
        public static string GetEmail()
        {
            //not implemented yet!
            Random _r = new Random();
            int _emailLength=_r.Next(5, 12);
            var _EndOfEmail = new List<string>()
            {"@email.ru", "@gmail.com", "@yahoo.com", "@yandex.ru"};
            int _index = _r.Next(0,_EndOfEmail.Count);
            StringBuilder _stringBuilder = new StringBuilder();
            for(int i=0; i<=_emailLength; i++)
            {
                int indexOfAlphabet = _r.Next(0, alphabets.Length);
                _stringBuilder.Append(alphabets[indexOfAlphabet]);
            }
            return _stringBuilder.Append(_EndOfEmail[_index]).ToString();
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
