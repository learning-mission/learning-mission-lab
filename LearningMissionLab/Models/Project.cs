using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab.Models
{
    public class Project
    {
        string _projectName;
        string _projectDescription;

        public Project() {}

        public Project(string projectName, string projectDescription)
        {
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;
        }

        public string ProjectName { get => _projectName; set => _projectName = value; }
        public string ProjectDescription { get => _projectDescription; set => _projectDescription = value; }
    }
}
