using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Note
    {
        private int _termId;
        private int _userId;
        private string _content;
        private string _termContent;

        public Note() { }
        public int TermID
        {
            get
            {
                return _termId;
            }
            set
            {
                _termId = value;
            }
        } 
        public int UserID
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }
        public string TermContent
        {
            get
            {
                return _termContent;
            }
            set
            {
                _termContent = value;
            }
        }
    }
}
