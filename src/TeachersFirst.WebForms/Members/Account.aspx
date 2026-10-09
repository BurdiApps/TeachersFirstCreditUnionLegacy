<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="TeachersFirst.WebForms.AccountPage" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title>Member Account | Teachers First Credit Union</title>
  <link rel="stylesheet" href="../Content/site.css" />
</head>
<body>
<form id="MainForm" runat="server">
  <div class="site-shell" id="top">
    <header><a class="brand" href="../Default.aspx"><span class="apple" aria-hidden="true">&#127822;</span><span>Teachers First<small>CREDIT UNION</small></span></a><asp:Button runat="server" Text="Log Out" OnClick="Logout_Click" CssClass="button" CausesValidation="false" /></header>
    <nav aria-label="Member navigation"><a class="selected" href="Account.aspx">Account Summary</a><a href="#activity">Account Activity</a><a href="../Accounts.aspx">Accounts</a><a href="../Loans.aspx">Loans &amp; Rates</a><a href="../Resources.aspx">Resources</a><a href="../Community.aspx">Community</a><a href="../Default.aspx">Home</a></nav>
    <main>
      <h1>Welcome, <asp:Literal ID="MemberName" runat="server" Mode="Encode" /></h1>
      <section class="band"><h2>Everyday Checking &bull; **** 4821</h2><p>Available balance</p><strong class="balance"><asp:Literal ID="Balance" runat="server" Mode="Encode" /></strong><p class="caption">Fictional funds. No payments or transfers are enabled.</p></section>
      <section id="activity"><h2>Recent Account Activity</h2><div class="filter"><asp:Label runat="server" AssociatedControlID="ActivityFilter" Text="Show transactions: " /><asp:DropDownList ID="ActivityFilter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Filter_Changed"><asp:ListItem Value="all">All activity</asp:ListItem><asp:ListItem Value="deposits">Deposits</asp:ListItem><asp:ListItem Value="spending">Spending</asp:ListItem></asp:DropDownList></div>
        <div class="table-scroll"><asp:GridView ID="ActivityGrid" runat="server" AutoGenerateColumns="false" CssClass="activity-grid" GridLines="None" EmptyDataText="No matching transactions." UseAccessibleHeader="true">
          <Columns><asp:BoundField DataField="Description" HeaderText="Transaction" HtmlEncode="true" /><asp:BoundField DataField="Category" HeaderText="Category" HtmlEncode="true" /><asp:BoundField DataField="PostedAt" HeaderText="Date" DataFormatString="{0:MMM dd, yyyy}" /><asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:C2}" ItemStyle-CssClass="amount" /></Columns>
        </asp:GridView></div>
      </section>
    </main>
    <footer><strong>Teachers First Credit Union</strong><span>Demo member account. Not a financial service.</span><span class="footer-links"><a href="../Contact.aspx">Contact</a><a href="../Resources.aspx#privacy">Privacy</a><a href="../Resources.aspx#security">Security</a><a href="#top">Back to Top</a></span></footer>
  </div>
</form>
</body>
</html>