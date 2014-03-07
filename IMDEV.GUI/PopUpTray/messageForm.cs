using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace IMDEV.GUI.PopUpForm
{
	public class messageForm : Form
	{

		private IContainer components;
		//string text;

        //System.Drawing.Font font;


		public System.Drawing.Color color;

		public string title;
		private Timer withEventsField_timer1;
		public Timer timer1 {
			get { return withEventsField_timer1; }
			set {
				if (withEventsField_timer1 != null) {
					withEventsField_timer1.Tick -= timer1_Tick;
				}
				withEventsField_timer1 = value;
				if (withEventsField_timer1 != null) {
					withEventsField_timer1.Tick += timer1_Tick;
				}
			}
		}
        //System.Drawing.Icon icon = SystemIcons.Information;


		public PopUpWnd p1;
		public messageForm() : base()
		{
			Paint += messageForm_Paint;
			this.InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if ((disposing && this.components != null)) {
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			this.timer1 = new Timer(this.components);
			this.timer1.Enabled = true;
			this.AutoScaleBaseSize = new Size(5, 13);
			base.ClientSize = new Size(292, 273);
			base.ControlBox = false;
			base.FormBorderStyle = 0;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "messageForm";
			base.ShowInTaskbar = false;
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.StartPosition = 0;
			this.Text = "messageForm";
			base.TopMost = true;
		}

		private void messageForm_Paint(object sender, PaintEventArgs e)
		{
			int num = 5;
			int num1 = 10;
			System.Drawing.Drawing2D.LinearGradientBrush linearGradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), this.p1.TopColor, this.p1.BottomColor, 2);
			System.Drawing.Drawing2D.LinearGradientBrush linearGradientBrush1 = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), this.p1.TopColor, this.p1.BottomColor, 3);
			Graphics graphic = Graphics.FromHwnd(base.Handle);
			graphic.FillRectangle(linearGradientBrush, 0, 0, base.Width, base.Height);
			System.Drawing.SizeF sizeF = graphic.MeasureString(this.title, this.Font);
			graphic.DrawIcon(this.Icon, num, Convert.ToInt32(Convert.ToInt32(sizeF.Height) + base.Height / 2 - this.Icon.Height));
			graphic.FillRectangle(linearGradientBrush1, 2f, 2f, Convert.ToSingle((base.Width - 2)), sizeF.Height);
			System.Drawing.Font font = new System.Drawing.Font(this.Font, FontStyle.Bold);
			graphic.DrawString(this.title, font, new SolidBrush(this.color), Convert.ToSingle(num), 2f, StringFormat.GenericDefault);
			graphic.DrawString(this.Text, this.Font, new SolidBrush(this.color), new RectangleF(Convert.ToSingle((this.Icon.Width + num * 2)), sizeF.Height + Convert.ToSingle(num1), Convert.ToSingle((base.Width - (this.Icon.Width + num * 2))), Convert.ToSingle(base.Height) - (sizeF.Height + Convert.ToSingle(num1))), StringFormat.GenericDefault);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			base.Close();
		}
        private void messageForm_Click(object sender, EventArgs e)
        {
            this.p1.OnClick(sender, e);
        }
	}

}