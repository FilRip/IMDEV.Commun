namespace IMDEV.GUI.InputBox
{
    partial class InputBoxForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputBoxForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFieldDescription = new System.Windows.Forms.Label();
            this.txbValue = new System.Windows.Forms.TextBox();
            this.lblMainDescription = new System.Windows.Forms.Label();
            this.separator1 = new IMDEV.GUI.InputBox.Separator();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(104, 104);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(204, 104);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblFieldDescription
            // 
            this.lblFieldDescription.AutoSize = true;
            this.lblFieldDescription.Location = new System.Drawing.Point(26, 48);
            this.lblFieldDescription.Name = "lblFieldDescription";
            this.lblFieldDescription.Size = new System.Drawing.Size(104, 13);
            this.lblFieldDescription.TabIndex = 3;
            this.lblFieldDescription.Text = "Please enter a value";
            // 
            // txbValue
            // 
            this.txbValue.Location = new System.Drawing.Point(136, 45);
            this.txbValue.Name = "txbValue";
            this.txbValue.Size = new System.Drawing.Size(140, 20);
            this.txbValue.TabIndex = 4;
            // 
            // lblMainDescription
            // 
            this.lblMainDescription.Location = new System.Drawing.Point(12, 6);
            this.lblMainDescription.Name = "lblMainDescription";
            this.lblMainDescription.Size = new System.Drawing.Size(278, 32);
            this.lblMainDescription.TabIndex = 5;
            this.lblMainDescription.Text = resources.GetString("lblMainDescription.Text");
            // 
            // separator1
            // 
            this.separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.separator1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.separator1.Location = new System.Drawing.Point(0, 95);
            this.separator1.Margin = new System.Windows.Forms.Padding(0);
            this.separator1.MinimumSize = new System.Drawing.Size(2, 2);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(302, 2);
            this.separator1.TabIndex = 6;
            // 
            // InputBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 135);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.lblMainDescription);
            this.Controls.Add(this.txbValue);
            this.Controls.Add(this.lblFieldDescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBoxForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblFieldDescription;
        private System.Windows.Forms.TextBox txbValue;
        private System.Windows.Forms.Label lblMainDescription;
        private IMDEV.GUI.InputBox.Separator separator1;
    }
}

