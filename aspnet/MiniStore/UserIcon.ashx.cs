using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Web;

namespace AppPortal
{
    /// <summary>
    /// UserIcon 的摘要描述
    /// </summary>
    public class UserIcon : IHttpHandler
    {
        CommTool Comm = new CommTool();
        JDB Main = new JDB();

        public void ProcessRequest(HttpContext context)
        {
            if (Comm.IsNumeric(context.Request.QueryString["i"]))
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = Main.ConnStr;
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "Select User_Icon from  Users where IDNo=" + context.Request.QueryString["i"];
                //object img = cmd.ExecuteScalar();              
                //if (img.GetType() !=  System.DBNull.Value.GetType())
                //{
                //    MemoryStream MS = new MemoryStream(Convert.ToByte(img));
                //    context.Response.ContentType = "image/jpeg";
                //    context.Response.BinaryWrite(MS.ToArray());
                //    MS.Close();
                //}
                //else
                //{
                //    FileStream aa = new FileStream(context.Server.MapPath("img/defaulthead.png"), FileMode.Open);
                //    byte[] buf = new byte[aa.Length];
                //    if (aa.Read(buf, 0, int.Parse(aa.Length.ToString())) > 1)
                //    {
                //        context.Response.ContentType = "image/png";
                //        context.Response.BinaryWrite(buf);
                //    }
                //    aa.Close();
                //    aa.Dispose();
                //}


                SqlDataReader dr = cmd.ExecuteReader();
                bool chk = false;
                if (dr.Read())
                {
                    if (dr["User_Icon"].GetType() != System.DBNull.Value.GetType())
                    {
                        byte[] imageData = (byte[])dr["User_Icon"];
                        MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length);
                        context.Response.ContentType = "image/jpeg";
                        context.Response.BinaryWrite(ms.ToArray());
                        ms.Close();
                        chk = true;
                    }
                }

                if (chk == false)
                {
                    FileStream aa = new FileStream(context.Server.MapPath("img/defaulthead.png"), FileMode.Open);
                    byte[] buf = new byte[aa.Length];
                    if (aa.Read(buf, 0, int.Parse(aa.Length.ToString())) > 0)
                    {
                        context.Response.ContentType = "image/png";
                        context.Response.BinaryWrite(buf);
                    }
                    aa.Close();
                    aa.Dispose();
                }
                conn.Close();

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}