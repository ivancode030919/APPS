Public Class User

    Public Type As String = ""
    Public id As Integer
    Public Status As Integer
    Public dfalt As String = ""

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        If Type = "Update" Then
            Dim Stat As Integer
            Dim df1 As String = ""

            If ComboBox1.Text = "Management" Then
                Stat = 1
            Else
                Stat = 0
            End If

            If RadioButton1.Checked = True Then
                df1 = "Default"

            Else
                df1 = "Non"
            End If


            q.updatedefault()
            q.updateuser(id, TextBox1.Text, TextBox2.Text, TextBox3.Text, Stat, df1)
            MessageBox.Show("Successfully Updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            With UserList
                .display()
            End With
            Me.Close()
        ElseIf Type = "Add" Then

            Dim uname As String
            Dim upass As String
            Dim stat As String

            If ComboBox1.Text = "Management" Then

                uname = "admn"
                upass = "p@ssw0rd"
                stat = "1"

            Else

                stat = "0"
                uname = TextBox2.Text
                upass = TextBox3.Text

            End If

            q.saveUser(TextBox1.Text, uname, upass, stat)
            MessageBox.Show("Successfully Added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            With UserList
                .display()
            End With
            Me.Close()
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        If Type = "Update" Then

        Else
            If ComboBox1.Text = "Management" Then
                TextBox2.Enabled = False
                TextBox3.Enabled = False
            ElseIf ComboBox1.Text = "Employee" Then
                TextBox2.Enabled = True
                TextBox3.Enabled = True
            End If
        End If

    End Sub

    Private Sub User_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If Status = 0 Then

            ComboBox1.Text = "Employee"

        Else

            ComboBox1.Text = "Management"

        End If


        If dfalt = "Default" Then
            RadioButton1.Checked = True
        Else
            RadioButton1.Checked = False
        End If
    End Sub

    Private Sub User_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ComboBox1.SelectedIndex = -1
    End Sub
End Class