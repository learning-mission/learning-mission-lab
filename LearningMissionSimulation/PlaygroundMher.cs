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
            foreach (var itemOfAccountList in accountList)
            {
                Console.WriteLine("=============== Create Account {0} =================\n", i);
                Console.WriteLine(itemOfAccountList + "\n");
                i++;
            }
        }

        // Simulate account activati process
        public void ActivateAccounts()
        {
           
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


        }
    }
}
