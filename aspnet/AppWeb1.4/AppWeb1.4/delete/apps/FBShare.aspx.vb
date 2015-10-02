Imports Facebook
Imports System.Dynamic

Public Class FBShare
    Inherits System.Web.UI.Page
    Dim main As New JDB()
    Dim comm As New CommTool()
    Dim str As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNumeric(Request.QueryString("i")) Then
            FBPO()
        End If
    End Sub

    Sub FBPO()
        str = "select * from User_App where IDNo=" & Request.QueryString("i") & "And User_ID=" & comm.User_ID
        Dim d As DataTable = Main.GetDataSetNoNull(Str)
        If d.Rows.Count > 0 Then
            Dim dw As DataRow = d.Rows(0)

            If Not IsNothing(Session("AccessToken")) Then
                Dim result As Object = New System.Dynamic.ExpandoObject()
                Dim accessToken = Session("AccessToken").ToString()
                Dim client = New FacebookClient(accessToken)
                result = client.[Get]("me", New With {Key .fields = "name,id"})
                Dim name As String = result.name
                Dim UserId As String = result.id
                Try
                    Dim messagePost As Object = New System.Dynamic.ExpandoObject()
                    messagePost.picture = "http://www.iapp-media.com/basic/Apps/Img/p04-1.jpg"

                    messagePost.link = dw("App_Url")
                    messagePost.name = dw("App_Name")
                    messagePost.description = dw("App_Memo")
                    ' messagePost.caption = "this is caption"
                    'messagePost.description = "這是季軒的FB整合測試 for description";//圖片描述
                    'messagePost.message = dw("App_Memo")
                    client.Post(UserId & Convert.ToString("/feed"), messagePost)
                Catch ex As FacebookOAuthException
                    Response.Write(ex.Message)
                End Try
            End If
        End If

        Response.Write("<Script>window.opener=null;window.close();</Script>")
        Response.End()
    End Sub

End Class