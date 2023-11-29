''' <summary>
''' Templated class to do connection with sql server
''' </summary>
Public Class SqlRetriever
    Inherits SqlInterface

    Protected _DataTable As DataTable

    Public DbName As String

    Public ReadOnly Property DataTable As DataTable
        Get
            Return _DataTable
        End Get
    End Property

    Public Sub New()
        Me.New("")
    End Sub

    Public Sub New(ByVal connString As String)
        MyBase.New(connString)

        _DataTable = New DataTable
    End Sub

#Region "DataAdapter Interface"
    ' Fills
    Public Sub Retrieve()
        Using DataAdapter As New SqlClient.SqlDataAdapter
            DataAdapter.SelectCommand = Command

            If Equals(Command, Nothing) Then
                Throw New Exception("Select command is not specified.")
            End If

            Connection.Open()

            If Not String.IsNullOrEmpty(DbName) Then
                Connection.ChangeDatabase(DbName)
            Else
                Debug.WriteLine("Database name is not provided. Unless the connection string specified a database, please provide the database name properly.")
            End If

            DataAdapter.Fill(DataTable)
            Connection.Close()
        End Using
    End Sub

#End Region
End Class
