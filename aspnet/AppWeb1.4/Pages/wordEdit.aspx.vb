Public Class wordEdit
    Inherits System.Web.UI.Page
    Dim main As New JDB()
    Dim comm As New CommTool()
    Dim str As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            main.ParaClear()
            main.ParaAdd("@UPID", Request.QueryString("UPID"), System.Data.SqlDbType.Int)
            str = "Select h" & Request.QueryString("text") & " as H,Page_ID  from User_Page where IDNo=@UPID"
            Dim dr As DataTable = main.GetDataSet(str)
            If (dr.Rows.Count > 0) Then
                'txtEditor.Text = dr.Rows(0).Item("H").ToString()
                If main.Scalar("select URL from [dbo].[Pages] where IDNo='" & dr.Rows(0).Item("Page_ID").ToString() & "'") = "p06.aspx" Then
                    LTextED.Text = "<textarea name=""txtEditor"" class=""txtEditor"" id=""txtEditor""  onkeyup=""words_deal(14)"" >" + dr.Rows(0).Item("H").ToString() + "</textarea>"
                Else
                    LTextED.Text = "<textarea name=""txtEditor"" class=""txtEditor"" id=""txtEditor""  onkeyup=""words_deal(100)"" >" + dr.Rows(0).Item("H").ToString() + "</textarea>"
                End If 
            Else
                LTextED.Text = "<textarea name=""txtEditor"" class=""txtEditor"" id=""txtEditor"" onkeyup=""words_deal(50)""   >" + "" + "</textarea>"
            End If

        End If
    End Sub

    Protected Sub send_Click(sender As Object, e As EventArgs) Handles send.Click
        'Response.Write("<Script>alert('" + EDvalues.Text + "') </Script>")
        wirteText()
        Response.Write("<Script>window.parent.show('Pages/see.aspx?ID=" & Request.QueryString("UPID") & "'," & Request.QueryString("UPID") & " );</Script>")
    End Sub

    Sub wirteText()
        main.ParaClear()
        main.ParaAdd("@UPID", Request.QueryString("UPID"), System.Data.SqlDbType.Int)
        If main.IsNumeric(Request.QueryString("UPID")) And main.IsNumeric(Request.QueryString("text")) Then
            main.ParaAdd("@text", EDval.Text, SqlDbType.NVarChar)
            str = "Update User_Page set h" & Request.QueryString("text") & "=@text where IDNo=@UPID"
            main.NonQuery(str)
        End If
    End Sub
End Class