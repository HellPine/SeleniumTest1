Public Class Batches

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim bdt, tdt, udt As New DataTable

        dbconnect()

        sqlstr.Connection = myconex
        sqlstr.CommandText = "select distinct batchid from batch"
        myAdapter.SelectCommand = sqlstr
        myAdapter.Fill(bdt)

        If (bdt.Rows.Count) >= 1 Then

            ComboBox1.DataSource = bdt
            ComboBox1.DisplayMember = "batchid"

        End If

        sqlstr.Connection = myconex
        sqlstr.CommandText = "select distinct testid from tests"
        myAdapter.SelectCommand = sqlstr
        myAdapter.Fill(tdt)

        If (tdt.Rows.Count) >= 1 Then

            ComboBox2.DataSource = tdt
            ComboBox2.DisplayMember = "testid"

        End If

        sqlstr.Connection = myconex
        sqlstr.CommandText = "select distinct url from batch"
        myAdapter.SelectCommand = sqlstr
        myAdapter.Fill(udt)

        If (udt.Rows.Count) >= 1 Then

            ComboBox3.DataSource = udt
            ComboBox3.DisplayMember = "url"

        End If
        loading.Hide()
        myconex.Close()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Text = ComboBox1.Text
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        If TextBox1.Text <> "" Then

            Dim dt As New DataTable

            Button4.Visible = True


            dbconnect()

            sqlstr.Connection = myconex
            sqlstr.CommandText = "select batchid,testid,url from batch where batchid='" & TextBox1.Text & "' "
            myAdapter.SelectCommand = sqlstr
            myAdapter.Fill(dt)

            If dt.Rows.Count >= 1 Then

                Label4.Visible = False
                Button4.Text = "Update"

                DataGridView1.DataSource = dt
                DataGridView1.Visible = True

            Else

                DataGridView1.Visible = False
                Button4.Text = "NEW"
                Label4.Visible = True

            End If

        Else

            Button4.Visible = False
            Label4.Visible = False

        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If Button4.Text = "NEW" Then

            dbconnect()

            If TextBox2.Text <> "" Then

                If TextBox3.Text <> "" Then

                    Try

                        sqlstr.Connection = myconex
                        sqlstr.CommandText = "insert into batch(batchid,testid,url) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                        sqlstr.ExecuteNonQuery()

                        MsgBox(TextBox1.Text & " Successfully created", MsgBoxStyle.Information)

                    Catch ex As Exception

                        MsgBox(ex.Message, MsgBoxStyle.Critical)

                    End Try

                Else

                    MsgBox("No URL is selected", MsgBoxStyle.Critical)

                End If

            Else

                MsgBox("No TestId to insert in batch", MsgBoxStyle.Critical)

            End If

            Dim testid As String
            testid = TextBox1.Text
            TextBox1.Text = ""
            TextBox1.Text = testid

            myconex.Close()

        Else

            If TextBox2.Text <> "" Then

                If TextBox3.Text <> "" Then


                    dbconnect()

                    Try

                        sqlstr.Connection = myconex
                        sqlstr.CommandText = "delete from batch where batchid=('" & TextBox1.Text & "')"
                        sqlstr.ExecuteNonQuery()

                        Dim n, i As Integer

                        n = DataGridView1.Rows.Count - 2

                        For i = 0 To n

                            sqlstr.Connection = myconex
                            sqlstr.CommandText = "insert into batch(batchid,testid,url) values('" & TextBox1.Text & "','" & DataGridView1.Rows(i).Cells(1).Value.ToString & "','" & TextBox3.Text & "')"
                            sqlstr.ExecuteNonQuery()

                        Next i

                        MsgBox(TextBox1.Text & " Successfully updated", MsgBoxStyle.Information)

                    Catch ex As Exception

                        MsgBox(ex.Message, MsgBoxStyle.Critical)

                    End Try

                    myconex.Close()

                Else

                    MsgBox("No URL is selected", MsgBoxStyle.Critical)

                End If

            Else

                MsgBox("No TestId to insert in batch", MsgBoxStyle.Critical)

            End If

            Dim testid As String
            testid = TextBox1.Text
            TextBox1.Text = ""
            TextBox1.Text = testid


        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        TextBox2.Text = ComboBox2.Text
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        TextBox3.Text = ComboBox3.Text
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox2.Text <> "" Then
            If TextBox1.Text <> "" Then
                If TextBox3.Text <> "" Then


                    Dim adt As New DataTable
                    Dim dt As New DataTable

                    dbconnect()

                    sqlstr.Connection = myconex
                    sqlstr.CommandText = "select testid from batch where batchid='" & TextBox1.Text & "' and testid='" & TextBox2.Text & "' "
                    myAdapter.SelectCommand = sqlstr
                    myAdapter.Fill(adt)

                    If adt.Rows.Count <= 0 Then

                        Try


                            sqlstr.Connection = myconex
                            sqlstr.CommandText = "insert into batch(batchid,testid,url) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                            sqlstr.ExecuteNonQuery()

                            sqlstr.Connection = myconex
                            sqlstr.CommandText = "select batchid,testid,url from batch where batchid='" & TextBox1.Text & "' "
                            myAdapter.SelectCommand = sqlstr
                            sqlstr.ExecuteNonQuery()
                            myAdapter.Fill(dt)


                            If dt.Rows.Count >= 1 Then

                                DataGridView1.Visible = True
                                DataGridView1.DataSource = dt

                            Else

                                DataGridView1.Visible = False

                            End If

                            Dim testid As String
                            testid = TextBox1.Text
                            TextBox1.Text = ""
                            TextBox1.Text = testid


                            'dt.Clear()
                            'adt.Clear()

                        Catch ex As Exception

                            MsgBox(ex.Message, MsgBoxStyle.Critical)

                        End Try

                    Else

                        MsgBox("Selected Test Id is already in the batch", MsgBoxStyle.Critical)

                    End If

                Else

                    MsgBox("No URL Selected", MsgBoxStyle.Critical)

                End If

            Else

                MsgBox("No Batch Id Selected", MsgBoxStyle.Critical)

            End If

        Else

            MsgBox("No Test Id to ADD", MsgBoxStyle.Critical)

        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        'MsgBox(DataGridView1.CurrentCell.Value.ToString)

    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved



    End Sub

    Private Sub DataGridView1_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView1.UserDeletedRow


    End Sub

    Private Sub DataGridView1_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow

        If TextBox2.Text <> "" Then

            If TextBox3.Text <> "" Then


                dbconnect()

                Try

                    MsgBox(TextBox1.Text & "    " & DataGridView1.CurrentRow.Cells(1).Value.ToString)
                    sqlstr.Connection = myconex
                    sqlstr.CommandText = "delete from batch where batchid=('" & TextBox1.Text & "' AND testid='" & DataGridView1.CurrentRow.Cells(1).Value.ToString & "')"
                    sqlstr.ExecuteNonQuery()


                    MsgBox("Row Deleted", MsgBoxStyle.Information)

                Catch ex As Exception

                    MsgBox(ex.Message, MsgBoxStyle.Critical)

                End Try

                myconex.Close()

            Else

                MsgBox("No URL is selected", MsgBoxStyle.Critical)

            End If

        Else

            MsgBox("No TestId to insert in batch", MsgBoxStyle.Critical)

        End If

        Dim testid As String
        testid = TextBox1.Text
        TextBox1.Text = ""
        TextBox1.Text = testid

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim bid, tid As String
        Dim dt As New DataTable
        bid = DataGridView1.CurrentRow.Cells(0).Value.ToString
        tid = DataGridView1.CurrentRow.Cells(1).Value.ToString
        If bid <> "" Then

            Try

                dbconnect()
                sqlstr.Connection = myconex
                sqlstr.CommandText = "delete from batch where batchid='" & bid & "' and testid='" & tid & "'"
                sqlstr.ExecuteNonQuery()

                sqlstr.Connection = myconex
                sqlstr.CommandText = "select batchid,testid,url from batch where batchid='" & TextBox1.Text & "' "
                myAdapter.SelectCommand = sqlstr
                sqlstr.ExecuteNonQuery()
                myAdapter.Fill(dt)

                If dt.Rows.Count >= 1 Then

                    DataGridView1.Visible = True
                    DataGridView1.DataSource = dt

                Else

                    DataGridView1.Visible = False

                End If


                Dim baid As String
                baid = TextBox1.Text
                TextBox1.Text = ""
                TextBox1.Text = baid
                dt.Clear()
                myconex.Close()


            Catch ex As Exception

                MsgBox(ex.Message, MsgBoxStyle.Critical)

            End Try

        End If


        'MsgBox(DataGridView1.CurrentRow.Cells(0).Value.ToString)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        If TextBox1.Text <> "" Then

            Try

                dbconnect()

                sqlstr.Connection = myconex
                sqlstr.CommandText = "delete from gotest"
                sqlstr.ExecuteNonQuery()

                sqlstr.Connection = myconex
                sqlstr.CommandText = "insert into gotest(batchid) values('" & TextBox1.Text & "')"
                sqlstr.ExecuteNonQuery()

                REM MsgBox("GOTEST")

                myconex.Close()

                REM Process.Start("c:\pruebajava\selsql.jar", "nothing")
                Process.Start("C:\Program Files (x86)\apache-maven-3.1.0\bin\mvn.bat", "clean test -f C:\Users\dprado\workspace\selqlmaven\pom.xml -Dtotest=nothing")


            Catch ex As Exception

                MsgBox(ex.Message, MsgBoxStyle.Critical)

            End Try

        End If



    End Sub

    Private Sub TextBox3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.DoubleClick
        TextBox3.SelectAll()
    End Sub

    Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus



    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TextBox1.Text <> "" Then

            Try

                dbconnect()

                sqlstr.Connection = myconex
                sqlstr.CommandText = "delete from gotest"
                sqlstr.ExecuteNonQuery()

                sqlstr.Connection = myconex
                sqlstr.CommandText = "insert into gotest(batchid) values('" & TextBox1.Text & "')"
                sqlstr.ExecuteNonQuery()

                REM MsgBox("GOTEST")

                myconex.Close()

                REM Process.Start("c:\pruebajava\selsql.jar", "nothing")
                REM Process.Start("C:\Program Files (x86)\apache-maven-3.1.0\bin\mvn.bat", "clean test -f C:\Users\dprado\workspace\selqlmaven\pom.xml -Dtotest=nothing")
                MsgBox("Now you can build project in Jenkins", MsgBoxStyle.Information)


            Catch ex As Exception

                MsgBox(ex.Message, MsgBoxStyle.Critical)

            End Try

        End If

    End Sub
End Class