Public Class Form8
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        With addSupplier
            addSupplier.Text = "Add"
            addSupplier.SimpleButton2.Text = "Record"
        End With
        addSupplier.ShowDialog()
    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Public Sub display()

        DataGridView1.DataSource = q.displaySup(TextEdit3.Text)
        DataGridView1.Columns(0).HeaderText = "ID"
        DataGridView1.Columns(1).HeaderText = "Supplier"
        DataGridView1.Columns(2).HeaderText = "Address"
        DataGridView1.Columns(3).HeaderText = "ZIP Code"
        DataGridView1.Columns(4).HeaderText = "TIN"
        DataGridView1.Columns(5).HeaderText = "Terms"
        DataGridView1.Columns(6).HeaderText = "Wtax Rate"
        DataGridView1.Columns(7).HeaderText = "ATC"
        DataGridView1.Columns(8).HeaderText = "ATC Description"
        DataGridView1.Columns(13).HeaderText = "Vat"

        With DataGridView1
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            For Each col As DataGridViewColumn In DataGridView1.Columns
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            .Columns(0).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False
            .Columns(10).Visible = False
            .Columns(11).Visible = False
            .Columns(12).Visible = False
        End With
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView1.Font, FontStyle.Bold)
    End Sub

    Private Sub TextEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit3.EditValueChanged
        display()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        With addSupplier
            addSupplier.Text = "Update"
            addSupplier.SimpleButton2.Text = "Save"
        End With

        addSupplier.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = DataGridView1.Rows(index)

            With addSupplier
                .vatstat = selectedrow.Cells(13).Value
                .TextBox2.Text = selectedrow.Cells(1).Value
                .TextBox4.Text = selectedrow.Cells(2).Value
                .TextBox8.Text = selectedrow.Cells(3).Value
                .TextBox3.Text = selectedrow.Cells(5).Value
                .TextBox1.Text = selectedrow.Cells(6).Value
                .TextBox5.Text = selectedrow.Cells(9).Value
                .TextBox9.Text = selectedrow.Cells(10).Value
                .TextBox10.Text = selectedrow.Cells(11).Value
                .TextBox11.Text = selectedrow.Cells(12).Value
                .TextBox6.Text = selectedrow.Cells(7).Value
                .TextBox7.Text = selectedrow.Cells(8).Value
                .id = selectedrow.Cells(0).Value.ToString
                addSupplier.Text = "Update"
                addSupplier.SimpleButton2.Text = "Save"
            End With

            addSupplier.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = DataGridView1.Rows(index)

            With addSupplier
                .vatstat = selectedrow.Cells(13).Value
                .TextBox2.Text = selectedrow.Cells(1).Value
                .TextBox4.Text = selectedrow.Cells(2).Value
                .TextBox8.Text = selectedrow.Cells(3).Value
                .TextBox3.Text = selectedrow.Cells(5).Value
                .TextBox1.Text = selectedrow.Cells(6).Value
                .TextBox5.Text = selectedrow.Cells(9).Value
                .TextBox9.Text = selectedrow.Cells(10).Value
                .TextBox10.Text = selectedrow.Cells(11).Value
                .TextBox11.Text = selectedrow.Cells(12).Value
                .TextBox6.Text = selectedrow.Cells(7).Value
                .TextBox7.Text = selectedrow.Cells(8).Value
                .id = selectedrow.Cells(0).Value.ToString
                addSupplier.Text = "Update"
                addSupplier.SimpleButton2.Text = "Save"
            End With

        Catch ex As Exception

        End Try
    End Sub
End Class