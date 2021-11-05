using System;
namespace LearningMissionSimulation
{
    public interface ISimulation
    {
        void CreateAccounts();

        void ActivateAccounts();

        void AssignInstructorsToCreateModules();

        void AssignCompletedModulesToStudents();

        void AssignInstructorsForClasses();

        void RegisterStudentsForClasses();

    }
}
