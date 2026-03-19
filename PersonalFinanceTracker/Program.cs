using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
namespace PersonalFinanceTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            FinanceTracker tracker = new FinanceTracker()!; // creating a new object from the class

            Console.Write("Enter Your Name: ");
            tracker.UserName = CheckField(Console.ReadLine());

            int transactionID = 1;

            static string CheckField(string? field) // a class method to validate client input
            {
                while (string.IsNullOrEmpty(field)) // continue to loop as long as the field is empty or null
                {
                    Console.WriteLine("field cannot be empty or null");
                    Console.Write("Enter Appropriate Value: ");
                    field = Console.ReadLine()!; // ask again
                }
                return field;
                
            }

            static decimal DecimalNum(decimal input) // a class method to validate client input
            {
                while (input <= 0) // continue to loop as long as the input is negative
                {
                    Console.WriteLine("Value cannot be negative or zero");
                    Console.Write("Enter Tranction Amount: ");
                    input = Convert.ToDecimal(Console.ReadLine()); // ask again
                }
                return input; //return the decimal value of input
            }

            static int IntNum(int opt) // a class method to validate client input
            {
                while (opt <= 0 || opt >= 10) // continue to loop as long as the the input for opt is true here
                {   
                    
                    Console.WriteLine("Invalid input, option should be 1 - 9");
                    Console.Write("Input a valid option: ");
                    opt = Convert.ToInt32(Console.ReadLine()); // ask again
                    
                }
                return opt; // return the int value of opt
            }

            
            bool running = true; // bool initialization and assignment fot the while loop
            while (running)
            {
                try
                {   
                    Console.WriteLine("\n=== Personal Finance Tracker ===");
                    Console.WriteLine($"Welcome, {tracker.UserName}!");
                    Console.WriteLine($"Current Balance: ${tracker.CurrentBalance}");
                    Console.WriteLine("");

                    Console.WriteLine("\n1. Add Income");
                    Console.WriteLine("2. Add Expense");
                    Console.WriteLine("3. View All Transactions");
                    Console.WriteLine("4. View Income Only");
                    Console.WriteLine("5. View Expenses Only");
                    Console.WriteLine("6. View by Category");
                    Console.WriteLine("7. View Highest Expense");
                    Console.WriteLine("8. Display Monthly Summary");
                    Console.WriteLine("9. Exit");

                    Console.Write("\nSelect an option: ");
                    int option = IntNum(Convert.ToInt32(Console.ReadLine())); // Read user option and convert to integer
                    
                    // Exit option
                    if (option == 9)
                    {
                        Console.WriteLine("Program is successfully terminated. Thank you."); // Friendly termination message
                        break;              // Exit the while loop
                    }

                    switch (option)
                    {
                        case 1: // case one and case 2 uses the same code but I use the shorthand for loop to differentiate the action upon the option selected
                        case 2:

                            Console.Write("Enter Transaction Description: ");
                            string desc = CheckField(Console.ReadLine()); // calling a defined method
                            

                            Console.Write("Enter Tranction Amount: ");
                            decimal amount = DecimalNum(Convert.ToDecimal(Console.ReadLine())); // calling a defined method

                            Console.WriteLine("Category: Salary, Food, Transport, Entertainment, Bills, Gift");
                            Console.Write("Enter Category: ");
                            string? category = CheckField(Console.ReadLine()); // calling a defined method

                            string type = option == 1 ? "Income" : "Expense"; // shorthand method to determine the case action and differentiate their record

                            Transaction t = new Transaction(transactionID++, desc, amount, type, category);
                            tracker.AddTransaction(t);

                            Console.WriteLine("Transaction added successfully!");
                            break;

                        case 3:
                            tracker.DisplayAllTransactions(); // calling a defined method
                            break;

                        case 4:
                            tracker.DisplayIncomeTransactions(); // calling a defined method
                            break;

                        case 5:
                            tracker.DisplayExpenseTransactions(); // calling a defined method
                            break;

                        case 6:
                            Console.Write("Enter category: ");
                            string cat = CheckField(Console.ReadLine());
                            tracker.DisplayTransactionsByCategory(cat); // calling a defined method
                            break;

                        case 7:
                            var highest = tracker.GetHighestExpense(); // calling a defined method
                            if (highest != null)
                                Console.WriteLine($"Highest Expense: {highest.Category} - ${highest.Amount}");
                            break;

                        case 8:
                            tracker.DisplayMonthlySummary();
                            break;

                    }
                }
                catch (System.Exception)
                {
                    
                    Console.WriteLine("Invalid input, please enter appropriate value");
                }
                
            }
        }

    }
}

