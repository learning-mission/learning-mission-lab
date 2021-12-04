using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class ZoomMeeting
    {
        string _link;
        string _pwd;
        string _id;
        string _passcode;


        public ZoomMeeting(string link, string pwd, string meetingId, string passcode)
        {
            this._link = link;
            this._pwd = pwd;
            this._id = meetingId;
            this._passcode = passcode;
        }


        public string Link { get => _link; set => _link = value; }
        public string Pwd { get => _pwd; set => _pwd = value; }
        public string Id { get => _id; set => _id = value; }
        public string Passcode { get => _passcode; set => _passcode = value; }
    }

}
