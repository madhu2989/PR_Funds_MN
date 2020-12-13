using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PR_Funds_MN.Controllers
{
    public class loginController : Controller
    {
        //
        // GET: /login/
        FundEntities db = new FundEntities();

        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(sp_fund_login__Result byname)
        {
            sp_fund_login__Result obj = new sp_fund_login__Result();
            obj = db.sp_fund_login_(byname.username).FirstOrDefault();

            if (obj != null)
            {
                if (obj.username == byname.username)
                {
                    if (obj.pass_word == byname.pass_word)
                    {
                        Session["username"] = obj.username.ToString();
                        Session["Name"] = obj.Name.ToString();
                        Session["userroleid"] = obj.user_roleid.ToString();

                        if (obj.user_roleid.ToString() == "1")
                        {
                            return RedirectToAction("mainpage", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("mem_mainpage", "member");
                        }
                    }
                    else
                    {
                        ViewBag.incrct_pass = "incorrect password....!";
                        return View();
                    }
                }
                else
                {
                    ViewBag.incrct_pass = "incorrect username....!";
                    return View();
                }
            }
            else
            {
                ViewBag.incrct_pass = "incorrect username....!";
                return View();
            }
        }

        public ActionResult logout()
        {
            if (Session["username"] != null && Session["userroleid"].ToString() != null)
            {
                Session.Abandon();
                Session.Clear();                 
                return RedirectToAction("login");
            }
            else
                return RedirectToAction("login");
        }

        public ActionResult sign_up()
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }

        }


        [HttpPost]
        public ActionResult sign_up(fund_login_onlyfor_signup tab)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(tab.pass_word==tab.con_pass_word)
                    {
                        ObjectParameter retout = new ObjectParameter("sl_noout", 0);
                        int res = db.sp_fund_login_insert(tab.sl_no,tab.username,tab.pass_word,tab.user_roleid,tab.Name,retout);
                        this.db.SaveChanges();
                        TempData["sign_up_success"] = "'"+tab.Name+"' has Signed up successfully.";
                        return RedirectToAction("sign_up");
                    }
                    else
                    {
                        ViewBag.pass_notmatch = "passwords do not match...!";
                        return View();
                    }
                }
                else
                {
                    ViewBag.nullvalues="please enter the details correctly..!";
                    return View("sign_up");
                }



            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public ActionResult accessed_uers()
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {
                List<sp_view_fund_login_Result> list = new List<sp_view_fund_login_Result>();
                list = db.sp_view_fund_login().ToList();
                return View(list);
            }
            else
            {
                return RedirectToAction("login");
            }
        }

        public ActionResult delete_access(int id,string name)
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {
                int res = db.sp_fund_login_delete(id);
                this.db.SaveChanges();
                TempData["access_del"] = "Access has been restricted to '" + name+"' successfully";
                return RedirectToAction("accessed_uers");
            }
            else
            {
                return RedirectToAction("login");
            }
        }
    }
}