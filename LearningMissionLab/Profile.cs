using System;
using System.Collections.Generic;

namespace LearningMissionLab
{
    /// <summary>
    /// Class: Profile
    /// Purpose: Provides a model for user profile
    /// </summary>
    public class Profile
    {
        string _firstName;
        string _lastName;  
        string _financialId;
        string _passportId;        
        string _education;
        string _resume;
        string _salary;
        string _militaryId;
        string _family;
        string _occupation;        
        string _stipend;
        string _computerInventory;
        DateTime _createDate;
        DateTime _updateDate;
        DateTime _dateOfBirth;
        Gender _gender;
        ContactInfo _contactInfo;
        List<Language> _languageList;
        public Profile()
        {

        }

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string FinancialId { get => _financialId; set => _financialId = value; }
        public string PassportId { get => _passportId; set => _passportId = value; }
        public string Education { get => _education; set => _education = value; }
        public string Resume { get => _resume; set => _resume = value; }
        public string Salary { get => _salary; set => _salary = value; }
        public string MilitaryId { get => _militaryId; set => _militaryId = value; }
        public string Family { get => _family; set => _family = value; }
        public string Occupation { get => _occupation; set => _occupation = value; }
        public string Stipend { get => _stipend; set => _stipend = value; }
        public string ComputerInventory { get => _computerInventory; set => _computerInventory = value; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime UpdateDate { get => _updateDate; set => _updateDate = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public Gender Gender { get => _gender; set => _gender = value; }
        public ContactInfo ContactInfo { get => _contactInfo; set => _contactInfo = value; }
        public List<Language> LanguageList { get => _languageList; set => _languageList = value; }
    }
}
