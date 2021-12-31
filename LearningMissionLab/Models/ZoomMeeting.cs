namespace LearningMissionLab.Models
{
    public class ZoomMeeting
    {
        string _link;
        string _id;
        string _passcode;


        public ZoomMeeting(string link, string meetingId, string passcode)
        {
            this._link = link;
            this._id = meetingId;
            this._passcode = passcode;
        }


        public string Link { get => _link; set => _link = value; }
        public string Id { get => _id; set => _id = value; }
        public string Passcode { get => _passcode; set => _passcode = value; }
    }

}
