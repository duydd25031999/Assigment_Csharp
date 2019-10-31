using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Entity
{
    public class Definition
    {
        int _typeCode;
        int _id;
        int _index;
        string _content;
        int _termId;

        Definition() { }
        Definition(int id, int index, string content, int typeCode, int termId)
        {
            this._id = id;
            this._index = index;
            this._content = content;
            this._typeCode = typeCode;
            this._termId = termId;
        }

        string Type
        {
            get {
                switch(_typeCode)
                {
                    case 1:
                        return "header";
                    case 2:
                        return "kind";
                    case 3:
                        return "example";
                    case 4:
                        return "explain";
                };
                return "other";
            }
            set { }
        }

        int ID
        {
            get { return _id;  }
            set { _id = value;  }
        }

        int Index
        {
            get { return _index;  }
            set { _index = value; }
        }

        string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        int TypeCode
        {
            get { return _typeCode; }
            set { _typeCode = value; }
        }

        int TermID
        {
            get { return _termId; }
            set { _termId = value; }
        }
    }
}