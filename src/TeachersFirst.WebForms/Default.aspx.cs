using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeachersFirst.WebForms.Infrastructure;

namespace TeachersFirst.WebForms
{
    public partial class HomePage : DemoPage
    {
        protected TextBox UserId;
        protected TextBox Password;
        protected Label LoginError;
        protected void Login_Click(object sender, EventArgs eventArgs)
        {
            if (!IsValid)
                return;

            if (UserId.Text != "demo.member" || Password.Text != "demo123")
            {
                LoginError.Text = "Use the published demo credentials.";
                return;
            }

            FormsAuthentication.SetAuthCookie("demo.member", false);
            Response.Redirect("~/Members/Account.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}