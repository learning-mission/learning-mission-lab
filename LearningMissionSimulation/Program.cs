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
            PlaygroundMher playgroundMher = new PlaygroundMher(5);
            AttributeGenerator.GetCity("2613");
            playgroundMher.CreateAccounts(5);
            playgroundMher.ActivateAccounts();
            playgroundMher.FairCoordinator();
        }
        ModuleLevel moduleLevel = new ModuleLevel();
    }
}
