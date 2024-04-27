Public Class addSupplier

    Public id As Integer
    Public vatstat As String

    Private Sub addSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.Text = "Update" Then

            If vatstat = "Non-Vatable" Then
                RadioButton2.Checked = True
                vatstat = "Non-Vatable"
            ElseIf vatstat = "Vatable" Then
                RadioButton1.Checked = True
                vatstat = "Vatable"
            End If

        Else

            TextBox2.Text = String.Empty
            TextBox4.Text = String.Empty
            TextBox8.Text = String.Empty
            TextBox5.Text = String.Empty
            TextBox9.Text = String.Empty
            TextBox10.Text = String.Empty
            TextBox11.Text = String.Empty
            TextBox3.Text = String.Empty
            RadioButton2.Checked = False
            RadioButton2.Checked = True
            TextBox1.Text = String.Empty
            TextBox6.Text = String.Empty
            TextBox7.Text = String.Empty

        End If

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If SimpleButton2.Text = "Record" Then
            q.saveSup(TextBox2.Text, TextBox3.Text, TextBox1.Text, TextBox4.Text, TextBox5.Text, TextBox9.Text, TextBox10.Text, TextBox11.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, vatstat)
            MessageBox.Show("Successfully Added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf SimpleButton2.Text = "Save" Then
            q.UpdateSupplier(id, TextBox2.Text, TextBox1.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox9.Text, TextBox10.Text, TextBox11.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, vatstat)
            MessageBox.Show("Successfully Updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox6.Text = String.Empty
            TextBox7.Text = String.Empty
            TextBox1.Text = String.Empty
        End If

        With Form8
            .display()
        End With
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ATC.ShowDialog()
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        '' Allow only digits (0-9) and handle backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        '' Limit the length to 3 digits
        If TextBox5.Text.Length >= 3 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            TextBox9.Focus()
        End If
    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        ' Allow only digits (0-9) and handle backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        ' Limit the length to 3 digits
        If TextBox9.Text.Length >= 3 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            TextBox10.Focus()
        End If
    End Sub

    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox10.KeyPress
        ' Allow only digits (0-9) and handle backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        ' Limit the length to 3 digits
        If TextBox10.Text.Length >= 3 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            TextBox11.Focus()
        End If
    End Sub

    Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox11.KeyPress
        ' Allow only digits (0-9) and handle backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        ' Limit the length to 3 digits
        If TextBox11.Text.Length >= 5 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged


        vatstat = "Non-Vatable"
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        vatstat = "Vatable"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class