Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class supplierimport
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

            Using excelConnection As New OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFilePath};Extended Properties='Excel 12.0 Xml;HDR=YES';")
                excelConnection.Open()

                Dim selectQuery As String = "SELECT * FROM [Sheet1$]"

                Using excelCommand As New OleDbCommand(selectQuery, excelConnection)
                    Using excelReader As OleDbDataReader = excelCommand.ExecuteReader()
                        ' Iterate over the records and create SQL INSERT statements

                        'While excelReader.Read()
                        '    Dim tinValue As String = excelReader("tin").ToString()

                        '    ' Split the tinValue based on the "-" delimiter
                        '    Dim tinParts As String() = tinValue.Split("-"c)

                        '    ' Ensure that there are at least four parts
                        '    If tinParts.Length >= 4 Then
                        '        Dim insertQuery As String = "INSERT INTO tblsupplier (Supplier, wtax, terms, tin1, tin2, tin3, tin4, address,zipcode) " &
                        '             "VALUES (@Column1, @Column2, @Column3, @Column4, @Column5, @Column6, @Column7, @Column8,@Column9)"

                        '        Using insertCommand As New SqlCommand(insertQuery, connection)
                        '            ' Set the parameter values based on your Excel file columns
                        '            insertCommand.Parameters.AddWithValue("@Column1", excelReader("Supplier"))
                        '            insertCommand.Parameters.AddWithValue("@Column2", excelReader("wtax"))
                        '            insertCommand.Parameters.AddWithValue("@Column3", excelReader("terms"))
                        '            insertCommand.Parameters.AddWithValue("@Column4", tinParts(0)) ' First part of tin
                        '            insertCommand.Parameters.AddWithValue("@Column5", tinParts(1)) ' Second part of tin
                        '            insertCommand.Parameters.AddWithValue("@Column6", tinParts(2)) ' Third part of tin
                        '            insertCommand.Parameters.AddWithValue("@Column7", tinParts(3)) ' Fourth part of tin
                        '            insertCommand.Parameters.AddWithValue("@Column8", excelReader("address"))
                        '            insertCommand.Parameters.AddWithValue("@Column9", excelReader("zipcode"))

                        '            ' Execute the INSERT statement
                        '            insertCommand.ExecuteNonQuery()
                        '        End Using
                        '    Else
                        '        ' Handle the case where the tin value does not have enough parts
                        '        ' You might want to log this or handle it in a way that fits your requirements
                        '    End If
                        'End While

                        While excelReader.Read()
                            ' Get the tin value from the Excel file
                            Dim tinValue As String = excelReader("tin").ToString()

                            ' Split the tinValue based on the "-" delimiter
                            Dim tinParts As String() = tinValue.Split("-"c)

                            ' Ensure that there are at least four parts or handle the case where tin is blank
                            If tinParts.Length >= 4 Or String.IsNullOrWhiteSpace(tinValue) Then
                                Dim insertQuery As String = "INSERT INTO tblsupplier (Supplier, wtax, terms, tin1, tin2, tin3, tin4, address,zipcode) " &
                                     "VALUES (@Column1, @Column2, @Column3, @Column4, @Column5, @Column6, @Column7, @Column8,@Column9)"

                                Using insertCommand As New SqlCommand(insertQuery, connection)
                                    ' Set the parameter values based on your Excel file columns
                                    insertCommand.Parameters.AddWithValue("@Column1", excelReader("Supplier"))
                                    insertCommand.Parameters.AddWithValue("@Column2", excelReader("wtax"))
                                    insertCommand.Parameters.AddWithValue("@Column3", excelReader("terms"))

                                    If String.IsNullOrWhiteSpace(tinValue) Then
                                        ' Handle the case where tin is blank
                                        insertCommand.Parameters.AddWithValue("@Column4", DBNull.Value)
                                        insertCommand.Parameters.AddWithValue("@Column5", DBNull.Value)
                                        insertCommand.Parameters.AddWithValue("@Column6", DBNull.Value)
                                        insertCommand.Parameters.AddWithValue("@Column7", DBNull.Value)
                                    Else
                                        ' Split the tin value and set parameters accordingly
                                        insertCommand.Parameters.AddWithValue("@Column4", tinParts(0)) ' First part of tin
                                        insertCommand.Parameters.AddWithValue("@Column5", tinParts(1)) ' Second part of tin
                                        insertCommand.Parameters.AddWithValue("@Column6", tinParts(2)) ' Third part of tin
                                        insertCommand.Parameters.AddWithValue("@Column7", tinParts(3)) ' Fourth part of tin
                                    End If

                                    insertCommand.Parameters.AddWithValue("@Column8", excelReader("address"))
                                    insertCommand.Parameters.AddWithValue("@Column9", excelReader("zipcode"))

                                    ' Execute the INSERT statement
                                    insertCommand.ExecuteNonQuery()
                                End Using
                            Else
                                ' Handle the case where the tin value does not have enough parts
                                ' You might want to log this or handle it in a way that fits your requirements
                            End If
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
End Class