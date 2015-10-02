Imports System.IO
Imports System.Drawing

Public Class AUL
    Inherits System.Web.UI.Page
    Dim main As New JDB()
    Dim Comm As New CommTool()
    Dim str As String = ""
    Dim SortNum As Integer = 1
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            imgShow()
            If main.IsNumeric(Request.QueryString("list")) Then backlist.Visible = True 
        End If
    End Sub

    Sub UpLoadPic()
        main.ParaClear()
        main.ParaAdd("@UPID", Request.QueryString("UPID"), System.Data.SqlDbType.Int)
        main.ParaAdd("@User_ID", Comm.User_ID, System.Data.SqlDbType.Int) 
        If main.IsNumeric(Request.QueryString("UPID")) Then
            Dim AP_ID As String = main.Scalar("select User_App_ID from User_Page where idno=@UPID")
            'If inputImage.ToString <> "" Then
            Dim ImgName As String = Comm.ImgSerial(Request.QueryString("UPID"), Request.QueryString("Img")) & ".jpg"
            Dim FileFolder As String = url(AP_ID) & "\pic\" & ImgName
            Dim ImgPath As String = Comm.CurrentAppFolder(AP_ID) & "\pic\"
            If File.Exists(ImgPath & ImgName) = True Then File.Delete(ImgPath & ImgName)
            If System.IO.Directory.Exists(ImgPath) = False Then
                System.IO.Directory.CreateDirectory(ImgPath)
            End If
            Dim buf As Byte() = Convert.FromBase64String(TS.Text.Trim)
            Dim TYU As New FileStream(ImgPath & ImgName, FileMode.CreateNew)
            TYU.Write(buf, 0, buf.Length)
            TYU.Close()
            main.ParaAdd("@Img", FileFolder.Replace("\", "/"), System.Data.SqlDbType.VarChar)
            'End If
            str = "Update User_Page set Img0" & Request.QueryString("Img") & " = @Img  where IDNo=@UPID and User_ID=@User_ID"
            main.NonQuery(str)
        End If

    End Sub

    Sub UpLoadPicApp()
        If main.IsNumeric(Request.QueryString("Icon")) Then 
            main.ParaClear()
            main.ParaAdd("@User_ID", Comm.User_ID, System.Data.SqlDbType.Int)
            main.ParaAdd("@App_id", Request.QueryString("Icon"), System.Data.SqlDbType.Int)

            Dim ImgName As String = "ico_" & Request.QueryString("Icon") & ".jpg"
            Dim FileFolder As String = url(Request.QueryString("Icon")) & "\pic\" & ImgName
            Dim ImgPath As String = Comm.CurrentAppFolder(Request.QueryString("Icon")) & "\pic\"
            If File.Exists(ImgPath & ImgName) = True Then File.Delete(ImgPath & ImgName)

            If System.IO.Directory.Exists(ImgPath) = False Then
                System.IO.Directory.CreateDirectory(ImgPath)
            End If
            Dim buf As Byte() = Convert.FromBase64String(TS.Text.Trim)
            Dim TYU As New FileStream(ImgPath & ImgName, FileMode.CreateNew)
            TYU.Write(buf, 0, buf.Length)
            TYU.Close()
            main.ParaAdd("@App_Icon", ImgName, System.Data.SqlDbType.NVarChar)
            str = "Update User_App set App_Icon=@App_Icon where IDNo=@App_id"
            main.NonQuery(str)
        End If
    End Sub
    Sub UpLoadICover()
        main.ParaClear() 
        main.ParaAdd("@App_id", Request.QueryString("APCover"), System.Data.SqlDbType.Int)

        If main.IsNumeric(Request.QueryString("APCover")) Then
            str = ""
            Dim ImgName As String = "icover_" & Request.QueryString("APCover") & ".jpg"
            Dim FileFolder As String = url(Request.QueryString("APCover")) & "\pic\" & ImgName
            Dim ImgPath As String = Comm.CurrentAppFolder(Request.QueryString("APCover")) & "\pic\"
            If File.Exists(ImgPath & ImgName) = True Then File.Delete(ImgPath & ImgName)

            If System.IO.Directory.Exists(ImgPath) = False Then
                System.IO.Directory.CreateDirectory(ImgPath)
            End If
            Dim buf As Byte() = Convert.FromBase64String(TS.Text.Trim)
            Dim TYU As New FileStream(ImgPath & ImgName, FileMode.CreateNew)
            TYU.Write(buf, 0, buf.Length)
            TYU.Close()
            main.ParaAdd("@App_Icover", ImgName, System.Data.SqlDbType.NVarChar)
            str = "Update User_App set App_Cover=@App_Icover where IDNo=@App_id"
            main.NonQuery(str)
        End If
    End Sub

    Sub User_Profile()
        main.ParaClear()
        main.ParaAdd("@User_ID", Comm.User_ID, System.Data.SqlDbType.Int) 
        If main.IsNumeric(Request.QueryString("Profile")) Then 
            Dim buf As Byte() = Convert.FromBase64String(TS.Text.Trim)
            main.ParaAdd("@User_Icon", buf, System.Data.SqlDbType.Image)
            str = "Update Users set User_Icon=@User_Icon where IDNo=@User_ID"
            main.NonQuery(str)
        End If
    End Sub

    Function url(AID As Integer) As String
        str = "Select App_Folder from User_App where IDNo=" & AID & " "
        Return main.Scalar(str)
    End Function

    Protected Sub BTN_Click(sender As Object, e As EventArgs) Handles BTN.Click
        If main.IsNumeric(Request.QueryString("Icon")) Then
            UpLoadPicApp()
            'Threading.Thread.Sleep(1000)
            DoTimeOut()
            imgShow()
            If main.IsNumeric(Request.QueryString("list")) Then
                Response.Redirect("../Setting1.aspx?i=" & Request.QueryString("list"))
            Else
                Response.Redirect("../Setting2.aspx?i=" & Request.QueryString("Icon"))
            End If
        ElseIf main.IsNumeric(Request.QueryString("Profile")) Then
            User_Profile()
            'Threading.Thread.Sleep(1000)
            DoTimeOut()
            Response.Write("<Script>window.parent.ref()</Script>")
        ElseIf main.IsNumeric(Request.QueryString("APCover")) Then
            UpLoadICover()
            'Threading.Thread.Sleep(1000)
            DoTimeOut()
            imgShow()
            If main.IsNumeric(Request.QueryString("list")) Then
                Response.Redirect("../Setting1.aspx?i=" & Request.QueryString("list"))
            Else
                Response.Redirect("../Setting2.aspx?i=" & Request.QueryString("APCover"))
            End If

        Else
            UpLoadPic()
            'Threading.Thread.Sleep(1000)
            DoTimeOut()
            imgShow()

            Response.Write("<Script>window.parent.show('Pages/see.aspx?ID=" & Request.QueryString("UPID") & "'," & Request.QueryString("UPID") & " );</Script>")
        End If

    End Sub

    Sub imgShow()
        If main.IsNumeric(Request.QueryString("Icon")) Then
            str = "Select App_Icon,App_Folder from User_App where IDNo=" & Request.QueryString("Icon")
            Dim dr As DataTable = main.GetDataSet(str)
            If (dr.Rows.Count > 0) Then
                showImg.Src = "../Apps/" & dr.Rows(0).Item("App_Folder") & "/pic/" & dr.Rows(0).Item("App_Icon")
                Response.Write("<Script>ref()</Script>")
            End If
        ElseIf main.IsNumeric(Request.QueryString("APCover")) Then
            str = "Select App_Cover,App_Folder from User_App where IDNo=" & Request.QueryString("APCover")
            Dim dr As DataTable = main.GetDataSetNoNull(str)
            If (dr.Rows.Count > 0) Then
                showImg.Src = "../Apps/" & dr.Rows(0).Item("App_Folder") & "/pic/" & dr.Rows(0).Item("App_Cover")
            End If
        Else
            str = "Select Img0" & Request.QueryString("Img") & " as thisImg from User_Page where IDNo=" & Request.QueryString("UPID")
            Dim dr As DataTable = main.GetDataSet(str)
            If (dr.Rows.Count > 0) Then
                showImg.Src = "../Apps/" & dr.Rows(0).Item("thisImg")
            End If
        End If
    End Sub


    Sub DoTimeOut()
        Threading.Thread.Sleep(1000)
        '  PDialog.Visible = False

    End Sub

    'Protected Sub confirm_Click(sender As Object, e As EventArgs) Handles confirm.Click
    '    If main.IsNumeric(Request.QueryString("Icon")) Then 
    '        If main.IsNumeric(Request.QueryString("list")) Then
    '            Response.Redirect("../Setting1.aspx?i=" & Request.QueryString("list"))
    '        Else
    '            Response.Write("<Script>window.parent.ref()</Script>")
    '        End If
    '    ElseIf main.IsNumeric(Request.QueryString("Profile")) Then 
    '        Response.Write("<Script>window.parent.ref()</Script>")
    '    Else

    '        Response.Write("<Script>window.parent.RDefault();</Script>")
    '    End If
    'End Sub
End Class