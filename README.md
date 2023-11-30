# SqlConnection

Simple (Visual Basic) template classes for using ASP's SqlClient.SqlConnection.

This templates the process where you would usually do something like:

```vb
Using Conn As New SqlClient.SqlConnection
  With Conn
    .ConnectionString = "[Put connection string here]"
  End With
  Using Cmd As New SqlClient.SqlCommand
    With Cmd
      .Connection = Conn
      .CommandType = ConnectionType.Text
      .CommandText = "[Put an sql query here]"
    End With
  End Using
End Using
```

To a shorter:

```vb
Using SqlConn As New SqlInterface
    With SqlConn
        .ConnectionString = "[Put connection string here]"
        .CommandText = "[Put an sql query here]"
    End With
End Using
```

As of the current version, the tempate supports the following properties:

1. SqlInterface:

    - **Property** ConnectionString
        
        The ConnectionString property of the SqlClient.SqlConnection class.

    - **Property** CommandText
        
        The CommandText property of the SqlClient.SqlCommand class.

    - **Property** Parameters
        
        The Parameters property of the SqlClient.SqlCommand class.
        
2. SqlRetriever (Inherits from SqlInterface):

    - **Property** DataTable
        
        A DataTable to be used for interaction with the database.

    - **Method** Retrieve()
        
        An interface of DataAdapter.Fill() that will be used on the DataTable property.
        
3. SqlUpdater (Inherits from SqlRetriever):

    - **Method** Update(UpdateType)
        
        An interface of DataAdapter.Update() that will execute either insert query or update query depends on the specified UpdateType.

In addition, this template provides an extension to SqlClient.SqlParameterCollection which allows you to do:

```vb
Paramaters.AddFromColumn(ParameterName, ColumnName)
```
