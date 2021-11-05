using System;
using System.Collections.Generic;
using System.Text;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class PlaygroundMher : ISimulation
    {
        int _accountCount;
        public PlaygroundMher(int accountCount)
        {
            this._accountCount = accountCount;
        }

        public int count = 0;
        public int AccountCount { get => _accountCount; set => _accountCount = value; }

        Account account = ObjectGenerator.GenerateAccount();

        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();

        // Simulate account creation  process
        public void CreateAccounts(int accountCount)
        {
            int i = 0;
            while (i < accountCount)
            {
                accountDictionary.Add(ObjectGenerator.GenerateAccount().Id, ObjectGenerator.GenerateAccount());
                i++;
            }
            foreach (var item in accountDictionary)
            {
                Console.WriteLine(item);
            }
        }

        // Simulate account activati process
        public void ActivateAccounts()
        {

            if( AttributeGenerator.GetStatus() == Status.Pending )
            {
                 account.Status = Status.Active;
            }

            //if (AttributeGenerator.GetStatus() != Status.Active)
            //{
            //    account.Status = Status.Active;
            //}

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
