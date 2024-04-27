<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form6
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form6))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txt4 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txt3 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txt2 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.dgv1)
        Me.PanelControl1.Location = New System.Drawing.Point(261, 8)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(899, 267)
        Me.PanelControl1.TabIndex = 0
        '
        'dgv1
        '
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.dgv1.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv1.Location = New System.Drawing.Point(2, 2)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(895, 263)
        Me.dgv1.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.dgv2)
        Me.PanelControl2.Location = New System.Drawing.Point(261, 281)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(899, 323)
        Me.PanelControl2.TabIndex = 1
        '
        'dgv2
        '
        Me.dgv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.dgv2.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv2.Location = New System.Drawing.Point(2, 2)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.Size = New System.Drawing.Size(895, 319)
        Me.dgv2.TabIndex = 1
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.SimpleButton1)
        Me.PanelControl3.Controls.Add(Me.GroupBox5)
        Me.PanelControl3.Controls.Add(Me.GroupBox4)
        Me.PanelControl3.Controls.Add(Me.GroupBox3)
        Me.PanelControl3.Controls.Add(Me.GroupBox2)
        Me.PanelControl3.Controls.Add(Me.GroupBox1)
        Me.PanelControl3.Location = New System.Drawing.Point(8, 8)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(247, 596)
        Me.PanelControl3.TabIndex = 1
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.SimpleButton1.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.SimpleButton1.Location = New System.Drawing.Point(5, 513)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(228, 78)
        Me.SimpleButton1.TabIndex = 21
        Me.SimpleButton1.Text = "Extract"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txt4)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 202)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(234, 52)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Account"
        '
        'txt4
        '
        Me.txt4.Location = New System.Drawing.Point(6, 20)
        Me.txt4.Name = "txt4"
        Me.txt4.Size = New System.Drawing.Size(222, 21)
        Me.txt4.TabIndex = 10
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt3)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 143)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(234, 52)
        Me.GroupBox4.TabIndex = 19
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Memo"
        '
        'txt3
        '
        Me.txt3.Location = New System.Drawing.Point(6, 20)
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(222, 21)
        Me.txt3.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt2)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 83)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(234, 54)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Reference"
        '
        'txt2
        '
        Me.txt2.Location = New System.Drawing.Point(6, 20)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(222, 21)
        Me.txt2.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton3)
        Me.GroupBox2.Controls.Add(Me.RadioButton4)
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(5, 260)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(234, 76)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Name"
        Me.GroupBox2.Visible = False
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(64, 20)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(54, 17)
        Me.RadioButton3.TabIndex = 17
        Me.RadioButton3.Text = "Select"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(10, 20)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(36, 17)
        Me.RadioButton4.TabIndex = 16
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "All"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(6, 43)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(222, 21)
        Me.ComboBox2.TabIndex = 13
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(234, 72)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Document Type"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(6, 43)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(222, 21)
        Me.ComboBox1.TabIndex = 12
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(64, 20)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(54, 17)
        Me.RadioButton2.TabIndex = 15
        Me.RadioButton2.Text = "Select"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(10, 20)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(36, 17)
        Me.RadioButton1.TabIndex = 14
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "All"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Form6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1168, 612)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form6"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bills"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt3 As TextBox
    Friend WithEvents txt2 As TextBox
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents txt4 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents dgv2 As DataGridView
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Private WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Private WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Private WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Private WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
