using System;
using System.Collections.Generic;
using System.Text;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class PlaygroundMher
    {
        int accountCount;
        List<string> passwoerdNameList;
        List<string> userNameList;
        List<string> emailNameList;
        List<string> phoneNumberList;
        List<Enum> roleEnumList;
        List<Enum> statusEnumList;
        List<DateTime> createDateList;
        List<DateTime> updateDateList;
        public PlaygroundMher(int count)
        {
            this.accountCount = count;
        }
        

        public List<string> PasswoerdNameList {private get => passwoerdNameList; set => passwoerdNameList = value; }
        public List<string> UserNameList { get => userNameList; set => userNameList = value; }
        public List<string> EmailNameList { get => emailNameList; set => emailNameList = value; }
        public List<string> PhoneNumberList { get => phoneNumberList; set => phoneNumberList = value; }
        public List<Enum> RoleEnumList { get => roleEnumList; set => roleEnumList = value; }
        public List<Enum> StatusEnumList { get => statusEnumList; set => statusEnumList = value; }
        public List<DateTime> CreateDateList { get => createDateList; set => createDateList = value; }
        public List<DateTime> UpdateDateList { get => updateDateList; set => updateDateList = value; }

        Account account = ObjectGenerator.GenerateAccount();
        // Simulate account creation  process
        public void SimulateAccountCreationProcess(int accountCount)
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
        // Simulate account activati process
        public void SimulateAccountActivatiProcess()
        {

        }
        public void FairCoordinator()
        {
            if (statusEnumList.Contains(Status.Suspended))
            {

            }
            
        }
    }
}
