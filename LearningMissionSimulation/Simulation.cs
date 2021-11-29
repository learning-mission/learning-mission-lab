using System;
namespace LearningMissionSimulation
{
    public class Simulation
    {
        public static void SimulationA(ISimulation simulation, int runCount)
        {
            int iRun = 0;
            while (iRun < runCount)
            {
                int methodIndex = AttributeGenerator.random.Next(1, 11);
                int itemCount = AttributeGenerator.random.Next(0, 10);
                switch (methodIndex)
                {
                    case 1:
                        simulation.CreateAccounts(itemCount);
                        break;
                    case 2:
                        simulation.ActivateAccounts();
                        break;
                    case 3:
                        simulation.CreateSubjects(itemCount);
                        break;
                    case 4:
                        simulation.CreateModules(itemCount);
                        break;
                    case 5:
                        simulation.AssignModulesToInstructors();
                        break;
                    case 6:
                        simulation.AssignModulesToStudents();
                        break;
                    case 7:
                        //simulation.CreateClassrooms(itemCount);
                        break;
                    case 8:
                        //simulation.AssignInstructorsToClassrooms();
                        break;
                    case 9:
                        //simulation.RegisterStudentsForClasses();
                        break;
                    case 10:
                        //simulation.Clear();
                        break;
                }
                iRun++;
            }
        }

        public static void SimulationB(ISimulation simulation, int runCount)
        {
            int iRun = 0;
            while (iRun < runCount)
            {
                int itemCount = AttributeGenerator.random.Next(0, 10);
            
                simulation.CreateAccounts(50);
                simulation.ActivateAccounts();
                simulation.CreateSubjects(50);
                simulation.CreateModules(50);
                simulation.AssignModulesToInstructors();
                simulation.AssignModulesToStudents();
                simulation.CreateClassrooms(50);        
                //simulation.AssignInstructorsToClassrooms();
                //simulation.RegisterStudentsForClasses();
                //simulation.Clear();

                iRun++;
            }
        }
    }
}
