Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class form2
    Private q As New qry
    Public HeaderID As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        openFileDialog.Title = "Select an Excel File"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim dbfFilePath As String = openFileDialog.FileName
            TextBox1.Text = dbfFilePath
        End If
    End Sub


    Private Sub UpdateExcelDataInSQLCash(connectionString As String, excelFilePath As String)
        ' Establish connection to the SQL database
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim series1 As String = "Open"

            Using excelConnection As New OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFilePath};Extended Properties='Excel 12.0 Xml;HDR=YES';")
                excelConnection.Open()

                Dim selectQuery As String = "SELECT * FROM [Sheet1$]"

                Using excelCommand As New OleDbCommand(selectQuery, excelConnection)
                    Using excelReader As OleDbDataReader = excelCommand.ExecuteReader()
                        ' Iterate over the records and create SQL INSERT statements
                        While excelReader.Read()
                            Dim insertQuery As String = "INSERT INTO tblDetail (Type,Date,Num,Name,Memo,Account,Class,Clr,Split,Amount,Balance,HeaderID) " &
                                                "VALUES (@Column3, @Column4, @Column5, @Column6, @Column7, @Column8, @Column9, @Column10, @Column11, @Column12, @Column13,@Column14)"

                            Using insertCommand As New SqlCommand(insertQuery, connection)
                                ' Set the parameter values based on your Excel file columns
                                insertCommand.Parameters.AddWithValue("@Column3", excelReader("Type"))
                                insertCommand.Parameters.AddWithValue("@Column4", excelReader("Date"))
                                insertCommand.Parameters.AddWithValue("@Column5", excelReader("Num"))
                                insertCommand.Parameters.AddWithValue("@Column6", excelReader("Name"))
                                insertCommand.Parameters.AddWithValue("@Column7", excelReader("Memo"))
                                insertCommand.Parameters.AddWithValue("@Column8", excelReader("Account"))
                                insertCommand.Parameters.AddWithValue("@Column9", excelReader("Class"))
                                insertCommand.Parameters.AddWithValue("@Column10", excelReader("Clr"))
                                insertCommand.Parameters.AddWithValue("@Column11", excelReader("Split"))
                                insertCommand.Parameters.AddWithValue("@Column12", excelReader("Amount"))
                                insertCommand.Parameters.AddWithValue("@Column13", excelReader("Balance"))
                                insertCommand.Parameters.AddWithValue("@Column14", series1)

                                ' Execute the INSERT statement
                                insertCommand.ExecuteNonQuery()
                            End Using
                        End While
                    End Using
                End Using

                excelConnection.Close()
            End Using

            connection.Close()
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click



        Dim excelFilePath As String = TextBox1.Text

        If String.IsNullOrEmpty(excelFilePath) Then
            MessageBox.Show("Please select an Excel file.")
            Return
        End If

        Dim connection As New sqlcon()
        Dim sqlConnectionString As String = connection.DBCon.ConnectionString
        ' Name of the SQL Server table to import data into
        UpdateExcelDataInSQLCash(sqlConnectionString, excelFilePath)

        TextBox1.Text = String.Empty
        MessageBox.Show("Successfuly Imported in Database")
    End Sub

    Private Sub form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Public Sub display()

    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub
End Class