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
        string _position;
        string _cityName;
        List<Project> _projectList;

        public WorkExperience() {}
        
        public WorkExperience
        (
            DateTime startDate,
            DateTime endDate,
            string companyName,
            string position,
            string cityName,
            List<Project> projectList
        )
        {
            this._startDate = startDate;
            this._endDate = endDate;
            this._companyName = companyName;
            this._position = position;
            this._cityName = cityName;
            this._projectList = projectList;
        }

        public List<Project> ProjectList { get => _projectList; set => _projectList = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public string CompanyName { get => _companyName; set => _companyName = value; }
        public string CityName { get => _cityName; set => _cityName = value; }
        public string Position { get => _position; set => _position = value; }
    }
}
