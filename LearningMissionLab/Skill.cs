using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class Skill
    {
        string _skillName;
        ModuleLevel _moduleLevel;

        public Skill()
        {

        }

        public Skill(string skillName, ModuleLevel moduleLevel)
        {
            this._skillName = skillName;
            this._moduleLevel = moduleLevel;
        }

        public string SkillName { get => _skillName; set => _skillName = value; }
        public ModuleLevel ModuleLevel { get => _moduleLevel; set => _moduleLevel = value; }
    }
}
