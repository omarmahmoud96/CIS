﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.doctor.account
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSignupSubmit_Click(object sender, EventArgs e)
        {
            
                string fName = this.TextboxSignupFirstname.Text;
                string lName = this.TextboxSignupLastname.Text;
                string email = this.TextboxSignupEmail.Text;
                string password = this.TextboxSignupPassword.Text;
                string phone = this.TextboxSignupMobile.Text;
                int fees = Convert.ToInt32(this.TextboxFees.Text);
                WebApplication1.scripts.doctor acc = new scripts.doctor();
                acc.setFname(fName);
                acc.setLname(lName);
                acc.setEmail(email);
                acc.setPassword(password);
                acc.setPNumber(phone);
                acc.setFees(fees);
                WebApplication1.scripts.doctorDAO dao = new scripts.doctorDAO();
                if (dao.getAccountByPhone(phone).getID() == -1)
                {
                    dao.insertData(acc);

                    ClientScriptManager cs = Page.ClientScript;
                    Type cstype = this.GetType();

                    String alert = "alert('registeration completed');";
                    cs.RegisterStartupScript(cstype, "PopupScript", alert, true);
                    Response.Redirect(Page.ResolveClientUrl("/doctor/account/login.aspx"));

                }
                else
                {
                    ClientScriptManager cs = Page.ClientScript;
                    Type cstype = this.GetType();

                    String alert = "alert('this phone number is already registered ');";
                    cs.RegisterStartupScript(cstype, "PopupScript", alert, true);
                }

            
        }
    }
}