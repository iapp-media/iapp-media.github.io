Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page
    Dim Main As New JDB()
    Dim comm As New CommTool()
    Dim str As String = ""

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not IsNothing(Session("User_Name")) Then
                Label1.Text = Session("User_Name")
            End If
            MySub()
        End If
    End Sub

    Sub myImageButton(ImgButton As Object, muti As Integer)

        Dim sort As Integer
        Dim ss As New StringBuilder()

        Main.ParaClear()
        Dim TmpSession As String = ""
        If IsNothing(Session("IDNo")) Then
            If Not IsNothing(Request.Cookies("ThisPC")) Then
                TmpSession = Request.Cookies("ThisPC").Value
            Else
                TmpSession = Session.SessionID
                comm.SaveCookie(Me, "ThisPC", Session.SessionID)
            End If

            str = "Select ISNULL(MAX(Sort),0) from User_Page where SessionID='" & TmpSession & "'"
            sort = Convert.ToInt32(Main.Scalar(str))

            Main.ParaAdd("@User_ID", 0, Data.SqlDbType.Int)
            Main.ParaAdd("@SessionID", TmpSession, System.Data.SqlDbType.VarChar)

        Else
            str = "Select ISNULL(MAX(Sort),0) from User_Page where User_ID=" & Session("IDNo")
            sort = Convert.ToInt32(Main.Scalar(str))


            Main.ParaAdd("@User_ID", Session("IDNo"), Data.SqlDbType.Int)
            Main.ParaAdd("@SessionID", "", System.Data.SqlDbType.VarChar)
        End If


        Main.ParaAdd("@Page_ID", ImgButton.CommandArgument.ToString(), Data.SqlDbType.Int)
        Main.ParaAdd("@Sort", sort + 1, Data.SqlDbType.Int)
        Main.ParaAdd("@MoreImgs", muti, Data.SqlDbType.Int)
        Dim sql As String = "Insert into User_Page(User_ID,Page_ID,Sort,SessionID,MoreImgs) Values(@User_ID,@Page_ID,@Sort,@SessionID,@MoreImgs)"
        Main.NonQuery(sql)
        MySub()
    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        myImageButton(ImageButton1, 0)
    End Sub
    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        myImageButton(ImageButton2, 0)
    End Sub

    Protected Sub ImageButton3_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton3.Click
        myImageButton(ImageButton3, 0)
    End Sub

    Protected Sub ImageButton4_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton4.Click
        myImageButton(ImageButton4, 1)
    End Sub

    Protected Sub ImageButton5_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton5.Click
        myImageButton(ImageButton5, 0)
    End Sub

    Protected Sub ImageButton6_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton6.Click
        myImageButton(ImageButton6, 0)
    End Sub

    Sub MySub()
       
        Dim ss As New StringBuilder()
        Main.ParaClear()
        Dim TmpSession As String = ""
        If IsNothing(Session("IDNo")) Then
            If Not IsNothing(Request.Cookies("ThisPC")) Then
                TmpSession = Request.Cookies("ThisPC").Value
            Else
                TmpSession = Session.SessionID
            End If
           
            Main.ParaAdd("@SessionID", TmpSession, System.Data.SqlDbType.VarChar)
            str = "Select b.IDNo PID, a.* from Pages a inner join User_Page b ON a.IDNo=b.Page_ID and b.SessionID=@SessionID  order by Sort"
        Else

            Main.ParaAdd("@User_IDNo", Session("IDNo"), System.Data.SqlDbType.Int)
            str = "Select b.IDNo PID, a.* from Pages a inner join User_Page b ON a.IDNo=b.Page_ID and b.User_ID=@User_IDNo  order by Sort"
        End If
        Dim dr As DataTable = Main.GetDataSet(str)
        Dim btnId As Integer = 0

        If (dr.Rows.Count > 0) Then
            For i = 0 To dr.Rows.Count - 1
                ss.Append("<li id=""s" & dr.Rows(i).Item("PID") & """>" & vbCrLf)
                ss.Append("     <img class=""border"" src=""img/border-small1.png""/>" & vbCrLf)
                ss.Append("     <a href=""#"" onclick=""putDELE('" & dr.Rows(i).Item("PID") & "');__doPostBack('DELE1','')"">" & vbCrLf)
                ss.Append("     <img class=""delete"" src=""img/delete.png""/></a>" & vbCrLf)
                ss.Append("     <a href=""#"" onclick=""show('Pages/see.aspx?ID=" & dr.Rows(i).Item("PID") & "'," & dr.Rows(i).Item("PID") & ")"">" & vbCrLf)
                ss.Append("     <img class=""picture"" src=""images/" & dr.Rows(i).Item("Img01") & """/></a>" & vbCrLf)
                ss.Append("</li>" & vbCrLf)
            Next
        End If
        L.Text = ss.ToString()
    End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        '  AA.Text = comm.Cint2(AA.Text) + 1
        If AA.Text <> "" Then
            Dim s() As String = AA.Text.Split(",")
            For i As Integer = 0 To s.Length - 1
                Main.NonQuery("Update User_Page set sort=" & (i + 1) & " where IDNo=" & s(i).Replace("s", ""))
            Next
        End If
        AA.Text = ""
    End Sub

    Private Sub DELE1_Click(sender As Object, e As EventArgs) Handles DELE1.Click
        La.Text = "現在我要刪除第" & DELEID.Text & "筆"
        Main.NonQuery("delete from User_Page where IDNo=" & DELEID.Text)
        MySub()
    End Sub
End Class
