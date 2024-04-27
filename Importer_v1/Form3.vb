Public Class Form3
    Private q As New qry
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Now.ToShortDateString
        DateTimePicker2.Value = Date.Now.ToShortDateString
        displa()
    End Sub

    Public Sub displa()

        q.Register(DateTimePicker1.Value, DateTimePicker2.Value, TextEdit1.Text, TextEdit2.Text, TextEdit3.Text, ComboBox1.Text)

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        displa()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        displa()
    End Sub

    Private Sub TextEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit3.EditValueChanged
        displa()
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit1.EditValueChanged
        displa()
    End Sub

    Private Sub TextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit2.EditValueChanged
        displa()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim row As Integer = DataGridView1.CurrentCell.RowIndex
        Try

            Form4.TextEdit4.Text = DataGridView1.Rows(row).Cells(1).Value.ToString
            Form4.TextEdit2.Text = DataGridView1.Rows(row).Cells(2).Value.ToString
            Form4.TextEdit1.Text = DataGridView1.Rows(row).Cells(3).Value.ToString
            Form4.TextEdit3.Text = DataGridView1.Rows(row).Cells(4).Value.ToString
            Form4.TextEdit5.Text = DataGridView1.Rows(row).Cells(5).Value.ToString
            Form4.TextEdit6.Text = DataGridView1.Rows(row).Cells(6).Value.ToString
            Form4.TextEdit7.Text = DateTime.Parse(DataGridView1.Rows(row).Cells(0).Value.ToString).ToShortDateString

            Form4.TextBox1.Text = DataGridView1.Rows(row).Cells(8).Value.ToString

            Form4.TextBox4.Text = DataGridView1.Rows(row).Cells(9).Value.ToString
            Form4.TextBox8.Text = DataGridView1.Rows(row).Cells(7).Value.ToString

            Form4.headerid = DataGridView1.Rows(row).Cells(10).Value.ToString


            Form4.TextBox2.Text = DataGridView1.Rows(row).Cells(13).Value.ToString
            Form4.TextBox3.Text = DataGridView1.Rows(row).Cells(14).Value.ToString

            Form4.rowToEdit = row
            Form4.Show()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Form3_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        displa()
    End Sub
End Class