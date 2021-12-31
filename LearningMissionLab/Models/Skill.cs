using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class Skill
    {
        string _skillName;
        SkillLevel _skillLevel;

        public Skill() {}

        public Skill(string skillName, SkillLevel skillLevel)
        {
            this.SkillName = skillName;
            this.SkillLevel = skillLevel;
        }

        public string SkillName { get => _skillName; set => _skillName = value; }
        public SkillLevel SkillLevel { get => _skillLevel; set => _skillLevel = value; }
    }
}
