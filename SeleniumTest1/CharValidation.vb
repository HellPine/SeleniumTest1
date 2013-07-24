Public Class CharValidation

    Public items As String() = {"First Name", "Last Name", "E-Mail", "Login Name", "Password", "fname", "lname", "email", "login", "password"} 'Declae an array with the fields to select
    Public dbitem, xpath As String 'declare a string that will contain field name in database



    Private Sub CharValidation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim i = 0

        For i = 0 To items.Length - 6

            ComboBox1.Items.Add(items(i))

        Next

        Dim bdt, tdt, udt As New DataTable

        dbconnect()

        sqlstr.Connection = myconex
        sqlstr.CommandText = "select distinct testid from tests where testkind='l1test'"
        myAdapter.SelectCommand = sqlstr
        myAdapter.Fill(bdt)

        If (bdt.Rows.Count) >= 1 Then

            ComboBox2.DataSource = bdt
            ComboBox2.DisplayMember = "testid"

        End If

        sqlstr.Connection = myconex
        sqlstr.CommandText = "select distinct testid from tests where testkind='validation'"
        myAdapter.SelectCommand = sqlstr
        myAdapter.Fill(tdt)

        If (tdt.Rows.Count) >= 1 Then

            ComboBox3.DataSource = tdt
            ComboBox3.DisplayMember = "testid"

        End If

        loading.Close()

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged

        If ComboBox3.Text <> "" Then

            TextBox2.Text = ComboBox3.Text
            
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim bdt As New DataTable

        If ComboBox2.Text <> "" Then

            dbitem = items(Array.IndexOf(items, ComboBox1.Text) + 5)


            sqlstr.Connection = myconex
            sqlstr.CommandText = "select " & dbitem & " from l1test where testid='" & ComboBox2.Text & "'"
            myAdapter.SelectCommand = sqlstr
            myAdapter.Fill(bdt)

            If (bdt.Rows.Count) >= 1 Then

                xpath = bdt.Rows(0).Item(0).ToString
                'MsgBox(xpath)

            Else

                MsgBox("Something went wrong retrieving data", MsgBoxStyle.Critical)

            End If

        Else

            MsgBox("Please select a test where to find the xpath's first", MsgBoxStyle.Exclamation)

        End If

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

        Dim bdt, tdt, udt As New DataTable
        Dim value As String
        Dim values As String() = Nothing
        Dim n As Integer

        If TextBox2.Text <> "" Then


            dbconnect()

            sqlstr.Connection = myconex
            sqlstr.CommandText = "select kind,value from validation where testid='" & TextBox2.Text & "'"
            myAdapter.SelectCommand = sqlstr
            myAdapter.Fill(bdt)

            If (bdt.Rows.Count) >= 1 Then

                Label5.Visible = False
                value = bdt.Rows(0).Item(1).ToString
                values = value.Split("¬")

                TextBox1.Text = ""

                For n = 0 To values.Length - 1

                    TextBox1.Text = TextBox1.Text & Chr(values(n))

                Next

            Else

                Label5.Visible = True

            End If

        Else

            Label5.Visible = False

        End If



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If ComboBox1.Text <> "" Then


            If ComboBox2.Text <> "" Then

                If TextBox2.Text <> "" Then


                    If TextBox1.Text <> "" Then


                        Dim n, ascii As Integer
                        Dim value As String = Nothing
                        Dim character As Char

                        For n = 0 To TextBox1.Text.Length - 1

                            character = TextBox1.Text(n)

                            If character <> "€" Then

                                ascii = Asc(character)

                            Else

                                ascii = 8364

                            End If

                            If value <> "" Then

                                value = value & "¬" & ascii

                            Else

                                value = ascii

                            End If


                        Next

                        dbconnect()

                        Dim bdt, tdt As New DataTable

                        sqlstr.Connection = myconex
                        sqlstr.CommandText = "select * from validation where testid='" & TextBox2.Text & "'"
                        myAdapter.SelectCommand = sqlstr
                        myAdapter.Fill(tdt)

                        If (tdt.Rows.Count >= 1) Then

                            If MsgBox("'" & TextBox2.Text & "' Already exists in the database, do you want to replace it?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then


                                sqlstr.Connection = myconex
                                sqlstr.CommandText = "delete from validation where testid='" & TextBox2.Text & "'"
                                sqlstr.ExecuteNonQuery()

                            End If



                        End If

                        Dim position As String

                        If (Array.IndexOf(items, ComboBox1.Text) <= 3) Then

                            position = "l1s1"

                        Else

                            position = "l1s2"

                        End If

                        sqlstr.Connection = myconex
                        sqlstr.CommandText = "insert into tests(testid,testkind) values('" & TextBox2.Text & "','validation')"
                        sqlstr.ExecuteNonQuery()

                        sqlstr.Connection = myconex
                        sqlstr.CommandText = "insert into validation(testid,kind,value,position,xpath) values('" & TextBox2.Text & "','text','" & value & "','" & position & "','" & xpath & "')"
                        sqlstr.ExecuteNonQuery()

                        MsgBox("Succesfull", MsgBoxStyle.Information)

                        Dim testid As String

                        testid = TextBox2.Text
                        TextBox2.Text = ""
                        TextBox2.Text = testid


                    Else

                        MsgBox("Invalid Characters have to be completed", MsgBoxStyle.Critical)

                    End If

                Else

                    MsgBox("A TestId have to be specified", MsgBoxStyle.Critical)

                End If

            Else

                MsgBox("A Test where to get the Xpath's have to be selected", MsgBoxStyle.Critical)

            End If

        Else

            MsgBox("A field to be tested have to be selected", MsgBoxStyle.Critical)

        End If

    End Sub
End Class