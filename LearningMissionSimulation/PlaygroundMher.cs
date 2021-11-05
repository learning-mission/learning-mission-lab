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
        Account account = ObjectGenerator.GenerateAccount();
        List<string> passwoerdNameList = new List<string>();
        List<string> userNameList = new List<string>();
        List<string> emailNameList = new List<string>();
        List<string> phoneNumberList = new List<string>();
        List<Enum> roleEnumList = new List<Enum>();
        List<Enum> statusEnumList = new List<Enum>();
        List<DateTime> createDateList = new List<DateTime>();
        List<DateTime> updateDateList = new List<DateTime>();
        public void PlyeMetod(uint accountCount)
        {
            
            account.Report();
            
            int i = 0;
            while (i < accountCount)
            {
                passwoerdNameList.Add(account.Password);
                userNameList.Add(account.Username);
                emailNameList.Add(account.Email);
                phoneNumberList.Add(account.Phone);
                roleEnumList.Add(account.Role);
                statusEnumList.Add(account.Status);
                createDateList.Add(account.CreateDate);
                updateDateList.Add(account.UpdateDate);
                i++;
            }

        }
        public void FairCoordinator()
        {
           
            foreach (var item in statusEnumList)
            {
                if(item  != Enum.GetValues(typeof(Status)).GetValue(2))
                {
                   
                }
            }
        }
    }
}
