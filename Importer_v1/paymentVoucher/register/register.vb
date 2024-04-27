Public Class register
    Private Sub register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub


    Public Sub display()
        dgv.DataSource = q.fetchvoucherregister(TextBox4.Text, DateTimePicker1.Value, DateTimePicker2.Value, ComboBox1.Text)

        With dgv
            .Columns(0).HeaderText = "Date"
            .Columns(1).HeaderText = "PV No."
            .Columns(2).HeaderText = "Vendor"
            .Columns(3).HeaderText = "Encoder"
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False
            .Columns(10).Visible = False
            .Columns(12).Visible = False
            .Columns(11).HeaderText = "Status"
            .Columns(0).Width = 100
            .Columns(1).Width = 150
            .Columns(2).Width = 300
            .Columns(3).Width = 200


            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        display()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        display()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick

        Dim row As Integer = dgv.CurrentCell.RowIndex
        Try
            With PVDetail
                .DateTimePicker1.Value = dgv.Rows(row).Cells(0).Value
                .TextBox2.Text = dgv.Rows(row).Cells(1).Value
                .TextBox4.Text = dgv.Rows(row).Cells(2).Value
                .TextBox1.Text = dgv.Rows(row).Cells(4).Value
                .DateTimePicker2.Value = dgv.Rows(row).Cells(5).Value
                .TextBox8.Text = dgv.Rows(row).Cells(6).Value
                .TextBox3.Text = dgv.Rows(row).Cells(7).Value
                .ComboBox1.Text = dgv.Rows(row).Cells(8).Value
                .ComboBox2.Text = dgv.Rows(row).Cells(9).Value
                .headerid = dgv.Rows(row).Cells(10).Value
                .TextBox5.Text = dgv.Rows(row).Cells(12).Value
                .Show()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        display()
    End Sub

    Private Sub register_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        display()
    End Sub
End Class