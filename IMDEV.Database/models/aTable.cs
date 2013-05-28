using System;
using System.Collections.Generic;
using System.Text;

namespace IMDEV.Database.models
{
    public class aTable
    {
        private List<aField> _listFields;
        private string _name;

        public aTable()
        {
            _listFields = new List<aField>();
        }

        public List<aField> listOfFields
        {
            get { return _listFields; }
            set { _listFields = value; }
        }

        public string tableName
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
