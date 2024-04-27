Public Class Form6

    Public sup As String = ""
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()

    End Sub


    Public Sub display()

        dgv1.DataSource = q.fetchAllData(txt2.Text, ComboBox1.Text, sup, txt3.Text, txt4.Text)
        With dgv1
            .ColumnHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)

            .Columns(7).DefaultCellStyle.Format = "₱ #,0.00"
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        End With
        With dgv2
            .Columns.Add("0", "Type")

            Dim columnIndex As Integer = .Columns.Add("1", "Date")

            ' Set the format for the specific column by its index
            .Columns(columnIndex).DefaultCellStyle.Format = "yyyy-MM-dd"
            .Columns.Add("2", "Num")
            .Columns.Add("3", "Name")
            .Columns.Add("4", "Memo")
            .Columns.Add("5", "Account")
            .Columns.Add("6", "Split")
            .Columns.Add("7", "Amount")

            .Columns(7).DefaultCellStyle.Format = "₱ #,0.00"
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

            .ColumnHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)

            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False


        End With

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        dgv2.Rows.Clear()
        dgv2.Columns.Clear()
        display()

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        dgv2.Rows.Clear()
        dgv2.Columns.Clear()
        display()
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then

            ComboBox1.Text = ""
            ComboBox1.DataSource = Nothing
            RadioButton2.Checked = False
            ComboBox1.Text = ""
            ComboBox1.Enabled = False
            dgv2.Rows.Clear()
            dgv2.Columns.Clear()
        End If

    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            ComboBox1.DataSource = q.FetchType
            RadioButton1.Checked = False
            ComboBox1.Enabled = True
            dgv2.Rows.Clear()
            dgv2.Columns.Clear()
        End If

    End Sub




    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged

        If RadioButton3.Checked = True Then
            ComboBox2.DataSource = q.fetchName
            RadioButton4.Checked = False
            ComboBox2.Enabled = True
            dgv2.Rows.Clear()
            dgv2.Columns.Clear()
        End If

    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            ComboBox2.Text = ""
            ComboBox2.DataSource = Nothing
            RadioButton3.Checked = False
            ComboBox2.Text = ""
            ComboBox2.Enabled = False
            dgv2.Rows.Clear()
            dgv2.Columns.Clear()
        End If

    End Sub

    Private Sub txt2_TextChanged(sender As Object, e As EventArgs) Handles txt2.TextChanged
        display()
    End Sub

    Private Sub txt3_TextChanged(sender As Object, e As EventArgs) Handles txt3.TextChanged
        display()
    End Sub

    Private Sub txt4_TextChanged(sender As Object, e As EventArgs) Handles txt4.TextChanged
        display()
    End Sub

    Private Sub dgv1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellDoubleClick

        'Dim index As Integer
        'index = e.RowIndex
        'Dim selectedrow As DataGridViewRow
        'selectedrow = dgv1.Rows(index)

        With dgv2

            .Columns(0).Visible = True
            .Columns(1).Visible = True
            .Columns(2).Visible = True
            .Columns(3).Visible = True
            .Columns(4).Visible = True
            .Columns(5).Visible = True
            .Columns(6).Visible = True
            .Columns(7).Visible = True

            .ColumnHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)
        End With


        For Each selectedRow As DataGridViewRow In dgv1.SelectedRows
            ' Clone the selected row and add it to the destination DataGridView
            Dim newRow As DataGridViewRow = CType(selectedRow.Clone(), DataGridViewRow)
            For i As Integer = 0 To selectedRow.Cells.Count - 1
                newRow.Cells(i).Value = selectedRow.Cells(i).Value
            Next
            dgv2.Rows.Add(newRow)
        Next


    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'For Each row As DataGridViewRow In dgv2.Rows
        '    ' Check if the row is not a header row
        '    If Not row.IsNewRow Then
        '        ' Clone the row and add it to the destination DataGridView
        '        Dim newRow As DataGridViewRow = CType(row.Clone(), DataGridViewRow)
        '        For i As Integer = 0 To row.Cells.Count - 1
        '            newRow.Cells(i).Value = row.Cells(i).Value
        '        Next
        '        dataGridView2.Rows.Add(newRow)
        '    End If
        'Next

        Dim columnsToCopy() As Integer = {0, 1, 2, 3, 4, 5, 6, 7}

        For Each row As DataGridViewRow In dgv2.Rows
            ' Check if the row is not a header row
            If Not row.IsNewRow Then
                ' Create a new row for the destination DataGridView
                Dim newRow As DataGridViewRow = CType(row.Clone(), DataGridViewRow)

                ' Copy specific columns to the new row
                For Each columnIndex As Integer In columnsToCopy
                    newRow.Cells(columnIndex).Value = row.Cells(columnIndex).Value
                Next

                ' Add the new row to the destination DataGridView
                Form7.dgv3.Rows.Add(newRow)
            End If
        Next

        ' Close the form after copying all the rows
        Me.Close()

        dgv2.Rows.Clear()
        dgv2.Columns.Clear()
        Form7.displaytotal()
        Form7.calcu()

    End Sub

    Private Sub Form6_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class