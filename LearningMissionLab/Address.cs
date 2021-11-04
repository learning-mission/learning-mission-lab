using System;
namespace LearningMissionLab
{
    /// <summary>
    /// Class: Address
    /// Purpose: Provides a model for postal address 
    /// </summary>
    public class Address
    {
        string _streetAddress;
        string _city;
        string _province;
        string _postalCode;
        string _country;

        public Address(string streetAddress, string city, string province, string postalCode, string country)
        {
            this._streetAddress = streetAddress;
            this._city = city;
            this._province = province;
            this._postalCode = postalCode;
            this._country = country;
        }

        
        public string StreetAddress { get => _streetAddress; set => _streetAddress = value; }
        public string City { get => _city; set => _city = value; }
        public string Province { get => _province; set => _province = value; }
        public string PostalCode { get => _postalCode; set => _postalCode = value; }
        public string Country { get => _country; set => _country = value; }
    }
}
