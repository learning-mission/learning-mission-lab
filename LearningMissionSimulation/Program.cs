using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            ISimulation playgroundEdvard = new PlaygroundEdvard();
            ISimulation playgroundGarush = new PlaygroundGarush();
            ISimulation playgroundVahe = new PlaygroundVahe();
            ISimulation playgroundMher = new PlaygroundMher();
            ISimulation playgroundGavril = new PlaygroundGavril(ReportType.Verbose);

            Simulation.SimulationB(playgroundGavril, 20);
            Simulation.SimulationA(playgroundEdvard, 20);
            Simulation.SimulationA(playgroundGarush, 20);
            Simulation.SimulationA(playgroundMher, 20);
            Simulation.SimulationA(playgroundVahe, 20);
        }
    }
}
