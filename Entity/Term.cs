using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Term
    {
        int _id;
        int _dictionaryId;
        string _content;
        List<Definition> _listDef;
        string _note;
        public Term()
        {
            _listDef = new List<Definition>();
        }
        public Term(int id, int dictionaryId, string content)
        {
            this._id = id;
            this._dictionaryId = dictionaryId;
            this._content = content;

        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public int DictionaryID
        {
            get { return _dictionaryId; }
            set { _dictionaryId = value; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
            }
        }
        public List<Definition> Definitions
        {
            get
            {
                return _listDef;
            }
            set
            {
                _listDef = value;
            }
        }
    }
}
