using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            //PlaygroundVahe.Play();
            //PlaygroundEdvard.Action0();
            //PlaygroundMher playgroundMher = new PlaygroundMher();
            //AttributeGenerator.GetCity("2613");
            Account account = ObjectGenerator.GenerateAccount();
            PlayGroundGavril groundGavril = new PlayGroundGavril();
            groundGavril.CreateAccounts(5);
            groundGavril.CreateAccounts(5);
            

        }
        //ModuleLevel moduleLevel = new ModuleLevel();
    }
}
