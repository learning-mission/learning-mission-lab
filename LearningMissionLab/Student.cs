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
        List<String> _recommendationList;
        List<Module> _completedModuleList;
        List<Student> _classroomList;
        Schedule _schedule;
        public Student(string coverLetter, List<String> recommendationList, List<Module> completedModuleList, List<Student> classroomList, Schedule schedule)
                       : base()
        {
            this._coverLetter = coverLetter;
            this._recommendationList = recommendationList;
            this._completedModuleList = completedModuleList;
            this._classroomList = classroomList;
            this._schedule = schedule;
        }
        public Student()
        {

        }


        public string CoverLetter { get => _coverLetter; set => _coverLetter = value; }
        public List<String> RecommendationList { get => _recommendationList; set => _recommendationList = value; }
        public List<Module> ComplatedModuleList { get => _completedModuleList; set => _completedModuleList = value; }        
        public Schedule Schedule { get => _schedule; set => _schedule = value; }
        public List<Student> ClassroomList { get => _classroomList; set => _classroomList = value; }
    }
}
