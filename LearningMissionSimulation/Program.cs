using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            PlaygroundEdvard playgroundEdvard = new PlaygroundEdvard();
            playgroundEdvard.SimulationSmall0(25);
            playgroundEdvard.SimulationBig1(15, 15);
            //PlaygroundGarush playgroundGarush = new PlaygroundGarush();
            //PlayGroundGavril playGroundGavril = new PlayGroundGavril();
            //PlaygroundVahe playgroundVahe = new PlaygroundVahe();
            //PlaygroundMher playgroundMher = new PlaygroundMher(); 
        }
    }
}