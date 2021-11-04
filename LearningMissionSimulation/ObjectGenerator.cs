using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class ObjectGenerator
    {
        static HashSet<string> emailNameSet = new HashSet<string>();

        public static Student GenerateStudent()
        {
            return new Student(coverLetter: AttributeGenerator.GetCoverLetter(),recommendationList: new List<string>(), 
                   completedModuleList: new List<Module>(), classroomList: new List<Classroom>(),
                   schedule: new Schedule(), firstName: AttributeGenerator.GetFirstName(), lastName: AttributeGenerator.GetLastName(),
                   contactInfo: new ContactInfo(new Address(AttributeGenerator.GetStreetAddress(), buildingNumber: AttributeGenerator.GetBuildingNumber(),
                   apartmentNumber: AttributeGenerator.GetApartmentNumber(), city: AttributeGenerator.GetCity("0001"), province: AttributeGenerator.GetProvince(),
                   postalCode: AttributeGenerator.GetPostalCode(), country: AttributeGenerator.GetCountry()), email: AttributeGenerator.GetEmail(),
                   homePhone: AttributeGenerator.GetPhoneNumber(), workPhone: AttributeGenerator.GetPhoneNumber(), cellPhone: AttributeGenerator.GetPhoneNumber()));
        }

        public static List<Student> GenerateStudentPool(uint studentCount)
        {
            List<Student> studentList = new List<Student>();
            int i = 0;
            while (i < studentCount)
            {
                studentList.Add(GenerateStudent());
                i++;
            }
            return studentList;
        }

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

        public static Account GenerateAccount()
        {
            return new Account(AttributeGenerator.GetUsername(), AttributeGenerator.GetPassword(), AttributeGenerator.GetEmail(),
                               AttributeGenerator.GetPhoneNumber(), AttributeGenerator.GetRole(), AttributeGenerator.GetStatus());

        }

        public static List<Account> GenerateAccountPool(uint accountCount)
        {
            List<Account> accountList = new List<Account>();
            for(int i = 0; i < accountCount; i++)
            {
                accountList.Add(GenerateAccount());
            }
            return accountList;
        }

        public static Profile GenerateProfile()
        {
            return new Profile(firstName: AttributeGenerator.GetFirstName(), lastName: AttributeGenerator.GetLastName(),
                               dateOfBirth: AttributeGenerator.GetDateOfBirth(18, 70), gender: AttributeGenerator.GetGender()); 
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
        
        public static Language GenerateLanguage()
        {
            return new Language(languageName: AttributeGenerator.GetLanguageName(), languageLevel: AttributeGenerator.GetLanguageLevel());
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
