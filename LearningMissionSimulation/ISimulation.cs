using System;
namespace LearningMissionSimulation
{
    public interface ISimulation
    {
        void CreateAccounts(int accountCount);

        void ActivateAccounts();

        void CreateModules(int moduleCount);

                void AssignModulesToStudents();

        void AssignModulesToInstructors();

        void CreateClassrooms(int classroomCount);

        void RegisterStudentsForClasses();

    }
}
