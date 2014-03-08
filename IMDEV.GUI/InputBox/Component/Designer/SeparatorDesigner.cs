namespace IMDEV.GUI.InputBox.Designer
{
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    internal class SeparatorDesigner : ControlDesigner
    {
        /// <summary>
        /// Initializes a newly created component.
        /// </summary>
        /// <param name="defaultValues">A name/value dictionary of default values to apply to properties. May be null if no default values are specified.</param>
        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);

            if (ParentComponent is Control)
                Control.Width = ((Control) ParentComponent).ClientSize.Width;

            Control.Left = 0;
            Control.Height = 2;
        }

        /// <summary>
        /// Gets the selection rules that indicate the movement capabilities of a component.
        /// </summary>
        /// <value></value>
        /// <returns>A bitwise combination of <see cref="T:System.Windows.Forms.Design.SelectionRules"/> values.</returns>
        public override SelectionRules SelectionRules
        {
            get
            {
                return SelectionRules.LeftSizeable | SelectionRules.RightSizeable |
                       SelectionRules.Moveable | SelectionRules.Visible;
            }
        }
    }
}
