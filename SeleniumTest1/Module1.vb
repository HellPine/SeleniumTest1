Imports MySql.Data.MySqlClient




Module Module1

    Public myconex As MySqlConnection
    Public sqlstr As New MySqlCommand
    Public myAdapter As New MySqlDataAdapter


    public connStr As String

    Function dbconnect()

        connStr = "Server=192.168.100.214;" & _
                "Database=automation_dev;" & _
                "Uid=daniel;" & _
                "Pwd=daniel;" & _
                "Connect Timeout=30;"

        myconex = New MySqlConnection(connStr)
        myconex.Open()

    End Function



End Module
