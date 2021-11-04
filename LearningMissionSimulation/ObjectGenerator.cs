using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class ObjectGenerator
    {
        static HashSet<string> emailNameSet = new HashSet<string>();
        static Random random = new Random();

        //public static Student GenerateStudent()
        //{
        //    return new Student(AttributeGenerator.GetCoverLetter(), new List<string>(), new List<Module>(), new List<Classroom>(),
        //           new Schedule(), AttributeGenerator.GetFirstName(), AttributeGenerator.GetLastName(),
        //           new ContactInfo(new Address(AttributeGenerator.GetStreetAddress(), AttributeGenerator.GetBuildingNumber(),
        //           AttributeGenerator.GetApartmentNumber(), AttributeGenerator.GetCity("0531"), AttributeGenerator.GetProvince(),
        //           AttributeGenerator.GetPostalCode(), AttributeGenerator.GetCountry()), AttributeGenerator.GetEmail(),
        //           AttributeGenerator.GetPhoneNumber(), AttributeGenerator.GetPhoneNumber(), AttributeGenerator.GetPhoneNumber()));
        //}

        //public static List<Student> GenerateStudentPool(uint studentCount)
        //{
        //    List<Student> studentList = new List<Student>();
        //    int i = 0;
        //    while (i < studentCount)
        //    {
        //        studentList.Add(GenerateStudent());
        //        i++;
        //    }
        //    return studentList;
        //}

        public static Instructor GenerateInstructor()
        {
            //not implemented yet!
            return null;

        }

        public static List<Instructor> GenerateInstructorPool(uint instructorCount)
        {
            List<Instructor> instructorList = new List<Instructor>();

            //not implemented yet!
            return instructorList;
        }

        //public static Account GenerateAccount()
        //{
        //    return new Account(AttributeGenerator.GetUsername(), AttributeGenerator.GetPassword(), AttributeGenerator.GetEmail(),
        //                       AttributeGenerator.GetPhoneNumber(), AttributeGenerator.GetRole(), AttributeGenerator.GetStatus());
        //}

        //public static List<Account> GenerateAccountPool(uint accountCount)
        //{
        //    List<Account> accountList = new List<Account>();
        //    for(int i = 0; i < accountCount; i++)
        //    {
        //        accountList.Add(GenerateAccount());
        //    }
        //    return accountList;
        //}

        public static Profile GenerateProfile()
        {
            return new Profile(AttributeGenerator.GetFirstName(), AttributeGenerator.GetLastName(),
                               AttributeGenerator.GetDateOfBirth(18, 70), AttributeGenerator.GetGender()); 
        }

        public static List<Profile> GenerateProfilePool(uint profileCount)
        {
            List<Profile> profileList = new List<Profile>();
            int i = 0;
            while (i < profileCount)
            {
                profileList.Add(GenerateProfile());
                i++;
            }
            return profileList;
        }

        public static Address GenerateAddress()
        {
            // First digit of city and province dictionaries started at 0 to 4
            string firstDigit = random.Next(0, 5).ToString();
            string restCityDigit = random.Next(100, 1000).ToString();
            string finalCityDigit = firstDigit + restCityDigit;
            string finalProvinceDigit = firstDigit + finalCityDigit[1];

            return new Address(
                 AttributeGenerator.GetStreetAddress(),
                 AttributeGenerator.GetCity(finalCityDigit),
                 AttributeGenerator.GetProvince(finalProvinceDigit),
                 AttributeGenerator.GetPostalCode(),
                 AttributeGenerator.GetCountry()
             );
        }

        public static List<Address> GenerateAddressPool(uint addressCount)
        {
            List<Address> addresseList = new List<Address>();

            for (int i = 0; i < addressCount; i++)
            {
                addresseList.Add(GenerateAddress());
            }

            return addresseList;
        }

        public static ContactInfo GenerateContactInfo()
        {
            return new ContactInfo
            (
                GenerateAddress(),
                AttributeGenerator.GetEmail(),
                AttributeGenerator.GetHomeNumber(),
                AttributeGenerator.GetWorkNumber(),
                AttributeGenerator.GetPhoneNumber()
            );
        }

        public static List<ContactInfo> GetContactInfoPool(uint contactInfoCount)
        {
            List<ContactInfo> contactInfoList = new List<ContactInfo>();

            for (int i = 0; i < contactInfoCount; i++)
            {
                contactInfoList.Add(GenerateContactInfo());
            }

            return contactInfoList;
        }

        public static Language GenerateLanguage()
        {
            return new Language(AttributeGenerator.GetLanguageName(), AttributeGenerator.GetLanguageLevel());
        }
        
        public static List<Language> GenerateLanguageList(uint languageCount)
        {
            int languageMaxCount = Enum.GetNames(typeof(LanguageName)).Length-1;
            int count = (int)Math.Min(languageMaxCount, languageCount);
            count = (int)Math.Max(1, count);
            List<Language> languageList = new List<Language>();
            ISet<LanguageName> nameSet = new HashSet<LanguageName>();
            int i = 0;
            while (i < count)
            {
                Language language = GenerateLanguage();
                LanguageName name = language.LanguageName;
                if (!nameSet.Contains(name))
                {
                    languageList.Add(language);
                    nameSet.Add(name);
                }
                i++;
            }
            return languageList;
        }
    }
}
