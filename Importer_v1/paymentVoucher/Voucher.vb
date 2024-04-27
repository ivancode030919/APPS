Public Class Voucher
    Private f As New qry
    Public payee As String = ""
    Private Sub Voucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Public Sub display()
        dgv3.DataSource = q.displayvoucher(payee, DateTimePicker1.Value, DateTimePicker2.Value, TextBox1.Text)

        With dgv3
            .Columns(0).HeaderText = "Date"
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).HeaderText = "PV No."
            .Columns(2).HeaderText = "Bank"
            .Columns(3).HeaderText = "Check No."
            .Columns(3).Visible = False
            .Columns(4).HeaderText = "Amount"
            .Columns(4).DefaultCellStyle.Format = "₱ #,0.00"
            .Columns(5).HeaderText = "headerid"
            .Columns(5).Visible = False

            .Columns(6).HeaderText = "date check"
            .Columns(6).Visible = False

            .Columns(7).HeaderText = "mode releasing"
            .Columns(7).Visible = False

            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

    End Sub

    Private Sub Voucher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        closing123()
    End Sub


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        '' Your existing code to get checked row indices
        'Dim checkedRowsData As New List(Of String)

        ''For Each row As DataGridViewRow In dgv3.Rows
        ''    If Convert.ToBoolean(row.Cells("CheckBoxColumn").Value) Then
        ''        ' The checkbox in this row is checked
        ''        Dim rowData As String = $"{row.Cells(1).Value}, {row.Cells(2).Value}, {row.Cells(3).Value}, {row.Cells(4).Value}, {row.Cells(5).Value},{row.Cells(6).Value}"
        ''        checkedRowsData.Add(rowData)
        ''    End If
        ''Next

        'For Each row As DataGridViewRow In dgv3.Rows
        '    If Convert.ToBoolean(row.Cells("CheckBoxColumn").Value) Then
        '        ' The checkbox in this row is checked
        '        ' Extract date only from row.Cells(1).Value
        '        Dim dateOnly As Date = DirectCast(row.Cells(1).Value, Date).Date
        '        Dim rowData As String = $"{dateOnly.ToShortDateString()}, {row.Cells(2).Value}, {row.Cells(3).Value}, {row.Cells(4).Value}, {row.Cells(5).Value}, {row.Cells(6).Value}"
        '        checkedRowsData.Add(rowData)


        '    End If
        'Next

        'If checkedRowsData.Count > 0 Then
        '    ' Assuming voucher1 is an instance of Voucher1

        '    Voucher1.AddRowsFromForm1(checkedRowsData)
        '    Me.Close()

        'Else
        '    MessageBox.Show("No rows are checked.")
        'End If

        'Voucher1.prfno()
        'closing123()

    End Sub


    Private Sub closing123()
        dgv3.DataSource = Nothing
        dgv3.Rows.Clear()
        dgv3.Columns.Clear()
        TextBox1.Text = ""
    End Sub

    Private Sub dgv3_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv3.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgv3.Rows(index)

            Voucher1.headeerid = selectedrow.Cells(5).Value

            Voucher1.profno = selectedrow.Cells(1).Value
            Voucher1.TextBox8.Text = selectedrow.Cells(3).Value
            Voucher1.TextBox1.Text = selectedrow.Cells(7).Value
            Voucher1.DateTimePicker2.Value = selectedrow.Cells(6).Value
            Voucher1.displaytotal()
            Voucher1.display()
            f.CheckSeries1()
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        display()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        display()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub

    Private Sub Voucher_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class