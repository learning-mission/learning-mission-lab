using System;
namespace LearningMissionLab
{
    /// <summary>
    /// Class: ContactInfo
    /// Purpose: Provides a model for Contact Information
    /// </summary>

    public class ContactInfo
    {
        Address _address;
        string _email;
        string _homePhone;
        string _workPhone;
        string _cellPhone;

        public ContactInfo
        (
            Address address,
            string email,
            string homePhone,
            string workPhone,
            string cellPhone
        )
        {
            this._address = address;
            this._email = email;
            this._homePhone = homePhone;
            this._workPhone = workPhone;
            this._cellPhone = cellPhone;
        }

        public Address Address { get => _address; set => _address = value; }
        public string Email { get => _email; set => _email = value; }
        public string HomePhone { get => _homePhone; set => _homePhone = value; }
        public string WorkPhone { get => _workPhone; set => _workPhone = value; }
        public string CellPhone { get => _cellPhone; set => _cellPhone = value; }
    }
}
