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

        List<Classroom> classroomList = new List<Classroom>();

        Dictionary<Guid, List<Instructor>> moduleInstructorDictionary = new Dictionary<Guid, List<Instructor>>();

        public void CreateAccounts(int accountCount)
        {
            ReportHeader("Create Account");
            int i = 0;
            while (i < accountCount)
            {
                Account account = ObjectGenerator.GenerateAccount();
                ReportItem(account.ToString(), "Created account", i++);
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
                Console.WriteLine("\n");
                i++;
            }
            ReportSummary("Account", accountCount);
            ReportFooter("Create Account");
        }

        public void ActivateAccounts()
        {
            ReportHeader("Activate account");
            int pendingAccountQueueCount = pendingAccountQueue.Count;
            int i = 0;
            while(pendingAccountQueue.Count > 0)
            {
                Account account = pendingAccountQueue.Dequeue();
                account.Status = Status.Active;
                ReportItem(account.ToString(), "Activated account", i++);
            }
            ReportFooter("Activate account");
        }

        public void CreateSubjects(int subjectCount)
        {
            ReportHeader("Subject generation");
            int i = 0;
            while (i < subjectCount)
            {
                Subject subject = ObjectGenerator.GenerateSubject();
                ReportItem(subject.ToString(), "Subject", i++);
                subjectList.Add(subject);
                subjectIdList.Add(subject.Id);
                i++;
            }
            ReportSummary("Subject", subjectCount);
            ReportFooter("Subject generation");
        }

        public void CreateModules(int moduleCount)
        {
            if(subjectIdList.Count != 0)
            {
                ReportHeader("Module generation");
                int i = 0;
                while (i < moduleCount)
                {
                    Guid subjectId = subjectIdList[AttributeGenerator.random.Next(0, subjectIdList.Count)];
                    Module module = ObjectGenerator.GenerateModule(subjectId);
                    moduleDictionary.Add(module.Id, module);
                    moduleIdList.Add(module.Id);
                    ReportItem(module.ToString(), "Module", i++);
                    i++;
                }
                ReportSummary("Module", moduleCount);
                ReportFooter("Module generation");
            } 
        }

        public void AssignModulesToInstructors()
        {
            ReportHeader("Assign modules to instructors");
            int i = 0;
            foreach (var instructor in instructorList)
            {
                instructor.ModuleList = GetModuleList();
                AddToModuleInstructorList(instructor);
                ReportItem(instructor.ToString(), "Assigned module", i++);
                i++;
            }
            ReportFooter("Assign modules to instructors");
        }

        void AddToModuleInstructorList(Instructor instructor)
        {
            List<Instructor> instructorList ;
            foreach (var module in instructor.ModuleList)
            {
                if (!moduleInstructorDictionary.ContainsKey(module.Id))
                {
                    instructorList = new List<Instructor>() { instructor };
                    moduleInstructorDictionary.Add(module.Id, instructorList);
                }
                else
                {
                    moduleInstructorDictionary.TryGetValue(module.Id, out instructorList);
                    instructorList.Add(instructor);
                }
            }
        }

        public void AssignModulesToStudents()
        {
            ReportHeader("Assign modules to students");
            int i = 0;
            foreach (var student in studentList)
            {
                student.CompletedModuleList = GetModuleList();
                ReportItem(student.ToString(), "Assigned module", i++);
                i++;
            }
            ReportFooter("Assign modules to students");
        }

        List<Module> GetModuleList() 
        {
            ISet<Guid> moduleIdSet = new HashSet<Guid>();
            List<Module> moduleList = new List<Module>();
            if (moduleIdList.Count != 0)
            {
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
                        Module module;
                        moduleDictionary.TryGetValue(moduleId, out module);
                        moduleList.Add(module);
                    }
                    i++;
                }
            }
            return moduleList;
        }

        public void CreateClassrooms(int classroomCount)
        {
            if(moduleIdList.Count != 0)
            {
                ReportHeader("Create Classroom");
                Guid moduleId = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count)];
                Module module;
                moduleDictionary.TryGetValue(moduleId, out module);
                int i = 0;
                while (i < classroomCount)
                {
                    Classroom classroom = ObjectGenerator.GenerateClassroom(module);
                    ReportItem(classroom.ToString(), "Created classroom", i++);
                    classroomList.Add(classroom);
                    i++;
                }
                ReportFooter("Create Classroom");
            } 
        }

        public void AssignInstructorsToClassrooms()
        {
            if(classroomList.Count != 0)
            {
                foreach (var classroom in classroomList)
                {
                    if (moduleInstructorDictionary.ContainsKey(classroom.Module.Id))
                    {
                        List<Instructor> instructorList;
                        moduleInstructorDictionary.TryGetValue(classroom.Module.Id, out instructorList);
                        classroom.Head = instructorList[AttributeGenerator.random.Next(0, instructorList.Count)];
                    }
                    else
                    {
                        Console.WriteLine("Failed to find instructor for classroom");
                    }
                }
            }
        }

        public void RegisterStudentsForClasses()
        {
            throw new NotImplementedException();
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
            Console.WriteLine($" {actionName} {itemIndex}\n{itemName}");
        }

        void ReportSummary(string summary, int count)
        {
            Console.WriteLine($"''''''Generated {count} {summary}''''''\n");
        }
        #endregion Reports
    }
}