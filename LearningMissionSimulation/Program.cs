using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
          //  ISimulation playgroundEdvard = new PlaygroundEdvard(ReportType.Silent);
            ISimulation playgroundGarush = new PlaygroundGarush(ReportType.Verbose);
          //  ISimulation playgroundGavril = new PlaygroundGavril();
          //  ISimulation playgroundVahe = new PlaygroundVahe();
          //  ISimulation playgroundMher = new PlaygroundMher();

         //   Simulation.SimulationA(playgroundEdvard, 20);
              Simulation.SimulationA(playgroundGarush, 20);
         //   Simulation.SimulationA(playgroundGavril, 20);
         //   Simulation.SimulationA(playgroundMher, 20);
         //   Simulation.SimulationA(playgroundVahe, 20);
        }
    }
}