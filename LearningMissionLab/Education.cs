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
            this.EducationalInstitution = educationalInstitution;
            this.EducationDegree = educationDegree;
            this.FieldOfStudy = fieldOfStudy;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public EducationalInstitution EducationalInstitution { get => _educationalInstitution; set => _educationalInstitution = value; }
        public EducationDegree EducationDegree { get => _educationDegree; set => _educationDegree = value; }
        public FieldOfStudy FieldOfStudy { get => _fieldOfStudy; set => _fieldOfStudy = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
    }
}
