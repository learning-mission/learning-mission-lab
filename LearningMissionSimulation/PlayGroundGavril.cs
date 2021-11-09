using LearningMissionLab;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionSimulation
{
    public class PlayGroundGavril
    {
        List<Account> pendingAccountList = new List<Account>();
        List<Student> studentList = new List<Student>();
        List<Instructor> instructorList = new List<Instructor>();
        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();
        public void CreateAccounts(int accountCount)
        {
            for (int i = 0; i < accountCount; i++)
            {
                Account account = ObjectGenerator.GenerateAccount();

                accountDictionary.Add(account.Id, account);
                if (account.Role == Role.Student)
                {
                    Student student = ObjectGenerator.GenerateStudent(account.Id);
                    studentList.Add(student);

                    if (student.DateOfBirth == new DateTime(8, 9, 1981))
                    {
                        pendingAccountList.Add(account);
                    }
                }
                else if (account.Role == Role.Instructor)
                {
                    Instructor instructor = (ObjectGenerator.GenerateInstructor(account.Id));
                    instructorList.Add(instructor);
                }
                if ((account.Role == Role.Student || account.Role == Role.Instructor) && account.Status == Status.Pending)
                {
                    pendingAccountList.Add(account);

                }
                Console.WriteLine("create account {0} \n", account);
            }
        }
        public void ActivateAccounts()
        {
            for (int i = 0; i < pendingAccountList.Count; i++)
            {
                pendingAccountList[i].Status = Status.Active;
                Console.WriteLine($" activated account is{pendingAccountList[i]}\n");
            }
            pendingAccountList.Clear();
            Console.WriteLine($" count is {pendingAccountList.Count}");
        }
    }
}



