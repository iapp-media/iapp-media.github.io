using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Act
{
    public partial class SendSMS : System.Web.UI.Page
    {

        JDB Main = new JDB(System.Configuration.ConfigurationManager.AppSettings.Get("Database2"));
        string vcode = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["n"] != null)
                {
                    if (Request["n"] != "")
                    {
                        Random Rm = new Random();
                        for (int i = 0; i < 4; i++)
                        {
                            vcode += Rm.Next(0, 9).ToString();
                        }
                        Main.ParaClear();
                        Main.ParaAdd("@Tel", Request["n"].ToString(), System.Data.SqlDbType.NVarChar);
                        Main.ParaAdd("@vcode", vcode, System.Data.SqlDbType.NVarChar);


                        //存在
                        if (Main.Scalar("select 1 from SMS_Record where Tel=@Tel") == "1")
                        {
                            //防五分鐘已內一直送
                            if (Main.Scalar("select IDNo from SMS_Record where Tel=@Tel and DATEDIFF(MINUTE,CreatDate,getdate())>5") != "")
                            {
                                //還要再送簡訊
                                Main.NonQuery(" update SMS_Record set vcode=@vcode,CreatDate=GETDATE(),cc=cc+1 where IDNo in (select IDNo from SMS_Record where Tel=@Tel and DATEDIFF(MINUTE,CreatDate,getdate())>5)");
                                Response.Write(Main.Scalar("select vcode from SMS_Record where Tel=@Tel"));
                                Response.End();
                            }
                        }
                        else
                        {
                            Main.NonQuery(" insert into SMS_Record (Tel,CreatDate,vcode,cc) values (@Tel,GETDATE(),@vcode,1)");
                            Response.Write(Main.Scalar("select vcode from SMS_Record where Tel=@Tel"));
                            Response.End();
                        }

                        // Response.Write("請立即前往接收訊息");
                        Response.Write(Main.Scalar("select vcode from SMS_Record where Tel=@Tel"));
                        Response.End();
                    }
                    else
                    {
                        Response.Write("err");
                        Response.End();

                    }
                }
                else
                {
                    Response.Write("err");
                    Response.End();

                }
            }
        }
    }
}