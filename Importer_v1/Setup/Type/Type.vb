Public Class Type
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        q.saveType(TextBox1.Text)
        MessageBox.Show("Successfully Added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
        With TypeList
            .display()
        End With
        Me.Close()
    End Sub
End Class