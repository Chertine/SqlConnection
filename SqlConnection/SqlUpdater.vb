Imports PoSApp

Public Class SqlUpdater
    Inherits SqlRetriever

    Public Sub New()
        Me.New("")
    End Sub

    Public Sub New(ByVal connString As String)
        MyBase.New(connString)

        _DataTable = New DataTable
    End Sub

    Public Enum UpdateType
        Insert
        Update
    End Enum

#Region "DataAdapter Interface"
    Public Sub Update(updateType As UpdateType)
        Using DataAdapter As New SqlClient.SqlDataAdapter
            Select Case updateType
                Case UpdateType.Insert
                    DataAdapter.InsertCommand = Command
                Case UpdateType.Update
                    DataAdapter.UpdateCommand = Command
                Case Else
                    Exit Select
            End Select

            If Equals(CommandText, Nothing) Then
                Throw New Exception("Command is not specified.")
            End If

            Connection.Open()
            If Not String.IsNullOrEmpty(DbName) Then
                Connection.ChangeDatabase(DbName)
            Else
                Debug.WriteLine("Database name is not provided. Unless the connection string specified a database, please provide the database name properly.")
            End If

            DataAdapter.Update(DataTable)
            Connection.Close()
        End Using
    End Sub
#End Region
End Class
