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

        Dictionary<Guid, Classroom> classroomDictionary = new Dictionary<Guid, Classroom>();

        List<Module> moduleList = new List<Module>();

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
                Console.WriteLine("\n========== Generated List Number {0} of the Instructor Number {1} =======\n\n\n", i+1, i+1);
                i++;
            }
            Console.WriteLine("========== Generated Lists of the Instructors Module List  =======\n");
            Console.WriteLine("******** Finished assigning modules to instructors  ********\n");
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
            Guid moduleIdListId = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count)];
            Module module;
            moduleDictionary.TryGetValue(moduleIdListId, out module);
            int i = 0;
            while (i < classroomCount)
            {
                Classroom classroom = ObjectGenerator.GenerateClassroom(module);
                classroomDictionary.Add(module.Id, classroom);
                moduleList.Add(module);
                i++;
            }
            
        }

        public void AssignInstructorsToClassrooms()
        {
            Module module = moduleList[AttributeGenerator.random.Next(0, moduleList.Count)];
            foreach (var instructor in instructorList)
            {
                if (GetModule(instructor, module))
                {
                    Classroom classroom;
                    classroomDictionary.TryGetValue(module.Id, out classroom);
                    classroom.Head = instructor;
                }
            }
        }

        bool GetModule(Instructor instructor, Module module)
        {
            foreach (var instructorModul in instructor.ModuleList)
            {
                if (module == instructorModul)
                {
                    return true;
                }
            }
            return false;
        }
        public void RegisterStudentsForClasses()
        {
           
        }
       

        
    }
}
