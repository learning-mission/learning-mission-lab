using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class PlaygroundMher
    {
        int _accountCount;
        public PlaygroundMher(int accountCount)
        {
            this._accountCount = accountCount;
        }

        public int count = 0;
        public int AccountCount { get => _accountCount; set => _accountCount = value; }

        Account account = ObjectGenerator.GenerateAccount();

        List<Account> accountList = new List<Account>();

        Queue<DateTime> creatDateTimeQueue = new Queue<DateTime>();
        
        // Simulate account creation  process
        public void CreateAccounts(int accountCount)
        {
            account.Report();
            Console.WriteLine("\n");
            int i = 0;
            while (i < accountCount)
            {
                accountList.Add(ObjectGenerator.GenerateAccount());
                i++;
            }
            i = 0;
            foreach (var itemOfAccountList in accountList)
            {
                //if (itemOfAccountList.Status == Status.Pending)
                //{
                //    creatDateTimeQueue.Enqueue(itemOfAccountList.CreateDate);
                //}
                if (!(itemOfAccountList.Status == Status.Active))
                {
                    creatDateTimeQueue.Enqueue(itemOfAccountList.CreateDate);
                }
                Console.WriteLine("=============== Create Account {0} =================\n", i);
                Console.WriteLine(itemOfAccountList + "\n");
                i++;
            }
        }

        // Simulate account activati process
        public void ActivateAccounts()
        {
            int i = 0;
            foreach (var itemOfAccountList in accountList)
            {
                //if (itemOfAccountList.Status == Status.Pending)
                //{
                //    itemOfAccountList.Status = Status.Active;
                //}
                if (!(itemOfAccountList.Status == Status.Active))
                {
                    itemOfAccountList.Status = Status.Active;
                }
                Console.WriteLine("=============== Create Account {0} =================\n", i);
                Console.WriteLine(itemOfAccountList + "\n");
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
            foreach (var itemOfAccountList in accountList)
            {
                //if (itemOfAccountList.Status == Status.Pending)
                //{
                //    creatDateTimeQueue.Dequeue();
                //    itemOfAccountList.Status = Status.Active;
                //}
                if (!(itemOfAccountList.Status == Status.Active))
                {
                    creatDateTimeQueue.Dequeue();
                    itemOfAccountList.Status = Status.Active;
                }
                Console.WriteLine("=============== Create Account {0} =================\n", i);
                Console.WriteLine(itemOfAccountList + "\n");
                i++;
            }
        }
    }
}
