using System;
using System.Collections.Generic;
using LearningMissionLab;

namespace LearningMissionSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
           // PlaygroundEdvard playgroundEdvard = new PlaygroundEdvard();
            PlaygroundGarush playgroundGarush = new PlaygroundGarush();
            //  PlayGroundGavril playGroundGavril = new PlayGroundGavril();
            //  PlaygroundVahe playgroundVahe = new PlaygroundVahe();
            //  PlaygroundMher playgroundMher = new PlaygroundMher();
            playgroundGarush.CreateSubjects(5);
            playgroundGarush.CreateModules(5);
            playgroundGarush.AssignModulesToInstructors();
            playgroundGarush.AssignModulesToStudents();
        }
    }
}