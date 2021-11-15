using LearningMissionLab;
using System;
using System.Collections.Generic;
using System.Text;




namespace LearningMissionSimulation
{
    public class PlayGroundGavril
    {
        List<Account> pendingAccountList = new List<Account>();
        List<Student> studentList = new List<Student>();
        List<Instructor> instructorList = new List<Instructor>();
        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();
        // Dictionary<Guid, Subject> subjectDictionary = new Dictionary<Guid, Subject>();
        Dictionary<Guid, Module> moduleDictionary = new Dictionary<Guid, Module>();
        List<Guid> moduleIdList = new List<Guid>();
        List<Guid> subjectIdList = new List<Guid>();

        public  void CreateAccounts(int accountCount)
        {
            for (int i = 0; i < accountCount; i++)
            {
                Account account = ObjectGenerator.GenerateAccount();
                accountDictionary.Add(account.Id, account);
                if (account.Role == Role.Student)
                { 
                    Student student = ObjectGenerator.GenerateStudent(account.Id);
                    studentList.Add(student);
                    if (student.DateOfBirth.Month == 7 && account.Status == Status.Pending)
                    {
                        pendingAccountList.Add(account);                       
                    }  
                }
                else if (account.Role == Role.Instructor)
                {
                    Instructor instructor = (ObjectGenerator.GenerateInstructor(account.Id));
                    instructorList.Add(instructor);
                    if (instructor.DateOfBirth.Month == 7 && account.Status == Status.Pending)
                    {
                        pendingAccountList.Add(account);
                    }
                }
             
            }
        }
        public void ActivateAccounts()
        {
            foreach (var account  in pendingAccountList )
            {
                account.Status = Status.Active; 
                pendingAccountList.Remove(account);
            }
            
        }
        public void CreateModules(int moduleCount)
        {
            for (int i = 0; i < moduleCount; i++)
            {
                
                Guid subjectId = GetSubjectId();

                Module module = ObjectGenerator.GenerateModule(subjectId);

                moduleDictionary.Add(module.Id, module);
                moduleIdList.Add(module.Id);
            }
        }

        Guid GetSubjectId()
        {
            return subjectIdList[AttributeGenerator.random.Next(0, subjectIdList.Count - 1)];
        }

       
        public void AssignModulesToInstructors()
        {
            Console.WriteLine("******** Started assigning modules to instructors  ********\n");
            int i = 0;
            foreach (var instructor in instructorList)
            {
                instructor.ModuleList = GetModuleList();
                Console.WriteLine("\n========== Generated List Number {0} of the Instructor Number {1} =======\n\n\n", i + 1, i + 1);
                i++;
            }
            Console.WriteLine("========== Generated Lists of the Instructors Module List  =======\n");
            Console.WriteLine("******** Finished assigning modules to instructors  ********\n");
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


        public void AssignModulesToStudents()
        {
            foreach (Student student in studentList)
            {
                student.CompletedModuleList = GetModuleList();
            }
        }
       
    }
}



