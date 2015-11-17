﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreMana.Mini
{
    public partial class MiniMaster : System.Web.UI.MasterPage
    {
        JDB Main =new JDB();
        CommTool Comm = new CommTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              //  Comm.DeleCoookie("iapp_sid");
            
              //      Comm.SaveCookie("iapp_sid", "4");
               

                if (Comm.Store_ID() == -1)
                {
                    Response.Write("<Script>window.open('" + "../Login/m-login.aspx?s=1&done=" + HttpUtility.UrlEncode("../StoreMana/default.aspx") + "','_self')</Script>");
                }
                string SNID = Main.Scalar("Select Store_NID from Store where idno='" + Comm.Store_ID() + "'");
                menu_QR.Text = "<a href=\"" + Comm.MiStoreUrl + "Default.aspx?SN=" + SNID + "&Intr=" + Comm.User_ID() + "\" target=\"_blank\" ><img src=\"QRcode.ashx?t=" + Comm.MiStoreUrl + "Default.aspx?SN=" + SNID + "&Intr=" + Comm.User_ID() +"\" alt=\"\" class=\"QRcode\"> </a>";
                LGoMini.Text = "<li><a href=\"../../MiniStore/Default.aspx?SN=" + SNID + "\"><span class=\"glyphicon glyphicon-home\" aria-hidden=\"true\"></span>回iApp微店</a></li>";
            }
        }

        protected void LBLogout_Click(object sender, EventArgs e)
        {
            if (Comm.DeleCoookie("iapp_sid") == 1)
            {
                Response.Write("<Script>window.open('" + "../Login/m-login.aspx?s=1&done=" + HttpUtility.UrlEncode("../StoreMana/default.aspx") + "','_self')</Script>"); 
            } 
        }
    }
}