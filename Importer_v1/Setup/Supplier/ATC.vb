Public Class ATC
    Private Sub ATC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub


    Private Sub display()

        DataGridView1.DataSource = q.displayATC(TextBox1.Text)

        With DataGridView1
            .Columns(0).HeaderText = "ATC"
            .Columns(1).HeaderText = "Description"
            .Columns(2).HeaderText = "Tax Rate"
        End With
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = DataGridView1.Rows(index)

        With addSupplier
            .TextBox6.Text = selectedrow.Cells(0).Value.ToString
            .TextBox7.Text = selectedrow.Cells(1).Value.ToString
            .TextBox1.Text = selectedrow.Cells(2).Value * 100
        End With
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub
End Class