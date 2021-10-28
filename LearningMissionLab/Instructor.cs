using System;
using System.Collections.Generic;

namespace LearningMissionLab
{
    /// <summary>
    /// Class: Instructor
    /// Purpose: Provides a model for Learning Mission user instructor 
    /// </summary>
    public class Instructor:Profile
    {
        List<Module> _moduleList;
        List<Classroom> _classroomList;
        Schedule _scheule;
        public Instructor(List<Module> moduleList, List<Classroom> classroomsList, Schedule schedule, string firstName,
                          string lastName, ContactInfo contactInfo):base(firstName, lastName, contactInfo)
        {
            this._moduleList = moduleList;
            this._classroomList = classroomsList;
            this._scheule = schedule;
        }

        public List<Module> ModuleList { get => _moduleList; set => _moduleList = value; }
        public List<Classroom> ClassroomList { get => _classroomList; set => _classroomList = value; }
        public Schedule Scheule { get => _scheule; set => _scheule = value; }
    }
}
