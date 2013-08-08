Public Class payments

    Private Sub payments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim bdt, tdt, udt As New DataTable

        dbconnect()

        sqlstr.Connection = myconex
        sqlstr.CommandText = "select distinct paymentid from payments"
        myAdapter.SelectCommand = sqlstr
        myAdapter.Fill(bdt)

        If (bdt.Rows.Count) >= 1 Then

            ComboBox1.DataSource = bdt
            ComboBox1.DisplayMember = "paymentid"

        End If

        ComboBox2.Items.Add("text")
        ComboBox2.Items.Add("button")
        ComboBox2.Items.Add("scroldown")



        myconex.Close()
        loading.Hide()

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        Dim bdt, tdt, udt As New DataTable

        If TextBox1.Text <> "" Then


            dbconnect()

            sqlstr.Connection = myconex
            sqlstr.CommandText = "select fieldname,fieldcss,fieldtype,fieldvalue from payments where paymentid='" & TextBox1.Text & "'"
            myAdapter.SelectCommand = sqlstr
            myAdapter.Fill(bdt)

            If (bdt.Rows.Count) >= 1 Then

                DataGridView1.DataSource = bdt

                GroupBox2.Enabled = True
                'GroupBox3.Enabled = True



                myconex.Close()
                loading.Hide()

            Else

                Label1.Visible = True
                Button1.Visible = True
                Button1.Text = "NEW"

            End If

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
            'GroupBox3.Enabled = True



        Else

            MsgBox("Payment ID could not be in blank", MsgBoxStyle.Critical)

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
            'GroupBox3.Enabled = False


        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim ok As Integer
        Dim success As Boolean

        ok = 0

        For Each cntrl As Control In GroupBox2.Controls

            If TypeOf cntrl Is TextBox Then

                If cntrl.Text = "" Then


                    ok = 1
                    cntrl.BackColor = Color.Red


                End If

            End If

        Next

        If TextBox1.Text = "" Then

            TextBox1.BackColor = Color.Red
            ok = 1

        End If


        If ComboBox2.Text = "" Then ok = 1



        If ok = 0 Then success = True


        If success = True Then

            dbconnect()

            For Each cntrl As Control In GroupBox2.Controls

                If TypeOf cntrl Is TextBox Then

                    cntrl.Text = cntrl.Text.Replace(ControlChars.Quote, "¬")
                    cntrl.Text = cntrl.Text.Replace("'", "¬")
                    'xpath = TextBox4.Text.Replace("'", "¬")

                End If

            Next

            sqlstr.Connection = myconex
            sqlstr.CommandText = "insert into payments(paymentid,fieldtype,fieldname,fieldcss,fieldvalue) values('" & TextBox1.Text & "','" & ComboBox2.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
            sqlstr.ExecuteNonQuery()


            For Each cntrl As Control In GroupBox2.Controls

                If TypeOf cntrl Is TextBox Then

                    cntrl.Text = ""
                    cntrl.BackColor = Color.White


                End If

            Next

            GroupBox2.Enabled = False
            'GroupBox3.Enabled = False

            Dim tdt As New DataTable



            sqlstr.Connection = myconex
            sqlstr.CommandText = "select distinct paymentid from payments"
            myAdapter.SelectCommand = sqlstr
            myAdapter.Fill(tdt)

            If (tdt.Rows.Count) >= 1 Then

                ComboBox1.DataSource = tdt
                ComboBox1.DisplayMember = "paymentid"

            End If


            myconex.Close()
            Dim testid As String
            testid = TextBox1.Text
            TextBox1.Text = ""
            TextBox1.Text = testid




        Else

            MsgBox("All the fields are required", MsgBoxStyle.Critical)

        End If



    End Sub



    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        TextBox3.BackColor = Color.White
    End Sub


    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub






    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        TextBox2.BackColor = Color.White
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim bid, tid As String
        Dim dt As New DataTable
        bid = TextBox1.Text
        tid = DataGridView1.CurrentRow.Cells(1).Value.ToString
        If bid <> "" Then

            Try

                dbconnect()
                sqlstr.Connection = myconex
                'MsgBox(bid & "       " & tid)
                sqlstr.CommandText = "delete from payments where paymentid='" & bid & "' and fieldcss='" & tid & "'"
                sqlstr.ExecuteNonQuery()

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

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        TextBox2.BackColor = Color.White
    End Sub
End Class