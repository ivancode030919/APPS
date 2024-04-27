Public Class TermsList
    Private Sub TermsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Public Sub display()
        DataGridView1.DataSource = q.displayTerms(TextBox1.Text)
        With DataGridView1
            .Columns(0).HeaderText = "ID"
            .Columns(1).HeaderText = "Terms"

            .Columns(0).Width = 100
            .Columns(1).Width = 230
            .ColumnHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Terms.ShowDialog()
    End Sub
End Class