namespace PersonalFinanceTracker
{
    public class Transaction 
    {
        // Read-only property (can only be set in constructor)
        public int TransactionID { get; } // automated property with readonly access

        // Auto-implemented properties
        public string Description { get; set; } // automated property with read/write access
        public DateTime Date { get; set; } // automated property with read/write access

        public string Category { get; set; } // automated property with read/write access

        private decimal _amount; // pricate field to be use in another property within the same class
        public decimal Amount // a defined property with validation
        {
            get { return _amount; }
            set
            {
                // Validation: amount must be greater than 0
                if (value > 0)
                    _amount = value;
                else
                    Console.WriteLine("Amount must be greater than 0.");
            }
        }

        private string _type = string.Empty; // making the string empty to solve non-null warning, as it's expecting an assignment.
        public string Type // a defined property with validation
        {
            get { return _type; } // to read from the private field and return the value
            set // to validate the returned value
            {
                // Validation: must be Income or Expense
                if (value == "Income" || value == "Expense")
                    _type = value;
                else
                    Console.WriteLine("Type must be 'Income' or 'Expense'.");
            }
        }

        // Constructor
        public Transaction(int id, string description, decimal amount, string type, string category) // to initialize the data type of the object
        { // a public constructor to initialise the class object
            TransactionID = id;
            Description = description;
            Amount = amount;
            Type = type;
            Category = category;
            Date = DateTime.Now;
        }
    }
}