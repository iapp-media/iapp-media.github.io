
Partial Class Mana_Form_List
    Inherits System.Web.UI.Page
    Dim Main As New JDB
    Dim Comm As New CommTool
    Dim CommA As New CommA
    Dim str As String

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Response.Expires = 0
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            DDLin()

            If IsNumeric(Request.QueryString("s")) Then
                L.Text = "select * from form where store_ID = '" & Request.QueryString("s") & "' order by Creat_Date"
                SD.ConnectionString = Main.ConnStr
                SD.SelectCommand = L.Text
                GV.DataSourceID = SD.ID
            End If
        End If
    End Sub

    Protected Sub GV_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GV.RowCommand
        Dim i As Integer = e.CommandArgument
        If e.CommandName = "CN" Then
            Response.Redirect("Form_Detail.aspx?entry=" & GV.DataKeys(i).Item(0))
        End If
    End Sub

    Sub DDLin()
        str = "select Status_Name,IDNo from Form_Status where ref=-1 order by IDNo"
        Comm.FillDDP(DDL_Status, str, "Status_Name", "IDNo")
    End Sub

    Protected Sub GV_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GV.RowDataBound

    End Sub

End Class
