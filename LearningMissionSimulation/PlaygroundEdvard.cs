using LearningMissionLab;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionSimulation
{
    class PlaygroundEdvard : ISimulation
    {
        Dictionary<Guid, Account> _accountDictionary = new Dictionary<Guid, Account>();
        Stack<Account> _pendingAccountStack = new Stack<Account>();
        Dictionary<Guid, Student> _studentDictionary = new Dictionary<Guid, Student>();
        List<Student> _activeStudentList = new List<Student>();
        Dictionary<Guid, Instructor> _instructorDictionary = new Dictionary<Guid, Instructor>();
        List<Instructor> _activeInstructorList = new List<Instructor>();
        Dictionary<Guid, Subject> _subjectDictionary = new Dictionary<Guid, Subject>();
        Dictionary<Guid, Module> _moduleDictionary = new Dictionary<Guid, Module>();
        List<Guid> _subjectIdList = new List<Guid>();
        List<Guid> _moduleIdList = new List<Guid>();
        Dictionary<Guid, Classroom> _classroomDictionary = new Dictionary<Guid, Classroom>();
        Dictionary<Guid, List<Instructor>> _moduleInstructorListDictionary = new Dictionary<Guid, List<Instructor>>();

        public Dictionary<Guid, Account> AccountDictionary { get => _accountDictionary; set => _accountDictionary = value; }
        public Stack<Account> PendingAccountStack { get => _pendingAccountStack; set => _pendingAccountStack = value; }
        public Dictionary<Guid, Student> StudentDictionary { get => _studentDictionary; set => _studentDictionary = value; }
        public List<Student> ActiveStudentList { get => _activeStudentList; set => _activeStudentList = value; }
        public Dictionary<Guid, Instructor> InstructorDictionary { get => _instructorDictionary; set => _instructorDictionary = value; }
        public List<Instructor> ActiveInstructorList { get => _activeInstructorList; set => _activeInstructorList = value; }
        public Dictionary<Guid, Subject> SubjectDictionary { get => _subjectDictionary; set => _subjectDictionary = value; }
        public Dictionary<Guid, Module> ModuleDictionary { get => _moduleDictionary; set => _moduleDictionary = value; }
        public List<Guid> SubjectIdList { get => _subjectIdList; set => _subjectIdList = value; }
        public List<Guid> ModuleIdList { get => _moduleIdList; set => _moduleIdList = value; }
        public Dictionary<Guid, Classroom> ClassroomDictionary { get => _classroomDictionary; set => _classroomDictionary = value; }
        public Dictionary<Guid, List<Instructor>> ModuleInstructorListDictionary { get => _moduleInstructorListDictionary; set => _moduleInstructorListDictionary = value; }

        public void CreateAccounts(int accountCount)
        {
            ReportHeader(actionName: "Create Account");
            for (int i = 1; i <= accountCount; i++)
            {
                Account account = ObjectGenerator.GenerateAccount();
                AccountDictionary.Add(account.Id, account);
                if ((account.Role == Role.Student || account.Role == Role.Instructor) && account.Status == Status.Pending)
                {
                    PendingAccountStack.Push(account);
                }

                ReportItem(itemName: account.ToString(), actionName: "Created account", itemIndex: i);

                if (account.Role == Role.Student)
                {
                    Student student = ObjectGenerator.GenerateStudent(account.Id);
                    StudentDictionary.Add(student.AccountId, student);
                    if (account.Status == Status.Active)
                    {
                        ActiveStudentList.Add(student);
                    }

                    student.Report();
                }
                else if (account.Role == Role.Instructor)
                {
                    Instructor instructor = ObjectGenerator.GenerateInstructor(account.Id);
                    InstructorDictionary.Add(instructor.AccountId, instructor);
                    if (account.Status == Status.Active)
                    {
                        ActiveInstructorList.Add(instructor);
                    }

                    instructor.Report();
                }
            }
            ReportSummary(summary: "Account", count: accountCount);
            ReportFooter(actionName: "Create Account");
        }

        public void ActivateAccounts()
        {
            ReportHeader(actionName: "Activate account");
            int item = 0;
            while (PendingAccountStack.Count > 0)
            {
                Account account = PendingAccountStack.Pop();
                account.Status = Status.Active;

                if (account.Role == Role.Student)
                {
                    Student student;
                    StudentDictionary.TryGetValue(account.Id, out student);

                    if (student != null)
                    {
                        ActiveStudentList.Add(student);
                    }
                }
                else if (account.Role == Role.Instructor)
                {
                    Instructor instructor;
                    InstructorDictionary.TryGetValue(account.Id, out instructor);

                    if (instructor != null)
                    {
                        ActiveInstructorList.Add(instructor);
                    }
                }

                ReportItem(itemName: account.ToString(), actionName: "Activated account", itemIndex: ++item);
            }
            ReportFooter(actionName: "Activate account");
        }

        public void CreateSubjects(int subjectCount)
        {
            ReportHeader(actionName: "Subject generation");
            for (int i = 1; i <= subjectCount; i++)
            {
                Subject subject = ObjectGenerator.GenerateSubject();
                SubjectDictionary.Add(subject.Id, subject);
                SubjectIdList.Add(subject.Id);
                
                ReportItem(itemName: subject.ToString(), actionName: "Subject", itemIndex: i);
            }

            ReportSummary(summary: "Subject", count: subjectCount);
            ReportFooter(actionName: "Subject generation");
        }

        public void CreateModules(int moduleCount)
        {
            ReportHeader(actionName: "Module generation");
            
            if (SubjectIdList.Count != 0)
            {
                for (int i = 1; i <= moduleCount; i++)
                {
                    Guid subjectId = GetSubjectId();
                    Module module = ObjectGenerator.GenerateModule(subjectId);
                    ModuleDictionary.Add(module.Id, module);
                    ModuleIdList.Add(module.Id);
                
                    ReportItem(itemName: module.ToString(), actionName: "Module", itemIndex: i);
                }
            }

            ReportSummary(summary: "Module", count: moduleCount);
            ReportFooter(actionName: "Module generation");
        }

        Guid GetSubjectId()
        {
            return SubjectIdList[AttributeGenerator.random.Next(0, SubjectIdList.Count)];
        }

        public void AssignModulesToStudents()
        {
            ReportHeader(actionName: "Assign modules to students");
            int count = 0;
            
            foreach (Student student in ActiveStudentList)
            {
                student.CompletedModuleList = GenerateModuleList();
                ReportItem(itemName: student.ToString(), actionName: "Assigned module", itemIndex: ++count);
            }
            ReportFooter(actionName: "Assign modules to students");
        }
        
        public void AssignModulesToInstructors()
        {
            ReportHeader(actionName: "Assign modules to instructors");
            int count = 0;
            foreach (Instructor instructor in ActiveInstructorList)
            {
                instructor.ModuleList = GenerateModuleList();
                AddInstructorToModuleList(instructor);
                ReportItem(itemName: instructor.ToString(), actionName: "Assign instructor", itemIndex: ++count);
            }
            ReportFooter(actionName: "Assign modules to instructors");
        }

        void AddInstructorToModuleList(Instructor instructor)
        {
            List<Module> moduleList = instructor.ModuleList;

            foreach(Module module in moduleList)
            {
                List<Instructor> instructorList;
                if (ModuleInstructorListDictionary.ContainsKey(module.Id))
                {
                    ModuleInstructorListDictionary.TryGetValue(module.Id, out instructorList);
                    instructorList.Add(instructor);
                }
                else
                {
                    instructorList = new List<Instructor>() { instructor };
                    ModuleInstructorListDictionary.Add(module.Id, instructorList);
                }
            }
        }

        public List<Module> GenerateModuleList()
        {
            List<Module> moduleList = new List<Module>();
            int totalModuleCount = ModuleIdList.Count;
            int minModuleCountLimit = 2;
            int maxModuleCountLimit = 5;
            minModuleCountLimit = Math.Min(totalModuleCount, minModuleCountLimit);
            maxModuleCountLimit = Math.Min(totalModuleCount, maxModuleCountLimit);
            int moduleCount = AttributeGenerator.random.Next(minModuleCountLimit, maxModuleCountLimit);

            for (int i = 0; i < moduleCount; i++)
            {
                Guid id = ModuleIdList[AttributeGenerator.random.Next(0, ModuleIdList.Count)];
                Module module;
                ModuleDictionary.TryGetValue(id, out module);
                moduleList.Add(module);
            }
            return moduleList;
        }

        public void CreateClassrooms(int classroomCount)
        {
            if (ModuleIdList.Count != 0)
            {
                for (int i = 0; i < classroomCount; i++)
                {
                    Guid moduleId = ModuleIdList[AttributeGenerator.random.Next(0, ModuleIdList.Count)];
                    Module module;
                    ModuleDictionary.TryGetValue(moduleId, out module);
                    Classroom classroom = ObjectGenerator.GenerateClassroom(module);
                    ClassroomDictionary.Add(classroom.Id, classroom);
                }
            }
        }

        public void AssignInstructorsToClassrooms()
        {
            if (ActiveInstructorList.Count != 0 && ClassroomDictionary.Count != 0)
            {
                foreach (Classroom classroom in ClassroomDictionary.Values)
                {
                    Guid moduleId = classroom.Module.Id;
                    List<Instructor> instructorList;

                    if (ModuleInstructorListDictionary.ContainsKey(moduleId))
                    {
                        ModuleInstructorListDictionary.TryGetValue(moduleId, out instructorList);
                        classroom.Head = instructorList[AttributeGenerator.random.Next(0, instructorList.Count)];
                    }
                }
            }
        }

        public void RegisterStudentsForClasses()
        {
            if (ClassroomDictionary.Count != 0)
            {
                int maxCount = 0;
                foreach (Classroom classroom in ClassroomDictionary.Values)
                {
                    if (classroom.ItemList.Count < classroom.MaximumCapacity)
                    {
                        UpdateStudentList(classroom);
                        maxCount = classroom.ItemList.Count;
                    }
                }
            }
        }

        void UpdateStudentList(Classroom classroom)
        {
            int studentCount = AttributeGenerator.random.Next(0, (classroom.MaximumCapacity - classroom.ItemList.Count) + 1);
            int count = 0;
            while (count < studentCount)
            {
                foreach (Student student in ActiveStudentList)
                {
                    if (!student.ClassroomList.Contains(classroom))
                    {
                        student.ClassroomList.Add(classroom);
                        classroom.ItemList.Add(student);
                    }

                    count++;
                }

                if (count == ActiveStudentList.Count)
                {
                    break;
                }
            }
        }

        public void Clear()
        {
            // Clear all internal data structures 
            this.AccountDictionary.Clear();
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
