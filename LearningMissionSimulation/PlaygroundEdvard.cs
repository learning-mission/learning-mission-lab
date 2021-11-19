using LearningMissionLab;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionSimulation
{
    class PlaygroundEdvard : ISimulation
    {
        // Add Properties of data strcuture
        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();
        Stack<Account> pendingAccountStack = new Stack<Account>();
        Dictionary<Guid, Student> studentDictionary = new Dictionary<Guid, Student>();
        List<Student> activeStudentList = new List<Student>();
        Dictionary<Guid, Instructor> instructorDictionary = new Dictionary<Guid, Instructor>();
        List<Instructor> activeInstructorList = new List<Instructor>();
        Dictionary<Guid, Subject> subjectDictionary = new Dictionary<Guid, Subject>();
        Dictionary<Guid, Module> moduleDictionary = new Dictionary<Guid, Module>();
        List<Guid> subjectIdList = new List<Guid>();
        List<Guid> moduleIdList = new List<Guid>();
        Dictionary<Guid, Classroom> classroomDictionary = new Dictionary<Guid, Classroom>();
        Dictionary<Guid, List<Instructor>> moduleInstructorListDictionary = new Dictionary<Guid, List<Instructor>>();

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
                    studentDictionary.Add(student.AccountId, student);
                    if (account.Status == Status.Active)
                    {
                        activeStudentList.Add(student);
                    }

                    student.Report();
                }
                else if (account.Role == Role.Instructor)
                {
                    Instructor instructor = ObjectGenerator.GenerateInstructor(account.Id);
                    instructorDictionary.Add(instructor.AccountId, instructor);
                    if (account.Status == Status.Active)
                    {
                        activeInstructorList.Add(instructor);
                    }

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
            
            if (subjectIdList.Count != 0)
            {
                for (int i = 1; i <= moduleCount; i++)
                {
                    Guid subjectId = GetSubjectId();
                    Module module = ObjectGenerator.GenerateModule(subjectId);
                    moduleDictionary.Add(module.Id, module);
                    moduleIdList.Add(module.Id);
                
                    ReportItem(module.ToString(), "Module", i);
                }
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
            
            foreach (Student student in activeStudentList)
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
            foreach (Instructor instructor in activeInstructorList)
            {
                instructor.ModuleList = GenerateModuleList();
                AddInstructorToModuleList(instructor);
                ReportItem(instructor.ToString(), "Assign instructor", ++count);
            }
            ReportFooter("Assign modules to instructors");
        }

        void AddInstructorToModuleList(Instructor instructor)
        {
            List<Module> moduleList = instructor.ModuleList;

            foreach(Module module in moduleList)
            {
                List<Instructor> instructorList;
                if (moduleInstructorListDictionary.ContainsKey(module.Id))
                {
                    moduleInstructorListDictionary.TryGetValue(module.Id, out instructorList);
                    instructorList.Add(instructor);
                }
                else
                {
                    instructorList = new List<Instructor>() { instructor };
                    moduleInstructorListDictionary.Add(module.Id, instructorList);
                }
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
                Guid id = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count)];
                Module module;
                moduleDictionary.TryGetValue(id, out module);
                moduleList.Add(module);
            }
            return moduleList;
        }

        public void CreateClassrooms(int classroomCount)
        {
            if (moduleIdList.Count != 0)
            {
                for (int i = 0; i < classroomCount; i++)
                {
                    Guid moduleId = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count)];
                    Module module;
                    moduleDictionary.TryGetValue(moduleId, out module);
                    Classroom classroom = ObjectGenerator.GenerateClassroom(module);
                    classroomDictionary.Add(classroom.Id, classroom);
                }
            }
        }

        public void AssignInstructorsToClassrooms()
        {
            if (activeInstructorList.Count != 0 && classroomDictionary.Count != 0)
            {
                foreach (Classroom classroom in classroomDictionary.Values)
                {
                    Guid moduleId = classroom.Module.Id;
                    List<Instructor> instructorList;

                    if (moduleInstructorListDictionary.ContainsKey(moduleId))
                    {
                        moduleInstructorListDictionary.TryGetValue(moduleId, out instructorList);
                        classroom.Head = instructorList[AttributeGenerator.random.Next(0, instructorList.Count)];
                    }
                }
            }
        }
        
        public void RegisterStudentsForClasses()
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
            SimulationSmall0(subjectCount);
            CreateSubjects(subjectCount);
            CreateModules(moduleCount);
            AssignModulesToStudents();
            AssignModulesToInstructors();
            CreateClassrooms(25);
            AssignInstructorsToClassrooms();
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
