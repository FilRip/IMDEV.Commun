using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace IMDEV.GUI.InputBox
{
    internal partial class InputBoxForm : Form
    {
        #region Consts

        private const int BORDER_PADDING = 10;
        private const int MINIMUM_WIDTH = 202;
        private const int BUTTON_ZONE_HEIGHT = 50;

        #endregion Consts

        #region Attributes

        private HorizontalAlignment _mainLabelAlignment = HorizontalAlignment.Left;

        #endregion Attributes

        #region Properties

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        internal string Value
        {
            get { return txbValue.Text; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InputBoxForm"/> class.
        /// </summary>
        private InputBoxForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputBoxForm"/> class.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public InputBoxForm(params object[] parameters) : this()
        {
            foreach (object parameter in parameters)
            {
                if (parameter is string)
                {
                    txbValue.Text = (string) parameter;
                }
                else if (parameter is HorizontalAlignment)
                {
                    _mainLabelAlignment = (HorizontalAlignment) parameter;
                }
                else if (parameter is string[])
                {
                    int stringCounter = 0;
                    foreach (string value in parameter as String[])
                    {
                        if (0 == stringCounter) lblFieldDescription.Text = value;
                        if (1 == stringCounter) lblMainDescription.Text = value;
                        if (2 == stringCounter) Text = value;
                        ++stringCounter;
                    }
                }
            }
            
            SetLayout();
        }

        #endregion Constructors

        #region Layout

        /// <summary>
        /// Sets the layout of the window according the descriptions.
        /// </summary>
        private void SetLayout()
        {
            #region Measures
            
            Graphics graph = this.CreateGraphics();

            lblMainDescription.Size = graph.MeasureString(lblMainDescription.Text, lblMainDescription.Font).ToSize();
            lblFieldDescription.Size = graph.MeasureString(lblFieldDescription.Text, lblFieldDescription.Font).ToSize();
            lblMainDescription.Width += 3;

            #endregion Measures

            #region Sizes

            int titleWidth = (int)graph.MeasureString(Text, SystemFonts.CaptionFont).Width + 30;

            int maxWidth = 0;
            maxWidth = Math.Max(Math.Max(Math.Max(lblMainDescription.Width,
                                                  lblFieldDescription.Width + txbValue.Width + 5 + BORDER_PADDING * 2),
                                         MINIMUM_WIDTH),
                                titleWidth);

            ClientSize = new Size(maxWidth, ClientSize.Height);

            int maxHeight = 0;
            maxHeight = BORDER_PADDING + lblMainDescription.Height +
                        BORDER_PADDING + lblFieldDescription.Height +
                        BORDER_PADDING + BUTTON_ZONE_HEIGHT;

            ClientSize = new Size(ClientSize.Width, maxHeight);

            #endregion Sizes

            #region Positions

            lblMainDescription.Top = BORDER_PADDING;
            switch (_mainLabelAlignment)
            {
                case HorizontalAlignment.Center:
                    lblMainDescription.Left = Convert.ToInt32((maxWidth - lblMainDescription.Width) / 2);
                    break;
                case HorizontalAlignment.Left:
                    lblMainDescription.Left = BORDER_PADDING;
                    break;
                case HorizontalAlignment.Right:
                    lblMainDescription.Left = ClientSize.Width - (lblMainDescription.Width + BORDER_PADDING);
                    break;
                default:
                    break;
            }

            lblFieldDescription.Top = lblMainDescription.Bottom + BORDER_PADDING + 3;
            lblFieldDescription.Left = Convert.ToInt32((maxWidth - (lblFieldDescription.Width + BORDER_PADDING + txbValue.Width)) / 2);

            txbValue.Top = lblFieldDescription.Top - 3;
            txbValue.Left = lblFieldDescription.Right + BORDER_PADDING;

            #endregion Positions
        }

        #endregion Layout
    }
}