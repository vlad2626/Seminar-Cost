Imports System.IO

Public Class Compute

    Private strFileName As String
    Private numSeminar As Double
    Private numPeople As Double
    Private numRevenue As Double
    Private cCategories As ArrayList
    Private Stats As Stats


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()

    End Sub


    Private Sub openFile()
        Dim intResults As Integer


        ofdOpen.InitialDirectory = Application.StartupPath
        ofdOpen.Filter = "All FIles (*.*)| *.*| Text Files(*.txt) | *.txt"
        ofdOpen.FilterIndex = 2
        ofdOpen.ShowDialog()
        If intResults = DialogResult.Cancel Then
            Exit Sub
        End If

        strFileName = ofdOpen.FileName
        Try
            readInputFile(strFileName)
        Catch ex As Exception

        End Try

    End Sub

#Region "columnn Constants"
    Private Const ID As Integer = 0
    Private Const Subject As Integer = 1
    Private Const Area As Integer = 2
    Private Const Type As Integer = 3
    Private Const Instructor As Integer = 4
    Private Const Length As Integer = 5
    Private Const Location As Integer = 6
    Private Const RoomCapacity As Integer = 7
    Private Const NumberRegistered As Integer = 8


#End Region

    Public Sub readInputFile(strFile As String)
        Dim fileIn As StreamReader
        Dim lineIn As String
        Dim strFields() As String
        Dim i As Integer

        lstInfo.Items.Clear() ' clears anything in the fiels 

        Try
            fileIn = New StreamReader(strFile)
            If Not fileIn.EndOfStream Then
                lineIn = fileIn.ReadLine
                strFields = lineIn.Split(",")

                'loop to gets column headings
                For i = 0 To strFields.Length - 1
                    lstInfo.Columns.Add(strFields(i))
                Next

                With lstInfo
                    .Columns(ID).Width = 80
                    .Columns(Subject).Width = 80
                    .Columns(Area).Width = 80
                    .Columns(Type).Width = 80
                    .Columns(Instructor).Width = 80
                    .Columns(Length).Width = 120
                    .Columns(Location).Width = 80
                    .Columns(RoomCapacity).Width = 120
                    .Columns(NumberRegistered).Width = 80

                End With
            End If

            'get data for each row
            While Not fileIn.EndOfStream
                lineIn = fileIn.ReadLine
                strFields = lineIn.Split(",")
                Dim lviRow As New ListViewItem(strFields(0))

                For i = 1 To strFields.Length - 1 ' change to 1
                    Dim lsiCol As New ListViewItem.ListViewSubItem
                    If i <> ID Then
                        lsiCol.Text = strFields(i)
                    Else
                        lsiCol.Text = FormatCurrency(strFields(i), 0)
                    End If
                    lviRow.SubItems.Add(lsiCol)
                Next
                lstInfo.Items.Add(lviRow)
                'updateStatistics(lviRow)
            End While
            fileIn.Close()




        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub writeOutputFile(strFile As String)
        Dim fileOut As StreamWriter
        Dim strLineOut As String = " "

        Dim i As Integer
        Dim j As Integer

        Try
            fileOut = New StreamWriter(strFile)


            For i = 0 To lstInfo.Columns.Count - 1
                If i <> lstInfo.Columns.Count - 1 Then
                    strLineOut &= lstInfo.Columns(i).Text & ","
                Else
                    strLineOut &= lstInfo.Columns(i).Text
                End If
            Next

            fileOut.WriteLine(strLineOut)

            For i = 0 To lstInfo.Items.Count - 1
                strLineOut = lstInfo.Items(i).Text

                For j = 1 To lstInfo.Items(i).SubItems.Count - 1
                    strLineOut &= "," & lstInfo.Items(i).SubItems(j).Text
                Next
                fileOut.WriteLine(strLineOut)

            Next
            fileOut.Close()
            fileOut.Dispose()

        Catch ex As Exception

        End Try
    End Sub



    ' saves file button
    Public Sub SaveFile()
        Dim intresult As Integer
        sfdSave.InitialDirectory = Application.StartupPath
        sfdSave.Filter = "all FIles (*.*) |*.*| Text files (*.txt)| *.txt"

        sfdSave.FilterIndex = 2
        intresult = sfdSave.ShowDialog

        If intresult = DialogResult.Cancel Then
            Exit Sub
        End If

        strFileName = sfdSave.FileName

        Try
            writeOutputFile(strFileName)
        Catch exNotFound As FileNotFoundException
            ' codes
        Catch exIoError As IOException
            'code
        Catch exOther As Exception
        End Try
    End Sub



    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        openFile()
    End Sub
End Class
