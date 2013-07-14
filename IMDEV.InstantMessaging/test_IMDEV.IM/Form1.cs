using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test_IMDEV.IM
{
    public partial class Form1 : Form
    {
        private IMDEV.InstantMessaging.GTalk _myGTalk;

        private delegate void delegateSetConnected();
        private void setConnected()
        {
            this.Text = "Connected";
        }
        private void invokeSetConnected()
        {
            if (this.InvokeRequired)
                this.Invoke(new delegateSetConnected(setConnected));
            else
                setConnected();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _myGTalk = new IMDEV.InstantMessaging.GTalk();
            _myGTalk.connectionOK += new IMDEV.InstantMessaging.GTalk.delegateConnectionOK(_myGTalk_connectionOK);
            _myGTalk.connect("filrip@gmail.com", "Havealover16384");
        }

        void _myGTalk_connectionOK()
        {
            invokeSetConnected();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _myGTalk.sendMessage("ptreille@imdeveloppement.com", "Ceci est un test depuis la librairie NET IMDEV");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_myGTalk != null)
                _myGTalk.Close();
        }
    }
}
