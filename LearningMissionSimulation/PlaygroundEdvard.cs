﻿using LearningMissionLab;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionSimulation
{
    class PlaygroundEdvard : ISimulation
    {
        Stack<Account> createAccountStack = new Stack<Account>();
        List<Student> studentList = new List<Student>();
        List<Instructor> instructorList = new List<Instructor>();
        Dictionary<Guid, Account> activatedStudentAccountDictionary = new Dictionary<Guid, Account>();
        Dictionary<Guid, Account> activatedInstructorAccountDictionary = new Dictionary<Guid, Account>();

        public static void Action0()
        {
            ObjectGenerator.GenerateAddress();
        }
        
        public static void Action1()
        {
            Address address0 = new Address("ASdhausd str", 23, 15, "Yerevan", "asdaqwer", "15", "Armenia");
            ContactInfo contact0 = new ContactInfo
            (
                address0,
                "zxmcla.hzxuchauxd@gmail.com",
                "010-54-74-90",
                "010-28-88-88",
                "000-00-77-77"
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

        public void Action2(int accountCount)
        {
            CreateAccounts(accountCount);
            ActivateAccounts();
        }

        public void CreateAccounts(int accountCount)
        {
            for (int i = 0; i < accountCount; i++)
            {
                Console.WriteLine($" Account {i + 1}");

                Account account = ObjectGenerator.GenerateAccount();

                createAccountStack.Push(account);

                if (account.Role == Role.Student)
                {
                    studentList.Add(ObjectGenerator.GenerateStudent(account.Id));
                }
                else if (account.Role == Role.Instructor)
                {
                    instructorList.Add(ObjectGenerator.GenerateInstructor(account.Id));
                }

                Console.WriteLine('\n');
            }
        }

        // Unfair Coordinator
        public void ActivateAccounts()
        {
            foreach (Account account in createAccountStack)
            {
                if (account.Role == Role.Student && account.Status == Status.Pending)
                {
                    account.Status = Status.Active;

                    activatedStudentAccountDictionary.Add(account.Id, account);
                }
                else if (account.Role == Role.Instructor && account.Status == Status.Pending)
                {
                    account.Status = Status.Active;

                    activatedInstructorAccountDictionary.Add(account.Id, account);
                }
            }
        }

        public void AssignModulesToInstructors()
        {
            throw new NotImplementedException();
        }

        public void AssignModulesToStudents()
        {
            throw new NotImplementedException();
        }


        public void CreateClassrooms(int classroomCount)
        {
            throw new NotImplementedException();
        }

        public void CreateModules(int moduleCount)
        {
            throw new NotImplementedException();
        }

        public void RegisterStudentsForClasses()
        {
            throw new NotImplementedException();
        }
    }
}
