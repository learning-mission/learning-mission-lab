using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    class Lesson
    {
        string subjectId;
        string moduleId; 
        string lessonId;
        string description;
        uint duration;
        List<string> videoList;
        List<string> slideList;
        DateTime createDate;
        DateTime updateDate;
        DateTime EndDate;
    }
}
