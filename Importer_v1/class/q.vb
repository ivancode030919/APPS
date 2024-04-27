Imports System.Data.Linq
Public Class q

    Public Shared path As String = "\\172.16.7.7\apps\Importer_v1\Importer_v1\print"

    Public Shared Function GetAssetDetail() As System.Data.Linq.Table(Of tblDetail)
        Return db.GetTable(Of tblDetail)()
    End Function

    Public Shared Function FetchType() As List(Of String)
        Dim querysection = (From s In db.tblDetails
                            Where s.Type <> ""
                            Select s.Type).Distinct.ToList
        Return querysection
    End Function

    Public Shared Function FetchPayto() As List(Of String)

        Dim querysection = (From s In db.tblsuppliers
                            Where s.Supplier <> ""
                            Select s.Supplier).Distinct.ToList
        Return querysection
    End Function

    Public Shared Function fetchName() As List(Of String)

        Dim querysection = (From s In db.tblDetails
                            Where s.Name <> ""
                            Select s.Name).Distinct.ToList
        Return querysection
    End Function

    Public Shared Function fetchAllData(ByVal ref As String, ByVal type1 As String, ByVal name1 As String, ByVal memo1 As String, ByVal accnt As String) As Object
        Dim querysection = (From s In db.tblDetails
                            Where (s.Num = ref Or ref = "") And (s.Type = type1 Or type1 = "") And (s.Name = name1 Or name1 = "") And (s.Memo = memo1 Or memo1 = "") And (s.Account = accnt Or accnt = "")
                            Select s.Type, s.Date, s.Num, s.Name, s.Memo, s.Account, s.Split, s.Amount).ToList
        Return querysection
    End Function

    Public Shared Function GetHeader() As System.Data.Linq.Table(Of tblHeader)
        Return db.GetTable(Of tblHeader)()
    End Function

    Public Shared Sub save(ByVal payto As String,
                           ByVal payor As String, ByVal type As String,
                           ByVal bank As String, ByVal series As String,
                           ByVal terms As String, ByVal date1 As Date,
                           ByVal remarks1 As String, ByVal encoder As String, ByVal check As String,
                           ByVal apprv As String, ByVal vat As String,
                           ByVal mreleasing As String, ByVal checkdate As Date)
        Try
            Dim printed As Integer = 0
            Dim Stat As String = "Open"
            Dim post As Table(Of tblHeader) = q.GetHeader
            Dim p As New tblHeader With
                {
                .Payto = payto,
                .Payor = payor,
                .Type = type,
                .Bank = bank,
                .Series = series,
                .Terms = terms,
                .[Date] = date1,
                .Remarks = remarks1,
                .Encoder = encoder,
                .apprv = apprv,
                .checkby = check,
                .vat = vat,
                .Status = Stat,
                .printed = printed,
                .Checkdate = checkdate,
                .Releasing = mreleasing
                 }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub


    Public Shared Sub updatePrfStat(ByVal id As Integer)
        Try
            Dim Stat As String = "Cancelled"

            Dim updateStat = (From p In db.GetTable(Of tblHeader)()
                              Where (p.HeaderID = id)
                              Select p).FirstOrDefault()
            updateStat.Status = Stat

            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data. update")
        End Try
    End Sub

    Public Shared Function fetchPrintStat(ByVal series As String)

        Dim querysection = (From s In db.tblHeaders
                            Where s.Series = series
                            Select s.printed).FirstOrDefault
        Return querysection

    End Function

    Public Shared Sub updatePRFPrintStat(ByVal prfno As String)
        Try
            Dim PStat As Integer = 1

            Dim updateStat = (From p In db.GetTable(Of tblHeader)()
                              Where (p.Series = prfno)
                              Select p).FirstOrDefault()
            updateStat.printed = PStat

            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data. update")
        End Try
    End Sub

    Public Shared Function fetchPRfStat(ByVal id As Integer)

        Dim querysection = (From s In db.tblHeaders
                            Where s.HeaderID = id
                            Select s.Status).FirstOrDefault
        Return querysection

    End Function
    Public Shared Function Getdetail() As System.Data.Linq.Table(Of tblTransDetail)
        Return db.GetTable(Of tblTransDetail)()
    End Function

    Public Shared Sub save1(ByVal Type As String, ByVal Date1 As Date,
                            ByVal ref1 As String, ByVal payment As String,
                            ByVal amount As Double, ByVal headerid As Integer,
                            ByVal accnt As String, ByVal tax1 As Double, ByVal formula1 As Double,
                            ByVal formula2 As Double, ByVal formula3 As Double)
        Try

            Dim post As Table(Of tblTransDetail) = q.Getdetail

            Dim p As New tblTransDetail With
                {
               .Type = Type,
               .[Date] = Date1,
               .Ref = ref1,
               .PaymentRelatedto = payment,
               .Amount = amount,
               .HeaderID = headerid,
               .Accnt = accnt,
               .tax = tax1,
               .formula1 = formula1,
               .formula2 = formula2,
               .formula3 = formula3
            }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub





    Public Shared Function fetchhID() As Object

        Dim querysection = (From s In db.tblHeaders
                            Order By s.HeaderID Descending
                            Select s.HeaderID).FirstOrDefault
        Return querysection
    End Function
    Public Shared Function fetchhID1() As Object

        Dim querysection = (From s In db.tblvoucherHeaders
                            Order By s.id Descending
                            Select s.id).FirstOrDefault
        Return querysection
    End Function
    Public Shared Function GetUser() As System.Data.Linq.Table(Of tbluser)
        Return db.GetTable(Of tbluser)()
    End Function


    Public Shared Sub saveUser(ByVal name As String, ByVal username As String, ByVal pass As String, ByVal Stat As String)
        Try

            Dim post As Table(Of tbluser) = q.GetUser

            Dim p As New tbluser With
                {
              .name = name,
              .username = username,
              .password = pass,
              .Status = Stat
            }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Sub updateuser(ByVal id As Integer, ByVal name As String,
                                 ByVal username As String, ByVal pass As String,
                                 ByVal Stat1 As Integer, ByVal df As String)

        Try

            Dim updateStat = (From p In db.GetTable(Of tbluser)()
                              Where (p.id = id)
                              Select p).FirstOrDefault()
            updateStat.name = name
            updateStat.username = username
            updateStat.password = pass
            updateStat.Status = Stat1
            updateStat.dfault1 = df
            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data. update")
        End Try

    End Sub

    Public Shared Sub updatedefault()

        Try
            Dim Stat As String = "Non"

            Dim updateStat = From p In db.GetTable(Of tbluser)()
                             Select p

            For Each user In updateStat
                user.dfault1 = Stat
            Next

            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data. update")
        End Try

    End Sub

    Public Shared Function displayuser(ByVal name1 As String) As Object

        Dim querysection = (From s In db.tblusers
                            Where s.name.Contains(name1)
                            Select s.id, s.name, s.username, s.password, s.Status, s.dfault1).ToList
        Return querysection
    End Function


    Public Shared Function Getbank() As System.Data.Linq.Table(Of tblbank)
        Return db.GetTable(Of tblbank)()
    End Function

    Public Shared Sub saveBank(ByVal bank1 As String)
        Try

            Dim post As Table(Of tblbank) = q.Getbank

            Dim p As New tblbank With
                {
             .bank = bank1
            }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Function displaybank(ByVal bank1 As String) As Object

        Dim querysection = (From s In db.tblbanks
                            Where s.bank.Contains(bank1)
                            Select s.id, s.bank).ToList
        Return querysection
    End Function

    Public Shared Function displaybank1() As Object

        Dim querysection = (From s In db.tblbanks
                            Select s.bank).ToList
        Return querysection
    End Function

    Public Shared Function GetType1() As System.Data.Linq.Table(Of tbltype)
        Return db.GetTable(Of tbltype)()
    End Function

    Public Shared Sub saveType(ByVal type1 As String)
        Try
            Dim post As Table(Of tbltype) = q.GetType1

            Dim p As New tbltype With
                {
           .Type = type1
            }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Function displayType(ByVal bank1 As String) As Object

        Dim querysection = (From s In db.tbltypes
                            Where s.Type.Contains(bank1)
                            Select s.id, s.Type).ToList
        Return querysection
    End Function

    Public Shared Function displayType1() As Object

        Dim querysection = (From s In db.tbltypes
                            Select s.Type).ToList
        Return querysection
    End Function

    '--------------------------------------------------------------------------
    Public Shared Function GetTerms() As System.Data.Linq.Table(Of tblTerm)
        Return db.GetTable(Of tblTerm)()
    End Function

    Public Shared Sub saveTerm(ByVal Term1 As String)
        Try

            Dim post As Table(Of tblTerm) = q.GetTerms

            Dim p As New tblTerm With
                {
                  .terms = Term1
                 }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Function displayTerms(ByVal bank1 As String) As Object

        Dim querysection = (From s In db.tblTerms
                            Where s.terms.Contains(bank1)
                            Select s.id, s.terms).ToList
        Return querysection
    End Function

    Public Shared Function displayTerms1() As Object

        Dim querysection = (From s In db.tblTerms
                            Select s.terms).ToList
        Return querysection
    End Function


    Public Shared Function displayLogin(ByVal username As String, ByVal pass As String) As Object

        Dim querysection = (From s In db.tblusers
                            Where s.username = username AndAlso s.password = pass
                            Select s).Count
        Return querysection
    End Function


    Public Shared Function fetchUser(ByVal username As String, ByVal pass As String) As Object

        Dim querysection = (From s In db.tblusers
                            Where s.username = username AndAlso s.password = pass
                            Select s.name).SingleOrDefault
        Return querysection
    End Function


    '--------------------------------------------------------------------------
    Public Shared Function GetSup() As System.Data.Linq.Table(Of tblsupplier)
        Return db.GetTable(Of tblsupplier)()
    End Function

    Public Shared Sub saveSup(ByVal Supplier1 As String, ByVal Terms1 As String,
                              ByVal wtax As Double, ByVal add1 As String, ByVal tin1 As String, ByVal tin2 As String, ByVal tin3 As String, ByVal tin4 As String,
                              ByVal atc As String, ByVal atcdes As String,
                              ByVal zipcode As String, ByVal vatstat As String)
        Try

            Dim post As Table(Of tblsupplier) = q.GetSup

            Dim p As New tblsupplier With
                {
                  .Supplier = Supplier1,
                  .terms = Terms1,
                  .wtax = wtax / 100,
                  .address = add1,
                  .tin1 = tin1,
                  .tin2 = tin2,
                  .tin3 = tin3,
                  .tin4 = tin4,
                  .ATC = atc,
                  .ATCdes = atcdes,
                  .zipcode = zipcode,
                  .Vat = vatstat
                 }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Sub UpdateSupplier(ByVal id As Integer, ByVal name As String,
                                     ByVal wtax As Double, ByVal terms As String,
                                     ByVal add1 As String, ByVal tin1 As String, ByVal tin2 As String, ByVal tin3 As String, ByVal tin4 As String,
                                     ByVal atc As String, ByVal atcdes As String,
                                     ByVal zipcode As String, ByVal vatstat As String)
        Try
            Dim updateStat = (From p In db.GetTable(Of tblsupplier)()
                              Where (p.id = id)
                              Select p).Single()

            updateStat.Supplier = name
            updateStat.wtax = wtax / 100
            updateStat.terms = terms
            updateStat.address = add1
            updateStat.tin1 = tin1
            updateStat.tin2 = tin2
            updateStat.tin3 = tin3
            updateStat.tin4 = tin4
            updateStat.ATC = atc
            updateStat.ATCdes = atcdes
            updateStat.zipcode = zipcode
            updateStat.Vat = vatstat
            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data. update")
        End Try
    End Sub

    Public Shared Function displaySup(ByVal bank1 As String) As Object

        Dim querysection = (From s In db.tblsuppliers
                            Where s.Supplier.Contains(bank1)
                            Let x = s.wtax * 100 Let u = s.tin1 + "-" + s.tin2 + "-" + s.tin3 + "-" + s.tin4
                            Select s.id, s.Supplier, s.address, s.zipcode, u, s.terms, x, s.ATC, s.ATCdes, s.tin1, s.tin2, s.tin3, s.tin4, s.Vat).ToList
        Return querysection

    End Function

    Public Shared Function displaySup1() As Object

        Dim querysection = (From s In db.tblsuppliers
                            Select s.Supplier).ToList
        Return querysection
    End Function

    Public Shared Function fetchVoucherPrintStat(ByVal series As String)

        Dim querysection = (From s In db.tblvoucherHeaders
                            Where s.PVseries = series
                            Select s.printed).FirstOrDefault
        Return querysection

    End Function

    Public Shared Function fetchData1(ByVal sup1 As String) As Object

        Dim querysection = (From s In db.tblsuppliers
                            Where s.Supplier = sup1
                            Select s.terms).SingleOrDefault
        Return querysection
    End Function

    Public Shared Function fetchData2(ByVal sup1 As String) As Object

        Dim querysection = (From s In db.tblsuppliers
                            Where s.Supplier = sup1
                            Select s.wtax).SingleOrDefault
        Return querysection
    End Function


    Public Shared Function GetMode() As System.Data.Linq.Table(Of tblmode)
        Return db.GetTable(Of tblmode)()
    End Function

    Public Shared Sub saveMode(ByVal mode As String)
        Try

            Dim post As Table(Of tblmode) = q.GetMode

            Dim p As New tblmode With
                {
                 .modeofreleasing = mode
                 }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Function displayMode(ByVal mode As String) As Object

        Dim querysection = (From s In db.tblmodes
                            Where s.modeofreleasing.Contains(mode)
                            Select s.id, s.modeofreleasing).ToList
        Return querysection
    End Function

    Public Shared Function displayMode1() As Object

        Dim querysection = (From s In db.tblmodes
                            Select s.modeofreleasing).ToList
        Return querysection
    End Function

    Public Shared Function displayATC(ByVal search As String) As Object

        Dim querysection = (From s In db.tblAtcs
                            Where s.ATC.Contains(search)
                            Order By s.Des Ascending
                            Select s.ATC, s.Des, s.rate).ToList
        Return querysection

    End Function

    Public Shared Function displayvoucher(ByVal payee As String, ByVal date1 As Date, ByVal date2 As Date, ByVal prfno As String) As Object

        Dim querysection = (From s In db.tblTransDetails
                            Join h In db.tblHeaders On s.HeaderID Equals h.HeaderID
                            Where h.Payto = payee AndAlso h.Date >= date1 AndAlso h.Date <= date2 And (h.Series.Contains(prfno)) And h.Status = "Open"
                            Group By sDate = h.Date, hSeries = h.Series, hBank = h.Bank, hCheck = h.Checkno, hheaderid = h.HeaderID, checkdate1 = h.Checkdate, mrelease = h.Releasing Into Group
                            Select sDate, hSeries, hBank, hCheck, TotalAmount = Group.Sum(Function(x) x.s.Amount.GetValueOrDefault()), hheaderid, checkdate1, mrelease).ToList
        Return querysection

    End Function


    Public Shared Function display2307(ByVal Sup As String) As Integer

        Dim querysection = (From s In db.tblsuppliers
                            Where s.Supplier = Sup And s.wtax > 0
                            Select s.wtax).Count
        Return querysection

    End Function

    Public Shared Function displayvoucher1(ByVal headerid As String) As Object

        'Dim querysection = (From s In db.tblTransDetails
        '                    Join h In db.tblHeaders On s.HeaderID Equals h.HeaderID
        '                    Where s.HeaderID = headerid
        '                    Select h.Date, h.Series, h.Bank, h.Checkno, s.Amount, s.Accnt, s.tax).ToList
        'Return querysection
        Dim querysection = (From s In db.tblTransDetails
                            Join h In db.tblHeaders On s.HeaderID Equals h.HeaderID
                            Where s.HeaderID = headerid
                            Group By sDate = h.Date, hSeries = h.Series, hBank = h.Bank, hCheck = h.Checkno, sacc = s.Accnt, stax = s.tax Into Group
                            Select sDate, hSeries, hBank, hCheck, TotalAmount = Group.Sum(Function(x) x.s.Amount.GetValueOrDefault()), sacc, stax).ToList

        Return querysection

    End Function


    Public Shared Function fetchuser() As Object

        Dim querysection = (From s In db.tblusers
                            Where s.Status = 0
                            Order By s.dfault1 Ascending
                            Select s.name).ToList
        Return querysection

    End Function
    Public Shared Function fetchuser1() As Object

        Dim querysection = (From s In db.tblusers
                            Where s.Status = 1
                            Select s.name).ToList
        Return querysection

    End Function


    Public Shared Sub DisplayResults(ByVal series As String)
        Dim querysection = (From s In db.tblTransDetails
                            Join h In db.tblHeaders On s.HeaderID Equals h.HeaderID
                            Where h.Series = series
                            Select s.PaymentRelatedto).ToList()

        If querysection.Any() Then
            Dim resultString As String = String.Join(Environment.NewLine, querysection)
            With Voucher1
                .memo3 = resultString

            End With

            With PVDetail
                .memo3 = resultString
            End With

        Else
            MessageBox.Show("No results found.", "Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Shared Function fetchdetails123(ByVal series1 As String) As Object

        Dim querysection = (From s In db.tblTransDetails
                            Join h In db.tblHeaders On s.HeaderID Equals h.HeaderID
                            Where h.Series = series1
                            Select s.Type, s.Date, s.PaymentRelatedto, s.Ref, s.Amount).ToList
        Return querysection
    End Function

    ''-------------------------------------------------------------------------------------------
    Public Shared Function Getvoucher() As System.Data.Linq.Table(Of tblvoucherHeader)
        Return db.GetTable(Of tblvoucherHeader)()
    End Function

    Public Shared Sub Savevoucher(ByVal payee As String, ByVal prfno As String,
                               ByVal pvno As String, ByVal date1 As Date,
                               ByVal checkdate As Date, ByVal checkno As String,
                               ByVal remarks As String, ByVal checkby As String,
                               ByVal apprv As String, ByVal status As String,
                                  ByVal modereleasing As String)
        Try
            Dim VStat As Integer = 0
            Dim Stat As String = "Open"
            Dim post As Table(Of tblvoucherHeader) = q.Getvoucher

            Dim p As New tblvoucherHeader With
                {
                  .Payee = payee,
                  .Prfno = prfno,
                  .[Date] = date1,
                  .PVseries = pvno,
                  .CheckDate = checkdate,
                  .Checkno = checkno,
                  .Remarks = remarks,
                  .Status = status,
                  .checkby = checkby,
                  .aprrv = apprv,
                  .encoder = Form1.name1,
                  .Stat = Stat,
                  .printed = VStat,
                  .modeofreleasing = modereleasing
                 }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Sub updateVoucherPrintStat(ByVal prfno As String)
        Try
            Dim VStat As Integer = 1

            Dim updateStat = (From p In db.GetTable(Of tblvoucherHeader)()
                              Where (p.PVseries = prfno)
                              Select p).FirstOrDefault()
            updateStat.printed = VStat

            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data. update")
        End Try
    End Sub
    Public Shared Sub updateVoucherfStat(ByVal id As Integer)
        Try
            Dim Stat As String = "Cancelled"

            Dim updateStat = (From p In db.GetTable(Of tblvoucherHeader)()
                              Where (p.id = id)
                              Select p).FirstOrDefault()
            updateStat.Status = Stat

            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data. update")
        End Try
    End Sub

    Public Shared Sub updateVoucherfStat2(ByVal id As Integer)
        Try
            Dim Stat As String = "Cancelled"

            Dim updateStat = (From p In db.GetTable(Of tblvoucherHeader)()
                              Where (p.id = id)
                              Select p).FirstOrDefault()
            updateStat.Stat = Stat

            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data. update")
        End Try
    End Sub


    Public Shared Sub UpdatePRStatus(ByVal PR As String)
        Try
            Dim Stat As String = "Closed"
            Dim updateStat = (From p In db.GetTable(Of tblHeader)()
                              Where (p.Series = PR)
                              Select p).FirstOrDefault()
            updateStat.Status = Stat

            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data. update")
        End Try
    End Sub

    Public Shared Function fetchVoucherStat(ByVal id As Integer)

        Dim querysection = (From s In db.tblvoucherHeaders
                            Where s.id = id
                            Select s.Status).FirstOrDefault
        Return querysection

    End Function

    ''-------------------------------------------------------------------------------------------
    Public Shared Function Getvoucherdetail() As System.Data.Linq.Table(Of tblvoucherdetail)
        Return db.GetTable(Of tblvoucherdetail)()
    End Function

    Public Shared Sub Savevoucher(ByVal Date1 As Date, ByVal prfno As String,
                               ByVal bank As String, ByVal checkno As String,
                               ByVal amount As Double, ByVal Status1 As String,
                               ByVal Status2 As String, ByVal headerid As String)
        Try

            Dim post As Table(Of tblvoucherdetail) = q.Getvoucherdetail

            Dim p As New tblvoucherdetail With
                {
                 .[Date] = Date1,
                 .Prf = prfno,
                 .Bank = bank,
                 .Checkno = checkno,
                 .Amount = amount,
                 .Status = Status1,
                 .Status1 = Status2,
                 .headerid = headerid
                 }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub


    Public Shared Function fetchadddress(ByVal vendor As String) As Object

        Dim querysection = (From s In db.tblsuppliers
                            Where s.Supplier = vendor
                            Select s.address).FirstOrDefault
        Return querysection
    End Function


    Public Shared Function fetchtin1(ByVal vendor As String) As Object

        Dim querysection = (From s In db.tblsuppliers
                            Where s.Supplier = vendor
                            Let g = s.tin1
                            Select g).FirstOrDefault
        Return querysection
    End Function

    Public Shared Function fetchtin2(ByVal vendor As String) As Object

        Dim querysection = (From s In db.tblsuppliers
                            Where s.Supplier = vendor
                            Let g = s.tin2
                            Select g).FirstOrDefault
        Return querysection
    End Function

    Public Shared Function fetchtin3(ByVal vendor As String) As Object

        Dim querysection = (From s In db.tblsuppliers
                            Where s.Supplier = vendor
                            Let g = s.tin3
                            Select g).FirstOrDefault
        Return querysection
    End Function

    Public Shared Function fetchtin4(ByVal vendor As String) As Object

        Dim querysection = (From s In db.tblsuppliers
                            Where s.Supplier = vendor
                            Let g = s.tin4
                            Select g).FirstOrDefault
        Return querysection
    End Function

    Public Shared Function fetchatc(ByVal vendor As String) As Object

        Dim querysection = (From s In db.tblsuppliers
                            Where s.Supplier = vendor
                            Let g = s.ATC
                            Select g).FirstOrDefault
        Return querysection
    End Function

    Public Shared Function fetchatcdes(ByVal vendor As String) As Object

        Dim querysection = (From s In db.tblsuppliers
                            Where s.Supplier = vendor
                            Let g = s.ATCdes
                            Select g).FirstOrDefault
        Return querysection
    End Function




    Public Shared Function fetchzip(ByVal vendor As String) As Object

        Dim querysection = (From s In db.tblsuppliers
                            Where s.Supplier = vendor
                            Select s.zipcode).FirstOrDefault
        Return querysection
    End Function



    Public Shared Function fetchqdate(ByVal prfno As String) As Object

        Dim querysection = (From s In db.tblTransDetails
                            Join k In db.tblHeaders On s.HeaderID Equals k.HeaderID
                            Where k.Series = prfno
                            Order By s.Date Descending
                            Select s.Date).FirstOrDefault

        Return querysection

    End Function


    Public Shared Function fetchvoucherregister(ByVal prfno1 As String, ByVal dat1 As Date, ByVal date2 As Date, ByVal status As String) As Object
        Dim rstatus As String
        If status = "All" Then
            rstatus = ""
        Else
            rstatus = status
        End If

        Dim querysection = (From s In db.tblvoucherHeaders
                            Where s.Date >= dat1 AndAlso s.Date <= date2 And (s.PVseries.Contains(prfno1)) And (s.Stat.Contains(rstatus) Or rstatus = "")
                            Select s.Date, s.PVseries, s.Payee, s.encoder, s.Prfno, s.CheckDate, s.Checkno, s.Remarks, s.checkby, s.aprrv, s.id, s.Stat, s.modeofreleasing).ToList
        Return querysection

    End Function

    Public Shared Function fetchvoucherdetail(ByVal headerid As String) As Object

        Dim querysection = (From s In db.tblvoucherdetails
                            Where s.headerid = headerid
                            Select s.Date, s.Prf, s.Bank, s.Checkno, s.Amount, s.Status, s.Status1).ToList
        Return querysection

    End Function


    Public Shared Function checkvatble(ByVal Vendor As String) As Object

        Dim querysection = (From s In db.tblsuppliers
                            Where s.Supplier = Vendor
                            Select s.Vat).FirstOrDefault
        Return querysection

    End Function

    Public Shared Function checkvatble1(ByVal Vendor As String, ByVal series As String) As Object

        Dim querysection = (From s In db.tblHeaders
                            Where s.Payto = Vendor And s.Series = series
                            Order By s.HeaderID Descending
                            Select s.vat).FirstOrDefault
        Return querysection

    End Function


    Public Shared Function FetchUserStat(ByVal name As String) As Object

        Dim querysection = (From s In db.tblusers
                            Where s.Status = 3 And s.name = name
                            Select s.Status).FirstOrDefault
        Return querysection
    End Function

    Public Shared Sub UpdatePVMReleasing(ByVal PVseries As String, ByVal Cdates As Date, ByVal remarks As String)

        Dim Status As String = "Closed"
        Try

            Dim updatemode = (From p In db.GetTable(Of tblvoucherHeader)()
                              Where (p.PVseries = PVseries)
                              Select p).FirstOrDefault()

            With updatemode
                .Confirmeddate = Cdates
                .Remarks = remarks
                .Stat = Status
            End With

            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data. update")
        End Try
    End Sub

    Public Shared Function checkmode(ByVal PVseries As String) As Object
        Dim querysection = (From s In db.tblvoucherHeaders
                            Where s.PVseries = PVseries
                            Select s.modeofreleasing).FirstOrDefault

        Dim naaysulod As Integer
        If querysection Is Nothing Then
            naaysulod = 0
        Else
            naaysulod = 1
        End If

        Return naaysulod
    End Function

    Public Shared Function ChechStatus(ByVal PVseries As String) As Object
        Dim querysection = (From s In db.tblvoucherHeaders
                            Where s.PVseries = PVseries
                            Select s.Stat).FirstOrDefault
        Return querysection
    End Function

    Public Shared Function FetchDataRef(ByVal reference As String, ByVal fromdate As Date, ByVal todate As Date) As Object

        Dim querysection = (From s In db.tblTransDetails
                            Join r In db.tblHeaders On s.HeaderID Equals r.HeaderID
                            Join t In db.tblvoucherHeaders On r.Series Equals t.Prfno
                            Where r.Date >= fromdate AndAlso r.Date <= todate And (s.Ref.Contains(reference) Or t.Checkno.Contains(reference))
                            Select s.Type, s.Ref, r.Date, t.Checkno, t.CheckDate, s.PaymentRelatedto).ToList
        Return querysection

    End Function

    Public Shared Function FetchDataRefDetails(ByVal reference As String) As Object

        Dim querysection = (From s In db.tblTransDetails
                            Join r In db.tblHeaders On s.HeaderID Equals r.HeaderID
                            Join t In db.tblvoucherHeaders On r.Series Equals t.Prfno
                            Join y In db.tblvoucherdetails On t.id Equals y.headerid
                            Where s.Ref.Contains(reference)
                            Let k = t.Date
                            Select s.Type, s.Ref, r.Series, r.Date, t.PVseries, k, s.Amount, t.modeofreleasing, t.Confirmeddate, t.Remarks).ToList
        Return querysection

    End Function

    Public Shared Function FetchDataForPVDetailsmodeofreleasing(ByVal PVseries As String)

        Dim queryResult = (From t In db.tblvoucherHeaders
                           Join y In db.tblvoucherdetails On t.id Equals y.headerid
                           Where t.PVseries = PVseries
                           Select t.modeofreleasing).ToList

        Return queryResult

    End Function

    Public Shared Function FetchDataForPVDetailsremarks(ByVal PVseries As String)

        Dim queryResult = (From t In db.tblvoucherHeaders
                           Join y In db.tblvoucherdetails On t.id Equals y.headerid
                           Where t.PVseries = PVseries
                           Select t.Remarks).ToList

        Return queryResult

    End Function

End Class
