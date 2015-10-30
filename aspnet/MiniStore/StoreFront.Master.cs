﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniStore
{
    public partial class StoreFront : System.Web.UI.MasterPage
    {
        CommTool Comm = new CommTool();
        JDB Main = new JDB(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string jump = "";
                if (Comm.User_ID() == -1)
                {
                    jump = "../Login/m-login.aspx?done=" + HttpUtility.UrlEncode("../MiniStore/default.aspx?SN=" + Request.QueryString["SN"] + "") + "";
                    Response.Write("<Script>window.open('" + jump + "','_self')</Script>");
                    return;
                    //System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "String",
                    //    "if(confirm('請先登入')){window.open('" + jump + "','_self');}else{window.open('" + jump + "','_self');}", true); 
                }

                if (Request.QueryString["SN"] == null)
                {
                    Response.Redirect("Default.aspx?SN=OfficACC");
                }

                jump = "../Login/m-login.aspx?s=1&done=" + HttpUtility.UrlEncode("../StoreMana/default.aspx");
                L_MyStore.Text = " <li><a href='" + jump + "'  target='_self' >打造自己的微店</a></li>" +
                                 " <li><a href='#'>加入行動分店</a></li>" +
                                 " <li>我的帳戶</li>" +
                                 " <li><a href='#'>會員資料</a></li>" +
                                 " <li><a href='Order_history.aspx?SN=" + Request.QueryString["SN"] + "'>訂單查詢</a></li>";
            }
        }
    }
}