<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TeachersFirst.WebForms.HomePage" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title>Teachers First Credit Union | Teachers and Their Families</title>
  <link rel="stylesheet" href="Content/site.css" />
</head>
<body>
<form id="MainForm" runat="server">
  <div class="site-shell" id="top">
    <div class="utility">A friendly face. A helpful answer. <a href="About.aspx#eligibility">Become a Member</a></div>
    <header><a class="brand" href="Default.aspx"><span class="apple" aria-hidden="true">&#127822;</span><span>Teachers First<small>CREDIT UNION</small></span></a><p>For those who teach. For those who learn.</p></header>
    <nav aria-label="Main navigation"><a class="selected" href="Default.aspx">Home</a><a href="About.aspx">About Us</a><a href="Accounts.aspx">Accounts</a><a href="Loans.aspx">Loans &amp; Credit</a><a href="Resources.aspx">Member Resources</a><a href="Community.aspx">Our Community</a></nav>
    <div class="notice">Teachers, school staff, and their families: you belong here. <strong>Fictional learning project, not a real credit union.</strong></div>
    <main>
      <div class="hero-row">
        <section class="hero"><p class="kicker">YOU PUT OTHERS FIRST. SO DO WE.</p><h1>Teachers First<br />Credit Union</h1><h2>A brighter future, starting with you.</h2><p>Thoughtful banking for teachers, school employees, and the families who stand beside them.</p><a class="button" href="About.aspx">Discover the Teachers First difference &raquo;</a><p class="caption">Your classroom. Your family. Your credit union.</p></section>
        <aside id="online-banking" class="login"><h2>Online Banking</h2><div class="login-body">
          <asp:Label runat="server" AssociatedControlID="UserId" Text="User ID" />
          <asp:TextBox ID="UserId" runat="server" Text="demo.member" MaxLength="40" />
          <asp:RequiredFieldValidator runat="server" ControlToValidate="UserId" ErrorMessage="Enter the demo user ID." Display="Dynamic" EnableClientScript="false" CssClass="error" />
          <asp:Label runat="server" AssociatedControlID="Password" Text="Password" />
          <asp:TextBox ID="Password" runat="server" TextMode="Password" MaxLength="40" />
          <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Enter the demo password." Display="Dynamic" EnableClientScript="false" CssClass="error" />
          <asp:Button runat="server" Text="Demo Log In &raquo;" OnClick="Login_Click" CssClass="button" />
          <asp:Label ID="LoginError" runat="server" CssClass="error" role="alert" />
          <p>Demo: <strong>demo.member / demo123</strong></p><p class="caption">Use only these fictional credentials. Never enter real banking information.</p>
        </div></aside>
      </div>
      <div class="quick-links"><a href="About.aspx#eligibility">Join the CU &raquo;</a><a href="Accounts.aspx">Everyday Banking &raquo;</a><a href="Loans.aspx#rates">View Rates &raquo;</a><a href="Loans.aspx#calculator">Loan Calculator &raquo;</a><a href="Resources.aspx">Member Resources &raquo;</a></div>
      <section id="membership" class="band"><p class="kicker">A PLACE WHERE YOU BELONG</p><h2>Teachers first. Families always.</h2><p>Membership is designed for teachers, school employees, retired educators, and their immediate family members.</p><ul class="member-list"><li>Educators and school staff</li><li>Retired teachers and school employees</li><li>Spouses and immediate family members</li></ul><p>For this learning demo, membership is informational only; no application or real account is created.</p><a href="About.aspx#eligibility">Review the membership details &raquo;</a></section>
      <section id="accounts"><h2>Here for all the chapters of your life.</h2><div class="products"><article id="checking"><h3>Everyday Banking</h3><p>Spend, save, and stay on top of the everyday.</p><a href="Members/Account.aspx">Open Demo Checking Account &raquo;</a><a href="Accounts.aspx#savings">Family Savings &raquo;</a></article><article><h3>Loans for Life</h3><p>A new set of keys or a fresh start.</p><a href="Loans.aspx#auto-loan">Auto Loans &raquo;</a><a href="Loans.aspx#home-loan">Home Equity &raquo;</a></article><article id="educator-support"><h3>Educator Advantages</h3><p>School-year schedules. Real-life goals.</p><a href="Community.aspx#classroom-grants">Classroom Support &raquo;</a><a href="Resources.aspx">Family Financial Wellness &raquo;</a></article></div></section>
      <section id="rates" class="rates"><div><h2>Make more possible.</h2><p>Illustrative rates only, not offers.</p><a href="Loans.aspx#calculator">Estimate a monthly payment &raquo;</a></div><div>Auto Loans<strong>5.49% <small>APR*</small></strong><a href="Loans.aspx#auto-loan">View sample details</a></div><div>12-Month Certificate<strong>4.00% <small>APY*</small></strong><a href="Loans.aspx#certificate">View sample details</a></div><div>Home Equity<strong>6.75% <small>APR*</small></strong><a href="Loans.aspx#home-loan">View sample details</a></div></section>
      <section id="community" class="band"><p class="kicker">IN OUR SCHOOLS. IN OUR COMMUNITY.</p><h2>Supporting the people who shape tomorrow.</h2><p>Our fictional community programs celebrate educators and their families with classroom grants, school supply drives, and financial wellness workshops.</p><a href="Community.aspx">Explore community programs &raquo;</a></section>
      <section id="resources" class="band"><h2>From the Resource Center</h2><p>Plan a school-year budget, build a family savings habit, and learn to recognize suspicious messages.</p><a href="Resources.aspx">Visit the resource center &raquo;</a></section>
    </main>
    <footer><strong>Teachers First Credit Union</strong><span>Mock site. All accounts, services, and rates are fictional.</span><span class="footer-links"><a href="Contact.aspx">Contact</a><a href="Resources.aspx#privacy">Privacy</a><a href="Resources.aspx#security">Security</a><a href="#top">Back to Top &raquo;</a></span></footer>
  </div>
</form>
</body>
</html>