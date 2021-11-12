using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class PlaygroundMher : ISimulation
    {
        List<Student> studentList = new List<Student>();

        List<Instructor> instructorList = new List<Instructor>();

        Queue<Account> pendingAccountQueue = new Queue<Account>();

        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();

        List<Subject> subjectList = new List<Subject>();

        Dictionary<Guid, Module> moduleDictionary = new Dictionary<Guid, Module>();

        List<Guid> moduleIdList = new List<Guid>();

        List<Guid> subjectIdList = new List<Guid>();

        public void CreateAccounts(int accountCount)
        {
            ReportItem("Started creating accounts");
            int i = 0;
            while (i < accountCount)
            {
                ReportHeader($"Created  account {i}"); 
                Account account = ObjectGenerator.GenerateAccount();
                accountDictionary.Add(account.Id, account);
                if (account.Role == Role.Student)
                {
                    Student student = ObjectGenerator.GenerateStudent(account.Id);
                    studentList.Add(student);
                    if (account.Status == Status.Pending)
                    {
                        pendingAccountQueue.Enqueue(account);
                    }
                }
                else if(account.Role == Role.Instructor)
                {
                    Instructor instructor = ObjectGenerator.GenerateInstructor(account.Id);
                    instructorList.Add(instructor);
                    if(account.Status == Status.Pending)
                    {
                        pendingAccountQueue.Enqueue(account);
                    }
                }
                i++;
            }
            ReportHeader($"Generated {accountCount} Accounts");
            ReportItem(" Finished creating accounts"); 
        }

        public void ActivateAccounts()
        {
            ReportItem("Started activating accounts");
            int pendingAccountQueueCount = pendingAccountQueue.Count;
            while(pendingAccountQueue.Count > 0)
            {
                Account account = pendingAccountQueue.Dequeue();
                account.Status = Status.Active;
                ReportSummary($"Activated account", Convert.ToString(account)); 
            }
            ReportHeader($"Activated {pendingAccountQueueCount} accounts "); 
            ReportItem("Finished activating accounts");
        }

        public void CreateSubjects(int subjectCount)
        {
            ReportItem("Started creating subjects"); 
            int i = 0;
            while (i < subjectCount)
            {
                Subject subject = ObjectGenerator.GenerateSubject();
                ReportSummary($"Created  Subject {i}", Convert.ToString(subject));
                subjectList.Add(subject);
                subjectIdList.Add(subject.Id);
                i++;
            }
            ReportHeader($"Generated {subjectCount} Subjects "); 
            ReportItem("Finished creating subjects");
        }

        public void CreateModules(int moduleCount)
        {
            ReportItem("Started creating modules"); 
            int i = 0;
            if(subjectIdList.Count != 0)
            {
                while (i < moduleCount)
                {
                    Guid subjectId = subjectIdList[AttributeGenerator.random.Next(0, subjectIdList.Count)];
                    Module module = ObjectGenerator.GenerateModule(subjectId);
                    moduleDictionary.Add(module.Id, module);
                    moduleIdList.Add(module.Id);
                    ReportSummary($"Created  Module {i}", Convert.ToString(module));
                    i++;
                }
            }

            ReportHeader($"Generated {moduleCount} Modules "); 
            ReportItem("Finished creating modules"); 
        }

        public void AssignModulesToInstructors()
        {
            ReportItem("Started assigning modules to instructors");
            int i = 0;
            foreach (var instructor in instructorList)
            {
                instructor.ModuleList = GetModuleList();
                ReportHeader($"Generated List Number {i + 1} of the Instructor Number {i + 1}");
                i++;
            }
            ReportHeader($"Generated Lists of the Instructors Module List"); 
            ReportItem("Finished assigning modules to instructors"); 
        }

        public void AssignModulesToStudents()
        {
            ReportItem("Started assigning modules to students"); 
            int i = 0;
            foreach (var student in studentList)
            {
                ReportHeader($" List of modules assigned to student {student.AccountId}, {student.FirstName},  {student.LastName}");
                student.CompletedModuleList = GetModuleList();
                i++;
            }
            ReportItem("Finished assigning modules to students"); 
        }

        List<Module> GetModuleList() 
        {
            ISet<Guid> moduleIdSet = new HashSet<Guid>();
            List<Module> moduleList = new List<Module>();
            int totalModuleCount = moduleIdList.Count;
            int maxModuleCountLimit = 5;
            int minModuleCountLimit = 2;
            maxModuleCountLimit = Math.Min(totalModuleCount, maxModuleCountLimit);
            minModuleCountLimit = Math.Min(totalModuleCount, minModuleCountLimit);
            int count = AttributeGenerator.random.Next(minModuleCountLimit, maxModuleCountLimit);
            int i = 0;
            while (i < count)
            {
                Guid moduleId = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count)];
                
                if (!moduleIdSet.Contains(moduleId))
                {
                    moduleIdSet.Add(moduleId);
                    ReportSummary("Randomly selected module id is", Convert.ToString(moduleId));
                    Module module;
                    moduleDictionary.TryGetValue(moduleId, out module);
                    moduleList.Add(module);
                    ReportSummary("Added module", Convert.ToString(module)); 
                }
                i++;
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

        void ReportItem( string actionDescription)
        {
            Console.WriteLine("\n************* {0} *************\n",actionDescription);
        }

        void ReportSummary(string actionDescription, string itemDiscriprionCount)
        {
            Console.WriteLine("\n=========== {0} ==========\n{1}\n",actionDescription,itemDiscriprionCount);
        }

        void ReportHeader(string actionDescription )
        {
            Console.WriteLine("\n------------ {0} ----------\n",actionDescription);
        }

        public void SimulationAll()
        {
            CreateAccounts(20);
            ActivateAccounts();
            CreateSubjects(20);
            CreateModules(15);
            AssignModulesToInstructors();
            AssignModulesToStudents();
        }

        public void SimulationSmallA()
        {
            CreateAccounts(20);
            ActivateAccounts();
        }

        public void SimulationSmallB()
        {
            CreateSubjects(20);
            CreateModules(15);
        }

        public void SimulationSmallC()
        {
            CreateAccounts(20);
            CreateSubjects(20);
            CreateModules(15);
            AssignModulesToInstructors();
        }

        public void SimulationSmallD()
        {
            CreateAccounts(20);
            CreateSubjects(20);
            CreateModules(15);
            AssignModulesToStudents();
        }
    }
}
