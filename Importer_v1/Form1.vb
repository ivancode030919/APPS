Public Class Form1


    Public name1 As String = ""
    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If q.FetchUserStat(name1) = 3 Then

            UsersToolStripMenuItem.Visible = True

        Else

            UsersToolStripMenuItem.Visible = False

        End If

    End Sub

    Private Sub RegisterToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Module2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Module2ToolStripMenuItem.Click


        Form7.MdiParent = Me
        Form7.Show()
        Form7.BringToFront()
    End Sub

    Private Sub RegisterToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RegisterToolStripMenuItem1.Click
        Form3.MdiParent = Me
        Form3.Show()

    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersToolStripMenuItem.Click
        UserList.MdiParent = Me
        UserList.Show()
    End Sub

    Private Sub BankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BankToolStripMenuItem.Click
        banklist.MdiParent = Me
        banklist.Show()
    End Sub

    Private Sub TypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TypeToolStripMenuItem.Click
        TypeList.MdiParent = Me
        TypeList.Show()
    End Sub

    Private Sub TermsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TermsToolStripMenuItem.Click
        TermsList.MdiParent = Me
        TermsList.Show()
    End Sub

    Private Sub Imoport1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Imoport1ToolStripMenuItem.Click
        form2.MdiParent = Me
        form2.Show()
    End Sub

    Private Sub CompanyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompanyToolStripMenuItem.Click
        Form8.MdiParent = Me
        Form8.Show()
    End Sub

    Private Sub ImportSupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportSupplierToolStripMenuItem.Click
        supplierimport.MdiParent = Me
        supplierimport.Show()
    End Sub

    Private Sub ModeOfReleasingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModeOfReleasingToolStripMenuItem.Click
        releasingList.MdiParent = Me
        releasingList.Show()
    End Sub

    Private Sub ATCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ATCToolStripMenuItem.Click
        Form9.MdiParent = Me
        Form9.Show()
    End Sub

    Private Sub PaymentVoucherToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PaymentVoucherToolStripMenuItem1.Click
        Voucher1.MdiParent = Me
        Voucher1.Show()
    End Sub

    Private Sub VoucherRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VoucherRegisterToolStripMenuItem.Click
        register.MdiParent = Me
        register.Show()
    End Sub

    Private Sub BillsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillsToolStripMenuItem.Click
        Listofbills.MdiParent = Me
        Listofbills.Show()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
        Login.Show()
    End Sub


End Class
