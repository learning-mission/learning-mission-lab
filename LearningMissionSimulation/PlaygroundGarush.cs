using LearningMissionLab;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionSimulation
{
    public class PlaygroundGarush : ISimulation
    {
        List<Account> pendingAccountList = new List<Account>();
        List<Student> studentList = new List<Student>();
        List<Instructor> instructorList = new List<Instructor>();
        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();
        List<Subject> subjectList = new List<Subject>();
        List<Guid> subjectIdList = new List<Guid>();
        Dictionary<Guid, Module> moduleDictionary = new Dictionary<Guid, Module>();
        List<Guid> moduleIdList = new List<Guid>();





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
                    if (student.Gender == Gender.Female && account.Status == Status.Pending)
                    {
                        pendingAccountList.Add(account);
                    }
                }
                else if (account.Role == Role.Instructor)
                {
                    Instructor instructor = (ObjectGenerator.GenerateInstructor(account.Id));
                    instructorList.Add(instructor);
                    if (instructor.Gender == Gender.Female && account.Status == Status.Pending)
                    {
                        pendingAccountList.Add(account);
                    }
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
            Console.WriteLine($"count is  {pendingAccountList.Count}");
            pendingAccountList.Clear();



        }

        public void AssignModulesToInstructors()
        {
            foreach (var instructor in instructorList)
            {
                instructor.ModuleList = GetModuleList();
                Console.WriteLine(instructor);
            }
        }

        List<Module> GetModuleList()
        {

            List<Module> moduleList = new List<Module>();
            int allModuleCount = moduleIdList.Count;
            int minModuleCount = 2;
            int maxModuleCount = 5;
            minModuleCount = Math.Min(allModuleCount, minModuleCount);
            maxModuleCount = Math.Min(allModuleCount, maxModuleCount);
            int moduleCount = AttributeGenerator.random.Next(minModuleCount, maxModuleCount + 1);

            for (int i = 0; i < moduleCount; i++)
            {
                Guid id = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count)];

                Module module;

                moduleDictionary.TryGetValue(id, out module);

                moduleList.Add(module);
            }

            return moduleList;
        }

        public void AssignModulesToStudents()
        {
            foreach (var student in studentList)
            {
                student.CompletedModuleList = GetModuleList();
                Console.WriteLine(student);
            }
        }

        public void CreateSubjects(int subjectCount)
        {
            int i = 0;
            while (i < subjectCount)
            {
                Subject subject = ObjectGenerator.GenerateSubject();
                subjectList.Add(subject);
                subjectIdList.Add(subject.Id);
                Console.WriteLine("\ncreate subject {0}\n", subject);
                i++;
            }
        }

        public void CreateModules(int moduleCount)
        {
            int i = 0;
            while (i < moduleCount)
            {
                Guid subjectId = subjectIdList[AttributeGenerator.random.Next(0, subjectIdList.Count - 1)];
                Module module = ObjectGenerator.GenerateModule(subjectId);
                moduleDictionary.Add(module.Id, module);
                moduleIdList.Add(module.Id);
                Console.WriteLine("\ncreate module {0}\n", module);
                i++;
            }
        }



        public void CreateClassrooms(int classroomCount)
        {
            throw new NotImplementedException();
        }

        public void RegisterStudentsForClasses()
        {
            throw new NotImplementedException();
        }


        public void AssignInstructorsToClassrooms()
        {
            throw new NotImplementedException();
        }
    }
}
