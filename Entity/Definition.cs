using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Definition
    {
        int _typeCode;
        int _id;
        int _index;
        string _content;
        int _termId;

        public Definition() { }
        public Definition(int id, int index, string content, int typeCode, int termId)
        {
            this._id = id;
            this._index = index;
            this._content = content;
            this._typeCode = typeCode;
            this._termId = termId;
        }

        public string Type
        {
            get
            {
                switch (_typeCode)
                {
                    case 1:
                        return "word-class";
                    case 2:
                        return "meaning";
                    case 3:
                        return "header";
                    case 4:
                        return "example";
                    case 5:
                        return "explain";
                };
                return "other";
            }
            set { }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public int TypeCode
        {
            get { return _typeCode; }
            set { _typeCode = value; }
        }

        public int TermID
        {
            get { return _termId; }
            set { _termId = value; }
        }
    }
}
