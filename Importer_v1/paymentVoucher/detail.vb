Public Class detail

    Public series As String = ""
    Private Sub detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Private Sub display()
        DataGridView1.DataSource = q.fetchdetails123(series)

        With DataGridView1
            .Columns(0).HeaderText = "Type"
            .Columns(1).HeaderText = "Date"
            .Columns(2).HeaderText = "Particulars/Memo"
            .Columns(3).HeaderText = "Reference No."
            .Columns(4).HeaderText = "Amount"
            .Columns(4).DefaultCellStyle.Format = "₱ #,0.00"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
    End Sub

    Private Sub detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class