using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            AttributeGenerator.GetModuleName();

            PlaygroundEdvard.Action0();
            PlaygroundMher playgroundMher = new PlaygroundMher();
        }
    }
}
