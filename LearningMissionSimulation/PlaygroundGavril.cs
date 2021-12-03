﻿using LearningMissionLab;
using System;
using System.Collections.Generic;


namespace LearningMissionSimulation
{
    public class PlaygroundGavril : ISimulation
    {

        ReportType _reportType;

        List<Student> activeStudentList = new List<Student>();

        List<Account> pendingAccountList = new List<Account>();

        List<Student> studentList = new List<Student>();

        List<Instructor> instructorList = new List<Instructor>();

        Dictionary<Guid, Account> accountDictionary = new Dictionary<Guid, Account>();

        Dictionary<Guid, Module> moduleDictionary = new Dictionary<Guid, Module>();

        List<Guid> moduleIdList = new List<Guid>();

        List<Guid> subjectIdList = new List<Guid>();

        List<Classroom> classroomList = new List<Classroom>();
        public PlaygroundGavril(ReportType reportType)
        {
            this._reportType = reportType;
        }

        public void CreateAccounts(int accountCount)
        {
            string action = "Create Account";
            ReportHeader(actionName: action);

            for (int i = 0; i < accountCount; i++)
            {
                Account account = ObjectGenerator.GenerateAccount();
                accountDictionary.Add(account.Id, account);
                ReportItem(itemName: account.ToString(), actionName: action, itemIndex: i);
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
            }

            ReportSummary(actionName: action, itemCount: accountCount);
            ReportFooter(actionName: action);
        }

        public void ActivateAccounts()
        {
            string action = "Activate account";
            ReportHeader(actionName: action);
            int i = 0;
            foreach (var account in pendingAccountList)
            {
                account.Status = Status.Active;

                ReportItem(itemName: account.ToString(), actionName: action, itemIndex: i);
                i++;
            }
            ReportSummary(actionName: action, itemCount: pendingAccountList.Count);
            ReportFooter(actionName: action);
            pendingAccountList.Clear();
        }

        public void CreateSubjects(int subjectCount)
        {
            string action = "Subject generation";
            ReportHeader(actionName: action);

            int i = 0;
            while (i < subjectCount)
            {
                Subject subject = ObjectGenerator.GenerateSubject();
                subjectIdList.Add(subject.Id);
                i++;
                ReportItem(itemName: subject.ToString(), actionName: action, itemIndex: i);
            }


            ReportSummary(actionName: action, itemCount: subjectCount);
            ReportFooter(actionName: action);
        }

        public void CreateModules(int moduleCount)
        {
            string action = "Create Modules";
            ReportHeader(actionName: action);

            if (subjectIdList.Count == 0)
            {
                ReportError("Subjects", action);
            }
            else
            {
                int i = 0;
                while (i < moduleCount)
                {
                    Guid subjectId = subjectIdList[AttributeGenerator.random.Next(0, subjectIdList.Count)];
                    Module module = ObjectGenerator.GenerateModule(subjectId);
                    moduleDictionary.Add(module.Id, module);
                    moduleIdList.Add(module.Id);
                    i++;
                    ReportItem(itemName: module.ToString(), actionName: action, itemIndex: i);
                }
            }

            ReportSummary(actionName: action, itemCount: moduleCount);
            ReportFooter(actionName: action);
        }

        public void AssignModulesToInstructors()
        {
            string action = "Assign modules to instructors";
            ReportHeader(actionName: action);
            int i = 0;
            foreach (var instructor in instructorList)
            {
                instructor.ModuleList = GetModuleList();
                i++;
                ReportItem(itemName: instructor.ToString(), actionName: action, itemIndex: i);
            }

            ReportSummary(actionName: action, itemCount: i);
            ReportFooter(actionName: action);

        }

        public void AssignModulesToStudents()
        {
            string action = "Assign modules to students";
            ReportHeader(actionName: action);
            int i = 0;
            foreach (Student student in studentList)
            {
                student.CompletedModuleList = GetModuleList();
                i++;
                ReportItem(itemName: student.ToString(), actionName: action, itemIndex: i);

            }

            ReportSummary(actionName: action, itemCount: i);
            ReportFooter(actionName: action);

        }

        List<Module> GetModuleList()
        {
            string action = "create personal module list";
            List<Module> moduleList = new List<Module>();
            int totalModuleCount = moduleIdList.Count;
            int maxModuleCountLimit = 7;
            int minModuleCountLimit = 1;
            maxModuleCountLimit = Math.Min(totalModuleCount, maxModuleCountLimit);
            minModuleCountLimit = Math.Min(totalModuleCount, minModuleCountLimit);
            int count = AttributeGenerator.random.Next(minModuleCountLimit, maxModuleCountLimit);
            maxModuleCountLimit = Math.Min(totalModuleCount, maxModuleCountLimit);
            minModuleCountLimit = Math.Min(totalModuleCount, minModuleCountLimit);

            for (int i = 0; i < count; i++)
            {
                Module module;
                Guid id = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count)];

                if (moduleDictionary.TryGetValue(id, out module))
                {
                    if (!moduleList.Contains(module))
                    {
                        moduleList.Add(module);
                    }

                }
                else
                {
                    ReportError(missingResource: "Module", failedAction: action);
                }


            }
            return moduleList;
        }

        public void CreateClassrooms(int classroomCount)
        {
            string action = "Create Classroom";
            int i = 0;
            ReportHeader(actionName: action);

            if (moduleIdList.Count == 0)
            {
                ReportError(missingResource: "Modules", failedAction: action);
            }
            else
            {
                while (i < classroomCount)
                {
                    Guid moduleId = moduleIdList[AttributeGenerator.random.Next(0, moduleIdList.Count)];
                    Module module;
                    if (!moduleDictionary.TryGetValue(moduleId, out module))
                    {
                        ReportError(missingResource: "Modules", failedAction: action);
                    }
                    else
                    {
                        Classroom classroom = ObjectGenerator.GenerateClassroom(module);
                        classroomList.Add(classroom);
                        i++;
                        ReportItem(itemName: classroom.ToString(), actionName: action, itemIndex: i);
                    }
                }
            }

            ReportSummary(actionName: action, itemCount: i);
            ReportFooter(actionName: action);

        }

        public void AssignInstructorsToClassrooms()
        {
            throw new NotImplementedException();
        }

        public void RegisterStudentsForClasses()
        {
            string action = "Register Students For Classes";
            ReportHeader(actionName: action);
            {
                foreach (var classroom in classroomList)
                {
                    if (classroom.ItemList.Count < classroom.MaximumCapacity)
                    {
                        UpdateStudentList(classroom);
                    }

                }
            }

            ReportSummary(actionName: action, itemCount: classroomList.Count);
            ReportFooter(actionName: action);
        }

        private void UpdateStudentList(Classroom classroom)
        {
            int maxStudentCountToRegister = Math.Min(classroom.MaximumCapacity - classroom.ItemList.Count, activeStudentList.Count);
            int itemListCount = AttributeGenerator.random.Next(0, maxStudentCountToRegister + 1);
            int i = 0;
            while (i < itemListCount)
            {
                Student studentActive = activeStudentList[AttributeGenerator.random.Next(0, activeStudentList.Count)];
                if (!studentActive.CompletedModuleList.Contains(classroom.Module) && !studentActive.ClassroomList.Contains(classroom))
                {
                    classroom.ItemList.Add(studentActive);
                    studentActive.ClassroomList.Add(classroom);
                    i++;

                    ReportItem(itemName: studentActive.ToString(), actionName: "Registered for class", itemIndex: i);
                }

            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        //REPORTS

        #region REPORTS
        void ReportHeader(string actionName)
        {
            Console.WriteLine($"******{actionName} is started******\n");
        }

        void ReportFooter(string actionName)
        {
            Console.WriteLine($"******{actionName} is finished******\n");
        }

        void ReportItem(string itemName, string actionName, int itemIndex)
        {
            Console.WriteLine($" {actionName} {itemIndex} {itemName}\n");
        }

        void ReportSummary(string actionName, int itemCount)
        {
            Console.WriteLine($"'''''' {actionName} {itemCount} ''''''\n");
        }

        void ReportError(string missingResource, string failedAction)
        {
            Console.WriteLine("--------- You do not have the appropriate {0} to {1} ---------\n", missingResource, failedAction);
        }

        #endregion REPORTS

    }
}
