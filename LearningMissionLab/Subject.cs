using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
   
    public class Subject 
    {
        SubjectType _subjectType;
        public Subject(SubjectType subjectType)
        {
            this._subjectType = subjectType; 
        }
        public SubjectType SubjectType { get => _subjectType; set => _subjectType = value; }

        
    }


}
