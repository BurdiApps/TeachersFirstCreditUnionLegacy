using System;
using System.Web.UI;

namespace TeachersFirst.WebForms.Infrastructure
{
    public class DemoPage : Page
    {
        protected override void OnInit(EventArgs eventArgs)
        {
            if (Session["ViewStateToken"] == null)
                Session["ViewStateToken"] = Guid.NewGuid().ToString("N");
            ViewStateUserKey = (string)Session["ViewStateToken"];
            base.OnInit(eventArgs);
        }
    }
}