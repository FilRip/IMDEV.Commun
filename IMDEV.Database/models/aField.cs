using System;
using System.Collections.Generic;
using System.Text;

namespace IMDEV.Database.models
{
    public class aField
    {
        private string _name;
        private aFieldType _type;
        private long _tableId;
        private bool _allowNull;
        private object _defaultValue;
        private long _maxLength;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public aFieldType fieldType
        {
            get { return _type; }
            set { _type = value; }
        }

        public long tableId
        {
            get { return _tableId; }
            set { _tableId = value; }
        }

        public bool allowNull
        {
            get { return _allowNull; }
            set { _allowNull = value; }
        }

        public object defaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }

        public long maxLength
        {
            get { return _maxLength; }
            set { _maxLength = value; }
        }
    }
}
