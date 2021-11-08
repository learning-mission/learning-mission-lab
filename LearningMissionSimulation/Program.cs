using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            PlaygroundEdvard playgroundEdvard0 = new PlaygroundEdvard();
            playgroundEdvard0.Action2(15);
            PlaygroundVahe.Play();
            PlaygroundEdvard.Action0();
            PlaygroundMher playgroundMher = new PlaygroundMher(3);
            //AttributeGenerator.GetCity("2613");

        }
        ModuleLevel moduleLevel = new ModuleLevel();
    }
}
