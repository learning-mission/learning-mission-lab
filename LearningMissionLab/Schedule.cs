using System;
using System.Collections.Generic;

namespace LearningMissionLab
{
    public class Schedule
    {
        DateTime _startDate;
        DateTime _finishDate;
        DateTime _createDate;
        DateTime _updateDate;
        List<ScheduleEvent> _scheduleEventList;

        public Schedule(DateTime startDate, DateTime finishDate, List<ScheduleEvent> scheduleEventList,
                        DateTime createDate, DateTime updateDate)
        {
            this._startDate = startDate;
            this._finishDate = finishDate;
            this._scheduleEventList = scheduleEventList;
            this._createDate = DateTime.UtcNow;
            this._updateDate = DateTime.UtcNow;
        }

    
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime FinishDate { get => _finishDate; set => _finishDate = value; }
        public List<ScheduleEvent> ScheduleEventList { get => _scheduleEventList; set => _scheduleEventList = value; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime UpdateDate { get => _updateDate; set => _updateDate = value; }
    }

}
