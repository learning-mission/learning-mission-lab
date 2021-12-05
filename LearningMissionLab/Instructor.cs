using System;
using System.Collections.Generic;

namespace LearningMissionLab
{
    /// <summary>
    /// Class: Instructor
    /// Purpose: Provides a model for Learning Mission instructor 
    /// </summary>
    public class Instructor : Profile
    {
        List<Module> _moduleList;
        List<Classroom> _classroomList;
        Schedule _schedule;


        public   Instructor(Guid accountId, List<Module> moduleList, List<Classroom> classroomsList, Schedule schedule, string firstName,
                          string lastName, DateTime dateOfBirth, Gender gender, ContactInfo contactInfo, List<Language> languageList)
                         : base(accountId, firstName, lastName, dateOfBirth, gender, contactInfo, languageList)
        {
            this._moduleList = moduleList;
            this._classroomList = classroomsList;
            this._schedule = schedule;
        }

        public List<Module> ModuleList { get => _moduleList; set => _moduleList = value; }
        public List<Classroom> ClassroomList { get => _classroomList; set => _classroomList = value; }
        public Schedule Schedule { get => _schedule; set => _schedule = value; }
        
    }
}
