using System;
using System.Collections.Generic;
using System.Text;
using LearningMissionLab;
namespace LearningMissionSimulation
{
    class PlaygroundVahe : ISimulation
    {
        #region Fields
        Dictionary<Guid, Account> _accountDictionary = new Dictionary<Guid, Account>();
        Dictionary<Guid, Instructor> _instructorDictionary = new Dictionary<Guid, Instructor>();
        List<Student> _activeStudentList = new List<Student>();
        Dictionary<Guid, Student> _studentDictionary = new Dictionary<Guid, Student>();
        List<Instructor> _activeInstructorList = new List<Instructor>();
        List<Account> _pendingAccountList = new List<Account>();
        List<Subject> _subjectList = new List<Subject>();
        List<Guid> _subjectIdList = new List<Guid>();
        List<Guid> _moduleIdList = new List<Guid>();
        List<Student> _studentList = new List<Student>();
        List<Instructor> _instructorList = new List<Instructor>();
        Dictionary<Guid, Module> _moduleDictionary = new Dictionary<Guid, Module>();
        Dictionary<Guid, Classroom> _classroomDictionary = new Dictionary<Guid, Classroom>();
        Dictionary<Guid, List<Instructor>> _moduleInstructorListDictionary = new Dictionary<Guid, List<Instructor>>();
        #endregion Fields

        public void CreateAccounts(int accountCount)
        {
            ReportHeader("Create account");
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
                ReportItem(account.ToString(), "Create account", i++);
            }
            ReportSummary("Account", accountCount);
            ReportFooter("Create account");
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
            ReportHeader("Pending accounts is activating");
            if (PendingAccountList.Count != 0)
            {
                int i = 0;
                foreach (var account in PendingAccountList)
                {
                    account.Status = Status.Active;
                    PendingAccountList.Remove(account);
                    ReportItem(account.ToString(), "Accounts", i);
                }
                ReportFooter("accounts");
            }
            ReportError(PendingAccountList.ToString(),"account");
        }

        public void CreateSubjects(int subjectCount)
        {
            ReportHeader("Subjects generation");
            for (int i = 0; i < subjectCount; i++)
            { 
                Subject subject = ObjectGenerator.GenerateSubject();
                SubjectList.Add(subject);
                SubjectIdList.Add(subject.Id);
                ReportItem(subject.ToString(), "Subjects", i);
            }

            ReportSummary("Subjects", subjectCount);
            ReportFooter("Subjects generated");
        }

        public void CreateModules(int moduleCount)
        {
            ReportHeader("Modules generation");
            if (SubjectIdList.Count > 0)
            {
                for (int i = 0; i < moduleCount; i++)
                {
                    Guid subjectId = SubjectIdList[AttributeGenerator.random.Next(0, SubjectIdList.Count)];
                    Module module = ObjectGenerator.GenerateModule(subjectId);
                    ModuleDictionary.Add(module.Id, module);
                    ModuleIdList.Add(module.Id);
                    ReportItem(module.ToString(), "Modules", i);
                }
            }
            ReportSummary("Modules", moduleCount);
            ReportFooter("Modules generated");
            ReportError(SubjectIdList.ToString(), "module");
        }

        public void AssignModulesToInstructors()
        {
            ReportHeader("Assigning modules to instructors");
            int i = 0;
            foreach (var instructor in ActiveInstructorList)
            {
                instructor.ModuleList = GetModuleList();
                AddInstructorToModuleList(instructor);
                ReportItem(instructor.ToString(), "Assign instructors", i++);
            }
            ReportFooter("Assigned modules to instructors");
        }

        public void AssignModulesToStudents()
        {
            ReportHeader("Assigning modules to students");
            int i = 0;
            foreach (var student in ActiveStudentList)
            {
                student.CompletedModuleList = GetModuleList();
                ReportItem(student.ToString(), "Assign students", i++);

            }
            ReportFooter("Assigned modules to students");
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
            ReportHeader("Create classrooms");
            if (ModuleIdList.Count != 0)
            {
                int i = 0;
                while (i < classroomCount)
                {
                    Guid moduleId = ModuleIdList[AttributeGenerator.random.Next(0, ModuleIdList.Count)];
                    Module module;
                    ModuleDictionary.TryGetValue(moduleId, out module);
                    Classroom classroom = ObjectGenerator.GenerateClassroom(module);
                    ClassroomDictionary.Add(classroom.Id, classroom);
                    ReportSummary("Classrooms", classroomCount);
                    ReportFooter("Modules generated");
                }
            }
            ReportError(ModuleIdList.ToString(), "classroom");
        }

        public void AssignInstructorsToClassrooms()
        {
            if(ActiveInstructorList.Count > 0 && ClassroomDictionary.Count > 0)
            {
                foreach (var classroom in ClassroomDictionary.Values)
                {
                    Guid moduleId = classroom.Module.Id;
                    List<Instructor> instructorList;
                    if (ModuleInstructorListDictionary.ContainsKey(moduleId))
                    {
                        ModuleInstructorListDictionary.TryGetValue(moduleId, out instructorList);
                    }
                }
            }
        }

        void AddInstructorToModuleList(Instructor instructor)
        {
            List<Module> moduleList = instructor.ModuleList;
            foreach (var module in moduleList)
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

        public void RegisterStudentsForClasses()
        {
            throw new NotImplementedException();
        }

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

        #region ReportMethods
        void ReportHeader(string actionName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" <<<<< {actionName} is started >>>>> \n");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        void ReportFooter(string actionName)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($" <<<<< {actionName} is finished >>>>> \n");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        void ReportItem(string itemName, string actionName, int itemIndex)
        {
            Console.WriteLine($"{actionName} {itemIndex}\n{itemName}");
        }

        void ReportSummary(string summary, int count)
        {
            Console.WriteLine($"<<<<< Generated {count} {summary} >>>>>\n");
        }
        void ReportError(string missingResource, string failedAction)
        {
            Console.WriteLine($"<<<<< Satisfy the condition first and then start work. Shoild be" +
                              $"{missingResource}  in order to {failedAction} will be created >>>>>");
        }

        #endregion ReportMethods

        public static void Play()
        {
            Console.WriteLine(AttributeGenerator.GetLanguageLevel());
            Console.WriteLine(AttributeGenerator.GetLanguageName());
        }

        #region Properties
        public Dictionary<Guid, Account> AccountDictionary { get => _accountDictionary; set => _accountDictionary = value; }
        public Dictionary<Guid, Instructor> InstructorDictionary { get => _instructorDictionary; set => _instructorDictionary = value; }
        public List<Student> ActiveStudentList { get => _activeStudentList; set => _activeStudentList = value; }
        public Dictionary<Guid, Student> StudentDictionary { get => _studentDictionary; set => _studentDictionary = value; }
        public List<Instructor> ActiveInstructorList { get => _activeInstructorList; set => _activeInstructorList = value; }
        public List<Account> PendingAccountList { get => _pendingAccountList; set => _pendingAccountList = value; }
        public List<Subject> SubjectList { get => _subjectList; set => _subjectList = value; }
        public List<Guid> SubjectIdList { get => _subjectIdList; set => _subjectIdList = value; }
        public List<Guid> ModuleIdList { get => _moduleIdList; set => _moduleIdList = value; }
        public List<Student> StudentList { get => _studentList; set => _studentList = value; }
        public List<Instructor> InstructorList { get => _instructorList; set => _instructorList = value; }
        public Dictionary<Guid, Module> ModuleDictionary { get => _moduleDictionary; set => _moduleDictionary = value; }
        public Dictionary<Guid, Classroom> ClassroomDictionary { get => _classroomDictionary; set => _classroomDictionary = value; }
        public Dictionary<Guid, List<Instructor>> ModuleInstructorListDictionary { get => _moduleInstructorListDictionary; set => _moduleInstructorListDictionary = value; }
        #endregion Properties
    }
}
