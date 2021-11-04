using System;
using System.Collections.Generic;
using System.Text;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class PlaygroundMher
    {
        public PlaygroundMher()
        {

        }
        Dictionary<int, Account> keyValuePairs = new Dictionary<int, Account>();
        Dictionary<int, Account> keyValuePairs1 = new Dictionary<int, Account>();
        Dictionary<int, Account> keyValuePairs2 = new Dictionary<int, Account>();
        Dictionary<int, Account> keyValuePairs3 = new Dictionary<int, Account>();
        // Simulate account creation process
        public void SimulateAccountCreationProcess(uint accountCount, int count)
        {
            Account account = ObjectGenerator.GenerateAccount();
            account.Report();
            List<Account> accountList = new List<Account>();
            int i = 0;
            while (i < accountCount)
            {
                keyValuePairs.Add(count, account);
                count++;
                i++;
            }

        }
        // Simulate account activation process
        public void SimulateAccountActivationProcess()
        {

        }
        public void FairCoordinator()
        {

        }
    }
}
