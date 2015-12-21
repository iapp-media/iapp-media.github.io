using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace MiniStore
{
    public partial class CreditCard_Finish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string CMD5(string txt)
        {
            //using System.Web.Security 

            string Hash = FormsAuthentication.HashPasswordForStoringInConfigFile(txt, "MD5");

            return Hash.ToLower();
        }

    }
}