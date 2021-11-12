using System;
using System.Collections.Generic;

namespace LearningMissionLab
{
    /// <summary>
    /// Class: Module
    /// Purpose: Provides a model for Learning Mission educational modules 
    /// </summary>
    public class Module : Unit<Lesson>, IReport
    {
        Guid _subjectId;
        ModuleLevel _moduleLevel;
        List<Module> _prerequisiteList = new List<Module>();

        public Module(Guid subjectId, ModuleLevel moduleLevel, List<Module> prerequisiteList, string name, string description, List<Lesson> itemList)
           :base (UnitType.Module, name, description, itemList)
        {        
            this._subjectId = subjectId;
            this._moduleLevel = moduleLevel;
            this._prerequisiteList = prerequisiteList;
        }
       
        public Guid SubjectId { get => _subjectId; set => _subjectId = value; }
        public ModuleLevel ModuleLevel { get => _moduleLevel; set => _moduleLevel = value; }
        public List<Module> PrerequisiteList { get => _prerequisiteList; set => _prerequisiteList = value; }
    }
}
