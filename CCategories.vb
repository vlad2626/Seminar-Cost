Public Class CCategories
    Private ReadOnly _subject As String
    Private subject As String
    Private area As String
    Private type As String
    Private instructor As String
    Private lenght As Integer
    Private location As String
    Private roomCapacity As Integer
    Private totalRegisters As Integer

    Public Sub New(subject As String, area As String, type As String, instructor As String, lenght As Integer, location As String, roomCapacity As Integer, totalRegisters As Integer)
        Me._subject = subject
        Me.area = area
        Me.type = type
        Me.instructor = instructor
        Me.lenght = lenght
        Me.location = location
        Me.roomCapacity = roomCapacity
        Me.totalRegisters = totalRegisters
    End Sub


    ' constructor object

End Class
