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
            ReportHeader("Create Account");
            for (int i = 1; i <= accountCount; i++)
            {
                Account account = ObjectGenerator.GenerateAccount();
                accountDictionary.Add(account.Id, account);
                if ((account.Role == Role.Student || account.Role == Role.Instructor) && account.Status == Status.Pending)
                {
                    pendingAccountStack.Push(account);
                }
                
                ReportItem(account.ToString(), "Created account", i);

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
            }
            ReportSummary("Account", accountCount);
            ReportFooter("Create Account");
        }

        public void ActivateAccounts()
        {
            ReportHeader("Activate account");
            int item = 0;
            while (pendingAccountStack.Count > 0)
            {
                Account account = pendingAccountStack.Pop();
                account.Status = Status.Active;
                ReportItem(account.ToString(), "Activated account", ++item);
            }
            ReportFooter("Activate account");
        }

        public void CreateSubjects(int subjectCount)
        {
            ReportHeader("Subject generation");
            for (int i = 1; i <= subjectCount; i++)
            {
                Subject subject = ObjectGenerator.GenerateSubject();
                subjectDictionary.Add(subject.Id, subject);
                subjectIdList.Add(subject.Id);
                
                ReportItem(subject.ToString(), "Subject", i);
            }

            ReportSummary("Subject", subjectCount);
            ReportFooter("Subject generation");
        }

        public void CreateModules(int moduleCount)
        {
            ReportHeader("Module generation");
            
            for (int i = 1; i <= moduleCount; i++)
            {
                Guid subjectId = GetSubjectId();
                Module module = ObjectGenerator.GenerateModule(subjectId);          
                moduleDictionary.Add(module.Id, module);
                moduleIdList.Add(module.Id);
                
                ReportItem(module.ToString(), "Module", i);
            }

            ReportSummary("Module", moduleCount);
            ReportFooter("Module generation");
        }

        Guid GetSubjectId()
        {
            return subjectIdList[AttributeGenerator.random.Next(0, subjectIdList.Count)];
        }

        public void AssignModulesToStudents()
        {
            ReportHeader("Assign modules to students");
            int count = 0;
            
            foreach (Student student in studentList)
            {
                student.CompletedModuleList = GenerateModuleList();
                ReportItem(student.ToString(), "Assigned module", ++count);
            }
            ReportFooter("Assign modules to students");
        }
        
        public void AssignModulesToInstructors()
        {
            ReportHeader("Assign modules to instructors");
            int count = 0;
            foreach (Instructor instructor in instructorList)
            {
                instructor.ModuleList = GenerateModuleList();
                ReportItem(instructor.ToString(), "Assign instructor", ++count);
            }
            ReportFooter("Assign modules to instructors");
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
                Guid id = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count)];
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
        
        public void AssignInstructorsToClassrooms()
        {
            throw new NotImplementedException();
        }

        #region Simulations
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
        #endregion Simulations

        #region Reports
        void ReportHeader(string actionName)
        {
            Console.WriteLine($"******{actionName} is started******\n");
        }

        void ReportFooter(string actionName)
        {
            Console.WriteLine($"******{actionName} is finished******\n");
        }

        void ReportItem(string itemName, string actionName, int itemIndex)
        {
            Console.WriteLine($" {actionName} {itemIndex}\n{itemName}");
        }

        void ReportSummary(string summary, int count)
        {
            Console.WriteLine($"''''''Generated {count} {summary}''''''\n");
        }
        #endregion Reports
    }
}
