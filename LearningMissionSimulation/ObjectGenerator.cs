using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class ObjectGenerator
    {

        // Creates a Student object with randomly selected attributes
        public static Student GenerateStudent()
        {
            return new Student(coverLetter: AttributeGenerator.GetCoverLetter(), recommendationList: GenerateRecommendationList(),
                               completedModuleList: GenerateModuleList(), classroomList: GenerateClassroomList(), schedule: GenerateSchedule(), 
                               firstName: AttributeGenerator.GetFirstName(), lastName: AttributeGenerator.GetLastName(), contactInfo: GenerateContactInfo());
        }

        // Creates a random list of Student objects
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

        // Creates an Instructor object with randomly selected attributes
        public static Instructor GenerateInstructor()
        {
            return new Instructor(moduleList: GenerateModuleList(), classroomsList: GenerateClassroomList(), schedule: GenerateSchedule(), 
                                  firstName: AttributeGenerator.GetFirstName(), lastName: AttributeGenerator.GetLastName(), contactInfo: GenerateContactInfo());

        }

        // Creates a random list of Instructor objects
        public static List<Instructor> GenerateInstructorPool(uint instructorCount)
        {
            List<Instructor> instructorList = new List<Instructor>();
            int i = 0;
            while (i < instructorCount)
            {
                instructorList.Add(GenerateInstructor());
                i++;
            }
            return instructorList;
        }

        // Creates an Account object with randomly selected attributes
        public static Account GenerateAccount()
        {
            return new Account(AttributeGenerator.GetUsername(), AttributeGenerator.GetPassword(), AttributeGenerator.GetEmail(),
                               AttributeGenerator.GetPhoneNumber(), AttributeGenerator.GetRole(), AttributeGenerator.GetStatus());

        }

        // Creates a random list of Account objects
        public static List<Account> GenerateAccountPool(uint accountCount)
        {
            List<Account> accountList = new List<Account>();
            for (int i = 0; i < accountCount; i++)
            {
                accountList.Add(GenerateAccount());
            }
            return accountList;
        }

        // Creates a Profile object with randomly selected attributes
        public static Profile GenerateProfile()
        {
            return new Profile(firstName: AttributeGenerator.GetFirstName(), lastName: AttributeGenerator.GetLastName(),
                               dateOfBirth: AttributeGenerator.GetDateOfBirth(18, 70), gender: AttributeGenerator.GetGender());
        }

        // Creates a random list of Profile objects
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

        // Creates a Language object with randomly selected attributes
        public static Language GenerateLanguage()
        {
            return new Language(languageName: AttributeGenerator.GetLanguageName(), languageLevel: AttributeGenerator.GetLanguageLevel());
        }

        // Creates a random list of Language objects
        public static List<Language> GenerateLanguageList(uint languageCount)
        {
            int languageMaxCount = Enum.GetNames(typeof(LanguageName)).Length - 1;
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

        // Creates an Address object with randomly selected attributes
        public static Address GenerateAddress()
        {
            //not implemented yet!
            return null;
        }

        // Creates a ContactInfo object with randomly selected attributes
        public static ContactInfo GenerateContactInfo()
        {
            //not implemented yet!
            return null;
        }

        // Creates a Schedule object with randomly selected attributes
        public static Schedule GenerateSchedule()
        {
            //not implemented yet!
            return null;
        }

        // Creates a random list of recommendations
        public static List<string> GenerateRecommendationList()
        {
            //not implemented yet!
            return new List<string>();
        }

        // Creates a random list of Classroom objects
        public static Classroom GenerateClassroom()
        {
            //not implemented yet!
            return null;
        }

        // Creates a random list of classroomList
        public static List<Classroom> GenerateClassroomList()
        {
            //not implemented yet!
            return new List<Classroom>();
        }

        // Creates a random list of Module objects
        public static List<Module> GenerateModuleList()
        {
            //not implemented yet!
            return new List<Module>();
        }
    }
}
