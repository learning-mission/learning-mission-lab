using System;
using System.Collections.Generic;

namespace LearningMissionLab
{
    public class Module: Unit<Lesson>
    {
        string subjectID;
        ModuleLevel moduleLevel;
        List<Module> prerequisiteList = new List<Module>();
                   

        public Module(string subjectID, ModuleLevel moduleLevel, List<Module> prerequisiteList, string name, string description, List<Lesson> itemList)
           :base (UnitType.Module, name, description, itemList)
        {
           
            this.subjectID = subjectID;
            this.moduleLevel = moduleLevel;
            this.prerequisiteList = prerequisiteList;
        }

        public string SubjectID { get => subjectID; set => subjectID = value; }
        public ModuleLevel ModuleLevel { get => moduleLevel; set => moduleLevel = value; }
        public List<Module> PrerequisiteList { get => prerequisiteList; set => prerequisiteList = value; }
    }
}
//module
// prerequisitList
