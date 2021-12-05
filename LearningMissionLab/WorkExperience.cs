using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class WorkExperience
    {
        DateTime _startDate;
        DateTime _endDate;
        string _companyName;
        string _occupation;
        ContactInfo _contactInfo;
        List<Project> _projectList;

        public WorkExperience() {}
        
        public WorkExperience
        (
            DateTime startDate,
            DateTime endDate,
            string companyName,
            string occupation,
            ContactInfo contactInfo,
            List<Project> projectList
        )
        {
            this._startDate = startDate;
            this._endDate = endDate;
            this._companyName = companyName;
            this._occupation = occupation;
            this._contactInfo = contactInfo;
            this._projectList = projectList;
        }

        public List<Project> ProjectList { get => _projectList; set => _projectList = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public string CompanyName { get => _companyName; set => _companyName = value; }
        public ContactInfo ContactInfo { get => _contactInfo; set => _contactInfo = value; }
        public string Occupation { get => _occupation; set => _occupation = value; }
    }
}
