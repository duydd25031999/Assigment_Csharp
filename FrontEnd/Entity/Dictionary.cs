using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Entity
{
    public class Dictionary
    {
        int _id;
        string _name;
        Dictionary() { }
        Dictionary(int id, string name)
        {
            this._id = id;
            this._name = name;
        }
        int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}