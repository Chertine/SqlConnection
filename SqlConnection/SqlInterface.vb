Public Class SqlInterface
    Implements IDisposable

    Private _Connection As SqlClient.SqlConnection
    Private _Command As SqlClient.SqlCommand

    Protected ReadOnly Property Connection As SqlClient.SqlConnection
        Get
            Return _Connection
        End Get
    End Property

    Protected ReadOnly Property Command As SqlClient.SqlCommand
        Get
            Return _Command
        End Get
    End Property

    Public Property CommandText As String
        Get
            Return _Command.CommandText
        End Get
        Set(value As String)
            _Command.CommandText = value
        End Set
    End Property

    Public Property ConnectionString As String
        Get
            Return _Connection.ConnectionString
        End Get
        Set(value As String)
            _Connection.ConnectionString = value
        End Set
    End Property

    Public ReadOnly Property Parameters As SqlClient.SqlParameterCollection
        Get
            Return _Command.Parameters
        End Get
    End Property

    Public Sub New()
        Me.New("")
    End Sub

    Public Sub New(ByVal connString As String)
        _Connection = New SqlClient.SqlConnection(connString)

        If Not String.IsNullOrEmpty(connString) Then
            Try
                _Connection.Open()
            Catch ex As Exception
                Throw New Exception("Connection refused with the specified connection string.")
            Finally
                _Connection.Close()
            End Try
        End If

        _Command = New SqlClient.SqlCommand
        _Command.Connection = _Connection
        _Command.CommandType = CommandType.Text
    End Sub

    Public Function ExecuteNonQuery() As Integer
        Return _Command.ExecuteNonQuery()
    End Function

    Public Sub ChangeDatabase(dbName As String)
        _Connection.ChangeDatabase(dbName)
    End Sub

    Public Sub Open()
        _Connection.Open()
    End Sub

    Public Sub Close()
        _Connection.Close()
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                _Connection.Dispose()
                _Command.Dispose()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
