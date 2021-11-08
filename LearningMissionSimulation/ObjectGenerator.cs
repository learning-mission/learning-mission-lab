using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class ObjectGenerator
    {
        // Creates a Student object with randomly selected attributes
        public static Student GenerateStudent(Guid accountId)
        {
            return new Student(accountId: accountId, coverLetter: AttributeGenerator.GetCoverLetter(), recommendationList: GenerateRecommendationList(),
                               completedModuleList: GenerateModuleList(), classroomList: GenerateClassroomList(), schedule: GenerateSchedule(),
                               firstName: AttributeGenerator.GetFirstName(), lastName: AttributeGenerator.GetLastName(), contactInfo:GenerateContactInfo());
        }

        // Creates an Instructor object with randomly selected attributes
        public static Instructor GenerateInstructor(Guid accountId)
        {
            return new Instructor(accountId: accountId, moduleList:GenerateModuleList(), classroomsList: GenerateClassroomList(), schedule: GenerateSchedule(),
                                  firstName: AttributeGenerator.GetFirstName(), lastName: AttributeGenerator.GetLastName(), contactInfo: GenerateContactInfo());

        }

        // Creates an Account object with randomly selected attributes
        public static Account GenerateAccount()
        {
            Account account =  new Account(AttributeGenerator.GetUsername(), AttributeGenerator.GetPassword(), AttributeGenerator.GetEmail(),
                               AttributeGenerator.GetPhoneNumber(), AttributeGenerator.GetRole(), AttributeGenerator.GetStatus());
            account.Report();
            return account;
        }

        // Creates a Profile object with randomly selected attributes
        public static Profile GenerateProfile(Guid accountId)
        {
            return new Profile(accountId: accountId, firstName: AttributeGenerator.GetFirstName(), lastName: AttributeGenerator.GetLastName(),
                               dateOfBirth: AttributeGenerator.GetDateOfBirth(18, 70), gender: AttributeGenerator.GetGender());
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
            string postalCode = AttributeGenerator.GetPostalCode();

            return new Address(
                 AttributeGenerator.GetStreetAddress(),
                 AttributeGenerator.GetBuildingNumber(),
                 AttributeGenerator.GetApartmentNumber(),
                 AttributeGenerator.GetCity(postalCode),
                 AttributeGenerator.GetProvince(postalCode),
                 AttributeGenerator.GetPostalCode(),
                 AttributeGenerator.GetCountry()
             );
        }

        // Creates a ContactInfo object with randomly selected attributes
        public static ContactInfo GenerateContactInfo()
        {
            return new ContactInfo(
                address: GenerateAddress(),
                email: AttributeGenerator.GetEmail(),
                homePhone: AttributeGenerator.GetPhoneNumber(),
                workPhone: AttributeGenerator.GetPhoneNumber(),
                cellPhone: AttributeGenerator.GetPhoneNumber()
            );
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

        // Creates a random list of Classroom objects
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
