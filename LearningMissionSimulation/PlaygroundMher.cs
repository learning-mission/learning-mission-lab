using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class PlaygroundMher
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
            int i = 0;
            while (i < accountCount)
            {
                Console.WriteLine("========== Created  account {0} =======\n", i);
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
            Console.WriteLine("========== Generated {0} accounts  =======\n", accountCount);
        }

        public void ActivateAccounts()
        {
            while(pendingAccountQueue.Count > 0)
            {
                Account account = pendingAccountQueue.Dequeue();
                account.Status = Status.Active;
                Console.WriteLine("========== Activated account =======\n{0}", account);
                Console.WriteLine("\n");
            }
            Console.WriteLine("========== Activated {0} accounts  =======\n", pendingAccountQueue.Count);
        }
        public void CreateSubject(int subjectCount)
        {
            int i = 0;
            while (i < subjectCount)
            {
                Subject subject = ObjectGenerator.GenerateSubject();
                subjectList.Add(subject);
                subjectIdList.Add(subject.Id);
                Console.WriteLine("\ncreate subject {0}\n", subject);
                i++;
            }
        }
        public void CreateModules(int moduleCount)
        {
            int i = 0;
            while (i < moduleCount)
            {
                Guid subjectId = subjectIdList[AttributeGenerator.random.Next(0, subjectIdList.Count-1)];
                Module module = ObjectGenerator.GenerateModule(subjectId);
                moduleDictionary.Add(module.Id, module);
                moduleIdList.Add(module.Id);
                Console.WriteLine("\ncreate module {0}\n", module);
                i++;
            }
        }
        public void AssignModulesToInstructors()
        {
            foreach (var instructor in instructorList)
            {
                instructor.ModuleList = GetModuleList();
                Console.WriteLine(instructor);
            } 
        }

        public void AssignModulesToStudents()
        {
            foreach (var student in studentList)
            {
                student.CompletedModuleList = GetModuleList();
                Console.WriteLine(student);
            }
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
                    Module module;
                    moduleDictionary.TryGetValue(moduleId, out module);
                    moduleList.Add(module);
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
    }
}
