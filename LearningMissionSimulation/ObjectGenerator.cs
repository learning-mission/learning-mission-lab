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
            //not implemented yet!
            return null;

        }

        public static List<Student> GenerateStudentPool(uint studentCount)
        {
            List<Student> studentList = new List<Student>();

            //not implemented yet!
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
            return new Account(AttributeGenerator.GetUsername(), AttributeGenerator.GetPassword(8, 20), AttributeGenerator.GetEmail(),
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
        
        public static Language GenerateLanguage()
        {
            return new Language(AttributeGenerator.GetLanguageName(), AttributeGenerator.GetLanguageLevel());
        }
        
        public static List<Language> GenerateLanguagePool(uint languageCount)
        {
            List<Language> languageList = new List<Language>();
            int i = 0;
            while (i < languageCount)
            {
                languageList.Add(GenerateLanguage());
                i++;
            }
            return languageList;
        }
    }
}
