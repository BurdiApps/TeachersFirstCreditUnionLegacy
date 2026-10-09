const signInScreen = document.querySelector("#sign-in");
const dashboard = document.querySelector("#dashboard");
const signInError = document.querySelector("#sign-in-error");
const activityError = document.querySelector("#activity-error");
const transactionList = document.querySelector("#transaction-list");
const emptyState = document.querySelector("#empty-state");
const searchInput = document.querySelector("#transaction-search");
const currency = new Intl.NumberFormat("en-US", { style: "currency", currency: "USD" });
const dateFormat = new Intl.DateTimeFormat("en-US", { month: "short", day: "numeric" });
let transactions = [];
let activeFilter = "all";

document.querySelector("#demo-login-form").addEventListener("submit", startDemoSession);
document.querySelector("#sign-out").addEventListener("click", endDemoSession);
searchInput.addEventListener("input", renderTransactions);

for (const button of document.querySelectorAll("[data-filter]")) {
  button.addEventListener("click", () => {
    activeFilter = button.dataset.filter;
    for (const filterButton of document.querySelectorAll("[data-filter]")) {
      const selected = filterButton === button;
      filterButton.classList.toggle("is-selected", selected);
      filterButton.setAttribute("aria-pressed", String(selected));
    }
    renderTransactions();
  });
}

document.querySelector("#today-date").textContent = new Intl.DateTimeFormat("en-US", {
  weekday: "long", month: "long", day: "numeric"
}).format(new Date());

initialize();

async function initialize() {
  try {
    const session = await request("/api/session");
    if (session.isAuthenticated) {
      await showDashboard();
    } else {
      showSignIn();
    }
  } catch {
    showSignIn("Could not reach the demo server. Start the API and try again.");
  }
}

async function startDemoSession(event) {
  event.preventDefault();
  const button = document.querySelector("#demo-login");
  button.disabled = true;
  signInError.hidden = true;

  try {
    const form = new FormData(event.currentTarget);
    await request("/api/session/demo", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ userId: form.get("userId"), password: form.get("password") })
    });
    await showDashboard();
  } catch {
    signInError.textContent = "Demo sign in failed. Check the sample password and try again.";
    signInError.hidden = false;
  } finally {
    button.disabled = false;
  }
}

async function endDemoSession() {
  await request("/api/session", { method: "DELETE" });
  showSignIn();
}

async function showDashboard() {
  const [account, activity] = await Promise.all([
    request("/api/accounts/mine"),
    request("/api/accounts/mine/transactions")
  ]);

  document.querySelector("#member-name").textContent = account.memberName.split(" ")[0];
  document.querySelector("#member-initials").textContent = account.memberName
    .split(" ").map(part => part[0]).join("").slice(0, 2);
  document.querySelector("#account-heading").textContent = account.accountType;
  document.querySelector("#account-number").textContent = account.maskedAccountNumber;
  document.querySelector("#last-four").textContent = account.maskedAccountNumber.slice(-4);
  document.querySelector("#balance").textContent = currency.format(account.availableBalance);
  transactions = activity;
  renderTransactions();
  signInScreen.hidden = true;
  dashboard.hidden = false;
}

function showSignIn(message = "") {
  dashboard.hidden = true;
  signInScreen.hidden = false;
  signInError.textContent = message;
  signInError.hidden = !message;
}

function renderTransactions() {
  const searchTerm = searchInput.value.trim().toLowerCase();
  const filtered = transactions.filter(transaction => {
    const isIncome = transaction.amount > 0;
    const matchesFilter = activeFilter === "all"
      || (activeFilter === "income" && isIncome)
      || (activeFilter === "spending" && !isIncome);
    const matchesSearch = `${transaction.description} ${transaction.category}`.toLowerCase().includes(searchTerm);
    return matchesFilter && matchesSearch;
  });

  transactionList.replaceChildren(...filtered.map(createTransactionRow));
  emptyState.hidden = filtered.length > 0;
}

function createTransactionRow(transaction) {
  const row = document.createElement("tr");
  const descriptionCell = document.createElement("td");
  const merchant = document.createElement("span");
  const detail = document.createElement("small");
  merchant.className = "merchant-name";
  merchant.textContent = transaction.description;
  detail.className = "transaction-detail";
  detail.textContent = `Posted ${dateFormat.format(new Date(transaction.postedAt))}`;
  descriptionCell.append(merchant, detail);
  row.append(descriptionCell);

  const categoryCell = document.createElement("td");
  const category = document.createElement("span");
  category.className = "category-tag";
  category.textContent = transaction.category;
  categoryCell.append(category);
  row.append(categoryCell);

  const dateCell = document.createElement("td");
  dateCell.className = "date-cell";
  dateCell.textContent = dateFormat.format(new Date(transaction.postedAt));
  row.append(dateCell);

  const amountCell = document.createElement("td");
  amountCell.className = `amount-cell ${transaction.amount > 0 ? "amount-positive" : ""}`;
  amountCell.textContent = `${transaction.amount > 0 ? "+" : ""}${currency.format(transaction.amount)}`;
  row.append(amountCell);
  return row;
}

async function request(url, options = {}) {
  const response = await fetch(url, {
    ...options,
    headers: { Accept: "application/json", ...options.headers }
  });
  if (!response.ok) {
    throw new Error(`Request failed: ${response.status}`);
  }
  return response.status === 204 ? null : response.json();
}