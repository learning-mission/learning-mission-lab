using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class PlaygroundMher
    {
        public PlaygroundMher()
        {
            
        }
       
        //Account account = ObjectGenerator.GenerateAccount();

        List<Account> accountList = new List<Account>();

        Queue<Status> statusQueue = new Queue<Status>();

        // Simulate account creation  process
        public void CreateAccounts(int accountCount)
        {
            int i = 0;
            while (i < accountCount)
            {
                accountList.Add(ObjectGenerator.GenerateAccount());
                i++;
            }
            i = 0;
            foreach (var account in accountList)
            {
                if (account.Status == Status.Pending)
                {
                    statusQueue.Enqueue(account.Status);
                }
                Console.WriteLine("=============== Create Account {0} =================\n", i);
                Console.WriteLine(account + "\n");
                i++;
            }
        }

        // Simulate account activati process
        public void ActivateAccounts()
        {
            int i = 0;
            foreach (var account in accountList)
            {
                if (account.Status == Status.Pending)
                {
                    account.Status = Status.Active;
                }
                Console.WriteLine("=============== Create Account {0} =================\n", i);
                Console.WriteLine(account + "\n");
                i++;
            }
            
        }

        public void CreateModules(int moduleCount)
        {
            throw new NotImplementedException();
        }

        public void AssignModulesToStudents()
        {
            throw new NotImplementedException();
        }

        public void AssignModulesToInstructors()
        {
            throw new NotImplementedException();
        }

        public void CreateClassrooms(int classroomCount)
        {
            throw new NotImplementedException();
        }

        public void RegisterStudentsForClasses()
        {
            throw new NotImplementedException();
        }
        public void FairCoordinator()
        {
            int i = 0;
            var statusQueueList = statusQueue.Peek();
            while (i < statusQueue.Count)
            {
                statusQueueList = Status.Active;
            }
            foreach (var account in accountList)
            {
                if (account.Status == Status.Pending)
                {
                    account.Status = Status.Active;
                }
                Console.WriteLine("=============== Create Account {0} =================\n", i);
                Console.WriteLine(account + "\n");
                i++;
            }


        }
    }
}
