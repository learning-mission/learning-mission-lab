using LearningMissionLab;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionSimulation
{
    class PlaygroundEdvard : ISimulation
    {
        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();
        Stack<Account> pendingAccountStack = new Stack<Account>();
        List<Student> studentList = new List<Student>();
        List<Instructor> instructorList = new List<Instructor>();
        Dictionary<Guid, Subject> subjectDictionary = new Dictionary<Guid, Subject>();
        Dictionary<Guid, Module> moduleDictionary = new Dictionary<Guid, Module>();
        List<Guid> subjectIdList = new List<Guid>();
        List<Guid> moduleIdList = new List<Guid>();

        public void CreateAccounts(int accountCount)
        {
            ReportHeader("Account");

            for (int i = 1; i <= accountCount; i++)
            {
                ReportItem("Account", i);

                Account account = ObjectGenerator.GenerateAccount();

                accountDictionary.Add(account.Id, account);

                if ((account.Role == Role.Student || account.Role == Role.Instructor) && account.Status == Status.Pending)
                {
                    pendingAccountStack.Push(account);
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

            ReportSummary("Account", accountCount);
            ReportFooter("Account");
        }

        public void ActivateAccounts()
        {
            if (pendingAccountStack.Count == 0)
            {
                EmptyPendingAccountStack();
            }
            else
            {
                ActivationProcess();

                while (pendingAccountStack.Count > 0)
                {
                    pendingAccountStack.Pop().Status = Status.Active;

                    Console.WriteLine($" Activated at {DateTime.Now}\n");
                }

                ActivationProcess();
            }
        }

        public void CreateSubjects(int subjectCount)
        {
            ReportHeader("Subject");

            for (int i = 1; i <= subjectCount; i++)
            {
                Subject subject = ObjectGenerator.GenerateSubject();

                ReportItem("Subject", i);

                subject.Report();

                subjectDictionary.Add(subject.Id, subject);
                subjectIdList.Add(subject.Id);
            }

            ReportSummary("Subject", subjectCount);
            ReportFooter("Subject");
        }

        public void CreateModules(int moduleCount)
        {
            ReportHeader("Module");

            for (int i = 1; i <= moduleCount; i++)
            {
                ReportItem("Module", i);

                Guid subjectId = GetSubjectId();

                Module module = ObjectGenerator.GenerateModule(subjectId);

                module.Report();

                moduleDictionary.Add(module.Id, module);
                moduleIdList.Add(module.Id);
            }

            ReportSummary("Module", moduleCount);
            ReportFooter("Module");
        }

        Guid GetSubjectId()
        {
            return subjectIdList[AttributeGenerator.random.Next(0, subjectIdList.Count)];
        }

        public void AssignModulesToStudents()
        {
            foreach (Student student in studentList)
            {
                student.CompletedModuleList = GenerateModuleList();
            }
        }
        
        public void AssignModulesToInstructors()
        {
            foreach (Instructor instructor in instructorList)
            {
                instructor.ModuleList = GenerateModuleList();
            }
        }

        public List<Module> GenerateModuleList()
        {
            List<Module> moduleList = new List<Module>();
            int totalModuleCount = moduleIdList.Count;
            int minModuleCountLimit = 2;
            int maxModuleCountLimit = 5;
            minModuleCountLimit = Math.Min(totalModuleCount, minModuleCountLimit);
            maxModuleCountLimit = Math.Min(totalModuleCount, maxModuleCountLimit);
            int moduleCount = AttributeGenerator.random.Next(minModuleCountLimit, maxModuleCountLimit);

            for (int i = 0; i < moduleCount; i++)
            {
                Guid id = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count - 1)];

                Module module;

                moduleDictionary.TryGetValue(id, out module);

                moduleList.Add(module);
            }

            return moduleList;
        }

        public void CreateClassrooms(int classroomCount)
        {
            throw new NotImplementedException();
        }

        public void RegisterStudentsForClasses()
        {
            throw new NotImplementedException();
        }

        public static void SimulationBig0()
        {
            Address address0 = new Address("dasdasd str",23, 15, "Yerevan", "asdqwe", "15", "Armenia");
            ContactInfo contact0 = new ContactInfo
            (
                address0,
                "zxczxc.asdasdqweqweqwe@gmail.com",
                "010-54-74-90",
                "010-28-88-88",
                "013-23-122-33"
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
        }

        public void SimulationSmall0(int accountCount)
        {
            CreateAccounts(accountCount);
            ActivateAccounts();
        }

        public void SimulationBig1(int subjectCount, int moduleCount)
        {
            CreateSubjects(subjectCount);
            CreateModules(moduleCount);
            AssignModulesToStudents();
            AssignModulesToInstructors();
        }

        #region Reports
        public void ReportHeader(string objectName)
        {
            switch (objectName)
            {
                case "Account":
                    Console.WriteLine("******Account generation is started******");

                    break;
                case "Subject":
                    Console.WriteLine("******Subject generation is started******");

                    break;
                case "Module":
                    Console.WriteLine("******Module generation is started******");

                    break;
            }
        }

        public void ReportFooter(string objectName)
        {
            switch (objectName)
            {
                case "Account":
                    Console.WriteLine("******Account generation is finished******\n");

                    break;
                case "Subject":
                    Console.WriteLine("******Subject generation is finished******\n");

                    break;
                case "Module":
                    Console.WriteLine("******Module generation is finished******\n");

                    break;
            }
        }

        public void ReportItem(string itemName, int count)
        {
            Console.WriteLine($" {itemName} {count}");
        }

        public void ReportSummary(string reportDescription, int count)
        {
            Console.WriteLine($"''''''Generated {count} {reportDescription}''''''");
        }

        void ActivationProcess(string coordinatorType)
        {
            if (pendingAccountStack.Count > 0)
            {
                Console.WriteLine($"------{coordinatorType} coordinator started activating accounts------\n");
            }
            else
            {
                Console.WriteLine($"------{coordinatorType} coordinator finished activating accounts------\n");
            }
        }

        void ActivationProcess()
        {
            ActivationProcess("Unfair");
        }

        void EmptyPendingAccountStack()
        {
            Console.WriteLine("______There is nothing to activate!______\n");
        }

        #endregion Reports
    }
}
