using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    /// <summary>
    /// Class: Lesson
    /// Purpose: Provides a model for Learning Mission lessons 
    /// </summary>
    public class Lesson
    {
        int _subjectId;
        int _moduleId;
        int _lessonId;
        int _duration;
        string _description;
        List<String> _videosList;
        List<String> _slidesList;
        DateTime createDate;
        DateTime updateDate;

        public Lesson(int subjectId, int moduleId, int lessonId, string description,
                      int duration, List<String> videosList, List<String> slidesList)
        {
            this._subjectId = subjectId;
            this._moduleId = moduleId;
            this._lessonId = lessonId;
            this._duration = duration;
            this._description = description;
            this._videosList = videosList;
            this._slidesList = slidesList;
        }

        public Lesson(int lessonId,int duration)
        {
            this._lessonId = lessonId;
            this._duration = duration;
        }

        public int SubjectId { get => _subjectId; set => _subjectId = value; }
        public int ModuleId { get => _moduleId; set => _moduleId = value; }
        public int LessonId { get => _lessonId; set => _lessonId = value; }
        public string Description { get => _description; set => _description = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public List<string> VideosList { get => _videosList; set => _videosList = value; }
        public List<string> SlidesList { get => _slidesList; set => _slidesList = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public DateTime UpdateDate { get => updateDate; set => updateDate = value; }
    }
}
