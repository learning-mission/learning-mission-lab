using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    /// <summary>
    /// Class: Subject
    /// Purpose: Provides a model for subject
    /// </summary>
    public class Subject : Unit<Module>
    {
        SubjectType _subjectType;
        public Subject(SubjectType subjectType, string description, string name, List<Module> itemList)
                       : base(UnitType.Subject, description, name, itemList)
        {
            this._subjectType = subjectType;
        }
        public SubjectType SubjectType { get => _subjectType; set => _subjectType = value; }

        public override string ToString()
        {
            return $" Subject Type is {SubjectType}\n" +
                   $" Name is {Name}\n" +
                   $" Description is {Description}\n";
        }
    }
}
