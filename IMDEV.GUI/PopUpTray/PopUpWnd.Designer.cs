using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IMDEV.GUI.PopUpForm
{
	[ToolboxBitmap(typeof(NotifyIcon))]
	public class PopUpWnd: Component
    {
		private Container components= null;

		private messageForm dlg; 

		private int fWidth  = 100;

		private int fHeight = 100;

        private System.Drawing.Font ffont = new System.Drawing.Font(FontFamily.GenericSansSerif, (float)8.25);

        private System.Drawing.Color fcolor;

        private System.Drawing.Color fTopColor;

        private System.Drawing.Color fBottomColor;

        private System.Drawing.Icon ficon = SystemIcons.Information;

		private int fopacity = 100;

		private int fTimeToLive = 5;

		[Category("Appearance")]
		[Description("Bottom gradient Color.")]
		public System.Drawing.Color BottomColor
        {
			get
            {
				return fBottomColor;
            }
			set
            {
				fBottomColor = value;
            }
        }

		[Category("Appearance")]
		[Description("Text Color.")]
		public System.Drawing.Color color
        {
			get
            {
				return fcolor;
            }
			set
            {
				fcolor = value;
            }
        }

		[Category("Appearance")]
		[Description("Text Font.")]
		public System.Drawing.Font font
        {
			get
            {
				return ffont;
            }
			set
            {
				ffont = value;
            }
        }

[Category("Appearance")]
[DefaultValue(100)]
[Description("Window Height.")]
public int Height {
	get { return this.fHeight; }
	set { this.fHeight = value; }
}

[Category("Appearance")]
[Description("Icon for message.")]
public System.Drawing.Icon icon {
	get { return this.ficon; }
	set { this.ficon = value; }
}

[Category("Appearance")]
[Description("Window Opacity.")]
public int opacity {
	get { return this.fopacity; }
	set {
		if ((value > 100) || (value < 0))
        {
			this.fopacity = 100;
		}
        else
        {
			this.fopacity = value;
		}
	}
}

[Category("Appearance")]
[DefaultValue(5)]
[Description("Time To Live, seconds.")]
public int TimeToLive {
	get { return this.fTimeToLive; }
	set { this.fTimeToLive = value; }
}

[Category("Appearance")]
[Description("Top gradient Color.")]
public System.Drawing.Color TopColor {
	get { return this.fTopColor; }
	set { this.fTopColor = value; }
}

[Category("Appearance")]
[DefaultValue(100)]
[Description("Window Width.")]
public int Width {
	get { return this.fWidth; }
	set { this.fWidth = value; }
}


public PopUpWnd(IContainer container) : base()
{
        fcolor = System.Drawing.Color.White;
        fTopColor  = System.Drawing.Color.Blue;
        fBottomColor  = System.Drawing.Color.Red;
	container.Add(this);
	this.InitializeComponent();
}

public PopUpWnd() : base()
{
        fcolor = System.Drawing.Color.White;
        fTopColor  = System.Drawing.Color.Blue;
        fBottomColor  = System.Drawing.Color.Red;
	this.InitializeComponent();
}

protected override void Dispose(bool disposing)
{
	if ((disposing && this.components != null)) {
		this.components.Dispose();
	}
	base.Dispose(disposing);
}

public void Hide()
{
	this.dlg.Visible = false;
}

private void InitializeComponent()
{
	this.components = new Container();
}

        public void ShowWindow(string messageToShow , string messageTitle)
        {
            dlg = new messageForm();
                dlg.p1 = this;
                dlg.Icon = this.icon;
                dlg.Text = messageToShow;
                dlg.title = messageTitle;
                dlg.Font = this.font;
                dlg.color = this.color;
            dlg.Width = Width;
            dlg.Height = Height;
            dlg.timer1.Interval = TimeToLive * 1000;
            messageForm _messageForm = dlg;
            System.Drawing.Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            int width = workingArea.Width - dlg.Width;
            System.Drawing.Rectangle rectangle = Screen.PrimaryScreen.WorkingArea;
            _messageForm.SetDesktopLocation(width, rectangle.Height - dlg.Height);
            this.dlg.Opacity=(double)((double)this.opacity / (double)100);
            dlg.Show();
            dlg.Visible = true;
        }

        internal virtual void OnClick(object sender, EventArgs e)
        {
            if (this.Click != null)
            {
                this.Click.Invoke(this, e);
            }
        }

		public event EventHandler Click;

    }
}