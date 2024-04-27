Public Class listdetail

    Public ref As String = ""
    Private Sub listdetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub


    Private Sub display()
        dgv.DataSource = q.FetchDataRefDetails(ref)

        With dgv
            .Columns(6).DefaultCellStyle.Format = "₱ #,0.00"
            .Columns(0).HeaderText = "Type"
            .Columns(1).HeaderText = "Reference"
            .Columns(2).HeaderText = "PRF No."
            .Columns(3).HeaderText = "PRF Date"
            .Columns(4).HeaderText = "PV No."
            .Columns(5).HeaderText = "PV Date"
            .Columns(6).HeaderText = "Amount"
            .Columns(7).HeaderText = "Mode of Releasing"

            .Columns(8).HeaderText = "Confirm Date"
            .Columns(8).DefaultCellStyle.Format = "yyyy-MM-dd"
            .Columns(9).HeaderText = "Remarks"

            .ColumnHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)
        End With

        For Each col As DataGridViewColumn In dgv.Columns
            col.HeaderCell.Style.Font = New Font("Tahoma", 8.25, FontStyle.Bold)
            col.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Next


    End Sub

End Class