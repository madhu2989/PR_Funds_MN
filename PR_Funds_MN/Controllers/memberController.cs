using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PR_Funds_MN.Controllers
{
    public class memberController : Controller
    {
        //
        // GET: /member/
        FundEntities db = new FundEntities();

        public ActionResult mem_mainpage()
        {
            if (Session["username"] != null && Session["userroleid"].ToString() != "1")
            {
                ViewBag.message = "Welcome '" + Session["Name"] + "'";
                return View();
            }
            else
            {
                return RedirectToAction("login", "login");
            }

        }


        public ActionResult mem_fundlist()
        {
            if (Session["username"] != null && Session["userroleid"].ToString() != "1")
            {
                ViewBag.name = "Loan details of '" + Session["Name"] + "'.";
                List<sp_view_funds_ofMember_byid_Result> list = new List<sp_view_funds_ofMember_byid_Result>();
                list = db.sp_view_funds_ofMember_byid(Convert.ToInt32(Session["userroleid"])).ToList();
                return View(list);
            }
            else
            {
                return RedirectToAction("login", "login");
            }
        }

        public ActionResult My_transactions()
        {
            if (Session["username"] != null && Session["userroleid"].ToString() != "1")
            {
                List<sp_viewtrans_fund_joined_deposit_byId_Result> list = new List<sp_viewtrans_fund_joined_deposit_byId_Result>();
                list = db.sp_viewtrans_fund_joined_deposit_byId(Convert.ToInt32(Session["userroleid"])).ToList();
                return View(list);
            }
            else
            {
                return RedirectToAction("login", "login");
            }
        }


    }
}