using System;
using System.Collections.Generic;

namespace LearningMissionLab
{
    public class Schedule
    {
        string _zoomReferanse;
        DateTime _startDate;
        DateTime _finishDate;
        List<HelperSchedule> _helperScheduleList;

        public Schedule(DateTime startDate, DateTime finishDate, string zoomReferanse, List<HelperSchedule> helperScheduleList)
        {
            this._startDate = startDate;
            this._finishDate = finishDate;
            this._zoomReferanse = zoomReferanse;
            this._helperScheduleList = helperScheduleList;
        }

        public string ZoomReferanse { get => _zoomReferanse; set => _zoomReferanse = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime FinishDate { get => _finishDate; set => _finishDate = value; }
        public List<HelperSchedule> HelperScheduleList { get => _helperScheduleList; set => _helperScheduleList = value; }
    }
}
