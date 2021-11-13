using LearningMissionLab;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionSimulation
{
    class PlaygroundEdvard : ISimulation
    {
        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();
        Stack<Account> pendingAccountStack = new Stack<Account>();
        List<Student> studentList = new List<Student>();
        List<Instructor> instructorList = new List<Instructor>();
        Dictionary<Guid, Subject> subjectDictionary = new Dictionary<Guid, Subject>();
        Dictionary<Guid, Module> moduleDictionary = new Dictionary<Guid, Module>();
        List<Guid> subjectIdList = new List<Guid>();
        List<Guid> moduleIdList = new List<Guid>();
        HashSet<Module> temporaryModuleHashSet = new HashSet<Module>();
        Dictionary<Guid, Classroom> classRoomDictionary = new Dictionary<Guid, Classroom>();

        public static void Action0()
        {
            ObjectGenerator.GenerateAddress();
        }
        
        public static void Action1()
        {
            Address address0 = new Address("dasdasd str",23, 15, "Yerevan", "asdqwe", "15", "Armenia");
            ContactInfo contact0 = new ContactInfo
            (
                address0,
                "zxczxc.asdasdqweqweqwe@gmail.com",
                "010-54-74-90",
                "010-28-88-88",
                "013-23-122-33"
            );

            Employee employee0 = new Employee();
            Employee employee1 = new Employee();

            List<Employee> employeeList = new List<Employee>
            {
                employee0,
                employee1
            };

            Department department0 = new Department(Guid.NewGuid(), contact0, "Dep0", "Department0", employeeList);

            List<Department> departmentList = new List<Department>
            {
                department0
            };

            Unit<Department> unit0 = new Unit<Department>(UnitType.Department, "Dep0", "Department0", departmentList);

            Console.WriteLine(AttributeGenerator.GetDateOfBirth(20, 60));
        }

        public void Action2(int accountCount)
        {
            CreateAccounts(accountCount);
            ActivateAccounts();
        }

        public void Action3(int subjectCount, int moduleCount)
        {
            Action2(20);
            CreateSubjects(subjectCount);
            CreateModules(moduleCount);
            AssignModulesToStudents();
            AssignModulesToInstructors();
            CreateClassrooms(moduleCount);
            AssignInstructorsToClassrooms();
        }

        public void CreateAccounts(int accountCount)
        {
            for (int i = 1; i <= accountCount; i++)
            {
                Console.WriteLine($" Account {i}");

                Account account = ObjectGenerator.GenerateAccount();

                accountDictionary.Add(account.Id, account);

                if ((account.Role == Role.Student || account.Role == Role.Instructor) && account.Status == Status.Pending)
                {
                    pendingAccountStack.Push(account);
                }

                if (account.Role == Role.Student)
                {
                    Student student = ObjectGenerator.GenerateStudent(account.Id);

                    studentList.Add(student);

                    student.Report();
                }
                else if (account.Role == Role.Instructor)
                {
                    Instructor instructor = ObjectGenerator.GenerateInstructor(account.Id);

                    instructorList.Add(instructor);

                    instructor.Report();
                }

                Console.WriteLine('\n');
            }
        }

        public void ActivateAccounts()
        {
            Console.WriteLine("-----Unfair coordinator started activating accounts-----\n");

            while (pendingAccountStack.Count > 0)
            {
                pendingAccountStack.Pop().Status = Status.Active;

                Console.WriteLine($" Activated at {DateTime.Now}\n");
            }

            Console.WriteLine("-----Unfair coordinator finished activating accounts-----");
        }

        public void CreateSubjects(int subjectCount)
        {
            for (int i = 0; i < subjectCount; i++)
            {
                Subject subject = ObjectGenerator.GenerateSubject();

                subjectDictionary.Add(subject.Id, subject);
                subjectIdList.Add(subject.Id);
            }
        }

        public void CreateModules(int moduleCount)
        {
            for (int i = 0; i < moduleCount; i++)
            {
                Guid subjectId = GetSubjectId();

                Module module = ObjectGenerator.GenerateModule(subjectId);

                moduleDictionary.Add(module.Id, module);
                moduleIdList.Add(module.Id);
            }
        }

        Guid GetSubjectId()
        {
            return subjectIdList[AttributeGenerator.random.Next(0, subjectIdList.Count - 1)];
        }

        public void AssignModulesToStudents()
        {
            foreach (Student student in studentList)
            {
                student.CompletedModuleList = GenerateModuleList();
            }
        }
        
        public void AssignModulesToInstructors()
        {
            foreach (Instructor instructor in instructorList)
            {
                instructor.ModuleList = GenerateModuleList();
            }
        }

        public List<Module> GenerateModuleList()
        {
            List<Module> moduleList = new List<Module>();
            int totalModuleCount = moduleIdList.Count;
            int minModuleCountLimit = 2;
            int maxModuleCountLimit = 5;
            minModuleCountLimit = Math.Min(totalModuleCount, minModuleCountLimit);
            maxModuleCountLimit = Math.Min(totalModuleCount, maxModuleCountLimit);
            int moduleCount = AttributeGenerator.random.Next(minModuleCountLimit, maxModuleCountLimit);

            for (int i = 0; i < moduleCount; i++)
            {
                Guid id = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count - 1)];

                Module module;

                moduleDictionary.TryGetValue(id, out module);

                moduleList.Add(module);
            }

            return moduleList;
        }

        public void CreateClassrooms(int classroomCount)
        {
            foreach(Module module in moduleDictionary.Values)
            {
                temporaryModuleHashSet.Add(module);

                Classroom classroom = ObjectGenerator.GenerateClassroom(module);

                classRoomDictionary.Add(Guid.NewGuid(), classroom);

                temporaryModuleHashSet.Remove(module);
            }
        }

        public void AssignInstructorsToClassrooms()
        {
            foreach(Classroom classroom in classRoomDictionary.Values)
            {
                foreach(Instructor instructor in instructorList)
                {
                    bool isCandidate = false;

                    foreach (Module module in instructor.ModuleList)
                    {
                        if (classroom.Module == module)
                        {
                            classroom.Head = instructor;

                            isCandidate = !isCandidate;

                            break;
                        }
                    }

                    if (isCandidate)
                    {
                        break;
                    }
                }
            }

        }

        public void RegisterStudentsForClasses()
        {
            throw new NotImplementedException();
        }
    }
}
