Imports System.Data
Imports System.IO
Imports Microsoft.Security.Application

Partial Class Mana_Photo_Add
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim Comm As New DBTool.CommTool
    Dim CommA As New CommA
    Dim str As String
  
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Response.Expires = 0
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Comm.FillDDP2(DDLStation, "select * from _Station", "Station", "IDNo")
            If IsNumeric(Sanitizer.GetSafeHtmlFragment(Request.QueryString("Station"))) Then
                Comm.GetDDL(DDLStation, Request.QueryString("Station"))
                tr_Station.Visible = False
            End If
            If Not IsNothing(Request.QueryString("entry")) Then

                Dim DT As DataTable = Main.GetDataSet("select * from Photo where IDNo=" & Request.QueryString("entry"))
                '     Response.Write(DT.Rows.Count)
                If DT.Rows.Count > 0 Then
                    If Not IsDBNull(DT.Rows(0).Item("Title")) Then Me.TextBox1.Text = DT.Rows(0).Item("Title")
                    If Not IsDBNull(DT.Rows(0).Item("Cont")) Then Me.TextBox2.Text = DT.Rows(0).Item("Cont")
                    If Not IsDBNull(DT.Rows(0).Item("Creat_Date")) Then TDate.Text = CDate(DT.Rows(0).Item("Creat_Date")).ToShortDateString()
                    Comm.GetDDL(DDLStation, DT.Rows(0).Item("Station"))
                End If

                str = "Select FileName,FilePath from PhotoFiles where Table_Name='Photo' and Table_Nu = '" & Request.QueryString("entry") & "'"
                Dim DD As DataTable = Main.GetDataSetNoNull(str)
                If DD.Rows.Count > 0 Then
                    For i As Integer = 0 To DD.Rows.Count - 1
                        Dim LI As New ListItem
                        LI.Text = "<div align=center><a href=""../" & DD.Rows(i).Item("FilePath").Replace("_s", "") & """ target=""_blank""><img src=""../" & DD.Rows(i).Item("FilePath") & """ border=""0"" width=""200""/></a></a><br>" & DD.Rows(i).Item("FileName") & "</div>"
                        LI.Value = DD.Rows(i).Item("FilePath") & "," & DD.Rows(i).Item("FileName")
                        CBL.Items.Add(LI)
                    Next

                End If

                Button2Vis()
                'LabelT.Text = "修改活動"
                BT.Text = "修改儲存"
                BTD.Visible = True
                BTD.Attributes.Add("onclick", "if(confirm('確定要刪除嗎？')){return true;}else{return false;}")
            Else
                TDate.Text = Today
            End If
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If FU.HasFile Then
            Dim FilePath As String = CommA.SaveBmp(FU.PostedFile, 350, 263, "pp\")

            Dim LI As New ListItem
            LI.Text = "<div align=center><a href=""../" & FilePath.Replace("_s", "") & """ target=""_blank""><img src=""../" & FilePath & """ border=""0""/></a><br>" & Me.TextBox3.Text & "</dv>"
            LI.Value = FilePath & "," & Me.TextBox3.Text
            'CBL.Items.Clear()
            CBL.Items.Add(LI)
            Me.TextBox3.Text = ""
        End If
        Button2Vis()
    End Sub

    Sub Button2Vis()
        If CBL.Items.Count = 0 Then
            Button2.Visible = False
        Else
            Button2.Visible = True
        End If
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If CBL.Items.Count = 0 Then Exit Sub
        For i As Integer = CBL.Items.Count - 1 To 0 Step -1
            If CBL.Items(i).Selected = True Then
                Dim tmp As String = CBL.Items(i).Text
                tmp = tmp.Replace("<div align=center><a href=""../", "")
                tmp = tmp.Substring(0, tmp.IndexOfAny(""""))
                '   Response.Write(tmp & "<bR>")
                File.Delete(Comm.MainPath & tmp)
                File.Delete(Comm.MainPath & tmp.Replace(".", "_s."))
                CBL.Items.RemoveAt(i)

            End If

        Next
        Button2Vis()
    End Sub

    Protected Sub BT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT.Click
        Dim tmp As String = ""
        Dim MID As String = ""
        If Me.TextBox1.Text = "" Then tmp += ",請輸入名稱"
        If Me.TextBox2.Text = "" Then tmp += ",請輸入說明"
        If tmp <> "" Then
            Me.ClientScript.RegisterStartupScript(Me.GetType, "String", "<script>alert('" & tmp.Substring(1) & "');</script>")
            Exit Sub
        End If

        If Not IsNothing(Request.QueryString("entry")) Then
            MID = Request.QueryString("entry")

            str = "update Photo set Station='" & DDLStation.SelectedValue & "', Title='" & Me.TextBox1.Text & "',Cont='" & Me.TextBox2.Text & "' where IDNo=" & Request.QueryString("entry") & "; "
            str += "delete from PhotoFiles where Table_Name='Photo' and Table_Nu='" & MID & "'; "
            Main.NonQuery(str)
            '  Response.Write(str)

        Else
         
            str = "insert into Photo (Station,Title,Cont,Creat_Date)"
            str += " values ('" & DDLStation.SelectedValue & "','" & Me.TextBox1.Text & "','" & Me.TextBox2.Text & "',getdate()); "
            Main.NonQuery(str)
            MID = Main.Scalar("Select Max(IDNo) from Photo")
        End If

        str = ""

        If CBL.Items.Count > 0 Then
            For i As Integer = 0 To CBL.Items.Count - 1
                Dim AA() As String = CBL.Items(i).Value.Split(",")
                str += "insert into PhotoFiles (Table_Name,Table_Nu,FilePath,FileName) values ('Photo','" & MID & "','" & AA(0) & "','" & AA(1) & "'); "
            Next
        End If
        Main.NonQuery(str)
        '   Response.Write(str)
        Response.Write("<script>alert('儲存成功');window.open('Photo_Mana.aspx','_self');</script>")

    End Sub

    Protected Sub BTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTD.Click
        str = "delete from photo where idno=" & Request("entry")
        str += "delete from photofiles where table_nu = " & Request("entry")
        Main.NonQuery(str)
        Response.Write("<script>alert('刪除成功');window.open('photo_mana.aspx','_self');</script>")
    End Sub
End Class
