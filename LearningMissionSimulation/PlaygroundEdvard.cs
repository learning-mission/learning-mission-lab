using LearningMissionLab;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionSimulation
{
    class PlaygroundEdvard : ISimulation
    {
        ReportType _reportType;
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

        public PlaygroundEdvard()
        {

        }
        
        public PlaygroundEdvard(ReportType reportType)
        {
            this.ReportType = reportType;
        }

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
        public ReportType ReportType { get => _reportType; set => _reportType = value; }

        public void CreateAccounts(int accountCount)
        {
            string action = "Create accounts";
            ReportHeader(actionName: action);
            for (int i = 1; i <= accountCount; i++)
            {
                Account account = ObjectGenerator.GenerateAccount();
                AccountDictionary.Add(account.Id, account);
                if ((account.Role == Role.Student || account.Role == Role.Instructor) && account.Status == Status.Pending)
                {
                    PendingAccountStack.Push(account);
                }

                ReportItem(itemName: account.ToString(), actionName: action, itemIndex: i);

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

            ReportSummary(actionName: action, count: accountCount);
            ReportFooter(actionName: action);
        }

        public void ActivateAccounts()
        {
            string action = "Activate account";
            ReportHeader(actionName: action);
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

                ReportItem(itemName: account.ToString(), actionName: action, itemIndex: ++item);
            }

            ReportSummary(actionName: action, count: item);
            ReportFooter(actionName: action);
        }

        public void CreateSubjects(int subjectCount)
        {
            string action = "Create subjects";
            ReportHeader(actionName: action);
            for (int i = 1; i <= subjectCount; i++)
            {
                Subject subject = ObjectGenerator.GenerateSubject();
                SubjectDictionary.Add(subject.Id, subject);
                SubjectIdList.Add(subject.Id);
                
                ReportItem(itemName: subject.ToString(), actionName: action, itemIndex: i);
            }

            ReportSummary(actionName: action, count: subjectCount);
            ReportFooter(actionName: action);
        }

        public void CreateModules(int moduleCount)
        {
            string action = "Create modules";
            ReportHeader(actionName: action);
            if (SubjectIdList.Count != 0)
            {
                for (int i = 1; i <= moduleCount; i++)
                {
                    Guid subjectId = GetSubjectId();
                    Module module = ObjectGenerator.GenerateModule(subjectId);
                    ModuleDictionary.Add(module.Id, module);
                    ModuleIdList.Add(module.Id);
                
                    ReportItem(itemName: module.ToString(), actionName: action, itemIndex: i);
                }
            }
            else
            {
                ReportError(missingResource: "Subject", failedAction: action);
            }

            ReportSummary(actionName: action, count: moduleCount);
            ReportFooter(actionName: action);
        }

        Guid GetSubjectId()
        {
            return SubjectIdList[AttributeGenerator.random.Next(0, SubjectIdList.Count)];
        }

        public void AssignModulesToStudents()
        {
            string action = "Assign modules to students";
            ReportHeader(actionName: action);
            int count = 0;
            
            foreach (Student student in ActiveStudentList)
            {
                student.CompletedModuleList = GenerateModuleList();
                ReportItem(itemName: student.ToString(), actionName: action, itemIndex: ++count);
            }

            ReportSummary(actionName: action, count: count);
            ReportFooter(actionName: action);
        }
        
        public void AssignModulesToInstructors()
        {
            string action = "Assign modules to instructors";
            ReportHeader(actionName: action);
            int count = 0;
            foreach (Instructor instructor in ActiveInstructorList)
            {
                instructor.ModuleList = GenerateModuleList();
                AddInstructorToModuleList(instructor);
                ReportItem(itemName: instructor.ToString(), actionName: action, itemIndex: ++count);
            }

            ReportSummary(actionName: action, count: count);
            ReportFooter(actionName: action);
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
            string action = "Create classrooms";
            ReportHeader(actionName: action);
            if (ModuleIdList.Count != 0)
            {
                for (int i = 0; i < classroomCount; i++)
                {
                    Guid moduleId = ModuleIdList[AttributeGenerator.random.Next(0, ModuleIdList.Count)];
                    Module module;
                    ModuleDictionary.TryGetValue(moduleId, out module);
                    Classroom classroom = ObjectGenerator.GenerateClassroom(module);
                    ClassroomDictionary.Add(classroom.Id, classroom);

                    ReportItem(itemName: classroom.ToString(), actionName: action, itemIndex: ++i);
                }
            }
            else
            {
                ReportError(missingResource: "Module", failedAction: action);
            }

            ReportSummary(actionName: action, count: classroomCount);
            ReportFooter(actionName: action);
        }

        public void AssignInstructorsToClassrooms()
        {
            string action = "Assign instructors to classroom";
            ReportHeader(actionName: action);
            int count = 0;
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
                        ReportItem(itemName: classroom.ToString(), actionName: action, ++count);
                    }
                }
            }
            else
            {
                ReportError(missingResource: "Instructor", failedAction: action);
            }

            ReportSummary(actionName: action, count: count);
            ReportFooter(actionName: action);
        }

        public void RegisterStudentsForClasses()
        {
            if (ClassroomDictionary.Count == 0)
            {
                ReportError(missingResource: "Classroom", failedAction: "Register");
            }
            else if (ActiveStudentList.Count == 0)
            {
                ReportError(missingResource: "Student", failedAction: "Register");
            }
            else
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
            int studentCount = AttributeGenerator.random.Next(0, (classroom.MaximumCapacity - classroom.ItemList.Count - ActiveStudentList.Count) + 1);
            int count = 0;
            while (count < studentCount)
            {
                foreach (Student student in StudentDictionary.Values)
                {
                    if (!student.ClassroomList.Contains(classroom))
                    {
                        student.ClassroomList.Add(classroom);
                        classroom.ItemList.Add(student);
                    }

                    count++;
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
            switch (this.ReportType)
            {
                case ReportType.Verbose:
                case ReportType.Short:
                case ReportType.Error:
                    Console.WriteLine($"******{actionName} is started******\n");
                    break;
            }
        }

        void ReportFooter(string actionName)
        {
            switch (this.ReportType)
            {
                case ReportType.Verbose:
                case ReportType.Short:
                case ReportType.Error:
                    Console.WriteLine($"******{actionName} is finished******\n");
                    break;
            }
        }

        void ReportItem(string itemName, string actionName, int itemIndex)
        {
            if (this.ReportType == ReportType.Verbose)
            {
                Console.WriteLine($" {actionName} {itemIndex} {itemName}\n");
            }
        }

        void ReportSummary(string actionName, int count)
        {
            if (this.ReportType == ReportType.Verbose || this.ReportType == ReportType.Short)
            {
                Console.WriteLine($"''''''{actionName} {count}''''''\n");
            }
        }

        void ReportError(string missingResource, string failedAction)
        {
            switch (this.ReportType)
            {
                case ReportType.Error:
                case ReportType.Verbose:
                case ReportType.Short:
                    Console.WriteLine("--------- You do not have the appropriate {0} to {1} ---------\n", missingResource, failedAction);
                    break;
            }
        }

        void ReportError(string missingResource, string failedAction)
        {
            Console.WriteLine("--------- You do not have the appropriate {0} to {1} ---------\n", missingResource, failedAction);
        }
        #endregion Reports
    }
}
