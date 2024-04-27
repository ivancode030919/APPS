Public Class Listofbills
    Private Sub Listofbills_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Private Sub display()
        dgv.DataSource = q.FetchDataRef(TextBox1.Text, DateTimePicker1.Value, DateTimePicker2.Value)

        With dgv

            .Columns(0).HeaderText = "Type"
            .Columns(1).HeaderText = "Reference"
            .Columns(2).HeaderText = "Date"
            .Columns(3).HeaderText = "Check No."
            .Columns(4).HeaderText = "Check Date"
            .Columns(5).HeaderText = "Memo"

            .Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)

        End With

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        display()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        display()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick

        Dim row As Integer = dgv.CurrentCell.RowIndex

        With listdetail
            .ref = dgv.Rows(row).Cells(1).Value
            .Show()
        End With

    End Sub
End Class