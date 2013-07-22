Public Class Singlerun



    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim col As New DataGridViewTextBoxColumn
        col.DataPropertyName = "URL"
        col.HeaderText = "URL"
        col.Name = "URL"
        DataGridView1.Columns.Add(col)

        Dim bdt, tdt, udt As New DataTable

        dbconnect()

        sqlstr.Connection = myconex
        sqlstr.CommandText = "select distinct testid from tests"
        myAdapter.SelectCommand = sqlstr
        myAdapter.Fill(bdt)

        If (bdt.Rows.Count) >= 1 Then

            ComboBox1.DataSource = bdt
            ComboBox1.DisplayMember = "testid"

        End If

        sqlstr.Connection = myconex
        sqlstr.CommandText = "select distinct url from url"
        myAdapter.SelectCommand = sqlstr
        myAdapter.Fill(tdt)

        If (tdt.Rows.Count) >= 1 Then

            ComboBox2.DataSource = tdt
            ComboBox2.DisplayMember = "url"

        End If
        loading.Hide()
        myconex.Close()

    End Sub

    Public Sub ShellandWait(ByVal ProcessPath As String, ByVal args As String)
        Dim objProcess As System.Diagnostics.Process
        Try
            objProcess = New System.Diagnostics.Process()
            objProcess.StartInfo.FileName = ProcessPath
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            objProcess.StartInfo.Arguments = args
            objProcess.Start()

            'Wait until the process passes back an exit code 
            objProcess.WaitForExit()

            'Free resources associated with this process
            objProcess.Close()
        Catch
            MessageBox.Show("Could not start process " & ProcessPath, "Error")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim n As Integer

        Dim bdt, tdt, udt As New DataTable

        If DataGridView1.Rows.Count >= 1 Then

            dbconnect()


            For n = 0 To DataGridView1.Rows.Count - 2


                sqlstr.Connection = myconex
                sqlstr.CommandText = "delete from batch where batchid='straight'"
                sqlstr.ExecuteNonQuery()
                sqlstr.CommandText = "insert into batch(batchid,testid,url) values('straight','" & ComboBox1.Text & "','" & DataGridView1.Rows(n).Cells(0).Value.ToString & "')"
                sqlstr.ExecuteNonQuery()
                sqlstr.CommandText = "delete from gotest"
                sqlstr.ExecuteNonQuery()
                sqlstr.CommandText = "insert into gotest(batchid) values('straight')"
                sqlstr.ExecuteNonQuery()

                'Process.Start("c:\pruebajava\selsql.jar", "nothing")
                ShellandWait("C:\Program Files (x86)\apache-maven-3.1.0\bin\mvn.bat", "clean test -f C:\Users\dprado\workspace\selqlmaven\pom.xml -Dtotest=nothing")
                'Process.Start("C:\Program Files (x86)\apache-maven-3.1.0\bin\mvn.bat", "clean test -f C:\Users\dprado\workspace\selqlmaven\pom.xml -Dtotest=nothing")

            Next

            myconex.Close()

        Else

            MsgBox("There is no URL to test", MsgBoxStyle.Critical)

        End If

    End Sub

    Private Sub TextBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        TextBox1.SelectAll()

    End Sub






    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim bdt, tdt, udt As New DataTable
        Dim url As String
        url = TextBox1.Text.Replace(" ", String.Empty)


        If TextBox1.Text.Trim <> "" And TextBox1.Text.StartsWith("http://") Then

            Dim n, s As Integer

            s = 0

            If DataGridView1.Rows.Count >= 1 Then

                For n = 0 To DataGridView1.Rows.Count - 2


                    If DataGridView1.Rows(n).Cells(0).Value.ToString = TextBox1.Text Then s = 1

                Next

            End If

            If s = 0 Then

                dbconnect()

                sqlstr.Connection = myconex
                sqlstr.CommandText = "select distinct url from url where url='" & TextBox1.Text & "'"
                myAdapter.SelectCommand = sqlstr
                myAdapter.Fill(tdt)

                If (tdt.Rows.Count) <= 0 Then

                    sqlstr.Connection = myconex
                    sqlstr.CommandText = "insert into url(url) values('" & TextBox1.Text & "')"
                    sqlstr.ExecuteNonQuery()

                End If


                myconex.Close()

                DataGridView1.Rows.Add(url)
                TextBox1.Text = ""



            Else

                MsgBox("This URL is already in use", MsgBoxStyle.Information)
                TextBox1.Text = ""

            End If

        Else

            MsgBox("URL Field is either blank or invalid, remember that url must starts with 'http://'", MsgBoxStyle.Exclamation)
            TextBox1.Text = ""


        End If


    End Sub

    Private Sub ComboBox2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedValueChanged

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim bdt, tdt, udt As New DataTable

        If TextBox1.Text.Trim <> "" Then

            dbconnect()

            sqlstr.Connection = myconex
            sqlstr.CommandText = "select distinct url from url where url like '%" & TextBox1.Text & "%'"
            myAdapter.SelectCommand = sqlstr
            myAdapter.Fill(tdt)

            If (tdt.Rows.Count) >= 1 Then

                ComboBox2.DataSource = tdt
                ComboBox2.DisplayMember = "url"

            Else

                ComboBox1.Text = ""

            End If

            myconex.Close()

        Else


            dbconnect()

            sqlstr.Connection = myconex
            sqlstr.CommandText = "select distinct url from url"
            myAdapter.SelectCommand = sqlstr
            myAdapter.Fill(bdt)

            If (bdt.Rows.Count) >= 1 Then

                ComboBox2.DataSource = bdt
                ComboBox2.DisplayMember = "url"

            End If

            myconex.Close()

        End If
    End Sub

    Private Sub ComboBox2_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectionChangeCommitted
        TextBox1.Text = ComboBox2.Text
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class