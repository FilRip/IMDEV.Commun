namespace IMDEV.GUI.InputBox
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Designer;

    [Designer(typeof(SeparatorDesigner))]
    internal partial class Separator : UserControl
    {
        public Separator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Performs the work of setting the specified bounds of this control.
        /// </summary>
        /// <param name="x">The new <see cref="P:System.Windows.Forms.Control.Left"/> property value of the control.</param>
        /// <param name="y">The new <see cref="P:System.Windows.Forms.Control.Top"/> property value of the control.</param>
        /// <param name="width">The new <see cref="P:System.Windows.Forms.Control.Width"/> property value of the control.</param>
        /// <param name="height">The new <see cref="P:System.Windows.Forms.Control.Height"/> property value of the control.</param>
        /// <param name="specified">A bitwise combination of the <see cref="T:System.Windows.Forms.BoundsSpecified"/> values.</param>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            // Set a fixed height for the control.
            base.SetBoundsCore(x, y, width, 2, specified);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.DrawLine(Pens.White, new Point(0, 1), new Point(Width, 1));
            pevent.Graphics.DrawLine(SystemPens.ControlDark, new Point(0, 0), new Point(Width, 0));
        }
    }
}
