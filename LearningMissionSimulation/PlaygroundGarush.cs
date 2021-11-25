using LearningMissionLab;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionSimulation
{
    public class PlaygroundGarush : ISimulation
    {
        ReportType _reportType;
        List<Account> pendingAccountList = new List<Account>();
        List<Student> studentList = new List<Student>();
        List<Instructor> instructorList = new List<Instructor>();
        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();
        List<Subject> subjectList = new List<Subject>();
        List<Guid> subjectIdList = new List<Guid>();
        Dictionary<Guid, Module> moduleDictionary = new Dictionary<Guid, Module>();
        List<Guid> moduleIdList = new List<Guid>();

        public PlaygroundGarush(ReportType reportType)
        {
            this.ReportType = reportType;
        }
        public ReportType ReportType { get => _reportType; set => _reportType = value; }

        public void CreateAccounts(int accountCount)
        {
            string action = "Create accounts ";
            ReportHeader(actionName: action);
            for (int i = 0; i < accountCount; i++)
            {                
                Account account = ObjectGenerator.GenerateAccount();

                accountDictionary.Add(account.Id, account);
                if (account.Role == Role.Student)
                {
                    Student student = ObjectGenerator.GenerateStudent(account.Id);
                    studentList.Add(student);

                    ReportItem(itemName: account.ToString(), actionName: action, itemIndex: i);
                    if (student.Gender == Gender.Female && account.Status == Status.Pending)
                    {
                        pendingAccountList.Add(account);
                    }
                    student.Report();
                }
                else if (account.Role == Role.Instructor)
                {
                    Instructor instructor = (ObjectGenerator.GenerateInstructor(account.Id));
                    instructorList.Add(instructor);
                    if (instructor.Gender == Gender.Female && account.Status == Status.Pending)
                    {
                        pendingAccountList.Add(account);
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
            for (int i = 0; i < pendingAccountList.Count; i++)
            {
                pendingAccountList[i].Status = Status.Active;

                ReportItem(itemName:item.ToString(), actionName: action, itemIndex: i);
            }            
           
            pendingAccountList.Clear();
            ReportSummary(actionName: action, count: item);
            ReportFooter(actionName: action);
        }

        public void AssignModulesToInstructors()
        {
            string action = "Assign modules to instructor";
            int count = 0;
            ReportHeader(actionName: action);
            foreach (var instructor in instructorList)
            {
                instructor.ModuleList = GetModuleList();
                
                ReportItem(itemName: count.ToString(), actionName: action, itemIndex: count);
            }

            ReportSummary(actionName: action, count: count);
            ReportFooter(actionName: action);
        }

        List<Module> GetModuleList()
        {
            List<Module> moduleList = new List<Module>();
            int allModuleCount = moduleIdList.Count;
            int minModuleCount = 2;
            int maxModuleCount = 5;
            minModuleCount = Math.Min(allModuleCount, minModuleCount);
            maxModuleCount = Math.Min(allModuleCount, maxModuleCount);
            int moduleCount = AttributeGenerator.random.Next(minModuleCount, maxModuleCount + 1);

            for (int i = 0; i < moduleCount; i++)
            {
                Guid id = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count)];

                Module module;

                moduleDictionary.TryGetValue(id, out module);
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
            int count = studentList.Count;
            ReportHeader(actionName: action);
            foreach (var student in studentList)
            {
                student.CompletedModuleList = GetModuleList();

                ReportItem(itemName: count.ToString(), actionName: action, itemIndex: count);               
            }

            ReportSummary(actionName: action, count: count);
            ReportFooter(actionName: action);
        }

        public void CreateSubjects(int subjectCount)
        {
            string action = "Create subject";
            ReportHeader(actionName: action);
            int i = 0;            
            while (i < subjectCount)
            {  
                
                Subject subject = ObjectGenerator.GenerateSubject();
                subjectList.Add(subject);
                subjectIdList.Add(subject.Id);
                if (subjectList.Count==0)
                {
                    ReportError(missingResource: "Subject", failedAction: action);
                }               
                
                ReportItem(itemName: subject.ToString(), actionName: action, itemIndex: ++i);
            }

            ReportSummary(actionName: action, count:subjectCount);
            ReportFooter(actionName: action);
        }

        public void CreateModules(int moduleCount)
        {
            string action = "Create module";
            ReportHeader(actionName: action);
            int i = 0;
            while (i < moduleCount)
            {
                Guid subjectId = subjectIdList[AttributeGenerator.random.Next(0, subjectIdList.Count)];
                Module module = ObjectGenerator.GenerateModule(subjectId);
                moduleDictionary.Add(module.Id, module);
                moduleIdList.Add(module.Id); 
                
                ReportItem(itemName: module.ToString(), actionName: action, itemIndex: ++i);
            }

            ReportSummary(actionName: action, count: moduleCount);
            ReportFooter(actionName: action);
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
