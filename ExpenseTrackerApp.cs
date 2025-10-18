using System;
using System.Collections.Generic;
using System.linq;

namespace ExpenseTrackerApp
{
    public class ExpenseTrackerApp 
    {
        private List<Expense> expenses; // list to hold all expenses
        private ExpenseRepo repo; // handles saving and loading data

        public ExpenseTrackerApp()
        {
            repo = new ExpenseRepo(); // create a repo to read and write data
            expenses = repo.LoadExpenses(); // load existing expenses from file
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.Clear(); // clear for fresh display
                Console.WriteLine("=== Expense Tracker ===");
                Console.WriteLine("1. View All");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. View Summary");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine(); // user input

                switch (choice) // actions based on user input
                {
                    case "1":
                        ViewExpenses();
                        break;
                    case "2":
                        AddExpense();
                        break;
                    case "3":
                        ViewSummary();
                        break;
                    case "4":
                        running = false; // stop loop and exit
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}