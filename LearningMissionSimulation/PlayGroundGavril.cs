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

        Dictionary<Guid, Module> moduleDictionary = new Dictionary<Guid, Module>();

        List<Guid> moduleIdList = new List<Guid>();

        List<Guid> subjectIdList = new List<Guid>();

        List<Subject> subjectList = new List<Subject>();

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
                Guid subjectId = subjectIdList[AttributeGenerator.random.Next(0, subjectIdList.Count )];
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
                Console.WriteLine("\n========== Generated List Number {0} of the Instructor Number {1} =======\n\n\n", i + 1, i + 1);
                i++;
            }
            Console.WriteLine("========== Generated Lists of the Instructors Module List  =======\n");
            Console.WriteLine("******** Finished assigning modules to instructors  ********\n");
        }

        List<Module> GetModuleList()
        {
            List<Module> moduleList = new List<Module>();
            int totalModuleCount = moduleIdList.Count;
            int maxModuleCountLimit = 7;
            int minModuleCountLimit = 1;
            maxModuleCountLimit = Math.Min(totalModuleCount, maxModuleCountLimit);
            minModuleCountLimit = Math.Min(totalModuleCount, minModuleCountLimit);
            int count = AttributeGenerator.random.Next(minModuleCountLimit, maxModuleCountLimit);

            for (int i = 0; i < count; i++)
            {
                Module module;
                Guid id = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count)];
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
            foreach (Student student in studentList)
            {
                student.CompletedModuleList = GetModuleList();
            }
        }  
    }
}
