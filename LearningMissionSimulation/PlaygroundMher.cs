using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class PlaygroundMher
    {
        Queue<Account> accountQueue = new Queue<Account>();

        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();

        public void CreateAccounts(int accountCount)
        {
            int i = 0;
            while (i < accountCount)
            {
                Account account = ObjectGenerator.GenerateAccount();
                accountDictionary.Add(account.Id, account);
                if (account.Role == Role.Student || account.Role == Role.Instructor)
                {
                    accountQueue.Enqueue(account);
                }
                Console.WriteLine("========== Create  account {0} =======\n{1}", i, account);
                Console.WriteLine("\n");
                i++;
            }
        }

        public void ActivateAccounts()
        {
            foreach (var accountStatus in accountQueue)
            {
                if (accountStatus.Status == Status.Pending)
                {
                    accountStatus.Status = Status.Active;
                    Console.WriteLine("========== Activate {0} status FiFo =======\n{1}", accountStatus.Role, accountStatus);
                    Console.WriteLine("\n");
                }
                accountQueue.Peek();
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
