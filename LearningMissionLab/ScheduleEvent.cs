using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class ScheduleEvent
    {
        DateTime _dayOfTheWeek;
        DateTime _startTimeHour;
        DateTime _startTimeMinutes;
        DateTime _duration;
       
        public ScheduleEvent(DateTime dayOfTheWeek, DateTime startTimeHour, DateTime startTimeMinutes, DateTime duration)
        {
            this._dayOfTheWeek = dayOfTheWeek;
            this._startTimeHour = startTimeHour;
            this._startTimeMinutes = startTimeMinutes;
            this._duration = duration;
        }

        public DateTime DayOfTheWeek { get => _dayOfTheWeek; set => _dayOfTheWeek = value; }
        public DateTime StartTimeHour { get => _startTimeHour; set => _startTimeHour = value; }
        public DateTime StartTimeMinutes { get => _startTimeMinutes; set => _startTimeMinutes = value; }
        public DateTime Duration { get => _duration; set => _duration = value; }
    }
}
