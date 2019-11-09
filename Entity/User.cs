using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class User
    {
        private int _id;
        private string _username;
        private string _password;
        private string _email;
        private DateTime _dob;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return _dob;
            }
            set
            {
                _dob = value;
            }
        }
        public User() { }
        public User(string username, string password)
        {
            this._username = username;
            this._password = password;
        }
        public User(int id, string username, string password, string email, DateTime dob)
        {
            this._id = id;
            this._username = username;
            this._password = password;
            this._email = email;
            this._dob = dob;
        }
    }
}
