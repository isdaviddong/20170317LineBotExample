using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class LineNotifyCallback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //callback頁面取回code
            string code = Request.QueryString["code"].ToString();
            if (!string.IsNullOrEmpty(code) && string.IsNullOrEmpty(this.TextBox1.Text))
            {
                //用code換Token
                var ret = isRock.LineNotify.Utility.GetToeknFromCode(
                    code, "FkAGRhqEzcte61s2PWjP8b", //ClientID一定要100%對
                    "i7HJlDONH--------請用你自己的---------X4Ib5wj", //ClientSecret 一定要100%對
                    "http://localhost:43970/LineNotifyCallback.aspx" //Callback url一定要100%對
                    );
                this.TextBox1.Text = ret.access_token;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //發送訊息
            isRock.LineNotify.Utility.SendNotify(this.TextBox1.Text, "test" + DateTime.Now.ToString());
        }
    }
}