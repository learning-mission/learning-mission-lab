using System;
namespace LearningMissionLab
{

    public class Person
    {
        // Fields
        String lastName;
        readonly DateTime birthDate;
        // Constuctors
        public Person(String firstName, String lastName, DateTime birthDate)
        {
            FirstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
        }
        // Properties
        public string FirstName { get; set; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime BirthDate => birthDate;

        //Methods
        public String GetDisplayName()
        {
            return $"{LastName}, {FirstName}";
        }
    }
}
