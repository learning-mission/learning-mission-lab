using System;
namespace LearningMissionSimulation
{
    public interface ISimulation
    {
        // Creates accounts 
        void CreateAccounts(int accountCount);

        // Activates pending student and instructor accounts
        void ActivateAccounts();

        // Creates subjects
        void CreateSubjects(int subjectCount);

        // Creates modules for existing subjects
        void CreateModules(int moduleCount);

        // Adds a random number of existing modules to student's completed
        // module list
        void AssignModulesToStudents();

        // Adds a random number of existing modules to instructor's module list
        void AssignModulesToInstructors();

        // Creates classrooms with randomly assigned modules
        void CreateClassrooms(int classroomCount);

        // Assigns instuctors to classrooms
        // The only requirement is: the classroom's module is in the
        // instructor's module list.
        void AssignInstructorsToClassrooms();

        // Assigns students to exisitng classrooms
        void RegisterStudentsForClasses();

        // Clear the internal state
        void Clear();

    }
}
