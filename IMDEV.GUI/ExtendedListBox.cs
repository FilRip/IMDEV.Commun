using System;
using System.Collections.Generic;
using System.Text;

namespace IMDEV.GUI
{
    public class ExtendedListBox:System.Windows.Forms.ListBox
    {
        private bool _rightClickSelectItem;

        public ExtendedListBox():base()
        {
            MouseUp+=new System.Windows.Forms.MouseEventHandler(ExtendedListBox_MouseUp);
        }

        public bool rightClickSelectItem
        {
            get { return _rightClickSelectItem; }
            set { _rightClickSelectItem = value; }
        }

        public void ExtendedListBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                if (_rightClickSelectItem)
                    try
                    {
                        SelectedIndex = IndexFromPoint(new System.Drawing.Point(e.X, e.Y));
                    }
                    catch
                    {
                        SelectedIndex = -1;
                    }
        }
    }
}
