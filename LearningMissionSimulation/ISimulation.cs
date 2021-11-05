using System;
namespace LearningMissionSimulation
{
    public interface ISimulation
    {
        void CreateAccounts();

        void ActivateAccounts();

        void CreateModules();

        void AssignModulesToStudents();

        void AssignModulesToInstructors();

        void CreateClassrooms();

        void RegisterStudentsForClasses();

    }
}
