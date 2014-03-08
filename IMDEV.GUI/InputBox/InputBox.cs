namespace IMDEV.GUI.InputBox
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Displays a prompt in a dialog box, waits for the user to input text or click a button, and then returns a string containing the contents of the text box.
    /// </summary>
    public static class InputBox
    {
        /// <summary>
        /// Show an InputBox using the specified parameters.
        /// <list type="table">
        /// <listheader>
        ///     <term>If the type of the parameter is</term>
        ///     <description>The value will be used as</description>
        /// </listheader>
        /// <item>
        ///     <term><see cref="System.String"/>[]</term>
        ///     <description>the text of the label next to the text field for the first string, the text for the upper label for the second string, the title for the third string</description>
        /// </item>
        /// <item>
        ///     <term><see cref="System.String"/></term>
        ///     <description>the default value</description>
        /// </item>
        /// <item>
        ///     <term><see cref="System.Windows.Forms.HorizontalAlignment"/></term>
        ///     <description>the position of the upper label</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="value">The string containing the contents of the text box</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// One of the <see cref="DialogResult"/> values.
        /// </returns>
        public static DialogResult Show(out string value, params object[] parameters)
        {
            value = String.Empty;
            InputBoxForm form = new InputBoxForm(parameters);

            DialogResult result = form.ShowDialog();
            value = form.Value;

            return result;
        }
    }
}
