using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class Resume
    {
        readonly Guid _resumeId;
        string _firstName;
        string _lastName;
        DateTime _birthDate;
        string _birthPlace;
        ContactInfo _contactInfo;
        List<WorkExperience> _workExperienceList;
        List<Education> _educationList;
        HashSet<Skill> _skillsHashSet;
        HashSet<Language> _languageHashSet;
        HashSet<string> _interestList;

        public Resume() {}

        public Resume
        (
            Guid resumeId,
            string firstName,
            string lastName,
            DateTime birthDate,
            string birthPlace,
            ContactInfo contactInfo,
            List<WorkExperience> workExperienceList,
            List<Education> educationList,
            HashSet<Skill> skillsHashSet,
            HashSet<Language> languageHashSet,
            HashSet<string> interestList
        )
        {
            this._resumeId = resumeId;
            this._firstName = firstName;
            this._lastName = lastName;
            this._birthDate = birthDate;
            this._birthPlace = birthPlace;
            this._contactInfo = contactInfo;
            this._workExperienceList = workExperienceList;
            this._educationList = educationList;
            this._skillsHashSet = skillsHashSet;
            this._languageHashSet = languageHashSet;
            this._interestList = interestList;
        }

        public Guid ResumeId => _resumeId;
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }
        public string BirthPlace { get => _birthPlace; set => _birthPlace = value; }
        public ContactInfo ContactInfo { get => _contactInfo; set => _contactInfo = value; }
        public List<WorkExperience> WorkExperienceList { get => _workExperienceList; set => _workExperienceList = value; }
        public List<Education> EducationList { get => _educationList; set => _educationList = value; }
        public HashSet<Skill> SkillsHashSet { get => _skillsHashSet; set => _skillsHashSet = value; }
        public HashSet<Language> LanguageHashSet { get => _languageHashSet; set => _languageHashSet = value; }
        public HashSet<string> InterestList { get => _interestList; set => _interestList = value; }
    }
}
