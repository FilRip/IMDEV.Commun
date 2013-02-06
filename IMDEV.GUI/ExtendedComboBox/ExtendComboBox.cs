using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.ComponentModel;

namespace IMDEV.GUI.ExtendedComboBox
{
    public class ExtendComboBox:System.Windows.Forms.ComboBox
    {
        private bool _autoSizeDropDownWidth;
        //private myCollection _myList;

        public ExtendComboBox():base()
        {
            //_myList = new myCollection();
            DropDown += new EventHandler(event_DropDown);
            //DrawItem += new DrawItemEventHandler(event_DrawItem);
        }

        public bool autoSizeDropDownWidth
        {
            get { return _autoSizeDropDownWidth; }
            set { _autoSizeDropDownWidth = value; }
        }

        void event_DropDown(object sender, EventArgs e)
        {
            if (_autoSizeDropDownWidth)
            {
                Graphics gfx;
                Font police;
                Int32 newWidth, currentWidth;

                gfx = CreateGraphics();
                police = this.Font;
                currentWidth = DropDownWidth;

                foreach (Object item in Items)
                {
                    newWidth = (int)gfx.MeasureString(item.ToString(), police).Width;
                    if (newWidth > currentWidth) currentWidth = newWidth;
                }

                if (Items.Count > MaxDropDownItems)
                    currentWidth += SystemInformation.VerticalScrollBarWidth;

                DropDownWidth = currentWidth;
            }
        }

        public void AddItem(ExtendComboBoxItem item)
        {
            Items.Add(item);
        }

        /*public new myCollection Items
        {
            get { return _myList; }
        }*/

    }

    /*public class myCollection : Collection<ExtendComboBoxItem>
    {
        public void Add(string text)
        {
            Add(new ExtendComboBoxItem(text));
        }
    }*/
}
