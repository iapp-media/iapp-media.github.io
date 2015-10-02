Imports System.IO
Imports System.Drawing

Public Class profile
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim comm As New CommTool()
    Dim str As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            str = "select Account,User_Name,User_Icon_B from Users where IDNo=" & comm.User_ID
            Dim dr As DataTable = Main.GetDataSet(str)
            If dr.Rows.Count > 0 Then
                Label1.Text = dr.Rows(0).Item("Account")
                TName.Text = dr.Rows(0).Item("User_Name")
                'Label2.Text = dr.Rows(0).Item("User_Name")
                ' p1.ImageUrl = "Apps/img/" & dr.Rows(0).Item("User_Icon_B")
                p1.ImageUrl = "UserIcon.ashx?i=" & comm.User_ID & ""
            End If
        End If
    End Sub


    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        Main.ParaClear()

        If TName.Text <> "" Then
            Main.ParaAdd("@TName", TName.Text, System.Data.SqlDbType.NVarChar)
            Main.NonQuery("Update Users Set User_name=@TName where IDNo =" & comm.User_ID)
            Response.Write("<Script>window.open('', '_self', ''); window.close();</Script>")
            Response.Write("<Script>window.ref();</Script>")
        End If


        If pw1.Text <> "" And pw2.Text <> "" Then
            Main.ParaAdd("@pw1", pw1.Text, System.Data.SqlDbType.NVarChar)
            If pw1.Text <> pw2.Text Then
                Response.Write("<Script>alert('確認密碼不同!!');</Script>")
            Else
                str = "Update Users Set Password=@pw1 where IDNo =" & comm.User_ID
                Main.NonQuery(str)
                Response.Write("<Script>alert('密碼修改成功!!');</Script>")
                Response.Write("<Script>window.close();</Script>")
            End If
        End If

    End Sub

    '

    'Protected Sub BTCancel_Click(sender As Object, e As EventArgs) Handles BTCancel.Click

    '    Response.Write("<script>window.open('', '_self', ''); window.close();</script>")

    'End Sub
End Class