using System;
namespace LearningMissionSimulation
{
    public interface ISimulation
    {
        void CreateAccounts(int accountCount);

        void ActivateAccounts();

        void CreateSubjects(int subjectCount);

        void CreateModules(int moduleCount);

        void AssignModulesToStudents();

        void AssignModulesToInstructors();

        void CreateClassrooms(int classroomCount);

        void RegisterStudentsForClasses();

    }
}
