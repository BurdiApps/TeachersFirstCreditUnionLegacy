using System;

namespace TeachersFirst.WebForms.Services
{
    public static class LoanPaymentCalculator
    {
        public static decimal CalculateMonthlyPayment(decimal principal, decimal annualRatePercent, int termMonths)
        {
            if (principal < 1 || principal > 1000000)
                throw new ArgumentOutOfRangeException("principal");
            if (annualRatePercent < 0 || annualRatePercent > 50)
                throw new ArgumentOutOfRangeException("annualRatePercent");
            if (termMonths < 1 || termMonths > 360)
                throw new ArgumentOutOfRangeException("termMonths");

            var monthlyRate = annualRatePercent / 1200m;
            if (monthlyRate == 0)
                return decimal.Round(principal / termMonths, 2, MidpointRounding.AwayFromZero);

            var growthFactor = (decimal)Math.Pow((double)(1m + monthlyRate), termMonths);
            var payment = principal * monthlyRate * growthFactor / (growthFactor - 1m);
            return decimal.Round(payment, 2, MidpointRounding.AwayFromZero);
        }
    }
}