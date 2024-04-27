Imports Microsoft.Reporting.WinForms
Public Class Form4
    Private f As New qry
    Public headerid As Integer
    Public rowToEdit As Integer


    Private tax As Double

    Private h As Double
    Private h1 As Double

    Private totalwtax As Double
    Private totasum1 As Double
    Private ttax As Decimal


    Private billvat As Decimal
    Private billvat1 As Decimal

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If q.fetchPRfStat(headerid) = "Cancelled" Then
            SimpleButton1.Visible = False
        Else
            SimpleButton1.Visible = True
        End If
        display()

        TextBox5.Text = "0.00"
        TextBox6.Text = "0.00"
        TextBox7.Text = "0.00"
        Label11.Text = "WTax Rate % :"

        displaytotal()
        calcu()
    End Sub


    Public Sub display()
        f.HeaderID(headerid)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
    Public Sub calcu()

        Dim f1 As Decimal = q.fetchData2(TextEdit3.Text) * 100
        'TextBox6.Text = f1.ToString + "%"
        tax = f1

        Label11.Text = "WTax Rate " + f1.ToString + "% :"

        'Dim f2 As Double = Double.Parse(TextBox5.Text) - (Double.Parse(TextBox5.Text) * (f1))
        Dim f3 As Double = (Double.Parse(totasum1) * f1)
        Dim f2 As Double = DataGridView1.Rows(0).Cells(6).Value
        Dim rtw As String = f2.ToString("N2")

        TextBox6.Text = rtw
        TextEdit6.Text = q.fetchData1(TextEdit3.Text)

        Dim sads2 As Decimal = DataGridView1.Rows(0).Cells(6).Value

        ttax = sads2 * -1


        If TextBox5.Text = "0.00" Then
            TextBox7.Text = "0.00"
        Else
            TextBox7.Text = (Double.Parse(TextBox5.Text)) + (Double.Parse(TextBox6.Text))
        End If

    End Sub


    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click

        Form5.ReportViewer1.RefreshReport()
        Dim Payor As String = TextEdit2.Text
        Dim Payto As String = TextEdit3.Text
        Dim Type As String = TextEdit1.Text
        Dim series As String = TextEdit4.Text

        Dim Terms As String = TextEdit6.Text
        Dim Bank As String = TextEdit5.Text

        Dim totalamount As String = TextBox5.Text
        Dim date1 As String = TextEdit7.Text
        Dim remarks As String = TextBox1.Text
        Dim user1 As String = Form1.name1
        Dim diff As String = TextBox6.Text
        Dim tax1 As String = tax
        Dim due As String = TextBox7.Text


        Dim checkby As String = TextBox2.Text
        Dim apprv As String = TextBox3.Text

        '===============================================
        Dim amount As String = billvat.ToString("N2")
        Dim amount1 As String = billvat1.ToString("N2")

        Dim wtax As String = ttax.ToString("N2")
        '===============================================

        Dim currentDate As Date = Date.Today
        Dim datatable1 As DataTable
        Dim dataset As New DataSet("Dataset")



        datatable1 = New DataTable("Mydatatable")
        datatable1.Columns.Add("Date")
        datatable1.Columns.Add("Ref")
        datatable1.Columns.Add("PaymentRelatedTo")
        datatable1.Columns.Add("Amount")
        datatable1.Columns.Add("Accnt")
        datatable1.Columns.Add("vat1")

        dataset.Tables.Add(datatable1)
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                Dim datarow2 As DataRow = datatable1.NewRow
                datarow2("Date") = DateTime.Parse(row.Cells(0).Value.ToString).ToShortDateString()
                datarow2("Ref") = row.Cells(1).Value.ToString
                datarow2("PaymentRelatedTo") = row.Cells(2).Value.ToString

                Dim amount12 As Decimal = row.Cells(3).Value.ToString
                Dim amount2 As String = amount12.ToString("N2")
                datarow2("Amount") = amount2


                datarow2("Accnt") = row.Cells(5).Value.ToString()

                Dim vat1Sum As Decimal = row.Cells(9).Value
                Dim amount234 As String = vat1Sum.ToString("N2")
                datarow2("vat1") = amount234
                datatable1.Rows.Add(datarow2)
            End If
        Next

        Dim path As String = q.path
        Dim reportDataSource As New ReportDataSource("DataSet1", datatable1)
        Form5.ReportViewer1.LocalReport.DataSources.Clear()
        Form5.ReportViewer1.LocalReport.DataSources.Add(reportDataSource)

        If q.fetchPRfStat(headerid) = "Cancelled" Then

            Form5.ReportViewer1.LocalReport.ReportPath = path + "\vReport6_2.rdlc"
        Else
            If q.fetchPrintStat(TextEdit4.Text) = 0 Then
                Form5.ReportViewer1.LocalReport.ReportPath = path + "\Report6.rdlc"
            ElseIf q.fetchPrintStat(TextEdit4.Text) = 1 Then
                Form5.ReportViewer1.LocalReport.ReportPath = path + "\vReport6.rdlc"

            End If

        End If


        Dim par As New ReportParameter("Payor", Payor)
        Form5.ReportViewer1.LocalReport.SetParameters(par)

        Dim par1 As New ReportParameter("Payto", Payto)
        Form5.ReportViewer1.LocalReport.SetParameters(par1)

        Dim par2 As New ReportParameter("Type", Type)
        Form5.ReportViewer1.LocalReport.SetParameters(par2)

        Dim par3 As New ReportParameter("series", series)
        Form5.ReportViewer1.LocalReport.SetParameters(par3)

        Dim par4 As New ReportParameter("Terms", Terms)
        Form5.ReportViewer1.LocalReport.SetParameters(par4)

        Dim par5 As New ReportParameter("Bank", Bank)
        Form5.ReportViewer1.LocalReport.SetParameters(par5)


        Dim par7 As New ReportParameter("totalamount", totalamount)
        Form5.ReportViewer1.LocalReport.SetParameters(par7)

        Dim par8 As New ReportParameter("date", date1)
        Form5.ReportViewer1.LocalReport.SetParameters(par8)

        Dim par9 As New ReportParameter("remarks", remarks)
        Form5.ReportViewer1.LocalReport.SetParameters(par9)


        Dim par10 As New ReportParameter("user", user1)
        Form5.ReportViewer1.LocalReport.SetParameters(par10)

        Dim par11 As New ReportParameter("rate", tax1)
        Form5.ReportViewer1.LocalReport.SetParameters(par11)

        Dim par12 As New ReportParameter("diff", diff)
        Form5.ReportViewer1.LocalReport.SetParameters(par12)

        Dim par13 As New ReportParameter("due", due)
        Form5.ReportViewer1.LocalReport.SetParameters(par13)



        Dim par16 As New ReportParameter("checkby", checkby)
        Form5.ReportViewer1.LocalReport.SetParameters(par16)

        Dim par17 As New ReportParameter("apprv", apprv)
        Form5.ReportViewer1.LocalReport.SetParameters(par17)

        Dim p1 As New ReportParameter("woutvat", amount)
        Form5.ReportViewer1.LocalReport.SetParameters(p1)

        Dim p2 As New ReportParameter("vat", amount1)
        Form5.ReportViewer1.LocalReport.SetParameters(p2)

        Dim p3 As New ReportParameter("wtax", wtax)
        Form5.ReportViewer1.LocalReport.SetParameters(p3)

        Form5.sesries = TextEdit4.Text
        Form5.WhatForm = 1
        Form5.ReportViewer1.RefreshReport()
        Form5.ShowDialog()


    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        ' Check if the event is for the "Amount" column (column index 7)
        If e.ColumnIndex = 3 AndAlso e.Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(e.Value.ToString()) Then
            ' Attempt to convert the value to decimal and format it
            Dim stringValue As String = e.Value.ToString()

            If IsNumeric(stringValue) Then
                Try
                    Dim numericValue As Decimal = Convert.ToDecimal(stringValue)
                    e.Value = "₱ " + String.Format("{0:n2}", numericValue)
                    e.FormattingApplied = True
                Catch ex As FormatException
                    ' Handle the FormatException gracefully (e.g., log it, display an error message)

                End Try
            Else
                ' Handle the case where the value is not numeric (e.g., display an error message)

            End If
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Try
            Dim inputValue As Double = TextBox6.Text
            Dim formattedValue As String = inputValue.ToString("N2")

            TextBox6.Text = formattedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        Try
            Dim inputValue As Double = TextBox7.Text
            Dim formattedValue As String = inputValue.ToString("N2")

            TextBox7.Text = formattedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

        Try
            Dim inputValue As Double = TextBox5.Text
            Dim formattedValue As String = inputValue.ToString("N2")

            TextBox5.Text = formattedValue
        Catch ex As Exception

        End Try

    End Sub

    Public Sub displaytotal()
        Dim totalSum As Decimal = 0

        Dim bill1 As Decimal = 0
        Dim cm1 As Decimal = 0

        For Each row As DataGridViewRow In DataGridView1.Rows

            '' Parse the cell value to Decimal and add it to the total sum
            'If row.Cells(0).Value = "Bill" Then

            'End If
            If row.Cells(4).Value = "Bill" Then
                bill1 += Convert.ToDecimal(row.Cells(3).Value)

            ElseIf row.Cells(4).Value = "Credit" Then
                cm1 += Convert.ToDecimal(row.Cells(3).Value)
            End If

            totalSum += Convert.ToDecimal(row.Cells(3).Value)
            totasum1 = totalSum
        Next

        h = bill1
        h1 = cm1

        totalwtax = h + h1
        TextBox5.Text = totalSum

        Dim Vatable As Decimal
        Dim NonVatable As Decimal
        Dim bvat As Decimal
        Dim bvat1 As Decimal

        If q.checkvatble1(TextEdit3.Text, TextEdit4.Text) = "Vatable" Then
            Vatable = h + h1
            totalwtax = Vatable / 1.12

            'to calculate vat
            bvat1 = totalSum / 1.12
            Dim amount As String = bvat1.ToString("N2")
            'Bill, Net of Vat
            billvat = amount

            bvat = bvat1 * 0.12
            Dim amount1 As String = bvat.ToString("N2")
            billvat1 = amount1

        ElseIf q.checkvatble1(TextEdit3.Text, TextEdit4.Text) = "Non-Vatable" Then

            NonVatable = h + h1
            totalwtax = NonVatable

            billvat = NonVatable
            billvat1 = "0"

        End If

        'display total due
        'TextBox7.Text = totalwtax





    End Sub

    Private Sub DataGridView1_Validated(sender As Object, e As EventArgs) Handles DataGridView1.Validated
        displaytotal()
    End Sub

    Private Sub DataGridView1_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.UserAddedRow
        displaytotal()
    End Sub

    Private Sub DataGridView1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridView1.Validating
        displaytotal()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure to cancel this Transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If result = DialogResult.Yes Then
            q.updatePrfStat(headerid)
            MessageBox.Show("Successfully Cancelled...", "Notification", MessageBoxButtons.OK)
            SimpleButton1.Visible = False
            Form3.displa()
        Else
        End If

    End Sub

    Private Sub Form4_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub PanelControl1_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl1.Paint

    End Sub
End Class