using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class ScheduleEvent
    {
        DayOfWeek _dayOfWeek;
        uint _startTimeHour;
        uint _startTimeMinutes;
        uint _duration;
        ZoomMeeting _zoomMeeting;


        public ScheduleEvent(DayOfWeek dayOfWeek, uint startTimeHour, uint startTimeMinutes, uint duration, ZoomMeeting zoomMeeting)
        {
            this._dayOfWeek = dayOfWeek;
            this._startTimeHour = startTimeHour;
            this._startTimeMinutes = startTimeMinutes;
            this._duration = duration;
            this._zoomMeeting = zoomMeeting;
        }


        public DayOfWeek DayOfWeek { get => _dayOfWeek; set => _dayOfWeek = value; }
        public uint Duration { get => _duration; set => _duration = value; }
        public ZoomMeeting ZoomMeeting { get => _zoomMeeting; set => _zoomMeeting = value; }
        public uint StartTimeHour
        {
            set
            {
                if(_startTimeHour < 24)
                {
                    _startTimeHour = value;
                }
            }
            get
            {
                return _startTimeHour;
            }
        }
        public uint StartTimeMinutes
        {
            set
            {
                if (_startTimeMinutes < 60)
                {
                    _startTimeMinutes = value;
                }
            }
            get
            {
                return _startTimeMinutes;
            }
        }
    }

}
