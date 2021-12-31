using System;
using System.Collections.Generic;

namespace LearningMissionLab.Models
{
    /// <summary>
    /// Class: Department
    /// Purpose: Provides a model for Learning Mission departments 
    /// </summary>
    public class Department : Unit<Employee>
    {
        private Guid _companyId;
        private ContactInfo _contactInfo;
        public Department(Guid companyId, ContactInfo contactInfo, string name, string description, List<Employee> itemList)
            : base(UnitType.Department, name, description, itemList)
        {
            this._companyId = companyId;
            this._contactInfo = contactInfo;
        }

        public Guid CompanyId { get => _companyId; set => _companyId = value; }
        public ContactInfo ContactInfo { get => _contactInfo; set => _contactInfo = value; }

        public override string ToString()
        {
            return $" Company id is {CompanyId}\n " +
                   $" Address is {ContactInfo.Address}\n " +
                   $" Phone number is {ContactInfo.CellPhone}\n " +
                   $" Email addresd is {ContactInfo.Email} ";
        }
    }
}
