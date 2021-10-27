using System;
namespace LearningMissionLab
{
    /// <summary>
    /// 
    /// </summary>
    public class Account
    {
        readonly string _accountId;
        string _userName;
        string _password;
        string _email;
        int _phone;
        Role _role;
        Status _status;
        DateTime _createDate;
        DateTime _updateDate;
        public Account( string userName, string password, string email, int phone, Role role, Status status )
        {
            this._accountId = GetGuid();
            this._userName = userName;
            this._password = password;
            this._email = email;
            this._phone = phone;
            this._role = role;
            this._status = status;
            this._createDate = DateTime.Now;
            this._updateDate = DateTime.Now;
        }
        public Account(string accountId, string userName, string password, string email, int phone, Role role, Status status,
                       DateTime createDate, DateTime updateDate)
        {
            this._accountId = accountId;
            this._userName = userName;
            this._password = password;
            this._email = email;
            this._phone = phone;
            this._role = role;
            this._status = status;
            this._createDate = createDate;
            this._updateDate = updateDate;
        }
        public string AccountId => _accountId;

        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public string Email { get => _email; set => _email = value; }
        public int Phone { get => _phone; set => _phone = value; }
        public Role Role { get => _role; set => _role = value; }
        public Status Status { get => _status; set => _status = value; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime UpdateDate { get => _updateDate; set => _updateDate = value; }
        public static string GetGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
