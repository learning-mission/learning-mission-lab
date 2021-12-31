using System;
namespace LearningMissionLab.Models
{
    /// <summary>
    /// Class: Address
    /// Purpose: Provides a model for postal address 
    /// </summary>
    public class Address
    {
        string _streetName;
        int _buildingNumber;
        int _apartmentNumber;
        string _city;
        string _province;
        string _postalCode;
        string _country;

        public Address(string streetName,int buildingNumber,int apartmentNumber, string city, string province, string postalCode, string country)
        {
            this._streetName = streetName;
            this._buildingNumber = buildingNumber;
            this._apartmentNumber = apartmentNumber;
            this._city = city;
            this._province = province;
            this._postalCode = postalCode;
            this._country = country;
        }

        public string StreetName { get => _streetName; set => _streetName = value; }
        public string City { get => _city; set => _city = value; }
        public string Province { get => _province; set => _province = value; }
        public string PostalCode { get => _postalCode; set => _postalCode = value; }
        public string Country { get => _country; set => _country = value; }
        public int BuildingNumber { get => _buildingNumber; set => _buildingNumber = value; }
        public int ApartmentNumber { get => _apartmentNumber; set => _apartmentNumber = value; }
    }
}
