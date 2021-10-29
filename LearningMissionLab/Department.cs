using System.Collections.Generic;

namespace LearningMissionLab
{

    /// <summary>
    /// Class: Department
    /// Purpose: Provides a model for Learning Mission departments 
    /// </summary>
    public class Department:Unit<Employee>
    {
        private int _companyId;
        private ContactInfo _contactInfo;


        public Department(int companyId, ContactInfo contactInfo, string name, string description, List<Employee> itemList)
            : base(UnitType.Department, name, description, itemList)
        { 
            this._companyId = companyId;
            this._contactInfo = contactInfo;
        }

        public int CompanyId { get => _companyId; set => _companyId = value; }
        public ContactInfo ContactInfo { get => _contactInfo; set => _contactInfo = value; }
    }
}
