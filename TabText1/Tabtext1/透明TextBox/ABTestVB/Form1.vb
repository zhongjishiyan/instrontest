Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents AlphaBlendTextBox1 As ZBobb.AlphaBlendTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.AlphaBlendTextBox1 = New ZBobb.AlphaBlendTextBox
        Me.SuspendLayout()
        '
        'AlphaBlendTextBox1
        '
        Me.AlphaBlendTextBox1.BackAlpha = 50
        Me.AlphaBlendTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
        Me.AlphaBlendTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AlphaBlendTextBox1.ForeColor = System.Drawing.Color.Yellow
        Me.AlphaBlendTextBox1.Location = New System.Drawing.Point(144, 48)
        Me.AlphaBlendTextBox1.Multiline = True
        Me.AlphaBlendTextBox1.Name = "AlphaBlendTextBox1"
        Me.AlphaBlendTextBox1.Size = New System.Drawing.Size(216, 184)
        Me.AlphaBlendTextBox1.TabIndex = 0
        Me.AlphaBlendTextBox1.Text = "AlphaBlendTextBox1"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(472, 374)
        Me.Controls.Add(Me.AlphaBlendTextBox1)
        Me.Name = "Form1"
        Me.Text = "AlphaBlendTextBox Test VB"
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
