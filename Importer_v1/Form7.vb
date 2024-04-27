Imports Microsoft.Reporting.WinForms

Public Class Form7
    ' In Form7


    Private f As New qry
    Private tax As Double

    Private h As Double
    Private h1 As Double

    Private totalwtax As Decimal
    Private totalsum1 As Decimal

    Private sup123 As String
    Private totalsum2 As Decimal

    Private billvat As Decimal
    Private billvat1 As Decimal
    Private ttax As Decimal


    Private totalvat As Decimal

    Private forje11 As Decimal

    Public Sub calcu()

        Dim f1 As Decimal = q.fetchData2(TextBox4.Text) * 100
        tax = f1

        Label11.Text = "WTax Rate " + f1.ToString + "% :"

        Dim f3 As Double = (Double.Parse(totalwtax) * f1)
        Dim f2 As Double = (f3 / 100) * -1

        TextBox6.Text = f2.ToString
        ttax = f2 * -1
        ComboBox1.Text = q.fetchData1(TextBox4.Text)

        If TextBox5.Text = "0.00" Then
            TextBox7.Text = "0.00"
        Else
            TextBox7.Text = (Double.Parse(TextBox5.Text)) + (Double.Parse(TextBox6.Text))
        End If

    End Sub

    Public Sub displaytotal()

        Dim totalSum As Decimal = 0

        Dim bill1 As Decimal = 0
        Dim cm1 As Decimal = 0

        Dim bvat As Decimal
        Dim bvat1 As Decimal

        For Each row As DataGridViewRow In dgv3.Rows

            If row.Cells(0).Value = "Bill" Then
                bill1 += Convert.ToDecimal(row.Cells(7).Value)

            ElseIf row.Cells(0).Value = "Credit" Then
                cm1 += Convert.ToDecimal(row.Cells(7).Value)
            End If

            totalSum += Convert.ToDecimal(row.Cells(7).Value)

        Next

        h = bill1
        h1 = cm1


        Dim Vatable As Decimal
        Dim NonVatable As Decimal

        If q.checkvatble(TextBox4.Text) = "Vatable" Then

            Vatable = h + h1
            totalwtax = Vatable / 1.12

            'to calculate vat
            bvat1 = totalSum / 1.12
            Dim amount As String = bvat1.ToString("N2")
            'Bill, Net of Vat

            If amount = 0 Then

                billvat = Vatable
            Else
                billvat = amount
            End If


            bvat = bvat1 * 0.12
            Dim amount1 As String = bvat.ToString("N2")
            billvat1 = amount1

        ElseIf q.checkvatble(TextBox4.Text) = "Non-Vatable" Then

            NonVatable = h + h1
            totalwtax = NonVatable
            If NonVatable = 0 Then
                billvat = h + h1
                billvat1 = "0"
            Else
                billvat = NonVatable
                billvat1 = "0"
            End If


        End If

        'display total due
        TextBox7.Text = totalwtax

        'display total all amount
        TextBox5.Text = totalSum
        jebills()
        checkingduplicate()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub checkingduplicate()
        'Dim lastCommittedRowIndex As Integer = dgv3.Rows.GetLastRow(DataGridViewElementStates.None)

        'For i As Integer = 0 To lastCommittedRowIndex - 1
        '    Dim currentRow As DataGridViewRow = dgv3.Rows(i)

        '    If currentRow.IsNewRow Then
        '        Continue For ' Skip uncommitted rows
        '    End If

        '    For j As Integer = i + 1 To lastCommittedRowIndex
        '        Dim nextRow As DataGridViewRow = dgv3.Rows(j)

        '        If nextRow.IsNewRow Then
        '            Continue For ' Skip uncommitted rows
        '        End If

        '        If currentRow.Cells(5).Value = nextRow.Cells(5).Value Then
        '            currentRow.Cells(11).Value = "same"
        '            nextRow.Cells(11).Value = "same"
        '            Exit For ' exit the inner loop once a match is found
        '        Else
        '            nextRow.Cells(11).Value = "not same"
        '            currentRow.Cells(11).Value = "not same"
        '        End If
        '    Next
        'Next
        For Each currentRow As DataGridViewRow In dgv3.Rows
            ' Check if the current row is not a new (uncommitted) row
            If Not currentRow.IsNewRow Then
                ' Assuming you want to check the value in the fifth cell of each row
                Dim currentValue As String = currentRow.Cells(5).Value
                Dim isSame As Boolean = False

                For Each otherRow As DataGridViewRow In dgv3.Rows
                    ' Check if the other row is not a new (uncommitted) row
                    If Not otherRow.IsNewRow And Not currentRow.Equals(otherRow) Then ' Avoid comparing the same row
                        Dim otherValue As String = otherRow.Cells(5).Value
                        If currentValue = otherValue Then
                            ' The value in the current row is repeated in another row
                            isSame = True
                            Exit For
                        End If
                    End If
                Next

                ' Mark the rows based on the comparison
                If isSame Then
                    currentRow.Cells(11).Value = "same"
                Else
                    currentRow.Cells(11).Value = "not same"
                End If
            End If

        Next



    End Sub



    Private Sub jebills()

        If q.checkvatble(TextBox4.Text) = "Vatable" Then

            ' Initialize forje11 to zero before the loop
            forje11 = 0

            Dim formula1 As Decimal
            Dim formula2 As Decimal
            Dim formula3 As Decimal
            Dim tax1 As Decimal

            For Each row As DataGridViewRow In dgv3.Rows
                ' Check if the row is not in edit mode
                If Not row.IsNewRow Then
                    ' Check if the row is committed (saved)
                    If Not row.Cells(7).IsInEditMode Then
                        Dim forje1 As Object = row.Cells(7).Value
                        tax1 = tax / 100
                        formula1 = forje1 / 1.12
                        formula2 = formula1 * tax1
                        formula3 = forje1 - formula2
                        Dim formula4 As String = formula3.ToString("N2")
                        ' Accumulate the values in forje11
                        row.Cells(8).Value = formula1
                        row.Cells(9).Value = formula2
                        row.Cells(10).Value = formula3
                        ' Show intermediate result for committed rows

                    End If
                End If
            Next

        ElseIf q.checkvatble(TextBox4.Text) = "Non-Vatable" Then

            ' Initialize forje11 to zero before the loop
            forje11 = 0

            Dim formula1 As Decimal
            Dim formula2 As Decimal
            Dim formula3 As Decimal
            Dim tax1 As Decimal

            For Each row As DataGridViewRow In dgv3.Rows
                ' Check if the row is not in edit mode
                If Not row.IsNewRow Then
                    ' Check if the row is committed (saved)
                    If Not row.Cells(7).IsInEditMode Then
                        Dim forje1 As Object = row.Cells(7).Value
                        tax1 = tax / 100
                        formula1 = forje1
                        formula2 = formula1 * tax1
                        formula3 = forje1 - formula2
                        Dim formula4 As String = formula3.ToString("N2")
                        ' Accumulate the values in forje11
                        row.Cells(8).Value = formula1
                        row.Cells(9).Value = formula2
                        row.Cells(10).Value = formula3
                        ' Show intermediate result for committed rows

                    End If
                End If
            Next
        End If

    End Sub




    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If TextBox4.Text = String.Empty Then
            MessageBox.Show("Please Select First Payee...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Form6.sup = TextBox4.Text
            Form6.Show()
        End If
    End Sub

    Private Sub checkby()

        ComboBox6.DataSource = q.fetchuser
        ComboBox5.DataSource = q.fetchuser1
        ComboBox4.DataSource = q.displayMode1
    End Sub
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = String.Empty
        TextBox5.Text = "0.00"
        TextBox6.Text = "0.00"
        TextBox7.Text = "0.00"
        Label11.Text = "WTax Rate % :"
        display()
        disbank()
        disType()
        disTerms()

        TextBox1.Text = "Evermore Distribution, Inc"
        ComboBox3.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox1.SelectedIndex = -1

        SimpleButton1.Focus()
        checkby()

    End Sub

    Private Sub disbank()
        ComboBox3.DataSource = q.displaybank1
    End Sub

    Private Sub disType()
        ComboBox2.DataSource = q.displayType1
    End Sub

    Private Sub disTerms()
        ComboBox1.DataSource = q.displayTerms1
    End Sub


    Private Sub dgv3_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        ' Check if the event is for the "Amount" column (column index 7)
        If e.ColumnIndex = 7 AndAlso e.Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(e.Value.ToString()) Then
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

    Private Sub display()
        f.CheckSeries()
        With dgv3
            .Columns.Add("0", "Type")
            Dim columnIndex As Integer = .Columns.Add("1", "Date")

            ' Set the format for the specific column by its index
            .Columns(columnIndex).DefaultCellStyle.Format = "yyyy-MM-dd"

            ' Center-align the content of the specific column
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns.Add("2", "Reference")
            .Columns.Add("3", "Name")
            .Columns.Add("4", "Particulars")
            .Columns.Add("5", "Accounts")
            .Columns.Add("6", "Split")
            .Columns.Add("7", "Amount")
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns.Add("8", "amount/1.12")
            .Columns.Add("9", "amount*0.05")
            .Columns.Add("10", "amount2")
            .Columns.Add("11", "stat")
            AddHandler .CellFormatting, AddressOf dgv3_CellFormatting

            '.Columns(0).Visible = False
            .Columns(3).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False
            .Columns(10).Visible = False
            .Columns(11).Visible = False

            'for suggestive in textbox
            '-------------------------------------------------------
            'ComboBox2.DataSource = q.FetchType
            'ComboBox1.DataSource = q.FetchPayto

            ' Assuming q.FetchPay returns a collection of strings
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
            '-------------------------------------------------------

            For Each col As DataGridViewColumn In .Columns
                col.HeaderCell.Style.Font = New Font("Tahoma", 8.25, FontStyle.Bold)
            Next


            .Columns(0).Width = 100
            .Columns(1).Width = 100
            .Columns(2).Width = 195
            .Columns(4).Width = 470
            .Columns(7).Width = 120
        End With
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click


        Dim committedRowCount As Integer = 0

        For Each row As DataGridViewRow In dgv3.Rows
            If Not row.IsNewRow Then
                committedRowCount += 1
            End If
        Next

        If SimpleButton2.Text = "Record" Then

            If TextBox4.Text = String.Empty Then
                MessageBox.Show("Payee is Required...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf ComboBox2.Text = String.Empty Then
                MessageBox.Show("Type is Required...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf ComboBox3.Text = String.Empty Then
                MessageBox.Show("Bank is Required...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf ComboBox1.Text = String.Empty Then
                MessageBox.Show("Terms is Required...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf committedRowCount = 0 Then
                MessageBox.Show("Please Select Bill...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else

                If TextBox3.Text = String.Empty Then
                    Dim result As DialogResult = MessageBox.Show("No Remarks Included", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                    If result = DialogResult.OK Then

                        q.save(TextBox4.Text, TextBox1.Text, ComboBox2.Text, ComboBox3.Text, TextBox2.Text, ComboBox1.Text, DateTimePicker1.Value, TextBox3.Text, Form1.name1, ComboBox6.Text, ComboBox5.Text, sup123, ComboBox4.Text, DateTimePicker2.Value)


                        For Each row As DataGridViewRow In dgv3.Rows
                            If Not row.IsNewRow Then
                                Dim Type1 As String = row.Cells(0).Value.ToString
                                Dim Date1 As String = row.Cells(1).Value.ToString
                                Dim Ref1 As String = row.Cells(2).Value
                                Dim Pay1 As String = row.Cells(4).Value.ToString
                                Dim accnt As String = row.Cells(5).Value.ToString
                                Dim Amount1 As String = row.Cells(7).Value.ToString
                                Dim TransHeaderID As Integer = q.fetchhID
                                Dim formula1 As Double = row.Cells(8).Value
                                Dim formula2 As Double = row.Cells(9).Value
                                Dim formula3 As Double = row.Cells(10).Value

                                q.save1(Type1, Date1, Ref1, Pay1, Double.Parse(Amount1), TransHeaderID, accnt, TextBox6.Text, formula1, formula2, formula3)

                            End If
                        Next

                        MessageBox.Show("Successfully Recorded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        SimpleButton3.Visible = True

                        SimpleButton2.Text = "New Entry"
                        disable()
                    ElseIf result = DialogResult.Cancel Then

                    End If
                Else
                    q.save(TextBox4.Text, TextBox1.Text, ComboBox2.Text, ComboBox3.Text, TextBox2.Text, ComboBox1.Text, DateTimePicker1.Value, TextBox3.Text, Form1.name1, ComboBox6.Text, ComboBox5.Text, sup123, ComboBox4.Text, DateTimePicker2.Value)

                    For Each row As DataGridViewRow In dgv3.Rows
                        If Not row.IsNewRow Then
                            Dim Type1 As String = row.Cells(0).Value.ToString
                            Dim Date1 As String = row.Cells(1).Value.ToString
                            Dim Ref1 As String = row.Cells(2).Value
                            Dim Pay1 As String = row.Cells(4).Value.ToString
                            Dim accnt As String = row.Cells(5).Value.ToString
                            Dim Amount1 As String = row.Cells(7).Value.ToString
                            Dim TransHeaderID As Integer = q.fetchhID
                            Dim formula1 As Double = row.Cells(8).Value
                            Dim formula2 As Double = row.Cells(9).Value
                            Dim formula3 As Double = row.Cells(10).Value
                            q.save1(Type1, Date1, Ref1, Pay1, Double.Parse(Amount1), TransHeaderID, accnt, TextBox6.Text, formula1, formula2, formula3)
                        End If
                    Next

                    MessageBox.Show("Successfully Recorded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SimpleButton3.Visible = True

                    SimpleButton2.Text = "New Entry"
                    disable()
                End If


            End If


        ElseIf SimpleButton2.Text = "New Entry" Then

            SimpleButton2.Text = "Record"
            TextBox2.Text = String.Empty
            dgv3.Rows.Clear()
            dgv3.Columns.Clear()
            display()
            disable()
            cleardata()
            TextBox5.Text = "0.00"
            TextBox6.Text = "0.00"
            TextBox7.Text = "0.00"
            SimpleButton3.Visible = False

        End If

    End Sub

    Private Sub disable()
        If SimpleButton2.Text = "New Entry" Then
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox7.Enabled = False

            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False

            ComboBox5.Enabled = False
            ComboBox6.Enabled = False
            dgv3.Enabled = False
        ElseIf SimpleButton2.Text = "Record" Then

            TextBox2.Enabled = False
            TextBox3.Enabled = True
            TextBox4.Enabled = True

            ComboBox1.Enabled = True
            ComboBox2.Enabled = True
            ComboBox3.Enabled = True

            ComboBox5.Enabled = True
            ComboBox6.Enabled = True
            dgv3.Enabled = True
        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click



        Dim Payor As String = TextBox1.Text
        Dim Payto As String = TextBox4.Text
        Dim Type As String = ComboBox2.Text
        Dim series As String = TextBox2.Text
        Dim Terms As String = ComboBox1.Text
        Dim Bank As String = ComboBox3.Text

        Dim totalamount As String = TextBox5.Text
        Dim date1 As String = DateTimePicker1.Value.ToShortDateString
        Dim remarks As String = TextBox3.Text
        Dim user1 As String = Form1.name1
        Dim diff As String = TextBox6.Text
        Dim tax1 As String = tax
        Dim due As String = TextBox7.Text

        Dim currentDate As Date = Date.Today

        Dim checkby As String = ComboBox6.Text
        Dim apprv As String = ComboBox5.Text

        Dim amount As String = billvat.ToString("N2")
        Dim amount1 As String = billvat1.ToString("N2")

        Dim wtax As String = ttax.ToString("N2")

        Dim datatable1 As DataTable
        Dim dataset As New DataSet("Dataset")

        '"Invoice Date,Invoice No., Particulars,Amount"

        datatable1 = New DataTable("Mydatatable")
        datatable1.Columns.Add("Date")
        datatable1.Columns.Add("Ref")
        datatable1.Columns.Add("PaymentRelatedTo")
        datatable1.Columns.Add("Amount")
        datatable1.Columns.Add("Accnt")
        datatable1.Columns.Add("vat1")

        dataset.Tables.Add(datatable1)
        Dim currentAccnt As String = ""

        For Each row As DataGridViewRow In dgv3.Rows
            If Not row.IsNewRow Then
                Dim datarow2 As DataRow = datatable1.NewRow
                datarow2("Date") = DateTime.Parse(row.Cells(1).Value.ToString).ToShortDateString()
                datarow2("Ref") = row.Cells(2).Value.ToString
                datarow2("PaymentRelatedTo") = row.Cells(4).Value.ToString

                Dim amount22321 As Decimal = row.Cells(7).Value.ToString

                Dim amount2231 As String = amount22321.ToString("N2")
                datarow2("Amount") = amount2231



                datarow2("Accnt") = row.Cells(5).Value.ToString()

                Dim vat1Sum As Decimal = row.Cells(10).Value
                Dim amount234 As String = vat1Sum.ToString("N2")
                datarow2("vat1") = amount234

                datatable1.Rows.Add(datarow2)
            End If
        Next

        Dim path As String = q.path
        Dim reportDataSource As New ReportDataSource("DataSet1", datatable1)

        Form5.ReportViewer1.LocalReport.DataSources.Clear()
        Form5.ReportViewer1.LocalReport.DataSources.Add(reportDataSource)
        Form5.ReportViewer1.LocalReport.ReportPath = path + "\Report6.rdlc"



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

        Form5.ReportViewer1.RefreshReport()
        Form5.sesries = TextBox2.Text
        Form5.WhatForm = 1
        Form5.ShowDialog()

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub dgv3_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgv3.UserAddedRow
        displaytotal()
        calcu()
    End Sub

    Private Sub dgv3_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgv3.UserDeletedRow
        displaytotal()
        calcu()
    End Sub
    Private Sub dgv3_Validated(sender As Object, e As EventArgs) Handles dgv3.Validated
        displaytotal()
        calcu()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        sup123 = q.checkvatble(TextBox4.Text)

    End Sub

    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        calcu()
    End Sub

    Private Sub cleardata()

        TextBox4.Text = String.Empty

        TextBox3.Text = String.Empty
        TextBox5.Text = String.Empty
        TextBox6.Text = String.Empty
        TextBox7.Text = String.Empty

        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1

        Label11.Text = "WTax Rate % :"
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

        Try
            Dim inputValue As Double = TextBox5.Text
            Dim formattedValue As String = inputValue.ToString("N2")

            TextBox5.Text = formattedValue
        Catch ex As Exception

        End Try

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

    Private Sub dgv3_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgv3.RowValidating

    End Sub

    Private Sub dgv3_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgv3.CellValidating

    End Sub

    Private Sub Form7_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Form7_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        SimpleButton2.Text = "Record"
        TextBox2.Text = String.Empty
        dgv3.Rows.Clear()
        dgv3.Columns.Clear()
        display()
        disable()
        cleardata()
        TextBox5.Text = "0.00"
        TextBox6.Text = "0.00"
        TextBox7.Text = "0.00"
        SimpleButton3.Visible = False

    End Sub


End Class