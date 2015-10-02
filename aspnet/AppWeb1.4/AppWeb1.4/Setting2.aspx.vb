Imports System.IO
Imports System.Drawing

Public Class Setting2
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim comm As New CommTool()
    Dim str As String = ""
    Dim SortNum As Integer = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
 
        If Not Page.IsPostBack Then
            '  If Not comm.ChkLoginStat("Login.aspx") Then Exit Sub
            If Not IsNumeric(Request.QueryString("i")) Then
                Response.Write("<Script>alert('參數錯誤');window.parent.sended();</Script>")
                Response.End()
                Exit Sub
            Else
                'comm.DoAppCover(Request.QueryString("i").ToString())   '第一次會不成功? posback才多加
                TAppName.Text = Main.Scalar("select App_Name from User_App Where IDNo=" & Request.QueryString("i") & "")
                TAppMemo.Text = Main.Scalar("select App_Memo from User_App Where IDNo=" & Request.QueryString("i") & "")

                'chkAPCover()
                show()
            End If
        End If
        chkAPCover()
        show()
    End Sub
    Sub chkAPCover()
        If Main.Scalar("select isnull(App_Cover,'') from User_App Where IDNo=" & Request.QueryString("i") & "  ") = "" Then
            Threading.Thread.Sleep(1000)
            comm.DoAppCover(Request.QueryString("i"))
            ' Response.Write(comm.DoAppCover(Request.QueryString("i").ToString()))
        End If
    End Sub
 
    Protected Sub send_Click(sender As Object, e As EventArgs) Handles send.Click

        If IsNumeric(Request.QueryString("i")) Then
            Dim APID As String = Request.QueryString("i")

            Dim tmp As String = ""
            If TAppName.Text.Trim() = "" Then
                Response.Write("<Script>alert('請輸入IApp名稱');</Script>")
                Return
            End If

            Session("Ap_Id") = APID

            Main.ParaClear()
            Main.ParaAdd("@app_id", APID, System.Data.SqlDbType.Int)
            Main.ParaAdd("@App_Name", TAppName.Text, System.Data.SqlDbType.NVarChar)
            Main.ParaAdd("@App_Memo", TAppMemo.Text.Trim(), System.Data.SqlDbType.NVarChar)
            'Main.ParaAdd("@App_Icon", ImgName, System.Data.SqlDbType.NVarChar)
            str = "Update User_App set App_Name=@App_Name,App_Memo=@App_Memo where IDNo=@app_id"
            Dim c As Integer = Main.NonQuery(str)
            If c > 0 Then
                Main.ParaAdd("@Share_Img", comm.FBShareImg(APID), System.Data.SqlDbType.NVarChar)
                Main.NonQuery("Update User_App set Share_Img=@Share_Img,IsPosted='1'  where IDNo=@app_id")

                Response.Write("<Script>window.parent.sended();window.parent.postit();window.open('Setting2.aspx?i=" & APID & "','_self');</Script>")
            Else
                Response.Write("<Script>alert('上傳失敗，請稍後再試');window.parent.sended();</Script>")
            End If

        End If
    End Sub

    Sub show()
        Threading.Thread.Sleep(1000)
        Main.ParaClear()
        Main.ParaAdd("@app_id", Request.QueryString("i"), System.Data.SqlDbType.Int)

        str = "Select * from User_App where IDNo=@app_id"
        Dim DT As DataTable = Main.GetDataSetNoNull(str)
        If DT.Rows.Count > 0 Then
             
            If DT.Rows(0).Item("App_Icon") <> "" Then
                p1.Src = "Apps/" & DT.Rows(0).Item("App_Folder") & "/pic/" & DT.Rows(0).Item("App_Icon")
            End If
            If DT.Rows(0).Item("App_Cover") <> "" Then
                Img1.Src = "Apps/" & DT.Rows(0).Item("App_Folder") & "/pic/" & DT.Rows(0).Item("App_Cover")
            End If
        End If
    End Sub
End Class