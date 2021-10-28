using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    /// <summary>
    /// Class: Classroom
    /// Purpose: Provides a model for Learning Mission  classroom 
    /// </summary>
    public class Classroom : Unit<Student>
    {
        int _maximumCapacity;
        int _minimumCapacity;
        Module _module;
        Schedule _schedule;
        public Classroom(int maximumCapacity, int minimumCapacity, Module module, Schedule schedule, string name,
                        string description, List<Student> itemList) : base(UnitType.Classroom, name, description, itemList)
        {
            this._maximumCapacity = maximumCapacity;
            this._minimumCapacity = minimumCapacity;
            this._module = module;
            this._schedule = schedule;
        }

        public int MaximumCapacity { get => _maximumCapacity; set => _maximumCapacity = value; }
        public int MinimumCapacity { get => _minimumCapacity; set => _minimumCapacity = value; }
        public Module Module { get => _module; set => _module = value; }
        public Schedule Schedule { get => _schedule; set => _schedule = value; }
    }
}
