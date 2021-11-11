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
       
        public  void CreateAccounts(int accountCount)
        {
            for (int i = 0; i < accountCount; i++)
            {
                Account account = ObjectGenerator.GenerateAccount();
                accountDictionary.Add(account.Id, account);
                if (account.Role == Role.Student)
                { 
                    Student student = ObjectGenerator.GenerateStudent(account.Id);
                    studentList.Add(student);
                    if (student.DateOfBirth.Month == 7 && account.Status == Status.Pending)
                    {
                        pendingAccountList.Add(account);                       
                    }  
                }
                else if (account.Role == Role.Instructor)
                {
                    Instructor instructor = (ObjectGenerator.GenerateInstructor(account.Id));
                    instructorList.Add(instructor);
                    if (instructor.DateOfBirth.Month == 7 && account.Status == Status.Pending)
                    {
                        pendingAccountList.Add(account);
                    }
                }
                Console.WriteLine("Create Account {0} \n ",account);
            }
        }
        public void ActivateAccounts()
        {
            foreach (var account  in pendingAccountList )
            {

                account.Status = Status.Active; 
                //pendingAccountList.Remove(account);
                //Console.WriteLine($" account is {pendingAccountList.Count} \n");
                Console.WriteLine($" Create account is {pendingAccountList.Count} \n");
            }
            Console.WriteLine("Count is  ", pendingAccountList.Count);
        }
    }
}



