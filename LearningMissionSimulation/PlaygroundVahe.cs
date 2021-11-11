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

        public void CreateSubjects(int subjectCount)
        {
            throw new NotImplementedException();
        }
    }
}
