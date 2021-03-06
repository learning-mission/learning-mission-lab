using System;
using System.Collections.Generic;
using System.Text;
using LearningMissionLab;
namespace LearningMissionSimulation
{
    class PlaygroundVahe : ISimulation
    {
        #region Properties and fields
        public ReportType ReportType { get; set; } = ReportType.Verbose;
        public Dictionary<Guid, Account> AccountDictionary { get; set; } = new Dictionary<Guid, Account>();
        public Dictionary<Guid, Instructor> InstructorDictionary { get; set; } = new Dictionary<Guid, Instructor>();
        public List<Student> ActiveStudentList { get; set; } = new List<Student>();
        public Dictionary<Guid, Student> StudentDictionary { get; set; } = new Dictionary<Guid, Student>();
        public List<Instructor> ActiveInstructorList { get; set; } = new List<Instructor>();
        public List<Account> PendingAccountList { get; set; } = new List<Account>();
        public List<Subject> SubjectList { get; set; } = new List<Subject>();
        public List<Guid> SubjectIdList { get; set; } = new List<Guid>();
        public List<Guid> ModuleIdList { get; set; } = new List<Guid>();
        public List<Student> StudentList { get; set; } = new List<Student>();
        public List<Instructor> InstructorList { get; set; } = new List<Instructor>();
        public Dictionary<Guid, Module> ModuleDictionary { get; set; } = new Dictionary<Guid, Module>();
        public Dictionary<Guid, Classroom> ClassroomDictionary { get; set; } = new Dictionary<Guid, Classroom>();
        public Dictionary<Guid, List<Instructor>> ModuleInstructorListDictionary { get; set; } = new Dictionary<Guid, List<Instructor>>();
        #endregion Properties and fields

        public PlaygroundVahe()
        {

        }

        public PlaygroundVahe(ReportType reportType)
        {
            this.ReportType = reportType;
        }

        public void CreateAccounts(int accountCount)
        {
            string action = "Create accounts";
            ReportHeader(action);
            int i = 0;

            while (i < accountCount)
            {
                Account account = ObjectGenerator.GenerateAccount();
                AccountDictionary.Add(account.Id, account);
                if (account.Role == Role.Instructor)
                {
                    Instructor instructor = ObjectGenerator.GenerateInstructor(account.Id);
                    InstructorDictionary.Add(account.Id, instructor);
                    if (account.Status == Status.Pending)
                    {
                        if (IsArmenianAndEnglishPresent(instructor.LanguageList))
                        {
                            PendingAccountList.Add(account);
                        }
                    }
                    else if (account.Status == Status.Active)
                    {
                        ActiveInstructorList.Add(instructor);
                    }
                }
                else if (account.Role == Role.Student)
                {
                    Student student = ObjectGenerator.GenerateStudent(account.Id);
                    StudentDictionary.Add(account.Id, student);
                    if (account.Status == Status.Pending)
                    {
                        if (IsArmenianAndEnglishPresent(student.LanguageList))
                        {
                            PendingAccountList.Add(account);
                        }
                    }
                    else if (account.Status == Status.Active)
                    {
                        ActiveStudentList.Add(student);
                    }
                }
                ReportItem(account.ToString(), action, i++);
            }
            ReportSummary(action, accountCount, "account");
            ReportFooter(action);
        }

        bool IsArmenianAndEnglishPresent(List<Language> languageList)
        {
            bool isArmenian = false;
            bool isEnglish = false;

            foreach (Language language in languageList)
            {
                if (language.LanguageName == LanguageName.English)
                {
                    isEnglish = true;
                }
                else if (language.LanguageName == LanguageName.Armenian)
                {
                    isArmenian = true;
                }
                if (isArmenian && isEnglish)
                {
                    return true;
                }
            }
            return false;
        }

        public void ActivateAccounts()
        {
            string action = "Activate account";
            ReportHeader(action);
            int count = 0;

            if (PendingAccountList.Count == 0)
            {
                ReportError(PendingAccountList.ToString(), "account");
            }
            else
            {
                PendingAccountList = new List<Account>();
                foreach (var account in PendingAccountList)
                {
                    account.Status = Status.Active;
                    if (account.Role == Role.Student)
                    {
                        Student student;
                        if (StudentDictionary.ContainsKey(account.Id))
                        {
                            StudentDictionary.TryGetValue(account.Id, out student);
                            ActiveStudentList.Add(student);
                        }
                    }
                    else if (account.Role == Role.Instructor)
                    {
                        Instructor instructor;
                        if (InstructorDictionary.ContainsKey(account.Id))
                        {
                            InstructorDictionary.TryGetValue(account.Id, out instructor);
                            ActiveInstructorList.Add(instructor);
                        }
                    }
                    ReportItem(account.ToString(), action, count++);
                    PendingAccountList.Remove(account);
                }
            }
            ReportSummary(action, count, "account");
            ReportFooter(action);
        }

        public void CreateSubjects(int subjectCount)
        {
            string action = "Subjects generation";
            ReportHeader(action);

            for (int i = 0; i < subjectCount; i++)
            {
                Subject subject = ObjectGenerator.GenerateSubject();
                SubjectList.Add(subject);
                SubjectIdList.Add(subject.Id);
                ReportItem(subject.ToString(), action, i);
            }

            ReportSummary(action, subjectCount, "subject");
            ReportFooter(action);
        }

        public void CreateModules(int moduleCount)
        {
            string action = "Modules generation";
            ReportHeader(action);

            if (SubjectIdList.Count == 0)
            {
                ReportError(SubjectIdList.ToString(), action);
            }
            else
            {
                for (int i = 0; i < moduleCount; i++)
                {
                    Guid subjectId = SubjectIdList[AttributeGenerator.random.Next(0, SubjectIdList.Count)];
                    Module module = ObjectGenerator.GenerateModule(subjectId);
                    ModuleDictionary.Add(module.Id, module);
                    ModuleIdList.Add(module.Id);
                    ReportItem(module.ToString(), action, i);
                }
            }
            ReportSummary(action, moduleCount, "module");
            ReportFooter(action);
        }

        public void AssignModulesToInstructors()
        {
            string action = "Assign modules to instructors";
            ReportHeader(action);

            int i = 0;
            foreach (var instructor in ActiveInstructorList)
            {
                instructor.ModuleList = GetModuleList();
                AddInstructorToModuleList(instructor);
                ReportItem(instructor.ToString(), action, i++);
            }
            ReportSummary(action, i, "instructor");
            ReportFooter(action);
        }

        public void AssignModulesToStudents()
        {
            string action = "Assign modules to students";
            ReportHeader(action);

            int i = 0;
            foreach (var student in ActiveStudentList)
            {
                student.CompletedModuleList = GetModuleList();
                ReportItem(student.ToString(), action, i++);

            }
            ReportSummary(action, i, "student");
            ReportFooter(action);
        }

        List<Module> GetModuleList()
        {
            HashSet<Guid> moduleIdSet = new HashSet<Guid>();
            List<Module> moduleList = new List<Module>();
            int totalModuleCount = ModuleIdList.Count;
            int maxModuleCountLimit = SimulationConstants.MaxModuleCountLimit;
            int minModuleCountLimit = SimulationConstants.MinModuleCountLimit;
            minModuleCountLimit = Math.Min(totalModuleCount, minModuleCountLimit);
            maxModuleCountLimit = Math.Min(totalModuleCount, maxModuleCountLimit);
            int count = AttributeGenerator.random.Next(minModuleCountLimit, maxModuleCountLimit);

            for (int i = 0; i < count; i++)
            {
                Guid moduleId = ModuleIdList[AttributeGenerator.random.Next(0, ModuleIdList.Count)];
                if (!moduleIdSet.Contains(moduleId))
                {
                    moduleIdSet.Add(moduleId);
                    Module module;
                    ModuleDictionary.TryGetValue(moduleId, out module);
                    moduleList.Add(module);
                }
            }
            return moduleList;
        }

        public void CreateClassrooms(int classroomCount)
        {
            string action = "Create classrooms";
            ReportHeader(action);

            if (ModuleIdList.Count == 0)
            {
                ReportError(ModuleIdList.ToString(), action);
            }
            else
            {
                int i = 0;
                while (i < classroomCount)
                {
                    Guid moduleId = ModuleIdList[AttributeGenerator.random.Next(0, ModuleIdList.Count)];
                    Module module;
                    ModuleDictionary.TryGetValue(moduleId, out module);
                    Classroom classroom = ObjectGenerator.GenerateClassroom(module);
                    ClassroomDictionary.Add(classroom.Id, classroom);
                    ReportItem(classroom.ToString(), action, i++);
                }
            }
            ReportSummary(action, classroomCount, "classroom");
            ReportFooter(action);
        }

        public void AssignInstructorsToClassrooms()
        {
            string action = "Assign instructor to classroom";
            ReportHeader(action);

            if (ActiveInstructorList.Count == 0)
            {
                ReportError(ActiveInstructorList.ToString(), action);
            }
            else if (ClassroomDictionary.Count == 0)
            {
                ReportError(ClassroomDictionary.ToString(), action);
            }
            else
            {
                int count = 0;
                foreach (var classroom in ClassroomDictionary.Values)
                {
                    Guid moduleId = classroom.Module.Id;
                    List<Instructor> instructorList;

                    if (ModuleInstructorListDictionary.ContainsKey(moduleId))
                    {
                        ModuleInstructorListDictionary.TryGetValue(moduleId, out instructorList);
                        classroom.Head = instructorList[AttributeGenerator.random.Next(0, instructorList.Count)];
                        ReportItem(classroom.ToString(), action, ++count);
                    }
                }
            }
            ReportSummary(action, 1, "classroom");
            ReportFooter(action);
        }

        void AddInstructorToModuleList(Instructor instructor)
        {
            List<Module> moduleList = instructor.ModuleList;
            foreach (var module in moduleList)
            {
                List<Instructor> instructorList;

                if (ModuleInstructorListDictionary.TryGetValue(module.Id, out instructorList))
                {
                    instructorList.Add(instructor);
                }
                else
                {
                    instructorList = new List<Instructor>() { instructor };
                    ModuleInstructorListDictionary.Add(module.Id, instructorList);
                }
            }
        }

        public void RegisterStudentsForClasses()
        {
            string action = "Register Students For Classes";
            int itemListCount = 0;
            ReportHeader(action);

            if (ClassroomDictionary.Count == 0)
            {
                ReportError(ClassroomDictionary.ToString(), action);
            }
            else
            {
                foreach (var classroom in ClassroomDictionary.Values)
                {
                    if (classroom.ItemList.Count < classroom.MaximumCapacity)
                    {
                        UpdateStudentList(classroom);
                        ++itemListCount;
                    }
                }
            }

            ReportSummary(action, itemListCount, "classroom");
            ReportFooter(action);
        }

        void UpdateStudentList(Classroom classroom)
        {
            string action = "Register Students For Classes";

            if (ActiveStudentList.Count == 0)
            {
                ReportError(ActiveStudentList.ToString(), action);
            }
            else
            {
                int itemListCount = AttributeGenerator.random.Next(0, classroom.MaximumCapacity - classroom.ItemList.Count + 1);
                itemListCount = Math.Min(itemListCount, ActiveStudentList.Count);

                foreach (Student student in ActiveStudentList)
                {
                    if (!student.CompletedModuleList.Contains(classroom.Module) && !student.ClassroomList.Contains(classroom))
                    {
                        student.ClassroomList.Add(classroom);
                        classroom.ItemList.Add(student);
                        ReportItem(student.ToString(), action, itemListCount);
                    }
                }
            }
        }

        #region ReportMethods
        void ReportHeader(string actionName)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($" <<<<< {actionName} is started >>>>> \n");
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        void ReportFooter(string actionName)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($" <<<<< {actionName} is finished >>>>> \n");
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        void ReportItem(string itemName, string actionName, int itemIndex)
        {
            Console.WriteLine($"{actionName} {itemIndex} {itemName} \n");
        }

        void ReportSummary(string actionName, int itemCount, string itemName)
        {
            Console.WriteLine($" <<<<<  Performed {actionName} for {itemCount} {itemName}(s) >>>>> \n");
        }
        void ReportError(string missingResource, string failedAction)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"<<<<< Satisfy the condition first and then start work. Should be" +
                              $" {missingResource}  in order to {failedAction} start working >>>>>");
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        #endregion ReportMethods

        public void SimulationAll(int count)
        {

            CreateAccounts(count);
            ActivateAccounts();
            CreateSubjects(count);
            CreateModules(count);
            AssignModulesToStudents();
            AssignModulesToInstructors();
            CreateClassrooms(count);
            AssignInstructorsToClassrooms();
        }

        public void Clear()
        {
            ActiveStudentList.Clear();
            StudentDictionary.Clear();
            ActiveInstructorList.Clear();
            InstructorDictionary.Clear();
            PendingAccountList.Clear();
            AccountDictionary.Clear();
            SubjectList.Clear();
            ModuleDictionary.Clear();
            ModuleIdList.Clear();
            SubjectIdList.Clear();
            ClassroomDictionary.Clear();
            ModuleInstructorListDictionary.Clear();
        }
    }
}
