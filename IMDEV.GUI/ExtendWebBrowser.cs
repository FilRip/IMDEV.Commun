using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace IMDEV.GUI
{
    public class ExtendWebBrowser:WebBrowser
    {
        private bool _useDefaultWebBrowser;

        public ExtendWebBrowser():base()
        {
            Navigating += new WebBrowserNavigatingEventHandler(event_Navigating);
        }

        public bool useDefaultWebBrowser
        {
            get { return _useDefaultWebBrowser; }
            set { _useDefaultWebBrowser = value; }
        }

        private void event_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (_useDefaultWebBrowser)
                if (Document.ActiveElement.TagName.Trim().ToLower() == "a")
                {
                    try
                    {
                        Document.ActiveElement.RemoveFocus();
                        System.Diagnostics.Process proc;
                        proc = new System.Diagnostics.Process();
                        proc.StartInfo.FileName = e.Url.ToString();
                        proc.Start();
                        proc = null;
                        e.Cancel = true;
                    }
                    catch
                    {
                    }
                }
        }
    }
}
