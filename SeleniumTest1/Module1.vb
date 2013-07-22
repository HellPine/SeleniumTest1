Imports MySql.Data.MySqlClient




Module Module1

    Public myconex As MySqlConnection
    Public sqlstr As New MySqlCommand
    Public myAdapter As New MySqlDataAdapter


    public connStr As String

    Function dbconnect()

        connStr = "Server=db4free.net;" & _
                "Database=firsttry;" & _
                "Uid=hellpine;" & _
                "Pwd=111111;" & _
                "Connect Timeout=30;"

        myconex = New MySqlConnection(connStr)
        myconex.Open()

    End Function



End Module
