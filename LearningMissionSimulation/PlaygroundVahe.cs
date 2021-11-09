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
        Dictionary<Guid, Account> accountLanguageDictionary = new Dictionary<Guid, Account>();
        Dictionary<Account, Instructor> instructorDictionary = new Dictionary<Account, Instructor>();
        Dictionary<Account, Student> studentDictionary = new Dictionary<Account, Student>();

        public void CreateAccounts(int accountCount)
        {
            int i = 0;
            while (i < accountCount)
            {
                Account account = ObjectGenerator.GenerateAccount();
                accountDictionary.Add(account.Id, account);
                if (account.Status == Status.Pending && account.Role == Role.Instructor)
                {
                    instructorDictionary.Add(account, ObjectGenerator.GenerateInstructor(account.Id));
                }
                else if (account.Status == Status.Pending && account.Role == Role.Student)
                {
                    studentDictionary.Add(account, ObjectGenerator.GenerateStudent(account.Id));
                }
                Console.WriteLine("... Create Account {0} ....\n", i);
                Console.WriteLine(account + "\n");
                i++;
            }
        }

        public void ActivateAccounts()
        {
            ISet<LanguageName> languageNameList = new HashSet<LanguageName>();
            int i = 0;
            while (i < 5)
            {
                Language language = ObjectGenerator.GenerateLanguage();
                languageNameList.Add(language.LanguageName);
                i++;
            }

            if (languageNameList.Contains(LanguageName.Armenian) && languageNameList.Contains(LanguageName.English))
            {
                foreach (var itemStudent in studentDictionary)
                {
                    itemStudent.Key.Status = Status.Active;
                    Console.WriteLine("...Activate Account....\n");
                    Console.WriteLine(itemStudent + "\n");
                }

                foreach (var itemInstructor in instructorDictionary)
                {
                    itemInstructor.Key.Status = Status.Active;
                    Console.WriteLine("...Activate Account....\n");
                    Console.WriteLine(itemInstructor + "\n");
                }
            }

        }

        public void AssignModulesToInstructors()
        {
            throw new NotImplementedException();
        }

        public void AssignModulesToStudents()
        {
            throw new NotImplementedException();
        }

        public void CreateClassrooms(int classroomCount)
        {
            throw new NotImplementedException();
        }

        public void CreateModules(int moduleCount)
        {
            throw new NotImplementedException();
        }

        public void RegisterStudentsForClasses()
        {
            throw new NotImplementedException();
        }
    }
}
