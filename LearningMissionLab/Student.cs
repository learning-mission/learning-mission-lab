using System;
using System.Collections.Generic;

namespace LearningMissionLab
{
    /// <summary>
    /// Class: Student
    /// Purpose: Provides a model for student
    /// </summary>
    public class Student : Profile
    {
        string _coverLetter;
        List<string> _recommendationList;
        List<Module> _completedModuleList;
        List<Classroom> _classroomList;
        Schedule _schedule;
        public Student(Guid accountId, string coverLetter, List<string> recommendationList, List<Module> completedModuleList, List<Classroom> classroomList,
            Schedule schedule, string firstName, string lastName, ContactInfo contactInfo)
                       : base(accountId, firstName, lastName, contactInfo)
        {
            this._coverLetter = coverLetter;
            this._recommendationList = recommendationList;
            this._completedModuleList = completedModuleList;
            this._classroomList = classroomList;
            this._schedule = schedule;
        }
       
        public string CoverLetter { get => _coverLetter; set => _coverLetter = value; }
        public List<string> RecommendationList { get => _recommendationList; set => _recommendationList = value; }
        public List<Module> CompletedModuleList { get => _completedModuleList; set => _completedModuleList = value; }        
        public Schedule Schedule { get => _schedule; set => _schedule = value; }
        public List<Classroom> ClassroomList { get => _classroomList; set => _classroomList = value; }

        public override string ToString()
        {
            return $" Cover letter is {CoverLetter}\n Recommendation list {RecommendationList}\n " +
                   $"Completed module {CompletedModuleList}\n Schedule is {Schedule}\n Classroom list is {ClassroomList} ";
        }
      
    }
}
