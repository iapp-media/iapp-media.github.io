Imports Microsoft.Security.Application

Partial Class Mana_Download_Download_Add
    Inherits System.Web.UI.Page
    Dim main As New DBTool.DBTool
    Dim Comm As New DBTool.CommTool
    Dim CommA As New CommA
    Dim str As String
    Dim WA_Table As String = "Download"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Response.Expires = 0
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            If Comm.GoodRequest(Me, "cate", "Int") Then
                Dim WA_Name As String = main.Scalar("select Name from Download_Cate where IDNo='" & Sanitizer.GetSafeHtmlFragment(Sanitizer.GetSafeHtmlFragment(Request.QueryString("cate"))) & "'")
                Label1.Text = "｜<a href=""" & WA_Table & "_Mana.aspx?cate=" & Sanitizer.GetSafeHtmlFragment(Request.QueryString("cate")) & """>" & WA_Name & "</a>｜<a href=""" & WA_Table & "_Add.aspx?cate=" & Sanitizer.GetSafeHtmlFragment(Request.QueryString("cate")) & """>新增" & WA_Name & "</a>｜"
                LabelT.Text = WA_Name


                str = "select Name,IDNo from Download_Cate where Ref=-1 order by Sort"
                Comm.FillDDP2(DDL, str, "Name", "IDNo")
                Comm.GetDDL(DDL, Sanitizer.GetSafeHtmlFragment(Request.QueryString("cate")))

                DDLIn(DDL2, DDL.SelectedValue)
                If DDL2.Items.Count > 0 Then tr_cate.Visible = True

            End If



            If Comm.GoodRequest(Me, "entry", "Int") Then
                Dim DT As Data.DataTable = main.GetDataSetNoNull("select * from Download where IDNo='" & Sanitizer.GetSafeHtmlFragment(Sanitizer.GetSafeHtmlFragment(Request.QueryString("entry"))) & "'")
                If DT.Rows.Count > 0 Then

                    TFileName.Text = DT.Rows(0).Item("FileName")
                    FileIN(CBLFU1, LFilePath, "", DT.Rows(0).Item("FilePath"))
                    TSort.Text = DT.Rows(0).Item("Sort")
                End If
            End If

        End If
    End Sub

    Sub DDLIn(ByVal DDLL As DropDownList, ByVal Cate_ID As String)
        str = "select Name,IDNo from Download_Cate where Ref='" & Cate_ID & "' order by Sort"
        Comm.FillDDP(DDLL, str, "Name", "IDNo")
        If DDLL.Items.Count > 0 Then DDLL.Visible = True
    End Sub

    Protected Sub DDL_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDL.SelectedIndexChanged
        DDLIn(DDL2, DDL.SelectedValue)
    End Sub

    Protected Sub DDL2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDL2.SelectedIndexChanged
        DDLIn(DDL3, DDL2.SelectedValue)
    End Sub

    Protected Sub DDL3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDL3.SelectedIndexChanged
        DDLIn(DDL3, DDL3.SelectedValue)
    End Sub

    Sub FileIN(ByVal CBL As CheckBoxList, ByVal LabelFile As Label, ByVal FileName As String, ByVal FilePath As String)
        Dim LI As New ListItem
        LI.Text = "<a href=""" & Comm.Url & FilePath & """ target=""_blank"">" & FileName & "附件瀏覽</a>"
        LI.Value = FilePath
        CBL.Items.Add(LI)

        LabelFile.Text = "<br />" & Sanitizer.GetSafeHtmlFragment(LI.Text)
    End Sub

    Function DataSave() As String
        Dim tmp As String = ""
        If TFileName.Text = "" Then tmp += ",請輸入檔案名稱"
        If LFilePath.Text = "" Then tmp += ",請上傳附件"
        If tmp <> "" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Me, Me.GetType(), "KeyName", "alert('" & tmp.Substring(1) & "');", True)
            Return ""
            Exit Function
        End If
        Dim MID As String = ""
        Dim Cate_ID As String = "null"
        Dim Cate2_ID As String = "null"
        Dim Cate3_ID As String = "null"
        Dim Cate4_ID As String = "null"

        If DDL.SelectedValue <> "" Then Cate_ID = DDL.SelectedValue
        If DDL2.SelectedValue <> "" Then Cate2_ID = DDL2.SelectedValue
        If DDL3.SelectedValue <> "" Then Cate3_ID = DDL3.SelectedValue
        If DDL4.SelectedValue <> "" Then Cate4_ID = DDL4.SelectedValue

        If IsNumeric(Request.QueryString("entry")) Then
            str = "Update " & WA_Table & " set Cate_ID=" & Cate_ID & ",Cate2_ID=" & Cate2_ID & ",Cate3_ID=" & Cate3_ID & ",Cate4_ID=" & Cate4_ID & _
            ",FileName=N'" & TFileName.Text & "',FilePath=N'" & CBLFU1.Items(0).Value & "',Sort='" & TSort.Text & _
            "',Update_Date=getdate(),Update_User='" & Session("User_ID") & "',Update_UName=N'" & Session("User_Name") & "' where IDNo=" & Sanitizer.GetSafeHtmlFragment(Request.QueryString("entry"))
            Dim NQ As Integer = main.NonQuery(str)
            If NQ = 0 Then
                Me.ClientScript.RegisterStartupScript(Me.GetType, "key", "alert('儲存失敗，請重新操作或聯絡系統管理者');", True)
                Return ""
                Exit Function
            End If
            MID = Sanitizer.GetSafeHtmlFragment(Request.QueryString("entry"))

        Else
            str = "Insert into " & WA_Table & " (Cate_ID,Cate2_ID,Cate3_ID,Cate4_ID,FileName,FilePath,Sort,Update_Date,Update_User,Update_UName) values" & _
            " (" & Cate_ID & "," & Cate2_ID & "," & Cate3_ID & "," & Cate4_ID & ",N'" & TFileName.Text & "','" & CBLFU1.Items(0).Value & "','" & TSort.Text & _
            "',getdate(),'" & Session("User_ID") & "',N'" & Session("User_Name") & "')"
            Dim NQ As Integer = main.NonQuery(str)
            If NQ = 0 Then
                Me.ClientScript.RegisterStartupScript(Me.GetType, "key", "alert('儲存失敗，請重新操作或聯絡系統管理者');", True)
                Return ""
                Exit Function
            End If

            MID = main.Scalar("Select Max(IDNo) from " & WA_Table & " where Update_User='" & Session("User_ID") & "'")
        End If

        Return MID
    End Function

    Protected Sub BT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BT.Click
        If DataSave() = "" Then Exit Sub
        Response.Write("<script>alert('儲存成功');window.open('" & WA_Table & "_Mana.aspx?cate=" & Sanitizer.GetSafeHtmlFragment(Request.QueryString("cate")) & "','_self');</script>")
    End Sub

    Protected Sub BTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTD.Click
        main.NonQuery("delete from " & WA_Table & " where IDNo=" & Sanitizer.GetSafeHtmlFragment(Request.QueryString("entry")))
        Response.Write("<script>alert('刪除成功');window.open('" & WA_Table & "_Mana.aspx?cate=" & Sanitizer.GetSafeHtmlFragment(Request.QueryString("cate")) & "','_self');</script>")
    End Sub

    Sub FU(ByVal FU As FileUpload, ByVal CBL As CheckBoxList, ByVal LabelFile As Label, ByVal FileName As String)
        If FU.HasFile Then
            Dim FF As String = Comm.FilePath & WA_Table & "\" & Year(Today) & Comm.GetFullNum(Month(Today), 2) & "\"

            If System.IO.Directory.Exists(Comm.MainPath & FF) = False Then
                System.IO.Directory.CreateDirectory(Comm.MainPath & FF)
            End If

            Dim FilePath As String = FF & Comm.GetFullNum(Day(Today), 2) & "_" & FU.FileName

            FU.SaveAs(Comm.MainPath & FilePath)

            CBL.Items.Clear()
            Dim LI As New ListItem
            LI.Text = "<a href=""" & Comm.Url & FilePath & """ target=""_blank"">" & FileName & "附件瀏覽</a>"
            LI.Value = FilePath
            CBL.Items.Add(LI)

            LabelFile.Text = "<br />" & Sanitizer.GetSafeHtmlFragment(LI.Text)
        End If
    End Sub

    Sub FUDel(ByVal CBL As CheckBoxList, ByVal LabelFile As Label)
        If System.IO.File.Exists(Comm.MainPath & Sanitizer.GetSafeHtmlFragment(CBL.Items(0).Value)) = True Then
            System.IO.File.Delete(Comm.MainPath & Sanitizer.GetSafeHtmlFragment(CBL.Items(0).Value))
        End If

        CBL.Items.Clear()
        LabelFile.Text = ""
    End Sub

    Protected Sub BTFU1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTFU1.Click
        FU(FU1, CBLFU1, LFilePath, "")
    End Sub

    Protected Sub BTFUDel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTFUDel1.Click
        FUDel(CBLFU1, LFilePath)
    End Sub

End Class
