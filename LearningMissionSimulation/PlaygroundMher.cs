using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class PlaygroundMher : ISimulation
    {
        public ReportType ReportType { get; set; } = ReportType.Verbose;
        public List<Student> ActiveStudentList { get; set; } = new List<Student>();
        public Dictionary<Guid, Student> StudentDictionary { get; set; } = new Dictionary<Guid, Student>();
        public List<Instructor> ActiveInstructorList { get; set; } = new List<Instructor>();
        public Dictionary<Guid, Instructor> InstructorDictionary { get; set; } = new Dictionary<Guid, Instructor>();
        public Queue<Account> PendingAccountQueue { get; set; } = new Queue<Account>();
        public Dictionary<Guid, Account> AccountDictionary { get; set; } = new Dictionary<Guid, Account>();
        public List<Subject> SubjectList { get; set; } = new List<Subject>();
        public Dictionary<Guid, Module> ModuleDictionary { get; set; } = new Dictionary<Guid, Module>();
        public List<Guid> ModuleIdList { get; set; } = new List<Guid>();
        public List<Guid> SubjectIdList { get; set; } = new List<Guid>();
        public List<Classroom> ClassroomList { get; set; } = new List<Classroom>();
        public Dictionary<Guid, List<Instructor>> ModuleInstructorDictionary { get; set; } = new Dictionary<Guid, List<Instructor>>();

        public PlaygroundMher()
        {

        }

        public PlaygroundMher(ReportType reportType)
        {
            this.ReportType = reportType;
        }

        public void CreateAccounts(int accountCount)
        {
            string action = "Create Account";
            ReportHeader(actionName: action);

            int i = 0;
            while (i < accountCount)
            {
                Account account = ObjectGenerator.GenerateAccount();
                AccountDictionary.Add(account.Id, account);

                ReportItem(itemName: account.ToString(), actionName: action, itemIndex: i);

                if (account.Role == Role.Student)
                {
                    Student student = ObjectGenerator.GenerateStudent(account.Id);
                    StudentDictionary.Add(account.Id, student);
                    if (account.Status == Status.Pending)
                    {
                        PendingAccountQueue.Enqueue(account);
                    }
                    else if (account.Status == Status.Active)
                    {
                        ActiveStudentList.Add(student);
                    }
                }
                else if (account.Role == Role.Instructor)
                {
                    Instructor instructor = ObjectGenerator.GenerateInstructor(account.Id);
                    InstructorDictionary.Add(account.Id, instructor);
                    if (account.Status == Status.Pending)
                    {
                        PendingAccountQueue.Enqueue(account);
                    }
                    else if (account.Status == Status.Active)
                    {
                        ActiveInstructorList.Add(instructor);
                    }
                }
                i++;
            }

            ReportSummary(actionName: action, itemCount: accountCount);
            ReportFooter(actionName: action);
        }

        public void ActivateAccounts()
        {
            string action = "Activate account";
            ReportHeader(actionName: action);

            int pendingAccountQueueCount = PendingAccountQueue.Count;
            int i = 0;
            while (PendingAccountQueue.Count > 0)
            {
                Account account = PendingAccountQueue.Dequeue();
                account.Status = Status.Active;
                if (account.Role == Role.Student)
                {
                    Student student = null;
                    if (StudentDictionary.TryGetValue(account.Id, out student))
                    {
                        ActiveStudentList.Add(student);
                    }
                }
                else if (account.Role == Role.Instructor)
                {
                    Instructor instructor = null;
                    if (InstructorDictionary.TryGetValue(account.Id, out instructor))
                    {
                        ActiveInstructorList.Add(instructor);
                    }
                }
                i++;

                ReportItem(itemName: account.ToString(), actionName: action, itemIndex: i);
            }

            ReportSummary(actionName: action, itemCount: pendingAccountQueueCount);
            ReportFooter(actionName: action);
        }

        public void CreateSubjects(int subjectCount)
        {
            string action = "Subject generation";
            ReportHeader(actionName: action);

            int i = 0;
            while (i < subjectCount)
            {
                Subject subject = ObjectGenerator.GenerateSubject();
                SubjectList.Add(subject);
                SubjectIdList.Add(subject.Id);
                i++;

                ReportItem(itemName: subject.ToString(), actionName: action, itemIndex: i);
            }

            ReportSummary(actionName: action, itemCount: subjectCount);
            ReportFooter(actionName: action);
        }

        public void CreateModules(int moduleCount)
        {
            string action = "Create Modules";
            ReportHeader(actionName: action);

            if (SubjectIdList.Count == 0)
            {
                ReportError("Subjects", action);
            }
            else
            {
                int i = 0;
                while (i < moduleCount)
                {
                    Guid subjectId = SubjectIdList[AttributeGenerator.random.Next(0, SubjectIdList.Count)];
                    Module module = ObjectGenerator.GenerateModule(subjectId);
                    ModuleDictionary.Add(module.Id, module);
                    ModuleIdList.Add(module.Id);
                    i++;

                    ReportItem(itemName: module.ToString(), actionName: action, itemIndex: i);
                }
            }

            ReportSummary(actionName: action, itemCount: moduleCount);
            ReportFooter(actionName: action);
        }

        public void AssignModulesToInstructors()
        {
            string action = "Assign modules to instructors";
            ReportHeader(actionName: action);

            int i = 0;
            foreach (var instructor in ActiveInstructorList)
            {
                instructor.ModuleList = GetModuleList();
                AddToModuleInstructorList(instructor);
                i++;

                ReportItem(itemName: instructor.ToString(), actionName: action, itemIndex: i);
            }

            ReportSummary(actionName: action, itemCount: i);
            ReportFooter(actionName: action);
        }

        void AddToModuleInstructorList(Instructor instructor)
        {
            List<Instructor> instructorList;
            foreach (var module in instructor.ModuleList)
            {
                if (!ModuleInstructorDictionary.ContainsKey(module.Id))
                {
                    instructorList = new List<Instructor>() { instructor };
                    ModuleInstructorDictionary.Add(module.Id, instructorList);
                }
                else
                {
                    ModuleInstructorDictionary.TryGetValue(module.Id, out instructorList);
                    instructorList.Add(instructor);
                }
            }
        }

        public void AssignModulesToStudents()
        {
            string action = "Assign modules to students";
            ReportHeader(actionName: action);
            int i = 0;
            foreach (var student in ActiveStudentList)
            {
                student.CompletedModuleList = GetModuleList();
                i++;

                ReportItem(itemName: student.ToString(), actionName: action, itemIndex: i);
            }

            ReportSummary(actionName: action, itemCount: i);
            ReportFooter(actionName: action);
        }

        List<Module> GetModuleList()
        {
            ISet<Guid> moduleIdSet = new HashSet<Guid>();
            List<Module> moduleList = new List<Module>();
            if (ModuleIdList.Count == 0)
            {
                ReportError(missingResource: "Modules", failedAction: "Module List");
            }
            else
            {
                int totalModuleCount = ModuleIdList.Count;
                int maxModuleCountLimit = 5;
                int minModuleCountLimit = 2;
                maxModuleCountLimit = Math.Min(totalModuleCount, maxModuleCountLimit);
                minModuleCountLimit = Math.Min(totalModuleCount, minModuleCountLimit);
                int count = AttributeGenerator.random.Next(minModuleCountLimit, maxModuleCountLimit);
                int i = 0;
                while (i < count)
                {
                    Guid moduleId = ModuleIdList[AttributeGenerator.random.Next(0, ModuleIdList.Count)];

                    if (!moduleIdSet.Contains(moduleId))
                    {
                        moduleIdSet.Add(moduleId);
                        Module module;
                        ModuleDictionary.TryGetValue(moduleId, out module);
                        moduleList.Add(module);
                    }
                    i++;
                }
            }
            return moduleList;
        }

        public void CreateClassrooms(int classroomCount)
        {
            string action = "Create Classroom";
            int i = 0;
            ReportHeader(actionName: action);

            if (ModuleIdList.Count == 0)
            {
                ReportError(missingResource: "Modules", failedAction: action);
            }
            else
            {
                while (i < classroomCount)
                {
                    Guid moduleId = ModuleIdList[AttributeGenerator.random.Next(0, ModuleIdList.Count)];
                    Module module;
                    ModuleDictionary.TryGetValue(moduleId, out module);
                    Classroom classroom = ObjectGenerator.GenerateClassroom(module);
                    ClassroomList.Add(classroom);
                    i++;

                    ReportItem(itemName: classroom.ToString(), actionName: action, itemIndex: i);
                }
            }

            ReportSummary(actionName: action, itemCount: i);
            ReportFooter(actionName: action);
        }

        public void AssignInstructorsToClassrooms()
        {
            string action = "Assign Instructors To Classrooms";
            ReportHeader(actionName: action);

            if (ClassroomList.Count == 0)
            {
                ReportError(missingResource: "Instructor", failedAction: action);
            }
            else
            {
                foreach (var classroom in ClassroomList)
                {
                    if (ModuleInstructorDictionary.ContainsKey(classroom.Module.Id))
                    {
                        List<Instructor> instructorList;
                        ModuleInstructorDictionary.TryGetValue(classroom.Module.Id, out instructorList);
                        classroom.Head = instructorList[AttributeGenerator.random.Next(0, instructorList.Count)];
                    }
                    else
                    {
                        ReportError(missingResource: "Instructor", failedAction: action);
                    }
                }
            }

            ReportSummary(actionName: action, itemCount: 1);
            ReportFooter(actionName: action);
        }

        public void RegisterStudentsForClasses()
        {
            string action = "Register Students For Classes";
            ReportHeader(actionName: action);

            if (ClassroomList.Count == 0)
            {
                ReportError(missingResource: "Classroom", failedAction: action);
            }
            else
            {
                foreach (var classroom in ClassroomList)
                {
                    if (classroom.ItemList.Count < classroom.MaximumCapacity)
                    {
                        UpdateStudentList(classroom);
                    }

                }
            }

            ReportSummary(actionName: action, itemCount: ClassroomList.Count);
            ReportFooter(actionName: action);
        }

        void UpdateStudentList(Classroom classroom)
        {
            int maxStudentCountToRegister = Math.Min(classroom.MaximumCapacity - classroom.ItemList.Count, ActiveStudentList.Count);
            int itemListCount = AttributeGenerator.random.Next(0, maxStudentCountToRegister + 1);
            int i = 0;
            while (i < itemListCount)
            {
                Student studentActive = ActiveStudentList[AttributeGenerator.random.Next(0, ActiveStudentList.Count)];

                if (!studentActive.CompletedModuleList.Contains(classroom.Module) && !studentActive.ClassroomList.Contains(classroom))
                {
                    classroom.ItemList.Add(studentActive);
                    studentActive.ClassroomList.Add(classroom);
                    i++;

                    ReportItem(itemName: studentActive.ToString(), actionName: "Registered for class", itemIndex: i);
                }
               
            }
        }

        public void Clear()
        {
            ActiveStudentList.Clear();
            StudentDictionary.Clear();
            ActiveInstructorList.Clear();
            InstructorDictionary.Clear();
            PendingAccountQueue.Clear();
            AccountDictionary.Clear();
            SubjectList.Clear();
            ModuleDictionary.Clear();
            ModuleIdList.Clear();
            SubjectIdList.Clear();
            ClassroomList.Clear();
            ModuleInstructorDictionary.Clear();
        }


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
            Console.WriteLine($" {actionName} {itemIndex} {itemName}\n");
        }

        void ReportSummary(string actionName, int itemCount)
        {
            Console.WriteLine($"'''''' {actionName} {itemCount} ''''''\n");
        }

        void ReportError(string missingResource, string failedAction)
        {
            Console.WriteLine("--------- You do not have the appropriate {0} to {1} ---------\n", missingResource, failedAction);
        }

        #endregion Reports
    }
}
