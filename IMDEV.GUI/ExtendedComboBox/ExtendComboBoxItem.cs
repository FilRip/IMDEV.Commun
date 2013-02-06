using System;
using System.Collections.Generic;
using System.Text;

namespace IMDEV.GUI.ExtendedComboBox
{
    public class ExtendComboBoxItem
    {
        private int _id;
        private string _text;

        public ExtendComboBoxItem()
        {
        }

        public ExtendComboBoxItem(string text)
        {
            _text = text;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
