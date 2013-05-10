using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace IMDEV.GUI.MsgBoxPerso
{
    public class MsgBoxPerso : System.Windows.Forms.Form
    {
        private string _result = "";
        private string _title = "";
        private string _body = "";
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.Panel panelBoutons;
        private List<MsgBoxPersoButton> _listeBoutons = new List<MsgBoxPersoButton>();
        private int maxSize;

        private const int START_X_BUTTON = 16;
        
        public MsgBoxPerso()
        {
            InitializeComponent();
        }
        
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        
        public string body
        {
            get { return _body; }
            set { _body = value; }
        }
        
        public int moreLength()
        {
            int retour;
            int enCours;
            Font police = new Font(lblBody.Font.Name, lblBody.Font.Size);
            retour = 0;
            foreach (string chaine in _body.Split('\r'))
            {
                enCours = (int)Graphics.FromHwnd(this.Handle).MeasureString(chaine, police).Width;
                if (enCours > retour)
                    retour = enCours;
            }
            return retour;
        }
        
        public bool addButton(MsgBoxPersoButton button)
        {
            foreach (MsgBoxPersoButton b in _listeBoutons)
                if (b.code == button.code)
                    return false;

            _listeBoutons.Add(button);
            return true;
        }

        public bool addButton(string label, string code)
        {
            return addButton(label, code, null);
        }
        public bool addButton(string label, string code, System.Drawing.Image image)
        {
            foreach (MsgBoxPersoButton b in _listeBoutons)
                if (b.code == code)
                    return false;

            MsgBoxPersoButton nb = new MsgBoxPersoButton();
            nb.label = label;
            nb.code = code;
            if (image!=null)
                nb.image = image;
            _listeBoutons.Add(nb);
            return true;
        }
        
        void init()
        {
            lblBody.Text = _body;
            maxSize = moreLength();
            this.Width = maxSize;
            int decalageX = 0;
            System.Windows.Forms.Button btn;
            if (_listeBoutons.Count == 0)
                addButton("OK", "OK");

            foreach (MsgBoxPersoButton bouton in _listeBoutons)
            {
                btn = new System.Windows.Forms.Button();
                btn.AutoSize = true;
                btn.Left = (decalageX + START_X_BUTTON);
                btn.Text = bouton.label;
                btn.Tag = bouton.code;
                if (bouton.image!=null)
                    btn.BackgroundImage = bouton.image;

                decalageX = (decalageX + btn.Width);
                btn.Click += new System.EventHandler(this.clickButton);
                panelBoutons.Controls.Add(btn);
                if (this.Width < decalageX)
                {
                    this.Width = (decalageX + 40);
                    maxSize = this.Width;
                }
            }
            panelBoutons_Resize(null, null);
        }

        void clickButton(object sender, EventArgs e)
        {
            try
            {
                _result = ((Button)sender).Tag.ToString();
            }
            catch { }
            this.Close();
        }

        public string showDialogBox(List<MsgBoxPersoButton> boutons)
        {
            if (boutons!=null)
                foreach (MsgBoxPersoButton btn in boutons)
                    addButton(btn);

            return showDialogBox();
        }
        public string showDialogBox()
        {
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterParent;
            this.Text = _title;
            ShowDialog();
            return _result;
        }

        void InitializeComponent()
        {
            this.lblBody = new System.Windows.Forms.Label();
            this.panelBoutons = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblBody
            // 
            this.lblBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBody.AutoSize = true;
            this.lblBody.Location = new System.Drawing.Point(1, 1);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(0, 13);
            this.lblBody.TabIndex = 0;
            this.lblBody.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBoutons
            // 
            this.panelBoutons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBoutons.Location = new System.Drawing.Point(0, 34);
            this.panelBoutons.Name = "panelBoutons";
            this.panelBoutons.Size = new System.Drawing.Size(105, 30);
            this.panelBoutons.TabIndex = 1;
            this.panelBoutons.Resize += new System.EventHandler(this.panelBoutons_Resize);
            // 
            // MsgBoxPerso
            // 
            this.ClientSize = new System.Drawing.Size(104, 64);
            this.Controls.Add(this.panelBoutons);
            this.Controls.Add(this.lblBody);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MsgBoxPerso";
            this.Shown += new System.EventHandler(this.MsgBoxPerso_Shown);
            this.Resize += new System.EventHandler(this.MsgBoxPerso_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void MsgBoxPerso_Resize(object sender, System.EventArgs e)
        {
            if (this.Width < maxSize) this.Width = maxSize;
        }

        void MsgBoxPerso_Shown(object sender, System.EventArgs e)
        {
            init();
        }

        void panelBoutons_Resize(object sender, System.EventArgs e)
        {
            if (panelBoutons.Controls.Count > 0)
            {
                int lengthButton = START_X_BUTTON;
                int newStartX;
                int decalageX;
                foreach (System.Windows.Forms.Button btn in panelBoutons.Controls)
                    lengthButton = (lengthButton + (btn.Width + START_X_BUTTON));

                newStartX = ((panelBoutons.Width - lengthButton) / 2);
                decalageX = newStartX;
                foreach (System.Windows.Forms.Button btn in panelBoutons.Controls)
                {
                    btn.Left = (decalageX + START_X_BUTTON);
                    decalageX = (decalageX + btn.Width);
                }
            }
        }
    }

    public class MsgBoxPersoButton
    {
        private string _label = "";
        private string _code = "";
        private Image _image;

        public Image image
        {
            get { return _image; }
            set { _image = value; }
        }

        public string label
        {
            get { return _label; }
            set { _label = value; }
        }

        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
    }
}
