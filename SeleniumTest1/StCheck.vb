Imports System
imports System.IO 

Public Class StCheck

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt, at As New DataTable

        dbconnect()

        Try


            sqlstr.Connection = myconex
            sqlstr.CommandText = "select distinct testkind from testkind"
            myAdapter.SelectCommand = sqlstr
            myAdapter.Fill(dt)

            If (dt.Rows.Count) >= 1 Then

                ComboBox1.DataSource = dt
                ComboBox1.DisplayMember = "testkind"

            End If

            sqlstr.Connection = myconex
            sqlstr.CommandText = "select distinct testid from tests"
            myAdapter.SelectCommand = sqlstr
            myAdapter.Fill(at)

            If (at.Rows.Count) >= 1 Then

                ComboBox2.DataSource = at
                ComboBox2.DisplayMember = "testid"

            End If


            TextBox2.Text = ""



        Catch ex As Exception

            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)

        End Try

        loading.Hide()
        myconex.Close()

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)






    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Button1.Text = "NEW" Then

            If (MsgBox("TEST ID " & TextBox1.Text & " will be created", MsgBoxStyle.OkCancel)) = 1 Then

                dbconnect()

                sqlstr.Connection = myconex
                sqlstr.CommandText = "insert into tests(testid,testkind) values('" & TextBox1.Text & "','" & TextBox1.Text & "_testkind')"
                sqlstr.ExecuteNonQuery()
                sqlstr.CommandText = "insert into linktofind(testid,tofind) values('" & TextBox1.Text & "','Changethis')"
                sqlstr.ExecuteNonQuery()
                sqlstr.CommandText = "insert into inlinks(testid,inlink,linkverify) values('" & TextBox1.Text & "','Changethis','changethis')"
                sqlstr.ExecuteNonQuery()
                sqlstr.CommandText = "insert into tofindin(testid,xpath,tofind) values('" & TextBox1.Text & "','Changethis','changethis')"
                sqlstr.ExecuteNonQuery()

                If TextBox2.Text = "" Then

                    sqlstr.CommandText = "insert into testkind(testkind,inlink) values('" & TextBox1.Text & "_testkind',false)"
                    sqlstr.ExecuteNonQuery()

                Else

                    sqlstr.CommandText = "insert into testkind(testkind,inlink) values('" & TextBox2.Text & "',false)"
                    sqlstr.ExecuteNonQuery()

                End If

                sqlstr.CommandText = "insert into tofindin(testid,xpath,tofind) values('" & TextBox1.Text & "','changethis','changethis')"
                sqlstr.ExecuteNonQuery()

                Dim testid As String
                testid = TextBox1.Text
                TextBox1.Text = ""
                TextBox1.Text = testid

                myconex.Close()

            End If

        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        TextBox2.Text = ComboBox1.Text

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        REM MsgBox(DataGridView1.Rows(0).Cells(0).Value.ToString)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged

        TextBox1.Text = ComboBox2.Text

    End Sub

    Private Sub TextBox1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        If TextBox1.Text <> "" Then

            Dim dt As New DataTable
            Dim mldt, ttfdt, inldt, tkdt As New DataTable

            Button1.Visible = True


            dbconnect()

            sqlstr.Connection = myconex
            sqlstr.CommandText = "select testid,testkind from tests where testid='" & TextBox1.Text & "' and testkind='single' or testkind='inlink'"
            myAdapter.SelectCommand = sqlstr
            myAdapter.Fill(dt)

            If dt.Rows.Count >= 1 Then

                DataGridView1.Visible = True
                Button1.Visible = False
                Label2.Visible = False
                sqlstr.Connection = myconex
                sqlstr.CommandText = "select tofind from linktofind where testid='" & TextBox1.Text & "' "
                myAdapter.SelectCommand = sqlstr
                myAdapter.Fill(mldt)

                DataGridView1.DataSource = mldt

                sqlstr.Connection = myconex
                sqlstr.CommandText = "select inlink from testkind where testkind='" & dt.Rows(0).Item(1) & "' "
                myAdapter.SelectCommand = sqlstr
                myAdapter.Fill(tkdt)


                TextBox2.Text = dt.Rows(0).Item(1)

                If tkdt.Rows.Count >= 1 Then



                    If tkdt.Rows(0).Item(0) = 0 Then

                        DataGridView2.Visible = True
                        sqlstr.Connection = myconex
                        sqlstr.CommandText = "select xpath,tofind from tofindin where testid='" & TextBox1.Text & "' "
                        myAdapter.SelectCommand = sqlstr
                        myAdapter.Fill(ttfdt)
                        DataGridView2.DataSource = ttfdt

                    Else

                        DataGridView3.Visible = True
                        sqlstr.Connection = myconex
                        sqlstr.CommandText = "select inlink,linkverify from inlinks where testid='" & TextBox1.Text & "' "
                        myAdapter.SelectCommand = sqlstr
                        myAdapter.Fill(inldt)
                        DataGridView3.DataSource = inldt


                    End If

                End If

            Else


                DataGridView1.Visible = False
                DataGridView2.Visible = False
                DataGridView3.Visible = False
                TextBox2.Text = ""
                Button1.Text = "NEW"
                Label2.Visible = True

            End If


            myconex.Close()
        Else

            Button1.Visible = False
            Label2.Visible = False

        End If

    End Sub

    Private Sub DataGridView3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        If TextBox3.Text <> "" Then

            If TextBox4.Text <> "" Then

                'Process.Start("c:\pruebajava\selsql.jar", "getcode " & TextBox3.Text & " " & TextBox4.Text)
                Process.Start("C:\Program Files (x86)\apache-maven-3.1.0\bin\mvn.bat", "clean test -f C:\Users\dprado\workspace\selqlmaven\pom.xml -Dtotest=getcode -Durl=" & TextBox3.Text & " -Dxpath=" & TextBox4.Text)

            Else

                'Process.Start("c:\pruebajava\selsql.jar", "getcode " & TextBox3.Text)
                Process.Start("C:\Program Files (x86)\apache-maven-3.1.0\bin\mvn.bat", "clean test -f C:\Users\dprado\workspace\selqlmaven\pom.xml -Dtotest=getcode -Durl=" & TextBox3.Text)

            End If

        Else

            MsgBox("URL is needed", MsgBoxStyle.Critical)

        End If

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If TextBox4.Text <> "" Then

            If RichTextBox1.Text <> "" Then

                Dim text As String

                text = RichTextBox1.Text
                text = text.Replace("'", "¬")
                text = text.Replace(vbCr, "сс") '.Replace(vbLf, "<>")
                Dim count As Integer = 0
                'Dim sr As stringreader = New stringreader(text)




                text = text.Replace(Space(2), Space(1))

                For j As Integer = 0 To text.Length - 1

                    If text.Chars(j) = " " And count >= 100 Then

                        text = text.Insert(j, "сс")
                        count = 0

                    End If

                    count = count + 1

                Next j

                text = text.Replace("сссссссс", "сс")
                text = text.Replace("сссссс", "сс")
                text = text.Replace("сссс", "сс")
                'text = text.Replace("сссс", "сс")
                text = text.Replace("сс ", "сс")
                text = text.Replace(" сс", "сс")
                '   text = text.Replace("(", "")
                '  text = text.Replace(")", "")


                Dim xpath As String
                dbconnect()
                xpath = TextBox4.Text.Replace("'", "¬")
                sqlstr.Connection = myconex
                sqlstr.CommandText = "insert into tofindin(testid,xpath,tofind) values('" & TextBox1.Text & "','" & xpath & "','" & Text & "')"
                sqlstr.ExecuteNonQuery()
                myconex.Close()
                Dim testid As String
                testid = TextBox1.Text
                TextBox1.Text = ""
                TextBox1.Text = testid


            Else

                MsgBox("Text to find is required", MsgBoxStyle.Critical)

            End If


        Else

            MsgBox("XPATH is required", MsgBoxStyle.Critical)

        End If
    End Sub

    Private Sub TextBox4_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox4.MouseDoubleClick
        TextBox3.SelectAll()
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox3_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox3.MouseDoubleClick
        TextBox3.SelectAll()
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim bid, tid As String
        Dim dt As New DataTable
        bid = TextBox1.Text
        tid = DataGridView2.CurrentRow.Cells(0).Value.ToString
        If bid <> "" Then

            Try

                dbconnect()
                sqlstr.Connection = myconex
                'MsgBox(bid & "       " & tid)
                sqlstr.CommandText = "delete from tofindin where testid='" & bid & "' and xpath='" & tid & "'"
                sqlstr.ExecuteNonQuery()

                sqlstr.Connection = myconex
                sqlstr.CommandText = "select testid,xpath,tofind from tofindin where testid='" & bid & "' "
                myAdapter.SelectCommand = sqlstr
                sqlstr.ExecuteNonQuery()
                myAdapter.Fill(dt)

                If dt.Rows.Count >= 1 Then

                    DataGridView2.Visible = True
                    DataGridView2.DataSource = dt

                Else

                    DataGridView2.Visible = False

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
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim tid As String
        Dim n As Integer
        Dim dt As New DataTable

        tid = TextBox1.Text

        'MsgBox(DataGridView1.Rows(0).Cells(0).Value.ToString)

        dbconnect()
        sqlstr.Connection = myconex
        'MsgBox(bid & "       " & tid)
        sqlstr.CommandText = "delete from linktofind where testid='" & tid & "'"
        sqlstr.ExecuteNonQuery()



        For n = 0 To DataGridView1.Rows.Count - 2

            sqlstr.CommandText = "insert into linktofind(testid,tofind) values('" & tid & "','" & DataGridView1.Rows(n).Cells(0).Value.ToString & "')"
            sqlstr.ExecuteNonQuery()

        Next

        sqlstr.Connection = myconex
        sqlstr.CommandText = "select tofind from linktofind where testid='" & tid & "' "
        myAdapter.SelectCommand = sqlstr
        sqlstr.ExecuteNonQuery()
        myAdapter.Fill(dt)

        If dt.Rows.Count >= 1 Then

            DataGridView1.Visible = True
            DataGridView1.DataSource = dt

        Else

            DataGridView1.Visible = False

        End If




    End Sub
End Class