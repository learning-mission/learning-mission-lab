using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab.Models
{
    public class Resume
    {
        Guid _accountId;
        string _firstName;
        string _lastName;
        DateTime _birthDate;
        string _birthPlace;
        ContactInfo _contactInfo;
        List<SocialNetwork> _socialNetworkList;
        List<WorkExperience> _workExperienceList;
        List<Education> _educationList;
        List<Skill> _skillList;
        List<Language> _languageList;
        List<string> _interestList;

        public Resume() {}

        public Resume
        (
            Guid accountId,
            string firstName,
            string lastName,
            DateTime birthDate,
            string birthPlace,
            ContactInfo contactInfo,
            List<SocialNetwork> socialNetworkList,
            List<WorkExperience> workExperienceList,
            List<Education> educationList,
            List<Skill> skillList,
            List<Language> languageList,
            List<string> interestList
        )
        {
            this.AccountId = accountId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.BirthPlace = birthPlace;
            this.ContactInfo = contactInfo;
            this.SocialNetworkList = socialNetworkList;
            this.WorkExperienceList = workExperienceList;
            this.EducationList = educationList;
            this.SkillList = skillList;
            this.LanguageList = languageList;
            this.InterestList = interestList;
        }

        public Guid AccountId { get => _accountId; private set => _accountId = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }
        public string BirthPlace { get => _birthPlace; set => _birthPlace = value; }
        public ContactInfo ContactInfo { get => _contactInfo; set => _contactInfo = value; }
        public List<SocialNetwork> SocialNetworkList { get => _socialNetworkList; set => _socialNetworkList = value; }
        public List<WorkExperience> WorkExperienceList { get => _workExperienceList; set => _workExperienceList = value; }
        public List<Education> EducationList { get => _educationList; set => _educationList = value; }
        public List<Skill> SkillList { get => _skillList; set => _skillList = value; }
        public List<Language> LanguageList { get => _languageList; set => _languageList = value; }
        public List<string> InterestList { get => _interestList; set => _interestList = value; }
    }
}
