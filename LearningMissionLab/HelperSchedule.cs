using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class HelperSchedule
    {
        DateTime _day;
        DateTime _time;
        int _maxDayInWeek;
        int _minDayInWeek;
        int _maxTimeInDay;
        int _minTimeInDay;
        public HelperSchedule(DateTime day, DateTime time)
        {
            this._day = day;
            this._time = time;
        }

        public DateTime Day { get => _day; set => _day = value; }
        public DateTime Time { get => _time; set => _time = value; }
        public int MaxDayInWeek { get => _maxDayInWeek; set => _maxDayInWeek = value; }
        public int MaxTimeInDay { get => _maxTimeInDay; set => _maxTimeInDay = value; }
        public int MinDayInWeek { get => _minDayInWeek; set => _minDayInWeek = value; }
        public int MinTimeInDay { get => _minTimeInDay; set => _minTimeInDay = value; }
    }
}
