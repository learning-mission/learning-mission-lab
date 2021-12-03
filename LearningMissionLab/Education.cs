using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class Education
    {
        EducationalInstitution _educationalInstitution;
        EducationDegree _educationDegree;
        FieldOfStudy _fieldOfStudy;
        DateTime _startDate;
        DateTime _endDate;

        public Education() {}

        public Education
        (
            EducationalInstitution educationalInstitution,
            EducationDegree educationDegree,
            FieldOfStudy fieldOfStudy,
            DateTime startDate,
            DateTime endDate
        )
        {
            this._educationalInstitution = educationalInstitution;
            this._educationDegree = educationDegree;
            this._fieldOfStudy = fieldOfStudy;
            this._startDate = startDate;
            this._endDate = endDate;
        }

        public EducationalInstitution EducationalInstitution { get => _educationalInstitution; set => _educationalInstitution = value; }
        public EducationDegree EducationDegree { get => _educationDegree; set => _educationDegree = value; }
        public FieldOfStudy FieldOfStudy { get => _fieldOfStudy; set => _fieldOfStudy = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
    }
}
