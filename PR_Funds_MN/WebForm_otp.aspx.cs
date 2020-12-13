using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace PR_Funds_MN
{
    public partial class WebForm_otp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = false;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                Random rdm = new Random();
                int otp = rdm.Next(01111, 99999);
                string dstn_addrs = "91" + TextBox1.Text;
                string message = "Your otp for PR Funds is : " + otp;
                string msg = HttpUtility.UrlEncode(message);

                using (var wc = new WebClient())
                {
                    byte[] response = wc.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                    {"apikey" , "b6rVufCpgqs-dXorDannqzokaBhGNpeOthKBUjQaYp" },
                    {"numbers" , dstn_addrs },
                    {"message" , msg },
                    {"Sender" , "MADHUSUDHAN" }
                });

                    string res = System.Text.Encoding.UTF8.GetString(response);
                    Session["OTP"] = otp;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox2.Text == Session["OTP"].ToString())
                {
                    Label3.Visible = false;
                    Panel2.Visible = false;
                    Label2.Text = "Your mobile number has been verified successfully";

                    string dstn_addrs = "91" + TextBox1.Text;
                    string message = "Your mobile number has been verified successfully.";
                    string msg = HttpUtility.UrlEncode(message);

                    using (var wc = new WebClient())
                    {
                        byte[] response = wc.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                    {"apikey" , "b6rVufCpgqs-dXorDannqzokaBhGNpeOthKBUjQaYp" },
                    {"numbers" , dstn_addrs },
                    {"message" , msg },
                    {"Sender" , "MADHUSUDHAN" }
                });
                    }
                }
                else
                {
                    Panel2.Visible = true;
                    Label3.Text = "OTP is incorrect";
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}