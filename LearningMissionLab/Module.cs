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
        readonly Guid _id;
        ModuleLevel _moduleLevel;
        List<Module> _prerequisiteList = new List<Module>();

        public Module(ModuleLevel moduleLevel, List<Module> prerequisiteList, string name, string description, List<Lesson> itemList)
           : base(UnitType.Module, name, description, itemList)
        {
            this._id = GetGuid();
            this._moduleLevel = moduleLevel;
            this._prerequisiteList = prerequisiteList;
        }
        public Module(Guid id, ModuleLevel moduleLevel, List<Module> prerequisiteList, string name, string description, List<Lesson> itemList)
           :base (UnitType.Module, name, description, itemList)
        {        
            this._id = id;
            this._moduleLevel = moduleLevel;
            this._prerequisiteList = prerequisiteList;
        }
       
        public ModuleLevel ModuleLevel { get => _moduleLevel; set => _moduleLevel = value; }
        public List<Module> PrerequisiteList { get => _prerequisiteList; set => _prerequisiteList = value; }
        public void Report()
        {
            throw new System.NotImplementedException();
        }
        private static Guid GetGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid;
        }
    }
}
