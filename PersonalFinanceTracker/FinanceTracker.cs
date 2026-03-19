namespace PersonalFinanceTracker
{
    public class FinanceTracker
    {
        public string UserName { get; set; } = string.Empty;

        // List to store all transactions
        private readonly List<Transaction> transactions = new List<Transaction>()!; // creating an object list from the transaction class

        // Computed property: calculates total income
        public decimal TotalIncome
        {
            get
            {
                decimal total = 0;
                foreach (Transaction t in transactions)
                {
                    if (t.Type == "Income")
                        total += t.Amount;
                }
                return total;
            }
        }

        // Computed property: calculates total expenses
        public decimal TotalExpenses
        {
            get
            {
                decimal total = 0;
                foreach (Transaction t in transactions) // to loop through each item in the object list
                {
                    if (t.Type == "Expense")
                        total += t.Amount;
                }
                return total;
            }
        }

        // Current balance
        public decimal CurrentBalance
        {
            get { return TotalIncome - TotalExpenses; }
        }

        // Add transaction
        public void AddTransaction(Transaction transaction) // a public method to add new object
        {
            transactions.Add(transaction); // use the add function
        }

        // Display all transactions
        public void DisplayAllTransactions() // a method to display all transactions
        {
            Console.WriteLine("\n=== All Transactions ===");

            foreach (Transaction t in transactions)
            {
                Console.WriteLine($"TransactionID |  Date  |  Description  |  Category  |  Type  | Amount");
                Console.WriteLine($"   {t.TransactionID}       |    {t.Date.ToShortDateString()}  |  {t.Description} |  {t.Category} |  {t.Type} |  ${t.Amount}");
            }
        }

        // a public method to display income only
        public void DisplayIncomeTransactions()
        {
            Console.WriteLine("\n=== Income Transactions ===");
            Console.WriteLine($"TransactionID | Description | Amount");

            foreach (Transaction t in transactions)
            {
                if (t.Type == "Income")
                    {
                        Console.WriteLine($"{t.TransactionID} | {t.Description} | ${t.Amount}");
                    }   
            }
        }

        // a public method to display expenses only
        public void DisplayExpenseTransactions()
        {
            Console.WriteLine("\n=== Expense Transactions ===");
            Console.WriteLine($"TransactionID | Description | Amount");
            foreach (Transaction t in transactions) // to loop through each of the object list
            {
                if (t.Type == "Expense")
                {
                    Console.WriteLine($"{t.TransactionID} | {t.Description} | ${t.Amount}");
                }
                    
            }
        }

        // Filter by category
        public void DisplayTransactionsByCategory(string category) // use a void for the method since I don't want it to return a specific data type value
        {   
            Console.WriteLine($"\n=== Transactions for {category} ===");
            Console.WriteLine($"TransactionID | Description | Type | Amount");

            foreach (Transaction t in transactions)
            {
                if (t.Category == category) // this help to confirm the search after looping through the category list
                {
                    Console.WriteLine($"{t.TransactionID} | {t.Description} | {t.Type} | ${t.Amount}");
                }

                else
                {
                    Console.WriteLine($"Record cannot doesn't exist!");
                }
                    
            }
        }

        // Highest expense
        public Transaction? GetHighestExpense() //I use ? to indicate a nullable
        {   
            Transaction? highest = null;

            foreach (Transaction t in transactions)
            {
                if (t.Type == "Expense" && (highest == null || t.Amount > highest.Amount))
                {                
                    highest = t;   
                }
            }

            return highest;
        }

        // Monthly summary
        public void DisplayMonthlySummary()
        {
            Console.WriteLine("\n=== Monthly Summary ===");

            Console.WriteLine($"Total Income: ${TotalIncome}");
            Console.WriteLine($"Total Expenses: ${TotalExpenses}");
            Console.WriteLine($"Current Balance: ${CurrentBalance}");
        }

    }
}