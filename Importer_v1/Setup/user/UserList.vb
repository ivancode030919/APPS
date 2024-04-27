Public Class UserList
    Private Sub UserList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        With User
            .Type = "Add"
        End With
        User.ShowDialog()
    End Sub



    Public Sub display()

        DataGridView1.DataSource = q.displayuser(TextBox1.Text)

        With DataGridView1

            .Columns(0).HeaderText = "ID"
            .Columns(1).HeaderText = "Name"

            .Columns(0).Width = 100
            .Columns(1).Width = 230

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .ColumnHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)

            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Visible = False

        End With
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = DataGridView1.Rows(index)

            With User

                .Type = "Update"
                .id = selectedrow.Cells(0).Value
                .TextBox1.Text = selectedrow.Cells(1).Value
                .TextBox2.Text = selectedrow.Cells(2).Value
                .TextBox3.Text = selectedrow.Cells(3).Value

                .Status = selectedrow.Cells(4).Value

                .dfalt = selectedrow.Cells(5).Value

                .Text = "Update"
                .SimpleButton1.Text = "Save"
            End With

            User.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
End Class