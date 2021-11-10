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
                               completedModuleList: GenerateModuleList(3), classroomList: GenerateClassroomList(), schedule: GenerateSchedule(),
                               firstName: AttributeGenerator.GetFirstName(), lastName: AttributeGenerator.GetLastName(),
                               dateOfBirth: AttributeGenerator.GetDateOfBirth(SimulationConstants.ApplicantMinAge, SimulationConstants.ApplicantMaxAge),
                               gender: AttributeGenerator.GetGender(), contactInfo:GenerateContactInfo(), languageList: GenerateLanguageList(5));
        }

        // Creates an Instructor object with randomly selected attributes
        public static Instructor GenerateInstructor(Guid accountId)
        {
            return new Instructor(accountId: accountId, moduleList:GenerateModuleList(3), classroomsList: GenerateClassroomList(),
                                  schedule: GenerateSchedule(), firstName: AttributeGenerator.GetFirstName(), lastName: AttributeGenerator.GetLastName(),
                                  dateOfBirth: AttributeGenerator.GetDateOfBirth(SimulationConstants.ApplicantMinAge, SimulationConstants.ApplicantMaxAge),
                                  gender: AttributeGenerator.GetGender(), contactInfo: GenerateContactInfo(), languageList: GenerateLanguageList(2));

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
                               dateOfBirth: AttributeGenerator.GetDateOfBirth(18, 70), gender: AttributeGenerator.GetGender(),
                               contactInfo: GenerateContactInfo(), languageList: GenerateLanguageList(2));
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
                 streetName: AttributeGenerator.GetStreetName(),
                 buildingNumber: AttributeGenerator.GetBuildingNumber(),
                 apartmentNumber: AttributeGenerator.GetApartmentNumber(),
                 city: AttributeGenerator.GetCity(postalCode),
                 province: AttributeGenerator.GetProvince(postalCode),
                 postalCode: AttributeGenerator.GetPostalCode(),
                 country: AttributeGenerator.GetCountry()
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

        // Creates a random Module object
        public static Module GenerateModule(Guid subjectId)
        {
            return new Module(subjectId: subjectId, moduleLevel: AttributeGenerator.GetModuleLevel(), prerequisiteList: GenerateModuleList(3),
                              name: AttributeGenerator.GetUnitName(UnitType.Module), description: AttributeGenerator.GetUnitDescprition(UnitType.Module),
                              itemList: new List<Lesson>());
        }

        // Creates a random list of Module objects
        public static List<Module> GenerateModuleList(int moduleListCount)
        {
            //not implemented yet!
            return new List<Module>();
        }

        // Creates a random Subject object
        public static Subject GenerateSubject()
        {
            return new Subject(subjectType: AttributeGenerator.GetSubjecType(), description: AttributeGenerator.GetUnitDescprition(UnitType.Subject),
                               name: AttributeGenerator.GetUnitName(UnitType.Subject), itemList: ObjectGenerator.GenerateModuleList(3));
        }
    }
}
