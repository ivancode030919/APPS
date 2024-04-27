Imports System.Drawing.Printing

Public Class Form5
    Public WhatForm As Integer
    Public sesries As String = ""
    Public d As Integer = 0
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.ReportViewer1.RefreshReport()
            Dim pageSettings As New System.Drawing.Printing.PageSettings()
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            If d = 1 Then


                pageSettings.PaperSize = New PaperSize("CustomSize", 850, 1300) ' Adjust the width and height as needed
                pageSettings.Landscape = False
                pageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
                ReportViewer1.SetPageSettings(pageSettings)
                ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
                ReportViewer1.ZoomPercent = 100
                ' Optionally, you can refresh the report if needed
                ReportViewer1.RefreshReport()
                Me.ReportViewer1.RefreshReport()

            Else


                pageSettings.Landscape = False ' Set to True for landscape orientation
                pageSettings.Margins = New System.Drawing.Printing.Margins(15, 15, 15, 15) ' 0.5 inches on all sides
                ReportViewer1.SetPageSettings(pageSettings)
                ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
                ReportViewer1.ZoomPercent = 100
                ' Optionally, you can refresh the report if needed
                ReportViewer1.RefreshReport()
                Me.ReportViewer1.RefreshReport()

            End If
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Form5_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.ReportViewer1.RefreshReport()
        Me.Dispose()
    End Sub

    Private Sub Form5_MinimumSizeChanged(sender As Object, e As EventArgs) Handles MyBase.MinimumSizeChanged
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Form5_MaximumSizeChanged(sender As Object, e As EventArgs) Handles MyBase.MaximumSizeChanged
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_Print(sender As Object, e As Microsoft.Reporting.WinForms.ReportPrintEventArgs) Handles ReportViewer1.Print

        If WhatForm = 1 Then
            q.updatePRFPrintStat(sesries)
        ElseIf WhatForm = 2 Then
            q.updateVoucherPrintStat(sesries)
        ElseIf WhatForm = 3 Then
            'wala pa ni diria gin ready ko lang
        End If

        Me.Hide()

    End Sub

    Private Sub Form5_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class