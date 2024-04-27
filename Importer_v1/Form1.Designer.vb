<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MODULE1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Module2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegisterToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentVoucherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentVoucherToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VoucherRegisterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompanyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TermsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModeOfReleasingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Imoport1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportSupplierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ATCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BillsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Process1 = New System.Diagnostics.Process()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MODULE1ToolStripMenuItem, Me.PaymentVoucherToolStripMenuItem, Me.SetupToolStripMenuItem, Me.ImportToolStripMenuItem, Me.BillsToolStripMenuItem, Me.ReportsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1292, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MODULE1ToolStripMenuItem
        '
        Me.MODULE1ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Module2ToolStripMenuItem, Me.RegisterToolStripMenuItem1})
        Me.MODULE1ToolStripMenuItem.Name = "MODULE1ToolStripMenuItem"
        Me.MODULE1ToolStripMenuItem.Size = New System.Drawing.Size(111, 20)
        Me.MODULE1ToolStripMenuItem.Text = "Payment Request"
        '
        'Module2ToolStripMenuItem
        '
        Me.Module2ToolStripMenuItem.Name = "Module2ToolStripMenuItem"
        Me.Module2ToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.Module2ToolStripMenuItem.Text = "Payment Request"
        '
        'RegisterToolStripMenuItem1
        '
        Me.RegisterToolStripMenuItem1.Name = "RegisterToolStripMenuItem1"
        Me.RegisterToolStripMenuItem1.Size = New System.Drawing.Size(211, 22)
        Me.RegisterToolStripMenuItem1.Text = "Payment Request Register"
        '
        'PaymentVoucherToolStripMenuItem
        '
        Me.PaymentVoucherToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PaymentVoucherToolStripMenuItem1, Me.VoucherRegisterToolStripMenuItem})
        Me.PaymentVoucherToolStripMenuItem.Name = "PaymentVoucherToolStripMenuItem"
        Me.PaymentVoucherToolStripMenuItem.Size = New System.Drawing.Size(112, 20)
        Me.PaymentVoucherToolStripMenuItem.Text = "Payment Voucher"
        '
        'PaymentVoucherToolStripMenuItem1
        '
        Me.PaymentVoucherToolStripMenuItem1.Name = "PaymentVoucherToolStripMenuItem1"
        Me.PaymentVoucherToolStripMenuItem1.Size = New System.Drawing.Size(212, 22)
        Me.PaymentVoucherToolStripMenuItem1.Text = "Payment Voucher"
        '
        'VoucherRegisterToolStripMenuItem
        '
        Me.VoucherRegisterToolStripMenuItem.Name = "VoucherRegisterToolStripMenuItem"
        Me.VoucherRegisterToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.VoucherRegisterToolStripMenuItem.Text = "Payment Voucher Register"
        '
        'SetupToolStripMenuItem
        '
        Me.SetupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsersToolStripMenuItem, Me.TypeToolStripMenuItem, Me.BankToolStripMenuItem, Me.CompanyToolStripMenuItem, Me.TermsToolStripMenuItem, Me.ModeOfReleasingToolStripMenuItem})
        Me.SetupToolStripMenuItem.Name = "SetupToolStripMenuItem"
        Me.SetupToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.SetupToolStripMenuItem.Text = "Setup"
        '
        'UsersToolStripMenuItem
        '
        Me.UsersToolStripMenuItem.Name = "UsersToolStripMenuItem"
        Me.UsersToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.UsersToolStripMenuItem.Text = "Users"
        '
        'TypeToolStripMenuItem
        '
        Me.TypeToolStripMenuItem.Name = "TypeToolStripMenuItem"
        Me.TypeToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.TypeToolStripMenuItem.Text = "Type"
        '
        'BankToolStripMenuItem
        '
        Me.BankToolStripMenuItem.Name = "BankToolStripMenuItem"
        Me.BankToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.BankToolStripMenuItem.Text = "Bank"
        '
        'CompanyToolStripMenuItem
        '
        Me.CompanyToolStripMenuItem.Name = "CompanyToolStripMenuItem"
        Me.CompanyToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CompanyToolStripMenuItem.Text = "Supplier"
        '
        'TermsToolStripMenuItem
        '
        Me.TermsToolStripMenuItem.Name = "TermsToolStripMenuItem"
        Me.TermsToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.TermsToolStripMenuItem.Text = "Terms"
        '
        'ModeOfReleasingToolStripMenuItem
        '
        Me.ModeOfReleasingToolStripMenuItem.Name = "ModeOfReleasingToolStripMenuItem"
        Me.ModeOfReleasingToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ModeOfReleasingToolStripMenuItem.Text = "Mode of Releasing"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Imoport1ToolStripMenuItem, Me.ImportSupplierToolStripMenuItem, Me.ATCToolStripMenuItem})
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(82, 20)
        Me.ImportToolStripMenuItem.Text = "Importation"
        '
        'Imoport1ToolStripMenuItem
        '
        Me.Imoport1ToolStripMenuItem.Name = "Imoport1ToolStripMenuItem"
        Me.Imoport1ToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.Imoport1ToolStripMenuItem.Text = "Unpaid Bills"
        '
        'ImportSupplierToolStripMenuItem
        '
        Me.ImportSupplierToolStripMenuItem.Name = "ImportSupplierToolStripMenuItem"
        Me.ImportSupplierToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ImportSupplierToolStripMenuItem.Text = "Vendor's Data"
        '
        'ATCToolStripMenuItem
        '
        Me.ATCToolStripMenuItem.Name = "ATCToolStripMenuItem"
        Me.ATCToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ATCToolStripMenuItem.Text = "ATC"
        '
        'BillsToolStripMenuItem
        '
        Me.BillsToolStripMenuItem.Name = "BillsToolStripMenuItem"
        Me.BillsToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.BillsToolStripMenuItem.Text = "Bills"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 689)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1292, 26)
        Me.PanelControl1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'Process1
        '
        Me.Process1.StartInfo.Domain = ""
        Me.Process1.StartInfo.LoadUserProfile = False
        Me.Process1.StartInfo.Password = Nothing
        Me.Process1.StartInfo.StandardErrorEncoding = Nothing
        Me.Process1.StartInfo.StandardOutputEncoding = Nothing
        Me.Process1.StartInfo.UserName = ""
        Me.Process1.SynchronizingObject = Me
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.APPS.My.Resources.Resources.ap_png2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1292, 715)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AP PRINTING SYSTEM"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MODULE1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Module2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegisterToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PaymentVoucherToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TypeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BankToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompanyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TermsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Imoport1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportSupplierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModeOfReleasingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ATCToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PaymentVoucherToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents VoucherRegisterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BillsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Process1 As Process
    Friend WithEvents Label1 As Label
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
End Class
