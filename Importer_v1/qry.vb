Public Class qry

    Public SQL As New sqlcon
    Public Sub CheckSeries()
        SQL.ExecQueryDT("SELECT TOP 1 Series FROM tblHeader ORDER BY HeaderID DESC")

        If SQL.HasException(True) Then
            Exit Sub
        End If

        If SQL.RecordCountDT > 0 Then
            ' Assuming HeaderID is the column containing the value you want to increment
            Dim currentValue As Integer = Convert.ToInt32(SQL.DBDT.Rows(0)("Series").ToString())
            Dim newValue As String = (currentValue + 1).ToString("D6")

            ' Assuming form2 is a valid instance of your form
            Form7.TextBox2.Text = newValue
        Else
            Form7.TextBox2.Text = "000001" ' Set a default value if no records are found
        End If
    End Sub

    Public Sub CheckSeries1()
        SQL.ExecQueryDT("SELECT TOP 1 PVseries FROM tblvoucherHeader ORDER BY PVseries desc")

        If SQL.HasException(True) Then
            Exit Sub
        End If

        If SQL.RecordCountDT > 0 Then
            ' Assuming HeaderID is the column containing the value you want to increment
            Dim currentValue As Integer = Convert.ToInt32(SQL.DBDT.Rows(0)("PVseries").ToString())
            Dim newValue As String = (currentValue + 1).ToString("D6")

            ' Assuming form2 is a valid instance of your form
            Voucher1.TextBox2.Text = newValue
        Else
            Voucher1.TextBox2.Text = "000001" ' Set a default value if no records are found
        End If

    End Sub

    Public Sub SaveHeader(Series As String, payto As String, payor As String, type As String)
        Dim Date1 As String = Date.Now.ToString("yyyy-MM-dd")

        SQL.AddParam("@date", Date1)
        SQL.AddParam("@series", Series)
        SQL.AddParam("@payor", payor)
        SQL.AddParam("@payto", payto)
        SQL.AddParam("@type", type)

        SQL.ExecQueryDT("INSERT INTO tblHeader
	                    (Date,Series,Payor,Type,Payto)
	                    VALUES
	                    (@date,@series,@payor,@type,@payto)")
        If SQL.HasException(True) Then Exit Sub

        With form2
            .display()
        End With

    End Sub

    Public Sub HeaderID()
        SQL.ExecQueryDT("SELECT TOP 1 HeaderID FROM tblHeader ORDER BY HeaderID DESC")

        If SQL.HasException(True) Then
            Exit Sub
        End If
        If SQL.RecordCountDT > 0 Then
            form2.HeaderID = SQL.DBDT.Rows(0).Item("HeaderID").ToString()
        End If

    End Sub

    Public Sub Register(dat1 As Date, date2 As Date, payor As String, type As String, Series As String, Status As String)

        Dim rStatus As String
        If Status = "All" Then
            rStatus = ""
        Else
            rStatus = Status
        End If

        SQL.AddParam("@dt1", dat1)
        SQL.AddParam("@dt2", date2)
        SQL.AddParam("@Payor", payor)
        SQL.AddParam("@Type", type)
        SQL.AddParam("@Series", Series)
        SQL.AddParam("@Status", rStatus)

        SQL.ExecQueryDT("SELECT 
                            Date,
                            Series,
                            Payor,
                            Type,
                            Payto,
                            Bank,
                            Terms,
                            CheckDate,
                            Remarks,
                            Releasing,
                            HeaderID,
                            Checkno,
                            Releasing,
                            checkby,
                            apprv,
                            Status FROM tblHeader  
                         WHERE Date BETWEEN @dt1 AND @dt2
                         AND (Series Like '%'+ @Series + '%' or @Series='') 
                         AND (Payto Like '%'+ @Payor + '%' or @Payor='')
                         AND (Type Like '%'+ @Type + '%' or @Type='')
                         AND (Status = @Status or @Status='')")
        If SQL.HasException(True) Then Exit Sub

        With Form3.DataGridView1
            .DataSource = SQL.DBDT
            .Columns(0).HeaderText = "Date"
            .Columns(1).HeaderText = "Series"
            .Columns(2).HeaderText = "Payor"
            .Columns(3).HeaderText = "Type"
            .Columns(4).HeaderText = "Pay To"
            .Columns(5).Visible = False
            '.Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False
            .Columns(10).Visible = False
            .Columns(11).Visible = False
            .Columns(12).Visible = False
            .Columns(13).Visible = False
            .Columns(14).Visible = False

            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True
            .Columns(5).ReadOnly = True

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(0).Width = 100
            .Columns(1).Width = 100
            .Columns(2).Width = 300
            .Columns(3).Width = 100
            .Columns(4).Width = 300
            .Columns(5).Width = 100

            .ColumnHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)
        End With

    End Sub



    Public Sub HeaderID(id As Integer)
        SQL.AddParam("@id", id)

        SQL.ExecQueryDT("Select Date,Ref,PaymentRelatedto,Amount,type,Accnt,tax,formula1,formula2,formula3 from tblTransDetail where HeaderID = @id")

        If SQL.HasException(True) Then Exit Sub

        With Form4.DataGridView1
            .DataSource = SQL.DBDT
            .Columns(0).HeaderText = "Date"
            .Columns(1).HeaderText = "Reference"
            .Columns(2).HeaderText = "Particulars"
            .Columns(3).HeaderText = "Amount"
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

            .ColumnHeadersDefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)

            .Columns(0).Width = 100
            .Columns(1).Width = 139
            .Columns(2).Width = 495
            .Columns(3).Width = 150

        End With

    End Sub

End Class
