using System;
using System.Collections.Generic;

namespace LearningMissionLab
{
    /// <summary>
    /// Class: Profile
    /// Purpose: Provides a model for user profile
    /// </summary>
    public class Profile : IReport
    {
        readonly Guid _id;
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
        public Profile(Guid id, string firstName, string lastName, string financialId, string passportId, string education,
                       string resume, string salary, string militaryId, string family, string occupation,string stipend,
                       string computerInventory, DateTime createDate, DateTime updateDate, DateTime dateOfBirth,
                       Gender gender, ContactInfo contactInfo, List<Language> languageList)
        {
            this._id = id;
            this._firstName = firstName;
            this._lastName = lastName;
            this._financialId = financialId;
            this._passportId = passportId;
            this._education = education;
            this._resume = resume;
            this._salary = salary;
            this._militaryId = militaryId;
            this._family = family;
            this._occupation = occupation;
            this._stipend = stipend;
            this._computerInventory = computerInventory;
            this._createDate = createDate;
            this._updateDate = updateDate;
            this._dateOfBirth = dateOfBirth;
            this._gender = gender;
            this._contactInfo = contactInfo;
            this._languageList = languageList;
        }
        public Profile(string firstName, string lastName, ContactInfo contactInfo)
        {
            this._id = GetGuid();
            this._firstName = firstName;
            this._lastName = lastName;
            this._contactInfo = contactInfo;
            this._createDate = DateTime.UtcNow;
        }
        public Guid Id => _id;
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
        public static Guid GetGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid;
        }
        public void Report()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return $" Id is {Id}, First Name is {FirstName}, Last Name is {LastName}, Financial Id is {FinancialId}," +
                   $" Passport Id is {PassportId}, Education is {Education}, Resume is {Resume}, Salary is {Salary}," +
                   $" Military Id is {MilitaryId}, Family is {Family}, Occupation is {Occupation}, Stipend is {Stipend}," +
                   $" Computer Inventory is {ComputerInventory}, Create Date is {CreateDate}, Update Date is {UpdateDate}," +
                   $" Date Of Birth is {DateOfBirth}, Gender is {Gender}, Contact Info is {ContactInfo}, " +
                   $" Language List is {LanguageList} ";
        }
        public string GetLastName()
        {
            return _lastName;
        }
        public string GetLastName1
        {
            set
            {
                _lastName = value;
            }
            get
            {
                return _lastName;
            }
        }
        public string GetFirstName()
        {
            return _firstName;
        }
        public string GetFirstName1
        {
            set
            {
                _firstName = value;
            }
            get
            {
                return _firstName;
            }
        }
        public DateTime GetDateOfBirth()
        {
            return _dateOfBirth;
        }
        public DateTime GetDateOfBirth1
        {
            set
            {
                _dateOfBirth = value;
            }
            get
            {
                return _dateOfBirth ;
            }
        }
       
    }
}
