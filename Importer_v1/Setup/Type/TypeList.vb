﻿Public Class TypeList
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Type.Show()
    End Sub

    Private Sub TypeList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Public Sub display()
        DataGridView1.DataSource = q.displayType(TextBox1.Text)

        With DataGridView1
            .Columns(0).HeaderText = "ID"
            .Columns(1).HeaderText = "Type"

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(0).Width = 100
            .Columns(1).Width = 230
            .ColumnHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)

        End With
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub
End Class