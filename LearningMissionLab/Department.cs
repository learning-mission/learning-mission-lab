using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class Department : Unit<Employee>
    {
        public int companyId;
        public string contactInfo;


        public Department()
        {

        }

        public int CompanyId { get => companyId; set => companyId = value; }
        public string ContactInfo { get => contactInfo; set => contactInfo = value; }

    }
}
