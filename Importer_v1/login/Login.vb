Public Class Login
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If q.displayLogin(TextBox2.Text, TextBox3.Text) = 1 Then
            Me.Hide()
            With Form1
                .name1 = q.fetchUser(TextBox2.Text, TextBox3.Text)

            End With
            Form1.Show()
        Else
            MessageBox.Show("Invalid Account", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = String.Empty
        TextBox3.Text = String.Empty
    End Sub

    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress

    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If q.displayLogin(TextBox2.Text, TextBox3.Text) = 1 Then
                Me.Hide()
                With Form1
                    .name1 = q.fetchUser(TextBox2.Text, TextBox3.Text)
                End With
                Form1.Show()
            Else
                MessageBox.Show("Invalid Account", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

End Class