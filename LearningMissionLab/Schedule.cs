using System;
namespace LearningMissionLab
{
    public class Schedule
    {
        string _linq;
        string _literatures;
        Instructor _instructor;
        Classroom _classroom;
        ModuleLevel _moduleLevel;
        SubjectType _subjectType;
        DateTime _day;
        DateTime _time;

        public Schedule()
        {

        }

        public Schedule(DateTime day, DateTime time, Classroom classroom, Instructor instructor,
                        ModuleLevel moduleLevel, SubjectType subjectType, string linq, string literaturesl)
        {
            this._day = day;
            this._time = time;
            this._classroom = classroom;
            this._instructor = instructor;
            this._moduleLevel = moduleLevel;
            this._subjectType = subjectType;
            this._linq = linq;
            this._literatures = literaturesl;
        }

        public string Linq { get => _linq; set => _linq = value; }
        public string Literatures { get => _literatures; set => _literatures = value; }
        public Instructor Instructor { get => _instructor; set => _instructor = value; }
        public Classroom Classroom { get => _classroom; set => _classroom = value; }
        public ModuleLevel ModuleLevel { get => _moduleLevel; set => _moduleLevel = value; }
        public SubjectType SubjectType { get => _subjectType; set => _subjectType = value; }
        public DateTime Day { get => _day; set => _day = value; }
        public DateTime Time { get => _time; set => _time = value; }
    }
}
