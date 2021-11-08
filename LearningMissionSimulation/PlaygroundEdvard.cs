using LearningMissionLab;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionSimulation
{
    class PlaygroundEdvard : ISimulation
    {
        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();
        List<Student> studentList = new List<Student>();
        List<Instructor> instructorList = new List<Instructor>();
        Stack<Account> generatedAccountStack = new Stack<Account>();

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

                accountDictionary.Add(account.Id, account);

                if (account.Role == Role.Student && account.Status == Status.Pending || account.Role == Role.Instructor && account.Status == Status.Pending)
                {
                    generatedAccountStack.Push(account);
                }

                if (account.Role == Role.Student)
                {
                    Student student = ObjectGenerator.GenerateStudent(account.Id);

                    studentList.Add(student);

                    student.Report();
                }
                else if (account.Role == Role.Instructor)
                {
                    Instructor instructor = ObjectGenerator.GenerateInstructor(account.Id);

                    instructorList.Add(instructor);

                    instructor.Report();
                }

                Console.WriteLine('\n');
            }
        }

        // Unfair Coordinator
        public void ActivateAccounts()
        {
            Console.WriteLine("-----Activation starting with Unfair coordinator-----\n");

            while (generatedAccountStack.Count > 0)
            {
                generatedAccountStack.Peek().Status = Status.Active;

                Console.WriteLine(generatedAccountStack.Peek());
                Console.WriteLine($" Activated at {DateTime.Now}\n");

                generatedAccountStack.Pop();
            }

            Console.WriteLine("-----Activation ended with Unfair coordinator-----");
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
