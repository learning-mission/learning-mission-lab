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
        public void PlyeMetod(uint accountCount, int count)
        {
            ISet<Password> passwordsName = new HashSet<Password>();
            Account account = ObjectGenerator.GenerateAccount();
            int i = 0;
            while (i < accountCount)
            {
                keyValuePairs.Add(count, account);
                count++;
                i++;
            }

        }
        public void FairCoordinator()
        {

        }
    }
}
