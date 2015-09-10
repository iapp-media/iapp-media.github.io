Imports System.IO
Imports System.Drawing

Public Class Setting1
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim Comm As New CommTool()
    Dim str As String = ""
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Comm.ChkLoginStat("Login.aspx") Then Exit Sub
            If IsNumeric(Request.QueryString("i")) Then
                Comm.DoAppCover(Request.QueryString("i").ToString())
                TAppName.Text = Main.Scalar("select case when isnull(App_Name,'')='' then '必填(限10字)' else App_Name  end from User_App Where IDNo=" & Request.QueryString("i") & "")
                TAppMemo.Text = Main.Scalar("select case when isnull(App_Memo,'')='' then '(限140字)' else App_Memo  end from User_App Where IDNo=" & Request.QueryString("i") & "")
                chktcol()
            End If
        End If
        chktcol()
        show()
    End Sub
    Sub chktcol()
        If TAppName.Text.Trim() <> "必填(限10字)" Then
            TAppName.ForeColor = Color.Black 
        End If
        If TAppMemo.Text.Trim() <> "(限140字)" Then
            TAppMemo.ForeColor = Color.Black 
        End If
    End Sub

    Sub show()
        str = "Select isnull(App_Icon,'') App_Icon,App_Name,isnull(App_Folder,'') App_Folder ,isnull(App_Memo,'') App_Memo,App_cover  from User_App Where IDNo=" & Request.QueryString("i") & " And User_ID = " & Comm.User_ID
        ' str = "Select * from User_App Where IDNo=" & Session("Ap_id") & " And User_ID = " & comm.User_ID
        Dim dr As DataTable = Main.GetDataSetNoNull(str)
        If dr.Rows.Count > 0 Then
             If dr.Rows(0).Item("App_Folder") <> "" And dr.Rows(0).Item("App_Icon") <> "" Then
                p1.ImageUrl = "Apps/" & dr.Rows(0).Item("App_Folder") & "/pic/" & dr.Rows(0).Item("App_Icon")
                Img_cover.ImageUrl = "Apps/" & dr.Rows(0).Item("App_Folder") & "/pic/" & dr.Rows(0).Item("App_cover") 
            ElseIf dr.Rows(0).Item("App_Folder") <> "" And dr.Rows(0).Item("App_cover") <> "" Then
                Img_cover.ImageUrl = "Apps/" & dr.Rows(0).Item("App_Folder") & "/pic/" & dr.Rows(0).Item("App_cover")
            End If
            'TAppName.Text = dr.Rows(0).Item("App_Name")
            'TAppMemo.Text = dr.Rows(0).Item("App_Memo") 
        End If 
    End Sub

    Protected Sub sendOK_Click(sender As Object, e As EventArgs) Handles sendOK.Click
        If TAppName.Text.Trim() = "必填(限10字)" Then
            Response.Write("<Script>alert('請輸入IApp名稱');</Script>") 
            Return
        End If

        Main.ParaClear()
        Main.ParaAdd("@app_id", Request.QueryString("i"), System.Data.SqlDbType.Int)
        Main.ParaAdd("@App_Name", TAppName.Text.Trim(), System.Data.SqlDbType.NVarChar)
        Main.ParaAdd("@App_Memo", TAppMemo.Text.Trim(), System.Data.SqlDbType.NVarChar)
        str = "Update User_App set App_Name=@App_Name,App_Memo=@App_Memo where IDNo=@app_id"
        Dim c As Integer = Main.NonQuery(str)
        If c > 0 Then
            Response.Write("<Script>window.open('list.aspx','_self');</Script>")
        Else
            System.Web.UI.ScriptManager.RegisterStartupScript(Me, Me.GetType(), "KeyName", "alert('儲存失敗，請稍後再試');", True)
        End If

    End Sub
End Class