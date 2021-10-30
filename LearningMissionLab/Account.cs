using System;
namespace LearningMissionLab
{
    /// <summary>
    /// Class: Account
    /// Purpose: Provides a model for Learning Mission user account 
    /// </summary>
    public class Account : IReport
    {
        readonly Guid _id;
        string _username;
        string _password;
        string _email;
        int _phone;
        Role _role;
        Status _status;
        DateTime _createDate;
        DateTime _updateDate;
        public Account(Guid id, string username, string password, string email, int phone, Role role, Status status,
                       DateTime createDate, DateTime updateDate)
        {
            this._id = id;
            this._username = username;
            this._password = password;
            this._email = email;
            this._phone = phone;
            this._role = role;
            this._status = status;
            this._createDate = createDate;
            this._updateDate = updateDate;
        }
        public Account(string username, string password, string email, int phone, Role role, Status status)
        {
            this._id = GetGuid();
            this._username = username;
            this._password = password;
            this._email = email;
            this._phone = phone;
            this._role = role;
            this._status = status;
            this._createDate = DateTime.UtcNow;
            this._updateDate = DateTime.UtcNow;
        }
        
        public Guid Id => _id;

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Email { get => _email; set => _email = value; }
        public int Phone { get => _phone; set => _phone = value; }
        public Role Role { get => _role; set => _role = value; }
        public Status Status { get => _status; set => _status = value; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime UpdateDate { get => _updateDate; set => _updateDate = value; }

        public static Guid GetGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid;
        }
        public void Report()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return $"  Id is {Id}, User Name is {Username}, Password is {Password}, Email is {Email}," +
                   $" Phone is {Phone}, Role is {Role}, Status is {Status}, Create Date is {CreateDate}, " +
                   $" Update Date is {UpdateDate}";
        }
        public int GetPhoneNumber()
        {
            return _phone;
        }
        public int GetPhoneNumber1
        {
            set
            {
                _phone = value;
            }
            get
            {
                return _phone;
            }
        }
        public string GetEmail()
        {
            return _email;
        }
        public string GetEmail1
        {
            set
            {
                _email = value;
            }
            get
            {
                return _email;
            }
        }
    }
}
