Imports Facebook
Public Class FacebookChk
    Inherits System.Web.UI.Page
    Dim Comm As New CommTool()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim str As String = ""
        Dim UID As String = ""
        Dim UName As String = ""
        Dim FBID As String = ""
        Dim accessToken = Request("accessToken")
        Session("AccessToken") = accessToken

        Dim client As FacebookClient = New FacebookClient(accessToken)
        Dim result As Object = New System.Dynamic.ExpandoObject()
        result = client.[Get]("me", New With {Key .fields = "name,id,email"})
        FBID = result.id
        UName = result.name

        Dim main As New JDB()
        main.ParaAdd("@fbId", result.id, SqlDbType.NVarChar)
        main.ParaAdd("@User_Name", result.name, SqlDbType.NVarChar)
        main.ParaAdd("@email", "", SqlDbType.NVarChar)
        main.ParaAdd("@User_Type", 2, SqlDbType.Int)
        main.ParaAdd("@AccessToken", Session("AccessToken").ToString(), SqlDbType.NVarChar)

        str = "Select IDNo from Users where fbId=@fbId"
        UID = main.Scalar(str)

        If UID = "" Then
            str = "if not exists (select * from Users where fbId=@fbId) " +
                  "Insert into Users (fbId,User_Name,Account,User_Type,AccessToken) values (@fbId,@User_Name,@email,@User_Type,@AccessToken)"
            main.NonQuery(str)
            str = "Select IDNo from  Users where fbId=@fbId"
            UID = main.Scalar(str) 
        Else
            str = "Update Users set AccessToken=@AccessToken where fbId=@fbId"
            main.NonQuery(str)
        End If
        Comm.SaveUserCookies(UID, UName, FBID)

        Response.Write("<script type=text/javascript> window.parent.location.href ='Default.aspx' </script>")
        Response.End()
    End Sub

End Class