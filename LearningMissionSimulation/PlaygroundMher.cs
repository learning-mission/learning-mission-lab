using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class PlaygroundMher
    {
        Random random = new Random();

        List<Student> studentList = new List<Student>();

        List<Instructor> instructorList = new List<Instructor>();

        Queue<Account> pendingAccountQueue = new Queue<Account>();

        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();

        List<Subject> subjectsList = new List<Subject>();

        Dictionary<Guid, Module> modulDictionary = new Dictionary<Guid, Module>();

        List<Guid> guidList = new List<Guid>();

        public void CreateAccounts(int accountCount)
        {
            int i = 0;
            while (i < accountCount)
            {
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
                Console.WriteLine("========== Create  account {0} =======\n{1}", i, account);
                Console.WriteLine("\n");
                i++;
            }
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
        }

        public void CreateModules(int moduleCount)
        {
            int i = 0;
            while (i < moduleCount)
            {
                Subject subject = ObjectGenerator.GenerateSubject();
                Module module = ObjectGenerator.GenerateModule(subject.Id);
                subjectsList.Add(subject);
                modulDictionary.Add(module.Id, module);
                guidList.Add(module.Id);
                Console.WriteLine("\ncreate modul {0}\n", module);
                i++;
            }
        }
        public void AssignModulesToInstructors()
        {
            foreach (var moduleItem in modulDictionary)
            {
                Guid guid = guidList[random.Next(0, guidList.Count - 1)];
                Console.WriteLine(guid);
                Console.WriteLine("\n");
                ModuleInstructor(instructorList, moduleItem.Value);
                Console.WriteLine(moduleItem.Value);
                Console.WriteLine("\n");
            } 
        }

        public void ModuleInstructor(List<Instructor> instructorList, Module module)
        {           
            foreach (var instructorModule in instructorList)
            {
                if (!(instructorModule.ModuleList.Contains(module)))
                {
                    instructorModule.ModuleList.Add(module);
                }    
            }
        } 
        public void AssignModulesToStudents()
        {
            foreach (var moduleItem in modulDictionary)
            {
                Guid guid = guidList[random.Next(0, guidList.Count - 1)];
                Console.WriteLine(guid);
                Console.WriteLine("\n");
                ModuleStudent(studentList, moduleItem.Value);
                Console.WriteLine(moduleItem.Value);
                Console.WriteLine("\n");
            }
        }

        public void ModuleStudent(List<Student> studentList, Module module)
        {
            foreach (var studentModule in studentList)
            {
                if (!(studentModule.CompletedModuleList.Contains(module)))
                {
                    studentModule.CompletedModuleList.Add(module);
                }
            }
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
