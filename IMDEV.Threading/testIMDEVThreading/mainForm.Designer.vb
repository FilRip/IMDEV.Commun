<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnStartThreads = New System.Windows.Forms.Button
        Me.btnStopThreads = New System.Windows.Forms.Button
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
        Me.btnNbThread = New System.Windows.Forms.Button
        Me.btnForSequentiel = New System.Windows.Forms.Button
        Me.btnForParallele = New System.Windows.Forms.Button
        Me.btnEmpileTache = New System.Windows.Forms.Button
        Me.btnNbTacheEmpilee = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnStartThreads
        '
        Me.btnStartThreads.Location = New System.Drawing.Point(6, 7)
        Me.btnStartThreads.Name = "btnStartThreads"
        Me.btnStartThreads.Size = New System.Drawing.Size(95, 23)
        Me.btnStartThreads.TabIndex = 0
        Me.btnStartThreads.Text = "Démarre threads"
        Me.btnStartThreads.UseVisualStyleBackColor = True
        '
        'btnStopThreads
        '
        Me.btnStopThreads.Location = New System.Drawing.Point(6, 36)
        Me.btnStopThreads.Name = "btnStopThreads"
        Me.btnStopThreads.Size = New System.Drawing.Size(95, 23)
        Me.btnStopThreads.TabIndex = 1
        Me.btnStopThreads.Text = "Stop threads"
        Me.btnStopThreads.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 115)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(327, 146)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = ""
        '
        'btnNbThread
        '
        Me.btnNbThread.Location = New System.Drawing.Point(6, 65)
        Me.btnNbThread.Name = "btnNbThread"
        Me.btnNbThread.Size = New System.Drawing.Size(95, 23)
        Me.btnNbThread.TabIndex = 3
        Me.btnNbThread.Text = "Nb thread"
        Me.btnNbThread.UseVisualStyleBackColor = True
        '
        'btnForSequentiel
        '
        Me.btnForSequentiel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnForSequentiel.Location = New System.Drawing.Point(234, 7)
        Me.btnForSequentiel.Name = "btnForSequentiel"
        Me.btnForSequentiel.Size = New System.Drawing.Size(99, 23)
        Me.btnForSequentiel.TabIndex = 4
        Me.btnForSequentiel.Text = "For sequentiel"
        Me.btnForSequentiel.UseVisualStyleBackColor = True
        '
        'btnForParallele
        '
        Me.btnForParallele.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnForParallele.Location = New System.Drawing.Point(234, 36)
        Me.btnForParallele.Name = "btnForParallele"
        Me.btnForParallele.Size = New System.Drawing.Size(99, 23)
        Me.btnForParallele.TabIndex = 5
        Me.btnForParallele.Text = "For parallele"
        Me.btnForParallele.UseVisualStyleBackColor = True
        '
        'btnEmpileTache
        '
        Me.btnEmpileTache.Location = New System.Drawing.Point(112, 7)
        Me.btnEmpileTache.Name = "btnEmpileTache"
        Me.btnEmpileTache.Size = New System.Drawing.Size(108, 23)
        Me.btnEmpileTache.TabIndex = 6
        Me.btnEmpileTache.Text = "Empile tache"
        Me.btnEmpileTache.UseVisualStyleBackColor = True
        '
        'btnNbTacheEmpilee
        '
        Me.btnNbTacheEmpilee.Location = New System.Drawing.Point(112, 36)
        Me.btnNbTacheEmpilee.Name = "btnNbTacheEmpilee"
        Me.btnNbTacheEmpilee.Size = New System.Drawing.Size(108, 23)
        Me.btnNbTacheEmpilee.TabIndex = 7
        Me.btnNbTacheEmpilee.Text = "nb tache en attente"
        Me.btnNbTacheEmpilee.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 273)
        Me.Controls.Add(Me.btnNbTacheEmpilee)
        Me.Controls.Add(Me.btnEmpileTache)
        Me.Controls.Add(Me.btnForParallele)
        Me.Controls.Add(Me.btnForSequentiel)
        Me.Controls.Add(Me.btnNbThread)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.btnStopThreads)
        Me.Controls.Add(Me.btnStartThreads)
        Me.Name = "Form1"
        Me.Text = "IMDEV.Threading"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnStartThreads As System.Windows.Forms.Button
    Friend WithEvents btnStopThreads As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents btnNbThread As System.Windows.Forms.Button
    Friend WithEvents btnForSequentiel As System.Windows.Forms.Button
    Friend WithEvents btnForParallele As System.Windows.Forms.Button
    Friend WithEvents btnEmpileTache As System.Windows.Forms.Button
    Friend WithEvents btnNbTacheEmpilee As System.Windows.Forms.Button

End Class
