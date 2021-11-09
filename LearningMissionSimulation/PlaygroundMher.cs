using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    public class PlaygroundMher
    {
        List<Student> studentList = new List<Student>();

        List<Instructor> instructorList = new List<Instructor>();

        Queue<Account> pendingAccountQueue = new Queue<Account>();

        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();

        public void CreateAccounts(int accountCount)
        {
            int i = 0;
            while (i < accountCount)
            {
                Account account = ObjectGenerator.GenerateAccount();
                accountDictionary.Add(account.Id, account);
                if (account.Role == Role.Student)
                {
                    Student student = ObjectGenerator.GenerateStudent(account.Id);
                    studentList.Add(student);
                    if (account.Status == Status.Pending)
                    {
                        pendingAccountQueue.Enqueue(account);
                    }
                }
                else if(account.Role == Role.Instructor)
                {
                    Instructor instructor = ObjectGenerator.GenerateInstructor(account.Id);
                    instructorList.Add(instructor);
                    if(account.Status == Status.Pending)
                    {
                        pendingAccountQueue.Enqueue(account);
                    }
                }
                Console.WriteLine("========== Create  account {0} =======\n{1}", i, account);
                Console.WriteLine("\n");
                i++;
            }
        }

        public void ActivateAccounts()
        {

            while(pendingAccountQueue.Count > 0)
            {
                Account account = pendingAccountQueue.Dequeue();
                account.Status = Status.Active;
                Console.WriteLine("========== Activated account =======\n{0}", account);
                Console.WriteLine("\n");
            }
        }

        public void AssignModulesToInstructors()
        {
            throw new NotImplementedException();
        }

        public void AssignModulesToStudents()
        {
            throw new NotImplementedException();
        }


        public void CreateClassrooms(int classroomCount)
        {
            throw new NotImplementedException();
        }

        public void CreateModules(int moduleCount)
        {
            throw new NotImplementedException();
        }

        public void RegisterStudentsForClasses()
        {
            throw new NotImplementedException();
        }
    }
}
