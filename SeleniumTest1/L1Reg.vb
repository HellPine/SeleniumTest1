Public Class L1Reg

    Private Sub L1Reg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim bdt, tdt, udt As New DataTable

        dbconnect()

        sqlstr.Connection = myconex
        sqlstr.CommandText = "select distinct testid from tests where testkind='l1test'"
        myAdapter.SelectCommand = sqlstr
        myAdapter.Fill(bdt)

        If (bdt.Rows.Count) >= 1 Then

            ComboBox1.DataSource = bdt
            ComboBox1.DisplayMember = "testid"

        End If


        myconex.Close()
        loading.Hide()

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        Dim bdt, tdt, udt As New DataTable

        If TextBox1.Text <> "" Then


            dbconnect()

            sqlstr.Connection = myconex
            sqlstr.CommandText = "select link,fname,lname,email,day,month,year,next,eighteen,accept,login,password,fun,realbutton from l1test where testid='" & TextBox1.Text & "'"
            myAdapter.SelectCommand = sqlstr
            myAdapter.Fill(bdt)

            If (bdt.Rows.Count) >= 1 Then

                Dim n As Integer
                Label1.Visible = False
                Button1.Visible = False

                For Each cntrl As Control In GroupBox2.Controls

                    If TypeOf cntrl Is TextBox Then

                        cntrl.Text = bdt.Rows(0).Item(n)
                        cntrl.BackColor = Color.White
                        n = n + 1
                        GroupBox2.Enabled = True


                    End If

                Next




            Else

                Label1.Visible = True
                Button1.Visible = True
                GroupBox2.Enabled = False

            End If


            myconex.Close()
            loading.Hide()

        Else

            Label1.Visible = False
            Button1.Visible = False

        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.Text <> "" Then

            TextBox1.Text = ComboBox1.Text


        End If



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.Text <> "" Then


            GroupBox2.Enabled = True


        Else

            MsgBox("TEST ID could not be in blank", MsgBoxStyle.Critical)

        End If


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        If (MsgBox("Are you sure to cancel data entry?", MsgBoxStyle.OkCancel) = 1) Then

            For Each cntrl As Control In GroupBox2.Controls

                If TypeOf cntrl Is TextBox Then

                    cntrl.Text = ""
                    cntrl.BackColor = Color.White


                End If

            Next


            GroupBox2.Enabled = False


        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim ok As Integer

        ok = 0

        For Each cntrl As Control In GroupBox2.Controls

            If TypeOf cntrl Is TextBox Then

                If cntrl.Text = "" Then


                    ok = 1
                    cntrl.BackColor = Color.Red


                End If

            End If

        Next

        If ok = 0 Then

            dbconnect()

            For Each cntrl As Control In GroupBox2.Controls

                If TypeOf cntrl Is TextBox Then

                    cntrl.Text = cntrl.Text.Replace("'", "¬")
                    'xpath = TextBox4.Text.Replace("'", "¬")

                End If

            Next

            sqlstr.Connection = myconex
            sqlstr.CommandText = "insert into tests(testid,testkind) values('" & TextBox1.Text & "','l1test')"
            sqlstr.ExecuteNonQuery()

            sqlstr.Connection = myconex
            sqlstr.CommandText = "insert into l1test(testid,link,fname,lname,email,day,month,year,next,eighteen,accept,login,password,fun,realbutton) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox11.Text & "','" & TextBox12.Text & "','" & TextBox13.Text & "','" & TextBox14.Text & "','" & TextBox15.Text & "')"
            sqlstr.ExecuteNonQuery()


            For Each cntrl As Control In GroupBox2.Controls

                If TypeOf cntrl Is TextBox Then

                    cntrl.Text = ""
                    cntrl.BackColor = Color.White


                End If

            Next

            GroupBox2.Enabled = False

            Dim bdt As New DataTable



            sqlstr.Connection = myconex
            sqlstr.CommandText = "select distinct testid from tests where testkind='l1test'"
            myAdapter.SelectCommand = sqlstr
            myAdapter.Fill(bdt)

            If (bdt.Rows.Count) >= 1 Then

                ComboBox1.DataSource = bdt
                ComboBox1.DisplayMember = "testid"

            End If


            myconex.Close()




        Else

            MsgBox("All the fields are required", MsgBoxStyle.Critical)

        End If



    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        TextBox2.BackColor = Color.White
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        TextBox3.BackColor = Color.White
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        TextBox4.BackColor = Color.White
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        TextBox5.BackColor = Color.White
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        TextBox6.BackColor = Color.White
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        TextBox7.BackColor = Color.White
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        TextBox8.BackColor = Color.White
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        TextBox9.BackColor = Color.White
    End Sub

    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.TextChanged

    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click

    End Sub
End Class