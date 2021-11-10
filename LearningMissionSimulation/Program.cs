using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // PlaygroundVahe.Play();
            // PlaygroundEdvard.Action0();
            // PlaygroundMher playgroundMher = new PlaygroundMher();
            // AttributeGenerator.GetCity("2613");
            //PlaygroundGarush playgroundGarush = new PlaygroundGarush();
            //playgroundGarush.CreateAccounts(20);
            //playgroundGarush.ActivateAccounts();
            PlaygroundEdvard playgroundEdvard0 = new PlaygroundEdvard();
            playgroundEdvard0.Action2(25);
            playgroundEdvard0.Action3(10, 10);
        }
        //ModuleLevel moduleLevel = new ModuleLevel();
    }
}
