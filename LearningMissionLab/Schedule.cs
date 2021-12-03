using System;
using System.Collections.Generic;

namespace LearningMissionLab
{
    public class Schedule
    {
        ZoomMeeting _zoomMeeting;
        DateTime _startDate;
        DateTime _finishDate;
        List<ScheduleEvent> _scheduleEvent;

        public Schedule(DateTime startDate, DateTime finishDate, ZoomMeeting zoomMeeting, List<ScheduleEvent> scheduleEvent)
        {
            this._startDate = startDate;
            this._finishDate = finishDate;
            this._zoomMeeting = zoomMeeting;
            this._scheduleEvent = scheduleEvent;
        }

        public ZoomMeeting ZoomMeeting { get => _zoomMeeting; set => _zoomMeeting = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime FinishDate { get => _finishDate; set => _finishDate = value; }
        public List<ScheduleEvent> ScheduleEvent { get => _scheduleEvent; set => _scheduleEvent = value; }
    }
}
