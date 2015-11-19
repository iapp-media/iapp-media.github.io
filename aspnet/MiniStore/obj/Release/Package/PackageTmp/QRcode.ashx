<%@ WebHandler Language="C#" Class="QRcode" %>

using System;
using System.Web;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;
public class QRcode : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    string url = System.Configuration.ConfigurationSettings.AppSettings.Get("Url");
    public void ProcessRequest(HttpContext context)
    {

        CommTool Comm = new CommTool();
        int size = 3;
        int ver = 5;
        if (Comm.IsNumeric(context.Request.QueryString["s"]) == true) { size = Comm.Cint2(context.Request.QueryString["s"]); }
        if (Comm.IsNumeric(context.Request.QueryString["v"]) == true) { ver = Comm.Cint2(context.Request.QueryString["v"]); }
        
        if (context.Request.QueryString["t"] != "" && context.Request.QueryString["t"] != null)
        {
            url = context.Request.QueryString["t"];
            Image im;
            try
            {
                QRCodeEncoder QRC = new QRCodeEncoder();
                QRC.QRCodeScale = size;
                QRC.QRCodeVersion = ver;
                QRC.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                im = QRC.Encode(url);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                im.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                context.Response.ContentType = "image/Gif";
                context.Response.BinaryWrite(ms.ToArray());
            }
            catch (Exception e)
            {

            }
        }
        //else
        //{
        //    if (context.Session["IDNo"] != null)
        //    {
        //        url = "http://www.iapp-media.com/basic/" + context.Request.QueryString["AppUrl"];
        //    }
        //}
    }
     
    
    //Sub GetQRCode(ByVal CodeText As String, ByVal QRSize As Integer, Optional ByVal QRVerson As Integer = 1)
    //    Dim im As Image
    //    Try
    //        Dim QRC As New QRCodeEncoder
    //        QRC.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE
    //        '  AlphaNumeric()
    //        '  Numeric()
    //        '  Byte 
    //        QRC.QRCodeScale = QRSize
    //        '  QRC.QRCodeVersion = 1
    //        QRC.QRCodeVersion = QRVerson
    //        '1~40
    //        QRC.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L
    //        'L
    //        'M()
    //        'Q()
    //        'H()
    //        If CodeText <> "" Then im = QRC.Encode(CodeText)

    //        Dim ms As New System.IO.MemoryStream()
    //        im.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
    //        Response.ClearContent()
    //        Response.ContentType = "image/Gif"
    //        Response.BinaryWrite(ms.ToArray())

    //    Catch ex As Exception
    //        Response.Write(ex.Message)

    //        '  im.Dispose()
    //    End Try 
    //End Sub

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}