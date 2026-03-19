# Personal Finance Tracker

**Assignment Option:** Option 2 (Console-based Personal Finance Management Application)

**Author:** Babatunde Adepoju   
**Date:** March 19th, 2025

## Project Description

This is a **console-based Personal Finance Tracker** application built in **C#** using .NET.  
The program helps users track their personal income and expenses, maintain a running balance, categorize transactions, and generate useful summaries and reports.

Main features include:
- Adding income and expense transactions
- Viewing all transactions or filtered views (income only, expenses only, by category)
- Finding the highest single expense
- Displaying a monthly summary of income, expenses, and net balance

The application uses object-oriented programming principles with separate classes for transactions and the tracker logic, input validation, and a simple menu-driven interface.

## Features Implemented

- User name input with validation (cannot be empty)
- Add **Income** transactions
- Add **Expense** transactions
- View **all transactions** with ID, description, amount, type, category and date
- View **income transactions** only
- View **expense transactions** only
- Filter and view transactions by **specific category**
- Show the **highest single expense** (category + amount)
- Display **monthly summary** (total income, total expenses, net balance for the current month)
- Robust input validation for:
  - Non-empty strings
  - Positive decimal amounts
  - Valid menu options (1–9)
- Error handling with try-catch blocks for invalid numeric input
- Clean console UI with clearing screen between menus
- Auto-incrementing transaction IDs
- Friendly exit message

## How to Run the Project

### Prerequisites
- .NET SDK 6.0 or newer (recommended: .NET 8.0)
- Any modern operating system (Windows, macOS, Linux)

### Steps

1. **Clone or download** the project folder
https://github.com/Badepoju1/dotnet-week5--assignment.git

2. **Open a terminal** and navigate to the project directory:
   ```bash
   cd PersonalFinanceTracker

   Build the project: dotnet build
   Run the application: dotnet run

   Follow the on-screen menu:
    Enter your name
    Choose options 1–9
    Use option 9 to exit

    Note: All data is stored in memory only — it will be lost when you close the program.

    PersonalFinanceTracker/
    ├── Program.cs              # Main entry point + menu logic
    ├── FinanceTracker.cs       # Core logic class 
    ├── Transaction.cs          # Transaction model class
    ├── README.md
    └── PersonalFinanceTracker.csproj


## Challenges Faced & Lessons Learned
    Handling invalid user input (e.g., empty strings, wrong data types)

    Implementing proper input validation loops to avoid crashes

    Understanding when to use try-catch vs conditional validation

    Managing program flow within a continuous loop

    Ensuring clean and reusable helper methods for validation

    Exception handling — broad catch (Exception) was used for simplicity, but in production we'd use more specific exceptions (FormatException, OverflowException).
