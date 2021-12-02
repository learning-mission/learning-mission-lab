using LearningMissionLab;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionSimulation
{
    public class PlaygroundGarush : ISimulation
    {
        ReportType _reportType;
        List<Account> _pendingAccountList = new List<Account>();
        List<Student> _studentList = new List<Student>();
        List<Instructor> _instructorList = new List<Instructor>();
        Dictionary<Guid, Account> _accountDictionary = new Dictionary<Guid, Account>();
        List<Subject> _subjectList = new List<Subject>();
        List<Guid> _subjectIdList = new List<Guid>();
        Dictionary<Guid, Module> _moduleDictionary = new Dictionary<Guid, Module>();
        List<Guid> _moduleIdList = new List<Guid>();
        Dictionary<Guid, Classroom> _classroomDictionary = new Dictionary<Guid, Classroom>();

        public PlaygroundGarush()
        {

        }
        public PlaygroundGarush(ReportType reportType)
        {
            this.ReportType = reportType;
        }
        public ReportType ReportType { get => _reportType; set => _reportType = value; }
        public List<Account> PendingAccountList { get => _pendingAccountList; set => _pendingAccountList = value; }
        public List<Student> StudentList { get => _studentList; set => _studentList = value; }
        public List<Instructor> InstructorList { get => _instructorList; set => _instructorList = value; }
        public Dictionary<Guid, Account> AccountDictionary { get => _accountDictionary; set => _accountDictionary = value; }
        public List<Subject> SubjectList { get => _subjectList; set => _subjectList = value; }
        public List<Guid> SubjectIdList { get => _subjectIdList; set => _subjectIdList = value; }
        public Dictionary<Guid, Module> ModuleDictionary { get => _moduleDictionary; set => _moduleDictionary = value; }
        public List<Guid> ModuleIdList { get => _moduleIdList; set => _moduleIdList = value; }
        public Dictionary<Guid, Classroom> ClassroomDictionary { get => _classroomDictionary; set => _classroomDictionary = value; }

        public void CreateAccounts(int accountCount)
        {
            string action = " create account ";
            ReportHeader(actionName: action);
            for (int i = 0; i < accountCount; i++)
            {                
                Account account = ObjectGenerator.GenerateAccount();

                AccountDictionary.Add(account.Id, account);
                if (account.Role == Role.Student)
                {
                    Student student = ObjectGenerator.GenerateStudent(account.Id);
                    StudentList.Add(student);
                    if (student.Gender == Gender.Female && account.Status == Status.Pending)
                    {
                        PendingAccountList.Add(account);
                    }
                    student.Report();
                }
                else if (account.Role == Role.Instructor)
                {
                    Instructor instructor = (ObjectGenerator.GenerateInstructor(account.Id));
                    InstructorList.Add(instructor);
                    if (instructor.Gender == Gender.Female && account.Status == Status.Pending)
                    {
                        PendingAccountList.Add(account);
                    }
                    instructor.Report();
                }               
            }

            ReportSummary(actionName: action, count: accountCount);
            ReportFooter(actionName: action);
        }

        public void ActivateAccounts()
        {
            string action = "activate account";
            int item = 0;
            ReportHeader(actionName: action);
            for (int i = 0; i < PendingAccountList.Count; i++)
            {
                PendingAccountList[i].Status = Status.Active;
                Console.WriteLine($" activated account is{PendingAccountList[i]}\n");
            }            
           
            ReportSummary(actionName: action, count: item);
            ReportFooter(actionName: action);
            PendingAccountList.Clear();
        }

        public void AssignModulesToInstructors()
        {
            string action = "Assign modules to instructor";
            int count = 0;
            ReportHeader(actionName: action);
            foreach (var instructor in InstructorList)
            {
                instructor.ModuleList = GetModuleList();
                Console.WriteLine(instructor);
            }

            ReportSummary(actionName: action, count: count);
            ReportFooter(actionName: action);
        }

        List<Module> GetModuleList()
        {
            List<Module> moduleList = new List<Module>();
            int allModuleCount = ModuleIdList.Count;
            int minModuleCount = 2;
            int maxModuleCount = 5;
            minModuleCount = Math.Min(allModuleCount, minModuleCount);
            maxModuleCount = Math.Min(allModuleCount, maxModuleCount);
            int moduleCount = AttributeGenerator.random.Next(minModuleCount, maxModuleCount + 1);

            for (int i = 0; i < moduleCount; i++)
            {
                Guid id = ModuleIdList[AttributeGenerator.random.Next(0, ModuleIdList.Count)];

                Module module;

                ModuleDictionary.TryGetValue(id, out module);
                if (!moduleList.Contains(module))
                {
                    moduleList.Add(module);
                }                               
            }
            return moduleList;
        }

        public void AssignModulesToStudents()
        {
            string action = "Assing Modules to students";
            int count = 0;
            ReportHeader(actionName: action);
            foreach (var student in StudentList)
            {
                student.CompletedModuleList = GetModuleList();
                Console.WriteLine(student);
            }

            ReportSummary(actionName: action, count: count);
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
                Console.WriteLine("\ncreate subject {0}\n", subject);
                i++;
                ReportItem(itemName: subject.ToString(), actionName: action, itemIndex: i);
            }

            ReportSummary(actionName: action, count:subjectCount);
            ReportFooter(actionName: action);
        }

        public void CreateModules(int moduleCount)
        {
            string action = "Subject generation";
            ReportHeader(actionName: action);
            int i = 0;
            while (i < moduleCount)
            {
                Guid subjectId = SubjectIdList[AttributeGenerator.random.Next(0, SubjectIdList.Count)];
                Module module = ObjectGenerator.GenerateModule(subjectId);
                ModuleDictionary.Add(module.Id, module);
                ModuleIdList.Add(module.Id);
                Console.WriteLine("\ncreate module {0}\n", module);
                i++;
                ReportItem(itemName: module.ToString(), actionName: action, itemIndex: i);
            }

            ReportSummary(actionName: action, count: moduleCount);
            ReportFooter(actionName: action);
        }

        public void CreateClassrooms(int classroomCount)
        {
            string action = "create Classrooms";
            int iSuccess = 0;
            int attemptCount = 0;
            ReportHeader(actionName: action);

            if (ModuleIdList.Count == 0)
            {
                ReportError(missingResource: "Module", failedAction: action);
            }
            else
            {
                while (attemptCount < classroomCount)
                {
                    Guid moduleId = ModuleIdList[AttributeGenerator.random.Next(0, ModuleIdList.Count)];
                    Module module;
                   if(ModuleDictionary.TryGetValue(moduleId, out module))
                   {
                    Classroom classroom = ObjectGenerator.GenerateClassroom(module);
                    ClassroomDictionary.Add(classroom.Id, classroom);
                    ReportItem(itemName: classroom.ToString(), actionName: action, itemIndex: ++iSuccess);                    
                   }
                   attemptCount++;   
                }
            }

            ReportSummary(actionName: action, count: iSuccess);
            ReportFooter(actionName: action);
        }

        public void RegisterStudentsForClasses()
        {
            throw new NotImplementedException();
        }
        
        public void AssignInstructorsToClassrooms()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            // Clear all internal data structures 
            throw new NotImplementedException();
        }

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
                Console.WriteLine($"'----{actionName} {count}----\n");
            }
        }

        void ReportError(string missingResource, string failedAction)
        {
            switch (this.ReportType)
            {
                case ReportType.Error:
                case ReportType.Verbose:
                case ReportType.Short:
                    Console.WriteLine("xxx You do not have the appropriate {0} to {1} xxx\n", missingResource, failedAction);
                    break;
            }
        }
        #endregion Reports
    }
}
