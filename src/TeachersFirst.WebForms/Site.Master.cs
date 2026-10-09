using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TeachersFirst.WebForms
{
    public partial class SiteMaster : MasterPage
    {
        protected HtmlGenericControl MainNavigation;

        protected void Page_Load(object sender, EventArgs eventArgs)
        {
            var currentPage = VirtualPathUtility.GetFileName(Page.AppRelativeVirtualPath);
            foreach (Control control in MainNavigation.Controls)
            {
                var link = control as HyperLink;
                if (link == null)
                    continue;
                var destination = VirtualPathUtility.GetFileName(link.NavigateUrl);
                link.CssClass = string.Equals(destination, currentPage, StringComparison.OrdinalIgnoreCase) ? "selected" : string.Empty;
                if (link.CssClass == "selected")
                    link.Attributes["aria-current"] = "page";
            }
        }
    }
}