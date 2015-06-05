Imports System.Drawing
Imports System.Windows
Public Class p04_Edit
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim comm As New CommTool()
    Public MainPath As String = System.Configuration.ConfigurationSettings.AppSettings.Get("MainPath")
    Dim str As String = ""
    Dim ss As New StringBuilder()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            str = "Select Image from Img_Url where User_Page_ID =" & Request.QueryString("ID")
            Dim dr As DataTable = Main.GetDataSet(str)
            If dr.Rows.Count > 0 Then
                For i As Integer = 0 To dr.Rows.Count - 1
                    ss.Append("<li><img alt="""" src=""../" & dr.Rows(i).Item("Image").ToString().Replace("\\", "/") & """ />")
                    ss.Append("<div><input name=""b1"" type=""button"" value=""X"" onclick="" "" /></div></li>")
                Next
            End If
            L.Text = ss.ToString()
        End If
      
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (FileUpload1.HasFile = True) Then
            For Each postedFile As HttpPostedFile In FileUpload1.PostedFiles
                Dim FileName As String = postedFile.FileName.Replace(",", "")
                Dim FilePath As String = "User_Pic" & postedFile.FileName.ToString() & ".jpg"
                Dim w As Integer = 290
                Dim h As Integer = 450
                Dim inbmp As New Bitmap(postedFile.InputStream)
                inbmp = comm.zoomImage(inbmp, w, h)
                inbmp = comm.CutImage(inbmp, w, h)
                'im inbmp As New Bitmap(FU.PostedFile.InputStream)
                inbmp.Save(MainPath & FilePath)
                Dim TmpSession As String = ""
                If IsNothing(Session("IDNo")) Then
                    If Not IsNothing(Request.Cookies("ThisPC")) Then
                        TmpSession = Request.Cookies("ThisPC").Value
                    Else
                        TmpSession = Session.SessionID
                    End If
                    Main.ParaClear()
                    Main.ParaAdd("@U_P_ID", Request.QueryString("ID"), Data.SqlDbType.Int)
                    Main.ParaAdd("@Img", FilePath, Data.SqlDbType.VarChar)
                    str = "Insert into Img_Url(User_Page_ID,Image) Values (@U_P_ID,@Img)"
                    Main.NonQuery(str)
                Else
                    Main.ParaClear()
                    Main.ParaAdd("@U_P_ID", Request.QueryString("ID"), Data.SqlDbType.Int)
                    Main.ParaAdd("@Img", FilePath, Data.SqlDbType.VarChar)
                    str = "Insert into Img_Url(User_Page_ID,Image) Values (@U_P_ID,@Img)"
                    Main.NonQuery(str)
                End If
            Next
        End If
        str = "Select Image from Img_Url where User_Page_ID =" & Request.QueryString("ID")
        Dim dr As DataTable = Main.GetDataSet(str)
        If dr.Rows.Count > 0 Then
            For i As Integer = 0 To dr.Rows.Count - 1
                ss.Append("<img alt="""" src=""../" & dr.Rows(i).Item("Image").ToString().Replace("\\", "/") & """ />")
                ss.Append("<div><input name=""b1"" type=""button"" value=""X"" onclick="""" /></div>")
            Next
        End If
        L.Text = ss.ToString()
    End Sub
End Class