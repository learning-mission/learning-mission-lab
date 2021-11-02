using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class ObjectGenerator
    {
        static HashSet<string> emailNameSet = new HashSet<string>();

        public static Student GenerateStudent()
        {
            //not implemented yet!
            return null;

        }

        public static List<Student> GenerateStudentPool(uint studentCount)
        {
            List<Student> studentList = new List<Student>();

            //not implemented yet!
            return studentList;
        }

        public static Instructor GenerateInstructor()
        {
            //not implemented yet!
            return null;

        }

        public static List<Instructor> GenerateInstructorPool(uint instructorCount)
        {
            List<Instructor> instructorList = new List<Instructor>();

            //not implemented yet!
            return instructorList;
        }

        public static Account GenerateAccount()
        {
            //not implemented yet!
            return null;

        }

        public static List<Account> GenerateAccountPool(uint accountCount)
        {
            List<Account> accountList = new List<Account>();

            //not implemented yet!
            return accountList;
        }

        public static Profile GenerateProfile()
        {
            //not implemented yet!
            return null;

        }

        public static List<Profile> GenerateProfilePool(uint profileCount)
        {
            List<Profile> profileList = new List<Profile>();

            //not implemented yet!
            return profileList;
        }

        public static Address GenerateAddress()
        {
            return new Address(AttributeGenerator.GetStreetAddress(), AttributeGenerator.GetCity(), 
                               AttributeGenerator.GetProvince(), AttributeGenerator.GetPostalCode(),
                               AttributeGenerator.GetCountry());
        }
        
        public static List<Address> GenerateAddressPool(uint addressCount)
        {
            List<Address> addresseList = new List<Address>();

            for (int i = 0; i < addressCount; i++)
            {
                addresseList.Add(GenerateAddress());
            }

            return addresseList;
        }
        
        public static ContactInfo GenerateContactInfo()
        {
            return new ContactInfo(GenerateAddress(), AttributeGenerator.GetEmail(),
                AttributeGenerator.GetHomeNumber(), AttributeGenerator.GetWorkNumber(),
                AttributeGenerator.GetPhoneNumber());
        }

        public static List<ContactInfo> GetContactInfoPool(uint contactInfoCount)
        {
            List<ContactInfo> contactInfoList = new List<ContactInfo>();

            for (int i = 0; i < contactInfoCount; i++)
            {
                contactInfoList.Add(GenerateContactInfo());
            }

            return contactInfoList;
        }
    }
}
