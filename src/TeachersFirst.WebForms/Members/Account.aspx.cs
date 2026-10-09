using System;
using System.Globalization;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using TeachersFirst.WebForms.Infrastructure;
using TeachersFirst.WebForms.Services;

namespace TeachersFirst.WebForms
{
    public partial class AccountPage : DemoPage
    {
        protected Literal MemberName;
        protected Literal Balance;
        protected DropDownList ActivityFilter;
        protected GridView ActivityGrid;

        protected void Page_Load(object sender, EventArgs eventArgs)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            if (!IsPostBack)
                BindAccount();
        }

        protected void Filter_Changed(object sender, EventArgs eventArgs)
        {
            BindAccount();
        }

        private void BindAccount()
        {
            var account = new DemoAccountService().Load(Server.MapPath("~/App_Data/Account.xml"));
            MemberName.Text = account.MemberName;
            Balance.Text = account.AvailableBalance.ToString("C2", CultureInfo.GetCultureInfo("en-US"));
            var transactions = account.Transactions.AsEnumerable();
            if (ActivityFilter.SelectedValue == "deposits")
                transactions = transactions.Where(transaction => transaction.Amount > 0);
            if (ActivityFilter.SelectedValue == "spending")
                transactions = transactions.Where(transaction => transaction.Amount < 0);
            ActivityGrid.DataSource = transactions.OrderByDescending(transaction => transaction.PostedAt).ToList();
            ActivityGrid.DataBind();
        }

        protected void Logout_Click(object sender, EventArgs eventArgs)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Redirect("~/Default.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}