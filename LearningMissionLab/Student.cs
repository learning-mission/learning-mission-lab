using System;
using System.Collections.Generic;

namespace LearningMissionLab
{
    /// <summary>
    /// Class: Student
    /// Purpose: Provides a model for user student
    /// </summary>
    public class Student : Profile
    {
        string _coverLetter;
        List<Student> _recommendationList;
        List<Student> _complatedModuleList;
        List<Student> _classroomList;
        Schedule _schedule;
        public Student(string coverLetter, List<Student> recommendationList, List<Student> complatedModuleList, List<Student> classroomList, Schedule schedule)
                       : base()
        {
            this._coverLetter = coverLetter;
            this._recommendationList = recommendationList;
            this._complatedModuleList = complatedModuleList;
            this._classroomList = classroomList;
            this._schedule = schedule;
        }
        public Student()
        {

        }


        public string CoverLetter { get => _coverLetter; set => _coverLetter = value; }
        public List<Student> RecommendationList { get => _recommendationList; set => _recommendationList = value; }
        public List<Student> ComplatedModuleList { get => _complatedModuleList; set => _complatedModuleList = value; }
        public List<Student> ClassroomList { get => _classroomList; set => _classroomList = value; }
        public Schedule Schedule { get => _schedule; set => _schedule = value; }
    }
}
