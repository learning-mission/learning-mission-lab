using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionSimulation
{
    class PlaygroundVahe
    {
        public static void Play()
        {
            Console.WriteLine(AttributeGenerator.GetLanguageLevel());
            Console.WriteLine(AttributeGenerator.GetLanguageName());
            Console.WriteLine(AttributeGenerator.GetPassword(8,20));
            Console.WriteLine(AttributeGenerator.GetUsername());
        }

    }
}
