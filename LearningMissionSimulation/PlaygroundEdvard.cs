using LearningMissionLab;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionSimulation
{
    class PlaygroundEdvard
    {
        public static void Action0()
        {
            //Console.WriteLine(AttributeGenerator.GetPostalCode());
            Console.WriteLine(AttributeGenerator.GetProvince());
        }
        
        public static void Action1()
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
        }


    }
}
