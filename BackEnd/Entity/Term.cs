using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace BackEnd.Entity
{
    public class Term
    {
        int _id;
        int _dictionaryId;
        string _content;
        List<Definition> _listDef;
        Term() {
            _listDef = new List<Definition>();
        }
        Term(int id, int dictionaryId, string content)
        {
            this._id = id;
            this._dictionaryId = dictionaryId;
            this._content = content;
            
        }
        int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        int DictionaryID
        {
            get { return _dictionaryId; }
            set { _dictionaryId = value; }
        }
        string Content
        {
            get { return _content; }
            set { _content = value; }
        }
    }
}