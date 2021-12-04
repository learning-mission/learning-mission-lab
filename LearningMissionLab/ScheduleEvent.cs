using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class ScheduleEvent
    {
        DayOfTheWeek _dayOfTheWeek;
        uint _startTimeHour;
        uint _startTimeMinutes;
        uint _duration;
        ZoomMeeting _zoomMeeting;


        public ScheduleEvent(DayOfTheWeek dayOfTheWeek, uint startTimeHour, uint startTimeMinutes, uint duration, ZoomMeeting zoomMeeting)
        {
            this._dayOfTheWeek = dayOfTheWeek;
            this._startTimeHour = startTimeHour;
            this._startTimeMinutes = startTimeMinutes;
            this._duration = duration;
            this._zoomMeeting = zoomMeeting;
        }


        public DayOfTheWeek DayOfTheWeek { get => _dayOfTheWeek; set => _dayOfTheWeek = value; }
        public uint StartTimeHour { get => _startTimeHour; set => _startTimeHour = value; }
        public uint StartTimeMinutes { get => _startTimeMinutes; set => _startTimeMinutes = value; }
        public uint Duration { get => _duration; set => _duration = value; }
        public ZoomMeeting ZoomMeeting { get => _zoomMeeting; set => _zoomMeeting = value; }
    }

}
