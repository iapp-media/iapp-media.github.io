Imports System.IO

Partial Class Mana_Product
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

            If IsNumeric(Request.QueryString("s")) And IsNumeric(Request.QueryString("p")) Then
                Dim DT As Data.DataTable = Main.GetDataSetNoNull("select * , Product_Img.idno as PINo from Product,Product_Img where Product.IDNo = Product_Img.Product_ID and Product.Store_ID=" & Request.QueryString("s") & " and Product.IDNo = " & Request.QueryString("p") & "")
                If DT.Rows.Count > 0 Then
                    TB_ProductName.Text = DT.Rows(0).Item("Product_Name")
                    Comm.GetDDL(DDL_Cate, DT.Rows(0).Item("Cate_ID"))
                    Comm.GetDDL(DDL_Unit, DT.Rows(0).Item("Unit"))
                    TB_Price.Text = DT.Rows(0).Item("Price")
                    Comm.GetDDL(DDL_Payment, DT.Rows(0).Item("Payment"))
                    Comm.GetDDL(DDL_Delivery, DT.Rows(0).Item("delivery"))
                    TB_Stock.Text = DT.Rows(0).Item("stock")
                    Comm.GetDDL(DDL_OnSale, DT.Rows(0).Item("Status"))
                    TB_Dimension.Text = DT.Rows(0).Item("dimension")
                    TB_Description.Text = DT.Rows(0).Item("description")
                    TB_ProductNo.Text = DT.Rows(0).Item("Product_No")
                    TB_BarCode.Text = DT.Rows(0).Item("BarCode")
                    TB_Memo.Text = DT.Rows(0).Item("Memo")
                    'imgA.Src = "../" + DT.Rows(0).Item("FilePath").ToString.Replace("\", "/")
                    For i As Integer = 0 To DT.Rows.Count - 1
                        Select Case i
                            Case "0"
                                imgA.Src = "../" + DT.Rows(i).Item("FilePath").ToString.Replace("\", "/")
                                LP1.Text = DT.Rows(i).Item("PINo")
                            Case "1"
                                imgB.Src = "../" + DT.Rows(i).Item("FilePath").ToString.Replace("\", "/")
                                LP2.Text = DT.Rows(i).Item("PINo")
                            Case "2"
                                imgC.Src = "../" + DT.Rows(i).Item("FilePath").ToString.Replace("\", "/")
                                LP3.Text = DT.Rows(i).Item("PINo")
                            Case "3"
                                imgD.Src = "../" + DT.Rows(i).Item("FilePath").ToString.Replace("\", "/")
                                LP4.Text = DT.Rows(i).Item("PINo")
                        End Select
                    Next

                    'Response.Write("select * from Product,Product_Img where Product.IDNo = Product_Img.Product_ID and Product.Store_ID=" & Request.QueryString("s") & " and Product.IDNo = " & Request.QueryString("p") & "")
                End If
            End If
        End If

    End Sub

    Sub DDLin()
        str = "select Cate_Name,IDNo from Product_Cate where ref=-1 order by Cate_Name"
        Comm.FillDDP(DDL_Cate, str, "Cate_Name", "IDNo")
    End Sub

    Protected Sub BT_Click(sender As Object, e As System.EventArgs) Handles BT.Click
        Dim tmp As String = ""
        If TB_ProductName.Text = "" Then tmp += "，請輸入商品名稱"

        If IsNumeric(Request.QueryString("p")) Then
            str = "update Product set Product_Name='" & TB_ProductName.Text.Trim() & "', Cate_ID = '" & DDL_Cate.SelectedValue & "', Unit='" & DDL_Unit.SelectedValue & _
                "' ,Price='" & TB_Price.Text & "',Payment='" & DDL_Payment.SelectedValue & "',delivery='" & DDL_Delivery.SelectedValue & "',stock='" & TB_Stock.Text & _
                "',Status='" & DDL_OnSale.SelectedValue & "',Description='" & TB_Description.Text & "',dimension='" & TB_Dimension.Text & "',Product_No='" & TB_ProductNo.Text.Trim() & _
                "',BarCode='" & TB_BarCode.Text.Trim() & "',Memo='" & TB_Memo.Text & "' where IDNo=" & Request.QueryString("p") & ""
            Dim NQ As Integer = Main.NonQuery(str)
            If NQ = 0 Then
                Me.ClientScript.RegisterStartupScript(Me.GetType, "String", "alert('儲存失敗，請重新操作或連絡管理者');", True)
                Response.Write(str) '測試
                Exit Sub
            End If

            Dim FilePath As String = ""
            If FU1.HasFile Then   ' 圖片1
                Dim FileName As String = FU1.FileName
                FilePath = Comm.GetDateString(Now) & "_" & FU1.FileName
                FU1.SaveAs(System.Configuration.ConfigurationManager.AppSettings("MainPath") & "Upload\" & FilePath)
                Dim sqlstr As String
                sqlstr = "UPDATE Product_Img SET Filename='" & FU1.FileName & "', FilePath='" + "Upload\" & FilePath & "' WHERE idno = " & LP1.Text & ""
                Main.NonQuery(sqlstr)
                Response.Write(sqlstr)
                'Else
                '    Response.Write(" no pic1/")
            End If
            If FU2.HasFile Then   ' 圖片2
                Dim FileName As String = FU2.FileName
                FilePath = Comm.GetDateString(Now) & "_" & FU2.FileName
                FU2.SaveAs(System.Configuration.ConfigurationManager.AppSettings("MainPath") & "Upload\" & FilePath)
                Dim sqlstr As String
                sqlstr = "UPDATE Product_Img SET Filename='" & FU2.FileName & "', FilePath='" + "Upload\" & FilePath & "' WHERE idno = " & LP2.Text & ""
                Main.NonQuery(sqlstr)
                Response.Write(sqlstr)
                'Else
                '    Response.Write(" no pic2/")
            End If
            If FU3.HasFile Then   ' 圖片3
                Dim FileName As String = FU3.FileName
                FilePath = Comm.GetDateString(Now) & "_" & FU3.FileName
                FU3.SaveAs(System.Configuration.ConfigurationManager.AppSettings("MainPath") & "Upload\" & FilePath)
                Dim sqlstr As String
                sqlstr = "UPDATE Product_Img SET Filename='" & FU3.FileName & "', FilePath='" + "Upload\" & FilePath & "' WHERE idno = " & LP3.Text & ""
                Main.NonQuery(sqlstr)
                Response.Write(sqlstr)
                'Else
                '    Response.Write(" no pic3/")
            End If
            If FU4.HasFile Then   ' 圖片4
                Dim FileName As String = FU4.FileName
                FilePath = Comm.GetDateString(Now) & "_" & FU4.FileName
                FU4.SaveAs(System.Configuration.ConfigurationManager.AppSettings("MainPath") & "Upload\" & FilePath)
                Dim sqlstr As String
                sqlstr = "UPDATE Product_Img SET Filename='" & FU4.FileName & "', FilePath='" + "Upload\" & FilePath & "' WHERE idno = " & LP4.Text & ""
                Main.NonQuery(sqlstr)
                Response.Write(sqlstr)
                'Else
                '    Response.Write(" no pic4")
            End If

        Else
            If FU1.HasFile Then
                Dim FL As Integer = Int(FU1.PostedFile.ContentLength / 1024)
                If FL > 5120 Then tmp += "，附件大小超過限制"
            Else
                tmp += "，請上傳圖片"
            End If

            If tmp <> "" Then
                Me.ClientScript.RegisterStartupScript(Me.GetType, "String", "alert('" & tmp.Substring(1) & "');", True)
                Exit Sub
            End If

            str = "insert into product (Product_Name, Cate_ID, Unit,Price,Payment,delivery,stock,OnSale,dimension,description,Product_No,BarCode,Memo,store_ID) values " & _
                " ('" & TB_ProductName.Text.Trim() & "','" & DDL_Cate.SelectedValue & "','" & DDL_Unit.SelectedValue & "','" & TB_Price.Text & "','" & DDL_Payment.SelectedValue & _
                "','" & DDL_Delivery.SelectedValue & "','" & TB_Stock.Text & "','" & DDL_OnSale.SelectedValue & "','" & TB_Dimension.Text & "','" & TB_Description.Text & "','" & TB_ProductNo.Text.Trim() & _
                "','" & TB_BarCode.Text.Trim() & "','" & TB_Memo.Text & "', " & Request.QueryString("s") & ")"
            Dim NQ As Integer = Main.NonQuery(str)
            If NQ = 0 Then
                Me.ClientScript.RegisterStartupScript(Me.GetType, "String", "alert('儲存失敗，請重新操作或連絡管理者');", True)
                Response.Write(str) '測試
                Exit Sub
            End If

            ' 取得Product_ID，insert用
            Dim Product_ID As Integer = Main.Scalar("select top 1 IDNo from product where store_ID =" & Request.QueryString("s") & " and product_Name ='" & TB_ProductName.Text.Trim() & "' order by IDNo")
            Dim FilePath As String = ""
            If FU1.HasFile Then   ' 圖片1
                Dim FileName As String = FU1.FileName
                FilePath = Comm.GetDateString(Now) & "_" & FU1.FileName
                FU1.SaveAs(System.Configuration.ConfigurationManager.AppSettings("MainPath") & "Upload\" & FilePath)
                Dim sqlstr As String
                sqlstr = "insert into Product_Img (Product_ID,FileName,FilePath) values "
                sqlstr += " ('" & Product_ID & "' , '" & FU1.FileName & "' , '" + "Upload\" & FilePath & "')"
                Main.NonQuery(sqlstr)
                Response.Write(sqlstr)
            End If
            If FU2.HasFile Then   ' 圖片2
                Dim FileName As String = FU2.FileName
                FilePath = Comm.GetDateString(Now) & "_" & FU2.FileName
                FU2.SaveAs(System.Configuration.ConfigurationManager.AppSettings("MainPath") & "Upload\" & FilePath)
                Dim sqlstr As String
                sqlstr = "insert into Product_Img (Product_ID,FileName,FilePath) values "
                sqlstr += " ('" & Product_ID & "' , '" & FU2.FileName & "' , '" + "Upload\" & FilePath & "')"
                Main.NonQuery(sqlstr)
                Response.Write(sqlstr)
            End If
            If FU3.HasFile Then   ' 圖片3
                Dim FileName As String = FU3.FileName
                FilePath = Comm.GetDateString(Now) & "_" & FU3.FileName
                FU3.SaveAs(System.Configuration.ConfigurationManager.AppSettings("MainPath") & "Upload\" & FilePath)
                Dim sqlstr As String
                sqlstr = "insert into Product_Img (Product_ID,FileName,FilePath) values "
                sqlstr += " ('" & Product_ID & "' , '" & FU3.FileName & "' , '" + "Upload\" & FilePath & "')"
                Main.NonQuery(sqlstr)
                Response.Write(sqlstr)
            End If
            If FU4.HasFile Then   ' 圖片4
                Dim FileName As String = FU4.FileName
                FilePath = Comm.GetDateString(Now) & "_" & FU4.FileName
                FU4.SaveAs(System.Configuration.ConfigurationManager.AppSettings("MainPath") & "Upload\" & FilePath)
                Dim sqlstr As String
                sqlstr = "insert into Product_Img (Product_ID,FileName,FilePath) values "
                sqlstr += " ('" & Product_ID & "' , '" & FU4.FileName & "' , '" + "Upload\" & FilePath & "')"
                Main.NonQuery(sqlstr)
                Response.Write(sqlstr)
            End If
        End If

        'Response.Write("<script>alert('儲存成功');window.open('Default.aspx?s=" & Request.QueryString("s") & "','_self');</script>")
        Response.Write("<script>alert('儲存成功');</script>")

    End Sub

    Protected Sub BTD_Click(sender As Object, e As System.EventArgs) Handles BTD.Click
        Response.Redirect("Default.aspx?s=" & Request.QueryString("s") & "")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Dim t As New MemoryStream()
        FU1.PostedFile.InputStream.CopyTo(t)
        imgA.Src = "data:image/jpg;base64," + Convert.ToBase64String(t.ToArray())
    End Sub
End Class
