using System;
using System.Collections.Generic;
using System.Text;

namespace IMDEV.GUI
{
    class ExtendedCheckedListBox:System.Windows.Forms.CheckedListBox
    {
        private bool _rightClickSelectItem;

        public ExtendedCheckedListBox():base()
        {
            MouseUp+=new System.Windows.Forms.MouseEventHandler(ExtendedCheckedListBox_MouseUp);
        }

        public bool rightClickSelectItem
        {
            get { return _rightClickSelectItem; }
            set { _rightClickSelectItem = value; }
        }

        public void ExtendedCheckedListBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
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
