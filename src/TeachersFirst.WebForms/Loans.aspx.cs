using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeachersFirst.WebForms.Infrastructure;
using TeachersFirst.WebForms.Services;

namespace TeachersFirst.WebForms
{
    public partial class LoansPage : DemoPage
    {
        protected TextBox LoanAmount;
        protected TextBox AnnualRate;
        protected TextBox TermMonths;
        protected Label LoanPaymentResult;

        protected void CalculatePayment_Click(object sender, EventArgs eventArgs)
        {
            Page.Validate("PaymentCalc");
            if (Page.GetValidators("PaymentCalc").Cast<IValidator>().Any(validator => !validator.IsValid))
            {
                LoanPaymentResult.Text = "Check the values and calculate again.";
                return;
            }

            decimal principal;
            decimal annualRate;
            int termMonths;
            if (!decimal.TryParse(LoanAmount.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out principal)
                || !decimal.TryParse(AnnualRate.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out annualRate)
                || !int.TryParse(TermMonths.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out termMonths))
            {
                LoanPaymentResult.Text = "Enter numbers using a period for decimals.";
                return;
            }

            var payment = LoanPaymentCalculator.CalculateMonthlyPayment(principal, annualRate, termMonths);
            LoanPaymentResult.Text = "Estimated monthly principal and interest: " + payment.ToString("C2", CultureInfo.GetCultureInfo("en-US"));
        }
    }
}