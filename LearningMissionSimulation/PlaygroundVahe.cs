using System;
using System.Collections.Generic;
using System.Text;
using LearningMissionLab;
namespace LearningMissionSimulation
{
    class PlaygroundVahe : ISimulation
    {
        public static void Play()
        {
            Console.WriteLine(AttributeGenerator.GetLanguageLevel());
            Console.WriteLine(AttributeGenerator.GetLanguageName());
        }

        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();
        Dictionary<Guid, Instructor> instructorDictionary = new Dictionary<Guid, Instructor>();
        Dictionary<Guid, Student> studentDictionary = new Dictionary<Guid, Student>();
        List<Account> pendingAccountList = new List<Account>();
        List<Subject> subjectList = new List<Subject>();
        List<Guid> subjectIdList = new List<Guid>();
        List<Guid> moduleIdList = new List<Guid>();
        List<Student> studentList = new List<Student>();
        List<Instructor> instructorList = new List<Instructor>();
        Dictionary<Guid, Module> moduleDictionary = new Dictionary<Guid, Module>();

        public void CreateAccounts(int accountCount)
        {
            int i = 0;
            while (i < accountCount)
            {
                Account account = ObjectGenerator.GenerateAccount();
                accountDictionary.Add(account.Id, account);
                if (account.Role == Role.Instructor)
                {
                    Instructor instructor = ObjectGenerator.GenerateInstructor(account.Id);
                    instructorDictionary.Add(account.Id, instructor);
                    if (account.Status == Status.Pending)
                    {
                        if (IsArmenianAndEnglishPresent(instructor.LanguageList))
                        {
                            pendingAccountList.Add(account);
                        }
                    }
                }
                else if (account.Role == Role.Student)
                {
                    Student student = ObjectGenerator.GenerateStudent(account.Id);
                    studentDictionary.Add(account.Id, student);
                    if (account.Status == Status.Pending)
                    {
                        if (IsArmenianAndEnglishPresent(student.LanguageList))
                        {
                            pendingAccountList.Add(account);
                        }
                    }
                }
                Console.WriteLine("... Create Account {0} ....\n", i);
                Console.WriteLine(account + "\n");
                i++;
            }
        }

        bool IsArmenianAndEnglishPresent(List<Language> languageList)
        {
            bool isArmenian = false;
            bool isEnglish = false;

            foreach (Language language in languageList)
            {
                if (language.LanguageName == LanguageName.English)
                {
                    isEnglish = true;
                }
                else if (language.LanguageName == LanguageName.Armenian)
                {
                    isArmenian = true;
                }
                if (isArmenian && isEnglish)
                {
                    return true;
                }
            }
            return false;
        }

        public void ActivateAccounts()
        {
            foreach (var account in pendingAccountList)
            {
                account.Status = Status.Active;
                pendingAccountList.Remove(account);
            }
        }

        public void CreateSubjects(int subjectCount)
        {
            for (int i = 0; i < subjectCount; i++)
            { 
                Subject subject = ObjectGenerator.GenerateSubject();
                subjectList.Add(subject);
                subjectIdList.Add(subject.Id);
            }
        }

        public void CreateModules(int moduleCount)
        {
            for (int i = 0;  i < moduleCount; i++)
            {
                Guid subjectId = subjectIdList[AttributeGenerator.random.Next(0, subjectIdList.Count)];
                Module module = ObjectGenerator.GenerateModule(subjectId);
                moduleDictionary.Add(module.Id, module);
                moduleIdList.Add(module.Id);
            }
        }

        public void AssignModulesToInstructors()
        {
            foreach (var instructor in instructorList)
            {
                instructor.ModuleList = GetModuleList();
            }
        }

        public void AssignModulesToStudents()
        {
            foreach (var student in studentList)
            {
                student.CompletedModuleList = GetModuleList();
            }
        }

        List<Module> GetModuleList()
        {
            HashSet<Guid> moduleIdSet = new HashSet<Guid>();
            List<Module> moduleList = new List<Module>();
            int moduleCount = moduleIdList.Count;
            int maxModuleCountLimit = 7;
            int minModuleCountLimit = 1;
            maxModuleCountLimit = Math.Min(moduleCount, maxModuleCountLimit);
            minModuleCountLimit = Math.Min(moduleCount, minModuleCountLimit);
            int count = AttributeGenerator.random.Next(minModuleCountLimit, maxModuleCountLimit);

            for (int i = 0; i < count; i++)
            {
                Guid moduleId = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count)];
                if (!moduleIdSet.Contains(moduleId))
                {
                    moduleIdSet.Add(moduleId);
                    Module module;
                    moduleDictionary.TryGetValue(moduleId, out module);
                    moduleList.Add(module);
                }
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
        
        public void AssignInstructorsToClassrooms()
        {
            throw new NotImplementedException();
        }
    }
}
