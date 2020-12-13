using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PR_Funds_MN.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        FundEntities db = new FundEntities();

        public ActionResult mainpage()
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {
                ViewBag.message = "Welcome '" + Session["Name"] + "'";
                return View();
            }
            else
            {
                return RedirectToAction("login", "login");
            }
        }

        public ActionResult addmember()
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {
                //ViewBag.message = "Welcome '" + Session["Name"] + "'";
                return View();
            }
            else
            {
                return RedirectToAction("login", "login");
            }
        }

        [HttpPost]
        public ActionResult addmember(new_addmember_only tab)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                if (tab.name == null || tab.dt == null)
                {
                    ViewBag.nonullvaluestoaddmember = "please enter the details correctly..!";
                    return View();
                }
                else
                {
                    //string check_name = db.sp_members_singlename(tab.name).FirstOrDefault();
                    string check_name = db.sp_members_checkname(tab.name).FirstOrDefault();
                    if (check_name != tab.name)
                    {
                        ObjectParameter retout = new ObjectParameter("idout", 0);
                        //int res = db.sp_fund_collection_new_addmember(tab.id, tab.name, tab.mobile_no, tab.dt, retout);
                        int res = db.sp_new_addmember_only(tab.id, tab.name, tab.mobile_no, tab.dt, retout);
                        int resout = Convert.ToInt16(retout.Value);
                        this.db.SaveChanges();
                        TempData["member_added"] = "Member added successfully of Id :" + resout + ".";
                        return RedirectToAction("addmember");
                    }
                    else
                    {
                        ViewBag.namealreadyexist = "Member name already exist";
                        return View();
                    }


                }

                //}
                //ViewBag.nonullvaluestoaddmember="please enter the details correctly..!";
                //return View("addmember");
            }
            catch (Exception)
            {
                ViewBag.Message = "Member not added.";
                return View();
                throw;
            }
        }

        //delete member
        public ActionResult deletemember(int? id, string name, long? mob)
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {

                Session["id"] = id;
                Session["Name"] = name;
                Session["mob"] = mob;
                // ViewBag.amount = db.sp_fund_amount().ToList();
                return View();
            }
            else
            {
                return RedirectToAction("login", "login");
            }
        }

        [HttpPost]
        public ActionResult deletemember(sp_view_fund_collection_new_byidonly_Result tab)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int res = db.sp_deleteMember(tab.id);
                    this.db.SaveChanges();
                    TempData["deleted"] = "Member deleted successfully.";
                    return RedirectToAction("fundlist");
                }
                else
                {
                    ViewBag.nonullvaluestoaddmember = "please enter the details correctly..!";
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }




        //list only contains detail button
        public ActionResult fundlist_details()
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {
                //ViewBag.message = "Welcome '" + Session["Name"] + "'";              

                //List<sp_view_fund_collection_new_Result> list = new List<sp_view_fund_collection_new_Result>();
                //list = db.sp_view_fund_collection_new().ToList();
                //return View(list);
                long avl_bl = Convert.ToInt64(db.sp_checkbal().FirstOrDefault());
                Session["avl_bl"]=avl_bl;
                List<sp_view_new_addmember_only_Result> list = new List<sp_view_new_addmember_only_Result>();
                list = db.sp_view_new_addmember_only().ToList();
                return View(list);
            }
            else
            {
                return RedirectToAction("login", "login");
            }
        }


        //after pressing detail button
        [HttpGet]
        public ActionResult fundlist(int? id, string name)
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {
                //ViewBag.message = "Welcome '" + Session["Name"] + "'";
                Session["id"] = id;
                Session["Name"] = name;
                //Session["mob"] = mob;
                //List<sp_view_loansof_member_Result> list = new List<sp_view_loansof_member_Result>();
                //list = db.sp_view_loansof_member(id).ToList();
                //return View(list);
                List<sp_view_funds_ofMember_byid_Result> list = new List<sp_view_funds_ofMember_byid_Result>();
                list = db.sp_view_funds_ofMember_byid(id).ToList();
                return View(list);
            }
            else
            {
                return RedirectToAction("login", "login");
            }
        }

        public ActionResult newfund()
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {

                sp_view_new_addmember_byid_Result obj = new sp_view_new_addmember_byid_Result();
                obj = db.sp_view_new_addmember_byid(Convert.ToInt32(Session["id"])).FirstOrDefault();
                if (obj != null)
                {
                    ViewBag.Nameofmember = "New fund for " + "'" + obj.name + "'";

                    Session["new_id"] = obj.id;
                    Session["new_Name"] = obj.name;
                    //Session["new_mob"] = obj.mobile_no;
                    // ViewBag.amount = db.sp_fund_amount().ToList();
                    return View();
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return RedirectToAction("login", "login");
            }
        }


        [HttpPost]
        public ActionResult newfund(valuesto_sp_funds_ofMember tab)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                if (tab.loan_amt != null)
                {

                    long avl_bl = Convert.ToInt64(db.sp_checkbal().FirstOrDefault());
                    if (tab.loan_amt <= avl_bl)
                    {
                        ObjectParameter retbal = new ObjectParameter("bal_amt", 0);
                        ObjectParameter rettrans_type = new ObjectParameter("trans_type", 0);
                        ObjectParameter retsl_no = new ObjectParameter("sl_no", 0);
                        ObjectParameter ret_avl_bal = new ObjectParameter("avl_bal", 0);
                        ObjectParameter ret_loan_id = new ObjectParameter("loan_idout", 0);


                        //int res = db.sp_fund_collection_new(Convert.ToInt32(Session["new_id"]), tab.name,Convert.ToInt64(Session["new_mob"]), tab.loan_amnt, 0,0, tab.dt, trans_type, retsl_no, ret_avl_bal);
                        int result = db.sp_funds_ofMember(tab.loan_id, tab.id, tab.name, tab.loan_amt, 0, retbal, 0, tab.paid_dt, rettrans_type, retsl_no, ret_avl_bal, ret_loan_id);
                        this.db.SaveChanges();
                        TempData["Trans_message"] = "Loan amount of 'Rs:" + tab.loan_amt + "' has been given to '" + tab.name + "'.";
                        //return RedirectToAction("fundlist", new { id = (Convert.ToInt32(Session["id"])) });
                        return RedirectToAction("fundlist", new { id = tab.id });
                    }
                    else
                    {
                        TempData["insufficient_bal"] = "There is no Sufficient balance for this loan amount.";
                        return RedirectToAction("fundlist", new { id = (Convert.ToInt32(Session["id"])) });
                    }
                }
                else
                {
                    ViewBag.loanamt_null = "please select loan amount";
                    return View();
                }
                //}
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult collectfund(int? loan_id, int? id, string name, decimal? loan)
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {
                Session["col_loan_id"] = loan_id;
                Session["col_id"] = id;
                Session["col_Name"] = name;
                Session["col_loan"] = loan;
                return View();
            }
            else
            {
                return RedirectToAction("login", "login");
            }
        }

        [HttpPost]
        public ActionResult collectfund(valuesto_sp_funds_ofMember tab)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //DateTime date_pass=Convert.ToDateTime(tab.paid_dt);

                    long avl_bl = Convert.ToInt64(db.sp_checkbal().FirstOrDefault());
                    if (0 < tab.inst_amt || tab.inst_amt != 0)
                    {
                        ObjectParameter retbal = new ObjectParameter("bal_amt", 0);
                        ObjectParameter trans_type = new ObjectParameter("trans_type", 0);
                        ObjectParameter retsl_no = new ObjectParameter("sl_no", 0);
                        ObjectParameter ret_avl_bal = new ObjectParameter("avl_bal", 0);
                        ObjectParameter ret_loan_id = new ObjectParameter("loan_idout", typeof(int));

                        // DateTime resdate = Convert.ToDateTime(retdate.Value);
                        int no_ofdue = Convert.ToInt32(db.sp_no_ofweeks(tab.name, tab.paid_dt).FirstOrDefault());
                        if (0 == no_ofdue || no_ofdue == 1)
                        {
                            //suppose,if i'm paying for next week. The above procedure will return 1.
                            //but,there will be no dues.
                            //if the member skips one week it will return 2. then, due =1
                            //because,one week skipped

                            //int res = db.sp_fund_collection_new(Convert.ToInt32(Session["id"]), tab.name, Convert.ToInt64(Session["mob"]),
                            //Convert.ToInt32(Session["loan"]), tab.inst_amt,
                            // 0, tab.paid_dt, trans_type, retsl_no, ret_avl_bal);
                            int result = db.sp_funds_ofMember(tab.loan_id, Convert.ToInt32(Session["col_id"]), tab.name, Convert.ToInt32(Session["col_loan"]),
                                tab.inst_amt, retbal, 0, tab.paid_dt, trans_type, retsl_no, ret_avl_bal, ret_loan_id);
                        }
                        else
                        {
                            int due = no_ofdue - 1;

                            //int res = db.sp_fund_collection_new(Convert.ToInt32(Session["id"]), tab.name, Convert.ToInt64(Session["mob"]),
                            //Convert.ToInt32(Session["loan"]), tab.inst_amt,
                            // due, tab.paid_dt, trans_type, retsl_no, ret_avl_bal);

                            int result = db.sp_funds_ofMember(tab.loan_id, Convert.ToInt32(Session["col_id"]), tab.name, Convert.ToInt32(Session["col_loan"]),
                                tab.inst_amt, retbal, due, tab.paid_dt, trans_type, retsl_no, ret_avl_bal, ret_loan_id);
                        }

                        this.db.SaveChanges();
                        TempData["Trans_message"] = "Amount of 'Rs:" + tab.inst_amt + "' has been credited by '" + tab.name + "'.";
                        return RedirectToAction("fundlist", new { id = (Convert.ToInt32(Session["col_id"])) });
                    }
                    else
                    {
                        TempData["amt_negtive_or_zero"] = "Invalid amount.";
                        return RedirectToAction("collectfund", new { id = (Convert.ToInt32(Session["col_id"])) });
                    }
                }
                ViewBag.nonullvaluestoaddmember = "please enter the details correctly..!";
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult transactions()
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {
                List<sp_viewtrans_fund_joined_deposit_Result> list = new List<sp_viewtrans_fund_joined_deposit_Result>();
                list = db.sp_viewtrans_fund_joined_deposit().ToList();
                return View(list);
            }
            else
            {
                return RedirectToAction("login", "login");
            }
        }

        public ActionResult printweeklyfund()
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {

                return View();
            }
            else
            {
                return RedirectToAction("login", "login");
            }
        }

        [HttpPost]
        public ActionResult printweeklyfund(sp_viewtrans_bydate_Result onlydate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (onlydate.trans_dt != null)
                    {
                        List<sp_viewtrans_bydate_Result> list = new List<sp_viewtrans_bydate_Result>();
                        list = db.sp_viewtrans_bydate(onlydate.trans_dt).ToList();
                        return View("printweeklyfundbydate", list);
                    }
                    else
                    {
                        ViewBag.datenotfound = "please check the selected date.";
                        return View();
                    }
                }
                else
                {
                    return View();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult updatebalance()
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {
                long avl_bl = Convert.ToInt64(db.sp_checkbal().FirstOrDefault());
                ViewBag.avl_bal = "Available balance is ' Rs :" + avl_bl + " '.";
                return View();
            }
            else
            {
                return RedirectToAction("login", "login");
            }
        }

        [HttpPost]
        public ActionResult updatebalance(avl_fund amt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int res = db.sp_avl_fund(amt.avl_fund_);
                    this.db.SaveChanges();
                    TempData["bal_upd"] = "Rs :" + amt.avl_fund_ + " has been added to available fund";
                    return RedirectToAction("updatebalance");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult editmember(int? id)
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {
                Session["mem_id"] = id;
                sp_view_new_addmember_byid_Result obj = new sp_view_new_addmember_byid_Result();
                obj = db.sp_view_new_addmember_byid(id).FirstOrDefault();
                return View(obj);
            }
            else
            {
                return RedirectToAction("login", "login");
            }
        }

        [HttpPost]
        public ActionResult editmember(sp_view_new_addmember_byid_Result tab)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ObjectParameter ret_id = new ObjectParameter("idout", typeof(int));
                    //int res = db.sp_fund_collection_new_editonly(tab.id, tab.name,tab.mobile_no);
                    int res = db.sp_new_addmember_only(tab.id, tab.name, tab.mobile_no, tab.dt, ret_id);
                    this.db.SaveChanges();
                    TempData["edited"] = "Details edited successfully.";
                    return RedirectToAction("fundlist_details");
                }
                else
                {
                    ViewBag.nonullvaluestoaddmember = "please enter the details correctly..!";
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult editloan_member(int? loan_id, int? id)
        {
            if (Session["username"] != null && Session["userroleid"].ToString() == "1")
            {
                Session["mem_id"] = id;
                sp_view_funds_ofMember_by_loanid_Result obj = new sp_view_funds_ofMember_by_loanid_Result();
                obj = db.sp_view_funds_ofMember_by_loanid(loan_id).FirstOrDefault();
                return View(obj);
            }
            else
            {
                return RedirectToAction("login", "login");
            }
        }

        [HttpPost]
        public ActionResult editloan_member(sp_view_funds_ofMember_by_loanid_Result tab)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int res = db.sp_funds_ofMember_for_edit(tab.loan_id, tab.name);
                    this.db.SaveChanges();
                    TempData["edited"] = "Details edited successfully.";
                    return RedirectToAction("fundlist", new { tab.id });
                }
                else
                {
                    ViewBag.nonullvaluestoaddmember = "please enter the details correctly..!";
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult deleteloan_member(int? loan_id, int? id)
        {
            try
            {
                int res = db.sp_delete_funds_ofMember_by_loanid(loan_id);
                this.db.SaveChanges();
                TempData["deleted"] = "deleted successfully...!";
                return RedirectToAction("fundlist", new { id });

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}