using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class PlaygroundMher : ISimulation
    {
        List<Account> studentList = new List<Account>();

        List<Account> instructorList = new List<Account>();

        List<Account> accountList = new List<Account>();

        Queue<Account> accountQueueList = new Queue<Account>();

        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();


        public void CreateAccounts(int accountCount)
        {
            int i = 0;
            while (i < accountCount)
            {
                Account account = ObjectGenerator.GenerateAccount();

                accountQueueList.Enqueue(account);

                accountList.Add(account);

                Console.WriteLine("========== Create  account {0} =======\n{1}",i, account);
                Console.WriteLine("\n");

                accountDictionary.Add(account.Id, account);
                //I think it should be here switch
                if (account.Role == Role.Instructor)
                {
                    instructorList.Add(account);
                }
                else if(account.Role == Role.Student)
                {
                    studentList.Add(account);
                }
                i++;
            }
        }

        public void ActivateAccounts()
        {
            foreach (var account in accountList)
            {
                if (account.Status == Status.Pending)
                {
                    account.Status = Status.Active;
                    Console.WriteLine("========== Activate {0} status =======\n{1}",account.Role, account);
                    Console.WriteLine("\n");
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
        public void FairCoordinator()
        {
            foreach (var accountStatus in accountQueueList)
            {
                if (accountStatus.Status == Status.Pending)
                {
                    accountStatus.Status = Status.Active;
                    Console.WriteLine("========== Activate {0} status FiFo =======\n{1}", accountStatus.Role, accountStatus);
                    Console.WriteLine("\n");
                }
                accountQueueList.Peek();
            }
        }
    }
}
