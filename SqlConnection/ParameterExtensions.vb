Imports System.Runtime.CompilerServices

Public Module ParameterExtensions
    <Extension()>
    Public Function AddFromColumn(aParameters As SqlClient.SqlParameterCollection, parameterName As String, sourceColumn As String) As SqlClient.SqlParameter
        Dim NewParam As New SqlClient.SqlParameter

        With NewParam
            .ParameterName = parameterName
            .SourceColumn = sourceColumn
        End With

        Return aParameters.Add(NewParam)
    End Function
End Module
