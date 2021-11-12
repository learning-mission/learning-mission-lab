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
            playgroundEdvard.Action2(25);
            playgroundEdvard.Action3(15, 15);
            //PlaygroundGarush playgroundGarush = new PlaygroundGarush();
            //PlayGroundGavril playGroundGavril = new PlayGroundGavril();
            //PlaygroundVahe playgroundVahe = new PlaygroundVahe();
            //PlaygroundMher playgroundMher = new PlaygroundMher(); 
        }
    }
}