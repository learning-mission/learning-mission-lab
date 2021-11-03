using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            PlaygroundVahe.Play();
            PlaygroundEdvard.Action0();
            PlaygroundMher playgroundMher = new PlaygroundMher();
        }
        ModuleLevel moduleLevel = new ModuleLevel();
    }
}
