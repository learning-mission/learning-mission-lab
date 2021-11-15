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
            Console.WriteLine("******** Started creating accounts  ********\n");
            int i = 0;
            while (i < accountCount)
            {
                Console.WriteLine("\n========== Created  account {0} =======\n", i);
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
                Console.WriteLine("\n");
                i++;
            }
            Console.WriteLine("========== Generated {0} Accounts  =======\n", accountCount);
            Console.WriteLine("********  Finished creating accounts   ********\n");
        }

        public void ActivateAccounts()
        {
            Console.WriteLine("******** Started activating accounts ********\n");
            int pendingAccountQueueCount = pendingAccountQueue.Count;
            while(pendingAccountQueue.Count > 0)
            {
                Console.WriteLine("========== Activate Account =======");
                Account account = pendingAccountQueue.Dequeue();
                account.Status = Status.Active;
                Console.WriteLine("\n========== Activated account =======\n{0}\n", account);
            }
            Console.WriteLine("========== Activated {0} accounts  =======\n", pendingAccountQueueCount);
            Console.WriteLine("******** Finished activating accounts ********\n");
        }

        public void CreateSubjects(int subjectCount)
        {
            Console.WriteLine("******** Started creating subjects  ********\n");
            int i = 0;
            while (i < subjectCount)
            {
                Subject subject = ObjectGenerator.GenerateSubject();
                Console.WriteLine("========== Created  Subject {0} =======\n\n{1}\n", i, subject);
                subjectList.Add(subject);
                subjectIdList.Add(subject.Id);
                i++;
            }
            Console.WriteLine("========== Generated {0} Subjects  =======\n", subjectCount);
            Console.WriteLine("******** Finished creating subjects  ********\n");
        }

        public void CreateModules(int moduleCount)
        {
            Console.WriteLine("******** Started creating modules  ********\n");
            int i = 0;
            while (i < moduleCount)
            {
                Guid subjectId = subjectIdList[AttributeGenerator.random.Next(0, subjectIdList.Count-1)];
                Module module = ObjectGenerator.GenerateModule(subjectId);
                moduleDictionary.Add(module.Id, module);
                moduleIdList.Add(module.Id);
                Console.WriteLine("\n========== Created  Module {0} =======\n\n{1}\n", i, module);
                i++;
            }
            Console.WriteLine("========== Generated {0} Modules  =======\n", moduleCount);
            Console.WriteLine("******** Finished creating modules ********\n");
        }

        public void AssignModulesToInstructors()
        {
            Console.WriteLine("******** Started assigning modules to instructors  ********\n");
            int i = 0;
            foreach (var instructor in instructorList)
            {
                instructor.ModuleList = GetModuleList();
                AddToModuleInstructorList(instructor);
                Console.WriteLine("\n========== Generated List Number {0} of the Instructor Number {1} =======\n\n\n", i+1, i+1);
                i++;
            }
            Console.WriteLine("========== Generated Lists of the Instructors Module List  =======\n");
            Console.WriteLine("******** Finished assigning modules to instructors  ********\n");
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
            Console.WriteLine("******** Started assigning modules to students  ********\n");
            int i = 0;
            foreach (var student in studentList)
            {
                Console.WriteLine("========== List of modules assigned to student {0} {1} {2} =======", student.AccountId, student.FirstName, student.LastName);
                student.CompletedModuleList = GetModuleList();
                i++;
            }
            Console.WriteLine("******** Finished assigning modules to students   ********\n\n\n\n");
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
                Guid moduleId = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count - 1)];
                
                if (!moduleIdSet.Contains(moduleId))
                {
                    moduleIdSet.Add(moduleId);
                    Console.WriteLine("========== Randomly selected module id is =======\n\n{0}\n\n", moduleId);
                    Module module;
                    moduleDictionary.TryGetValue(moduleId, out module);
                    moduleList.Add(module);
                    Console.WriteLine("========== Added module =======\n\n{0}\n\n", module);
                }
                i++;
            }
            return moduleList;
        }

        public void CreateClassrooms(int classroomCount)
        {
            Guid moduleId = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count)];
            Module module;
            moduleDictionary.TryGetValue(moduleId, out module);
            int i = 0;
            while (i < classroomCount)
            {
                Classroom classroom = ObjectGenerator.GenerateClassroom(module);
                classroomList.Add(classroom);
                i++;
            }
        }

        public void AssignInstructorsToClassrooms()
        {
            foreach (var classroom in classroomList)
            {
                if (moduleInstructorDictionary.ContainsKey(classroom.Module.Id))
                {
                    List<Instructor> instructorList = new List<Instructor>();
                    moduleInstructorDictionary.TryGetValue(classroom.Module.Id, out instructorList);
                    classroom.Head = instructorList[AttributeGenerator.random.Next(0, instructorList.Count)];
                }
            }
        }

        public void RegisterStudentsForClasses()
        {
            throw new NotImplementedException();
        }

    }
}