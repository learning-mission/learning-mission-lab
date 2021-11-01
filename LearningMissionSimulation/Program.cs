using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address0 = new Address("Tbilisyan str", "Yerevan", "Arabkir", "15", "Armenia");
            ContactInfo contact0 = new ContactInfo
            (
                address0,
                "e.soghomonyan98@gmail.com",
                "010-54-74-90",
                "010-28-88-88",
                "043-23-09-99"
            );

            Employee employee0 = new Employee();
            Employee employee1 = new Employee();

            List<Employee> employeeList = new List<Employee>
            {
                employee0,
                employee1
            };

            Department department0 = new Department(Guid.NewGuid(), contact0, "Dep0", "Department0", employeeList);

            List<Department> departmentList = new List<Department>
            {
                department0
            };

            Unit<Department> unit0 = new Unit<Department>(UnitType.Department, "Dep0", "Department0", departmentList);

            Console.WriteLine(AttributeGenerator.GetDateOfBirth(20, 60));

            //unit0.Report();
            PlaygroundMher playgroundMher = new PlaygroundMher();
        }
    }
}
