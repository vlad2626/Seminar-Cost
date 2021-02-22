Public Class CCategories

    Private _numSeminar As Double
    Private _numPeople As Double
    Private _numRevenue As Double
    Private _strCatName As String


    Public Sub New(numSeminar As Double, numPeople As Double, numRevenue As Double, strName As String)
        _numSeminar = numSeminar
        _numPeople = numPeople
        _numRevenue = numRevenue
        _strCatName = strName
    End Sub


    Public ReadOnly Property CatName()
        Get
            Return _strCatName
        End Get


    End Property


    Public Property totalRevenue() As Integer
        Get
            Return _numRevenue
        End Get
        Set(intVal As Integer)
            _numRevenue = intVal
        End Set

    End Property
    Public Property totalPeople() As Integer
        Get
            Return _numPeople
        End Get
        Set(intVal As Integer)
            _numPeople = intVal
        End Set

    End Property

    Public Property totalSeminar() As Integer
        Get
            Return _numSeminar
        End Get
        Set(intVal As Integer)
            _numSeminar = intVal
        End Set

    End Property




    ' constructor object

End Class
