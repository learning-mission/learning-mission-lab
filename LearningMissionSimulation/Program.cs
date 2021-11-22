﻿using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            ISimulation playgroundEdvard = new PlaygroundEdvard(ReportType.Short);
            ISimulation playgroundGarush = new PlaygroundGarush();
            ISimulation playgroundGavril = new PlaygroundGavril();
            ISimulation playgroundVahe = new PlaygroundVahe();
            ISimulation playgroundMher = new PlaygroundMher();

            Simulation.SimulationA(playgroundEdvard, 20);
            Simulation.SimulationA(playgroundGarush, 20);
            Simulation.SimulationA(playgroundGavril, 20);
            Simulation.SimulationA(playgroundMher, 20);
            Simulation.SimulationA(playgroundVahe, 20);
        }
    }
}