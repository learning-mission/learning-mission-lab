using System;
using System.Collections.Generic;

namespace LearningMissionLab
{
    public class Module: Unit<Lesson>
    {
        string subjectID;
        ModuleLevel moduleLevel;
        List<ModuleLevel> ListOfPrerequisites = new List<ModuleLevel>();
                   

        public Module(string subjectID, ModuleLevel moduleLevel, List<ModuleLevel> listOfPrerequisites)
            :base (subjectID, moduleLevel,listOfPrerequisites)
        {
           
            this.subjectID = subjectID;
            this.moduleLevel = moduleLevel;
            ListOfPrerequisites = listOfPrerequisites;
        }

        public string SubjectID { get => subjectID; set => subjectID = value; }
        public ModuleLevel ModuleLevel { get => moduleLevel; set => moduleLevel = value; }
        public List<ModuleLevel> ListOfPrerequisites1 { get => ListOfPrerequisites; set => ListOfPrerequisites = value; }
    }
}
