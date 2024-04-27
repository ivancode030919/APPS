Imports System.Text
Imports Microsoft.Reporting.WinForms
Public Class Voucher1
    Public rowToEdit As Integer
    Public headeerid As Integer
    Private Totalamount As Double
    Public memo3 As String = ""

    Private quarter As Integer
    Private qrterdate1 As String = ""
    Private qrterdate2 As String = ""

    Private prt3qtramount As String = ""
    Private amount2 As Double

    Private tin11 As String = ""
    Private tin22 As String = ""
    Private tin33 As String = ""
    Private tin44 As String = ""
    Public profno As String = ""
    Private zipcode1 As String = ""


    Private Sub Voucher1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
        sugest()
        checkby()
    End Sub

    Private Sub checkby()

        ComboBox1.DataSource = q.fetchuser
        ComboBox2.DataSource = q.fetchuser1

    End Sub


    Private Sub dgv3_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)

    End Sub
    Public Sub displaytotal()
        Dim totalSum As Decimal = 0
        For Each row As DataGridViewRow In dgv3.Rows
            ' Check if the cell value is not null or empty
            'If Not IsDBNull(row.Cells(7).Value) AndAlso Not String.IsNullOrEmpty(row.Cells(7).Value.ToString()) Then
            ' Parse the cell value to Decimal and add it to the total sum
            totalSum += Convert.ToDecimal(row.Cells(4).Value)
            'End If
        Next


        Totalamount = totalSum
    End Sub
    Public Sub display()
        With dgv3
            .DataSource = q.displayvoucher1(headeerid)


            .Columns(0).HeaderText = "PRF Date"
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(1).HeaderText = "PRF No."
            .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(2).HeaderText = "Bank"
            .Columns(3).HeaderText = "Check No."
            .Columns(4).HeaderText = "Amount"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            ' Set the custom format for the "Amount" column to display only the peso sign
            .Columns(4).DefaultCellStyle.Format = "₱ #,0.00"

            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(3).Visible = False

            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True



            For Each col As DataGridViewColumn In dgv3.Columns
                col.HeaderCell.Style.Font = New Font("Tahoma", 8.25, FontStyle.Bold)
            Next





            .Refresh()
        End With




        'for suggestive in textbox
        '-------------------------------------------------------
        'ComboBox2.DataSource = q.FetchType
        'ComboBox1.DataSource = q.FetchPayto

        ' Assuming q.FetchPay returns a collection of strings

        '-------------------------------------------------------


    End Sub




    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If TextBox4.Text = String.Empty Then
            MessageBox.Show("Select Payee First...", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Voucher.payee = TextBox4.Text
            Voucher.ShowDialog()
        End If

    End Sub

    Public Sub AddRowsFromForm1(data As List(Of String))
        ' Assuming dgv3 is the DataGridView on Voucher1
        For Each rowData As String In data
            Dim rowValues As String() = rowData.Split(", ") ' Split the string into individual values
            dgv3.Rows.Add(rowValues)
        Next
    End Sub
    Public Sub prfno()

        Dim concatenatedText As New StringBuilder()

        For Each row As DataGridViewRow In dgv3.Rows
            ' Check if the cell is not null before appending to the StringBuilder
            If row.Cells(1).Value IsNot Nothing Then
                concatenatedText.Append(row.Cells(1).Value.ToString())
                concatenatedText.Append(", ") ' Add a separator if needed
            End If
        Next

        ' Remove the trailing separator if it exists
        If concatenatedText.Length > 0 Then
            concatenatedText.Length -= 2
        End If

        'TextBox1.Text = concatenatedText.ToString()
        TextBox8.Text = dgv3.Rows(0).Cells(3).Value.ToString
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

        If SimpleButton2.Text = "Record" Then
            If TextBox8.Text = String.Empty Then
                MessageBox.Show("Invalid Check Number...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim committedRowCount As Integer = 0
                For Each row As DataGridViewRow In dgv3.Rows
                    If Not row.IsNewRow Then
                        committedRowCount += 1
                    End If
                Next

                If committedRowCount = 0 Then
                    MessageBox.Show("Please Select Request...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else

                    Dim Status As String = "Recorded"
                    Dim Status1 As String = "0"

                    q.Savevoucher(TextBox4.Text, profno, TextBox2.Text, DateTimePicker1.Value, DateTimePicker2.Value, TextBox8.Text, TextBox3.Text, ComboBox1.Text, ComboBox2.Text, Status, TextBox1.Text)
                    q.UpdatePRStatus(profno)

                    For Each row As DataGridViewRow In dgv3.Rows
                        If Not row.IsNewRow Then
                            Dim prfdate As String = row.Cells(0).Value.ToString
                            Dim prfno As String = row.Cells(1).Value.ToString
                            Dim bank As String = row.Cells(2).Value.ToString
                            Dim checkno As String = TextBox8.Text
                            Dim amount As String = row.Cells(4).Value
                            Dim tax As String = row.Cells(6).Value
                            Dim acct As String = row.Cells(5).Value.ToString
                            Dim TransHeaderID As Integer = q.fetchhID1
                            q.Savevoucher(prfdate, prfno, bank, checkno, Double.Parse(amount), tax, acct, TransHeaderID)
                        End If
                    Next
                    MessageBox.Show("Successfully Recorded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SimpleButton3.Visible = True


                    If q.display2307(TextBox4.Text) = 1 Then
                        SimpleButton3.Enabled = True
                        SimpleButton4.Enabled = True
                        SimpleButton2.Text = "New Entry"
                    ElseIf q.display2307(TextBox4.Text) = 0 Then
                        SimpleButton3.Enabled = True
                        SimpleButton4.Enabled = False
                        SimpleButton2.Text = "New Entry"
                    End If
                End If

                disable()
            End If

        ElseIf SimpleButton2.Text = "New Entry" Then
            TextBox8.Text = String.Empty
            TextBox3.Text = String.Empty
            profno = String.Empty
            TextBox2.Text = String.Empty
            TextBox4.Text = String.Empty
            DateTimePicker1.Value = Now
            SimpleButton3.Enabled = False
            SimpleButton4.Enabled = False
            SimpleButton2.Text = "Record"
            dgv3.DataSource = Nothing
            dgv3.Rows.Clear()
            disable()
        End If

    End Sub


    Private Sub disable()
        If SimpleButton2.Text = "Record" Then
            TextBox4.Enabled = True
            SimpleButton1.Enabled = True
            DateTimePicker2.Enabled = True
            TextBox8.Enabled = True
            TextBox3.Enabled = True
            ComboBox1.Enabled = True
            ComboBox2.Enabled = True
        ElseIf SimpleButton2.Text = "New Entry" Then
            TextBox4.Enabled = False
            SimpleButton1.Enabled = False
            DateTimePicker2.Enabled = False
            TextBox8.Enabled = False
            TextBox3.Enabled = False
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
        End If

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click

        q.DisplayResults(profno)
        displaytotal()
        Dim word As String = NumberToWordsWithCents(Totalamount)
        Dim totalSum As Double = 0.0
        Dim formattedTotalSum As String = totalSum.ToString("N2")
        Dim pvno As String = TextBox2.Text
        For Each row As DataGridViewRow In dgv3.Rows
            ' Check if the cell is not empty
            If Not row.Cells(4).Value Is Nothing Then
                ' Attempt to convert the cell value to a double
                Dim cellValue As Double
                If Double.TryParse(row.Cells(4).Value.ToString(), cellValue) Then
                    ' Add the value to the total sum
                    totalSum += cellValue
                End If
            End If
        Next

        Dim bank As String = dgv3.Rows(0).Cells(2).Value.ToString
        Dim amount As String = totalSum
        'Dim accnt As String = dgv3.Rows(0).Cells(5).Value.ToString

        Dim user1 As String = Form1.name1
        Dim check21 As String = ComboBox1.Text
        Dim apprv As String = ComboBox2.Text

        Dim tax1 As String = dgv3.Rows(0).Cells(6).Value * -1

        Dim payee As String = TextBox4.Text
        Dim chckno As String = TextBox8.Text
        Dim chckdate As String = DateTimePicker2.Value.ToShortDateString
        Dim prfno As String = dgv3.Rows(0).Cells(1).Value.ToString
        Dim memo As String = memo3
        Dim datatable1 As DataTable
        Dim dataset As New DataSet("Dataset")



        '"Invoice Date,Invoice No., Particulars,Amount"

        datatable1 = New DataTable("Mydatatable")
        datatable1.Columns.Add("Accnt")
        datatable1.Columns.Add("Amount")

        dataset.Tables.Add(datatable1)

        For Each row As DataGridViewRow In dgv3.Rows
            If Not row.IsNewRow Then
                Dim datarow2 As DataRow = datatable1.NewRow
                datarow2("Accnt") = row.Cells(5).Value.ToString
                datarow2("Amount") = String.Format("₱ {0:#,##0.00}", Convert.ToDecimal(row.Cells(4).Value))
                datatable1.Rows.Add(datarow2)
            End If
        Next
        Dim path As String = q.path
        Dim reportDataSource As New ReportDataSource("DataSet1", datatable1)
        Form5.ReportViewer1.LocalReport.DataSources.Clear()
        Form5.ReportViewer1.LocalReport.DataSources.Add(reportDataSource)
        Form5.ReportViewer1.LocalReport.ReportPath = path + "\voucher.rdlc"

        Dim par As New ReportParameter("bank", bank)
        Form5.ReportViewer1.LocalReport.SetParameters(par)

        Dim formattedAmount As String = String.Format("₱ {0:#,##0.00}", Convert.ToDecimal(amount))
        Dim par1 As New ReportParameter("amount1", formattedAmount)
        Form5.ReportViewer1.LocalReport.SetParameters(par1)


        Dim par2 As New ReportParameter("payee", payee)
        Form5.ReportViewer1.LocalReport.SetParameters(par2)

        Dim par3 As New ReportParameter("checkno", chckno)
        Form5.ReportViewer1.LocalReport.SetParameters(par3)

        Dim par4 As New ReportParameter("checkdate", chckdate)
        Form5.ReportViewer1.LocalReport.SetParameters(par4)

        Dim par5 As New ReportParameter("prfno", prfno)
        Form5.ReportViewer1.LocalReport.SetParameters(par5)

        Dim par6 As New ReportParameter("money1", word)
        Form5.ReportViewer1.LocalReport.SetParameters(par6)

        Dim par7 As New ReportParameter("memo", memo)
        Form5.ReportViewer1.LocalReport.SetParameters(par7)

        Dim par8 As New ReportParameter("user", user1)
        Form5.ReportViewer1.LocalReport.SetParameters(par8)

        Dim par9 As New ReportParameter("checkby", check21)
        Form5.ReportViewer1.LocalReport.SetParameters(par9)


        Dim par10 As New ReportParameter("Apprv", apprv)
        Form5.ReportViewer1.LocalReport.SetParameters(par10)

        Dim formattedAmount1 As String = String.Format("₱ {0:#,##0.00}", Convert.ToDecimal(tax1))
        Dim par11 As New ReportParameter("tax1", formattedAmount1)
        Form5.ReportViewer1.LocalReport.SetParameters(par11)

        Dim par12 As New ReportParameter("Series1", pvno)
        Form5.ReportViewer1.LocalReport.SetParameters(par12)

        'Dim par13 As New ReportParameter("due", due)
        'Form5.ReportViewer1.LocalReport.SetParameters(par13)

        'Dim par14 As New ReportParameter("mode", mode)
        'Form5.ReportViewer1.LocalReport.SetParameters(par14)

        'Dim par15 As New ReportParameter("checkno", checkno)
        'Form5.ReportViewer1.LocalReport.SetParameters(par15)

        Form5.ReportViewer1.RefreshReport()
        Form5.sesries = TextBox2.Text
        Form5.WhatForm = 2
        Form5.ShowDialog()
    End Sub

    Private Sub sugest()
        Dim payList As List(Of String) = q.FetchPayto()

        ' Set up the TextBox properties
        TextBox4.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextBox4.AutoCompleteSource = AutoCompleteSource.CustomSource

        ' Create an AutoCompleteStringCollection from the data source
        Dim suggestions As New AutoCompleteStringCollection()
        suggestions.AddRange(payList.ToArray())
        TextBox4.Text = ""
        ' Set the custom source for auto-complete suggestions
        TextBox4.AutoCompleteCustomSource = suggestions
    End Sub

    Function NumberToWordsWithCents(ByVal amount As Decimal) As String
        If amount = 0 Then
            Return "Zero Cents"
        End If

        Dim wholePart As Integer = Decimal.Truncate(amount)
        Dim fractionalPart As Integer = Decimal.ToInt32((amount - wholePart) * 100)

        Dim units() As String = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"}
        Dim teens() As String = {"", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
        Dim tens() As String = {"", "Ten ", "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety "}

        Dim result As String = ""

        ' Convert the whole part to words
        If (wholePart \ 1000000) > 0 Then
            result += NumberToWordsWithCents(wholePart \ 1000000) & " Million "
            wholePart = wholePart Mod 1000000
        End If

        If (wholePart \ 1000) > 0 Then
            result += NumberToWordsWithCents(wholePart \ 1000) & " Thousand "
            wholePart = wholePart Mod 1000
        End If

        If (wholePart \ 100) > 0 Then
            result += units(wholePart \ 100) & " Hundred "
            wholePart = wholePart Mod 100
        End If

        If wholePart > 0 Then
            If result <> "" Then
                result += "and "
            End If

            If wholePart < 10 Then
                result += units(wholePart)
            ElseIf wholePart < 20 Then
                result += teens(wholePart - 10)
            Else
                result += tens(wholePart \ 10)
                If (wholePart Mod 10) > 0 Then
                    result += units(wholePart Mod 10)
                End If
            End If
        End If

        ' Convert the fractional part to words
        If fractionalPart > 0 Then
            If result <> "" Then
                result += " and "
            End If

            If fractionalPart < 10 Then
                result += units(fractionalPart)
            ElseIf fractionalPart < 20 Then
                result += teens(fractionalPart - 10)
            Else
                result += tens(fractionalPart \ 10)
                If (fractionalPart Mod 10) > 0 Then
                    result += units(fractionalPart Mod 10)
                End If
            End If

            result += " Cents"
        End If

        Return result.Trim()
    End Function

    Private Sub dgv3_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv3.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgv3.Rows(index)

            With detail
                .series = selectedrow.Cells(1).Value.ToString
            End With

            detail.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Form5.ReportViewer1.RefreshReport()
        Form5.d = 1
        qdate()
        prtIII()
        fetchtin()


        Dim qtrdt1 As String = qrterdate1
        Dim qtrdt2 As String = qrterdate2
        Dim address As String = q.fetchadddress(TextBox4.Text)

        Dim tin1 As String = tin11
        Dim tin2 As String = tin22
        Dim tin3 As String = tin33
        Dim tin4 As String = tin44

        Dim atc As String = q.fetchatc(TextBox4.Text)
        Dim atcdes As String = q.fetchatcdes(TextBox4.Text)


        Dim zip As String = zipcode1
        Dim payee As String = TextBox4.Text

        Dim mqrt1 As Double
        Dim mqrt2 As Double
        Dim mqrt3 As Double



        Dim tax15 As Decimal = dgv3.Rows(0).Cells(6).Value * -1
        Dim tax As String = tax15.ToString("N2")


        If prt3qtramount = 1 Then
            For Each row As DataGridViewRow In dgv3.Rows
                mqrt1 += row.Cells(4).Value
            Next
            mqrt2 = 0
            mqrt3 = 0
        ElseIf prt3qtramount = 2 Then
            mqrt1 = 0
            For Each row As DataGridViewRow In dgv3.Rows
                mqrt2 += row.Cells(4).Value
            Next
            mqrt3 = 0
        ElseIf prt3qtramount = 3 Then
            mqrt1 = 0
            mqrt2 = 0
            For Each row As DataGridViewRow In dgv3.Rows
                mqrt3 += row.Cells(4).Value
            Next

        End If

        Dim amount As Decimal = mqrt1 + mqrt2 + mqrt3



        Dim datatable1 As DataTable
        Dim dataset As New DataSet("Dataset")

        datatable1 = New DataTable("Mydatatable")
        datatable1.Columns.Add("Accnt")
        datatable1.Columns.Add("Amount")

        Dim path As String = q.path
        Dim reportDataSource As New ReportDataSource("DataSet1", datatable1)
        Form5.ReportViewer1.LocalReport.DataSources.Clear()
        Form5.ReportViewer1.LocalReport.DataSources.Add(reportDataSource)
        'Form5.ReportViewer1.LocalReport.ReportPath = "C:\Users\HSDP_SYS_DEV\source\repos\APPS\APPS\print\Report1.rdlc"

        Form5.ReportViewer1.LocalReport.ReportPath = path + "\Report1.rdlc"
        Dim par As New ReportParameter("payee", payee)
        Form5.ReportViewer1.LocalReport.SetParameters(par)

        Dim par1 As New ReportParameter("address", address)
        Form5.ReportViewer1.LocalReport.SetParameters(par1)
        Form5.ReportViewer1.RefreshReport()


        Dim par2 As New ReportParameter("zip", zip)
        Form5.ReportViewer1.LocalReport.SetParameters(par2)
        Form5.ReportViewer1.RefreshReport()

        Dim par3 As New ReportParameter("tin1", tin1)
        Form5.ReportViewer1.LocalReport.SetParameters(par3)
        Form5.ReportViewer1.RefreshReport()

        Dim par4 As New ReportParameter("tin2", tin2)
        Form5.ReportViewer1.LocalReport.SetParameters(par4)
        Form5.ReportViewer1.RefreshReport()
        Dim par5 As New ReportParameter("tin3", tin3)
        Form5.ReportViewer1.LocalReport.SetParameters(par5)
        Form5.ReportViewer1.RefreshReport()
        Dim par6 As New ReportParameter("tin4", tin4)
        Form5.ReportViewer1.LocalReport.SetParameters(par6)
        Form5.ReportViewer1.RefreshReport()

        Dim par7 As New ReportParameter("ATC", atc)
        Form5.ReportViewer1.LocalReport.SetParameters(par7)
        Form5.ReportViewer1.RefreshReport()

        Dim par8 As New ReportParameter("ATCDES", atcdes)
        Form5.ReportViewer1.LocalReport.SetParameters(par8)

        Dim par9 As New ReportParameter("qtrdt1", qtrdt1)
        Form5.ReportViewer1.LocalReport.SetParameters(par9)


        Dim par10 As New ReportParameter("qtrdt2", qtrdt2)
        Form5.ReportViewer1.LocalReport.SetParameters(par10)

        '----------------------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------------------
        Dim amount1 As String = mqrt1.ToString("N2")
        Dim r1 As New ReportParameter("amount1", amount1)
        Form5.ReportViewer1.LocalReport.SetParameters(r1)

        Dim amount2 As String = mqrt2.ToString("N2")
        Dim r2 As New ReportParameter("amount2", amount2)
        Form5.ReportViewer1.LocalReport.SetParameters(r2)

        Dim amount3 As String = mqrt3.ToString("N2")
        Dim r3 As New ReportParameter("amount3", amount3)
        Form5.ReportViewer1.LocalReport.SetParameters(r3)


        Dim t1 As New ReportParameter("tax", tax)
        Form5.ReportViewer1.LocalReport.SetParameters(t1)

        Dim totam As String = amount.ToString("N2")
        Dim y1 As New ReportParameter("amount", totam)
        Form5.ReportViewer1.LocalReport.SetParameters(y1)

        Form5.ReportViewer1.RefreshReport()
        Form5.ShowDialog()
    End Sub

    Private Sub qdate()
        Dim billdate As Date = q.fetchqdate(profno)

        Dim currentYear As String = DateTime.Now.Year.ToString()
        Dim formattedYear As String = String.Join("  ", currentYear.Select(Function(c) c.ToString()))

        If billdate.Month >= 1 AndAlso billdate.Month <= 3 Then
            quarter = 1
            qrterdate1 = "0 1" & "  " & "  0 1   " & formattedYear
            qrterdate2 = "0 3" + "  " + "  3 1   " + formattedYear
        ElseIf billdate.Month >= 4 AndAlso billdate.Month <= 6 Then
            quarter = 2
            qrterdate1 = "0 4" + "  " + "  0 1   " + formattedYear
            qrterdate2 = "0 6" + "  " + "  3 0   " + formattedYear
        ElseIf billdate.Month >= 7 AndAlso billdate.Month <= 9 Then
            quarter = 3
            qrterdate1 = "0 7" + "  " + "  01   " + formattedYear
            qrterdate2 = "0 9" + "  " + "  3 0   " + formattedYear
        ElseIf billdate.Month >= 10 AndAlso billdate.Month <= 12 Then
            quarter = 4
            qrterdate1 = "1 0" & "  " & "  0 1   " & formattedYear
            qrterdate2 = "1 2" + "  " + "  3 1   " + formattedYear
        End If
    End Sub



    Private Sub prtIII()
        Dim billdate As Date = q.fetchqdate(profno)


        If quarter = 1 Then
            If billdate.Month = 1 Then
                prt3qtramount = 1
            ElseIf billdate.Month = 2 Then
                prt3qtramount = 2
            ElseIf billdate.Month = 3 Then
                prt3qtramount = 3
            End If

        ElseIf quarter = 2 Then

            If billdate.Month = 4 Then
                prt3qtramount = 1
            ElseIf billdate.Month = 5 Then
                prt3qtramount = 2
            ElseIf billdate.Month = 6 Then
                prt3qtramount = 3
            End If

        ElseIf quarter = 3 Then
            If billdate.Month = 7 Then
                prt3qtramount = 1
            ElseIf billdate.Month = 8 Then
                prt3qtramount = 2
            ElseIf billdate.Month = 9 Then
                prt3qtramount = 3
            End If

        ElseIf quarter = 4 Then
            If billdate.Month = 10 Then
                prt3qtramount = 1
            ElseIf billdate.Month = 11 Then
                prt3qtramount = 2
            ElseIf billdate.Month = 12 Then
                prt3qtramount = 3
            End If

        End If

    End Sub


    Private Sub fetchtin()

        Dim t1 As String = q.fetchtin1(TextBox4.Text)
        Dim t11 As String = String.Join("  ", t1.Select(Function(c) c.ToString()))
        tin11 = t11

        Dim t2 As String = q.fetchtin2(TextBox4.Text)
        Dim t22 As String = String.Join("  ", t2.Select(Function(c) c.ToString()))
        tin22 = t22

        Dim t3 As String = q.fetchtin3(TextBox4.Text)
        Dim t33 As String = String.Join("  ", t3.Select(Function(c) c.ToString()))
        tin33 = t33

        Dim t4 As String = q.fetchtin4(TextBox4.Text)
        Dim t44 As String = String.Join("   ", t4.Select(Function(c) c.ToString()))
        tin44 = t44


        Dim z As String = q.fetchzip(TextBox4.Text)
        Dim z1 As String = String.Join("  ", z.Select(Function(c) c.ToString()))
        zipcode1 = z1


    End Sub

    Private Sub Voucher1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Voucher1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        TextBox8.Text = String.Empty
        TextBox3.Text = String.Empty
        profno = String.Empty
        TextBox2.Text = String.Empty
        TextBox4.Text = String.Empty
        DateTimePicker1.Value = Now
        SimpleButton3.Visible = False
        SimpleButton4.Visible = False
        SimpleButton2.Text = "Record"
        dgv3.DataSource = Nothing
        dgv3.Rows.Clear()
        disable()

    End Sub
End Class