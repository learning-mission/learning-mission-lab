using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class Department:Unit<Employee>
    {
        private int _companyId;
        private ContactInfo _contactInfo;


        public Department(int companyId, ContactInfo contactInfo)
            : base()
        { 
            this._companyId = companyId;
            this._contactInfo = contactInfo;
        }

        public int CompanyId { get => _companyId; set => _companyId = value; }
        public ContactInfo ContactInfo { get => _contactInfo; set => _contactInfo = value; }
    }
}
