using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PR_Funds_MN
{
    public class sp_fund_login__ResultMetadata
    {

        public int sl_no { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [StringLength(25, ErrorMessage = "only 25 characters are allowed")]
        public string username { get; set; }
        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password, ErrorMessage = "please enter password")]
        public string pass_word { get; set; }
        //[NotMapped]
        //[Compare("pass_word")]
        //public string Confirm_pass_word { get; set; }
        public Nullable<int> user_roleid { get; set; }
        public string Name { get; set; }

    }

    [MetadataType(typeof(sp_fund_login__ResultMetadata))]
    public partial class sp_fund_login__Result
    {

    }


    //addmember
    public class fund_collection_newMetadata
    {
        public int id { get; set; }
        //[RegularExpression("[A-Za-z 0-9( *)./ ]", ErrorMessage = "enter name correctly")]
        [StringLength(20, ErrorMessage = "characters exceeded")]
        public string name { get; set; }
        [RegularExpression("[0-9]*", ErrorMessage = "enter valid mobile no.")]
        [Range(6666666666, 9999999999, ErrorMessage = "enter a valid mobile no.")]
        [DataType(DataType.PhoneNumber)]
        public Nullable<long> mobile_no { get; set; }
        public Nullable<decimal> loan_amnt { get; set; }
        public Nullable<decimal> balance_amt { get; set; }
        public Nullable<int> no_ofdue { get; set; }
        [Required(ErrorMessage = "please select date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> dt { get; set; }
    }

    [MetadataType(typeof(fund_collection_newMetadata))]
    public partial class fund_collection_new
    {

    }


    //addmember new
    public class new_addmember_onlyMetadata
    {
        public int id { get; set; }
        [Required(ErrorMessage="please enter name")]
        //[RegularExpression("[A-Za-z 0-9( *)./ ]", ErrorMessage = "enter name correctly")]
        [StringLength(25, ErrorMessage = "characters exceeded")]
        public string name { get; set; }
        [RegularExpression("[0-9]*", ErrorMessage = "enter valid mobile no.")]
        [Range(6666666666, 9999999999, ErrorMessage = "enter a valid mobile no.")]
        [DataType(DataType.PhoneNumber)]
        public Nullable<long> mobile_no { get; set; }
        [Required(ErrorMessage = "please select date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> dt { get; set; }
    }

    [MetadataType(typeof(new_addmember_onlyMetadata))]
    public partial class new_addmember_only
    {

    }

    //member edit from details fund list
    public class sp_view_new_addmember_byid_ResultMetadata
    {
        public int id { get; set; }
         [Required(ErrorMessage="please enter name")]
        [StringLength(25, ErrorMessage = "characters exceeded")]
        public string name { get; set; }
        [RegularExpression("[0-9]*", ErrorMessage = "enter valid mobile no.")]
        [Range(6666666666, 9999999999, ErrorMessage = "enter a valid mobile no.")]
        [DataType(DataType.PhoneNumber)]
        public Nullable<long> mobile_no { get; set; }
        public Nullable<System.DateTime> dt { get; set; }
    }
    [MetadataType(typeof(sp_view_new_addmember_byid_ResultMetadata))]
    public partial class sp_view_new_addmember_byid_Result
    {
        
    }


    //new fund insert proc
    public class valuesto_sp_funds_ofMembermetdata
    {
        public int loan_id { get; set; }
        public Nullable<int> id { get; set; }
        public string name { get; set; }
        public Nullable<decimal> loan_amt { get; set; }
        [Required(ErrorMessage = "please enter the amount")]
        [Range(1, 9999, ErrorMessage = "please check amount..!")]
        public Nullable<decimal> inst_amt { get; set; }
        public Nullable<int> no_ofdue { get; set; }
        [Required(ErrorMessage = "please select date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> paid_dt { get; set; }
    }
    [MetadataType(typeof(valuesto_sp_funds_ofMembermetdata))]
    public partial class valuesto_sp_funds_ofMember
    {

    }

    public class full_valuestoprocedureMetadata
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<long> mobile_no { get; set; }
        public Nullable<decimal> loan_amt { get; set; }
        [Required(ErrorMessage = "please enter the amount")]
        [Range(1, 9999, ErrorMessage = "please check amount..!")]
        public Nullable<decimal> inst_amt { get; set; }
        public Nullable<int> no_ofdue { get; set; }
        [Required(ErrorMessage = "please select date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> paid_dt { get; set; }
    }

    [MetadataType(typeof(full_valuestoprocedureMetadata))]
    public partial class full_valuestoprocedure
    {

    }


    public class sp_viewtrans_bydate_ResultMetadata
    {
        [Required(ErrorMessage = "please select date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> trans_dt { get; set; }
    }

    [MetadataType(typeof(sp_viewtrans_bydate_ResultMetadata))]
    public partial class sp_viewtrans_bydate_Result
    {

    }

    public class avl_fundMetadata
    {
        public int sl_no { get; set; }
        [Required(ErrorMessage = "please enter amount")]
        [DataType(DataType.Currency)]
        [RegularExpression("[0-9]*", ErrorMessage = "invalid amount")]
        public Nullable<decimal> avl_fund_ { get; set; }
    }

    [MetadataType(typeof(avl_fundMetadata))]
    partial class avl_fund
    {

    }

    public class sp_view_fund_collection_new_byidonly_ResultMetadata
    {
        public int id { get; set; }
        [Required(ErrorMessage = "please enter the name")]
        //[RegularExpression("[A-Za-z 0-9*( )./ ]", ErrorMessage = "enter name correctly")]
        [StringLength(25, ErrorMessage = "characters exceeded")]
        public string name { get; set; }
        //[Required(ErrorMessage = "please enter the Mobile no.")]
        [RegularExpression("[0-9]*", ErrorMessage = "enter valid mobile no.")]
        [Range(6666666666, 9999999999, ErrorMessage = "enter a valid mobile no.")]
        [DataType(DataType.PhoneNumber)]
        public Nullable<long> mobile_no { get; set; }
    }

    [MetadataType(typeof(sp_view_fund_collection_new_byidonly_ResultMetadata))]
    partial class sp_view_fund_collection_new_byidonly_Result
    {

    }

    public class fund_login_onlyfor_signupMetadata
    {
        public int sl_no { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression("[a-zA-Z0-9]*", ErrorMessage = "No special characters and spaces")]
        [StringLength(25, ErrorMessage = "only 25 characters are allowed")]
        public string username { get; set; }
        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password, ErrorMessage = "please enter password")]
        public string pass_word { get; set; }
        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password, ErrorMessage = "please enter password")]
        //[Compare("pass_word",ErrorMessage="password doesnot match")]
        public string con_pass_word { get; set; }
        public Nullable<int> user_roleid { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("[A-Za-z]*", ErrorMessage = "Alphabets only")]
        [StringLength(25, ErrorMessage = "only 25 characters are allowed")]
        public string Name { get; set; }
    }
    [MetadataType(typeof(fund_login_onlyfor_signupMetadata))]
    partial class fund_login_onlyfor_signup
    {

    }

    //edit for members having loan after pressing details

    public class abc
    {
        public int loan_id { get; set; }
        public Nullable<int> id { get; set; }
        [Required(ErrorMessage="please enter name")]
        [StringLength(25, ErrorMessage = "characters exceeded")]
        public string name { get; set; }
        public Nullable<decimal> loan_amnt { get; set; }
        public Nullable<decimal> balance_amt { get; set; }
        public Nullable<int> no_ofdue { get; set; }
        public Nullable<System.DateTime> dt { get; set; }
    }
    [MetadataType(typeof(abc))]
    public partial class sp_view_funds_ofMember_by_loanid_Result
    {
    }
}