Public Class releasing
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        q.saveMode(TextBox1.Text)
        MessageBox.Show("Successfully Added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
        With releasingList
            .display()
        End With
        Me.Close()
    End Sub
End Class