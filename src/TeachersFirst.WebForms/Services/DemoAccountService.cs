using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace TeachersFirst.WebForms.Services
{
    public sealed class DemoAccountService
    {
        public DemoAccount Load(string filePath)
        {
            var root = XDocument.Load(filePath).Root;
            return new DemoAccount
            {
                MemberName = (string)root.Attribute("memberName"),
                OpeningBalance = decimal.Parse((string)root.Attribute("openingBalance"), CultureInfo.InvariantCulture),
                Transactions = root.Elements("transaction").Select(element => new DemoTransaction
                {
                    Description = (string)element.Attribute("description"),
                    Category = (string)element.Attribute("category"),
                    Amount = decimal.Parse((string)element.Attribute("amount"), CultureInfo.InvariantCulture),
                    PostedAt = DateTimeOffset.Parse((string)element.Attribute("postedAt"), CultureInfo.InvariantCulture)
                }).ToList()
            };
        }
    }

    public sealed class DemoAccount
    {
        public string MemberName { get; set; }
        public decimal OpeningBalance { get; set; }
        public List<DemoTransaction> Transactions { get; set; }
        public decimal AvailableBalance { get { return OpeningBalance + Transactions.Sum(transaction => transaction.Amount); } }
    }

    public sealed class DemoTransaction
    {
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset PostedAt { get; set; }
    }
}