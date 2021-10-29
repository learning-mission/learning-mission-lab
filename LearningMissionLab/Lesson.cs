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
        Guid _subjectId;
        Guid _moduleId;
        readonly Guid _id;
        int _duration;
        string _description;
        List<string> _videoList;
        List<string> _slideList;
        DateTime _createDate;
        DateTime _updateDate;

        public Lesson(Guid subjectId, Guid moduleId, Guid id, string description,
                      int duration, List<string> videoList, List<string> slideList,
                      DateTime createDate, DateTime updateDate)
        {
            this._subjectId = subjectId;
            this._moduleId = moduleId;
            this._id = id;
            this._duration = duration;
            this._description = description;
            this._videoList = videoList;
            this._slideList = slideList;
            this._createDate = createDate;
            this._updateDate = updateDate;
        }
        public Lesson(string description, int duration, List<string> videoList, List<string> slideList)                      
        {
            this._subjectId = GetGuid();
            this._moduleId = GetGuid();
            this._id = GetGuid();
            this._duration = duration;
            this._description = description;
            this._videoList = videoList;
            this._slideList = slideList;
            this._createDate = DateTime.UtcNow;
            this._updateDate = DateTime.UtcNow;
        }
        public Guid SubjectId { get => _subjectId; set => _subjectId = value; }
        public Guid ModuleId { get => _moduleId; set => _moduleId = value; }
        public string Description { get => _description; set => _description = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public List<string> VideoList { get => _videoList; set => _videoList = value; }
        public List<string> SlideList { get => _slideList; set => _slideList = value; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime UpdateDate { get => _updateDate; set => _updateDate = value; }
        public Guid id => _id;

        private static Guid GetGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid;
        }
    }
}
