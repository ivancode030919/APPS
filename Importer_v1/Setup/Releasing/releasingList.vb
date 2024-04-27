Public Class releasingList
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        releasing.ShowDialog()
    End Sub

    Private Sub releasingList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub


    Public Sub display()
        dgv.DataSource = q.displayMode(TextBox1.Text)
        With dgv
            .Columns(0).HeaderText = "ID"
            .Columns(1).HeaderText = "Mode Of Releasing"

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(0).Width = 100
            .Columns(1).Width = 230

        End With
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font(dgv.Font, FontStyle.Bold)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub
End Class