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

                if (running)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }
            }

            repo.SaveExpenses(expenses); // save expenses before exiting
        }

        private void ViewExpenses() // show all recorded expenses
        {
            Console.Clear();
            Console.WriteLine("=== All Expenses ===\n");

            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses found.");
                return;
            }

            foreach (var e in expenses)
                Console.WriteLine(e.ToString()); // print each expense
        }

        private void AddExpense() // let user add a new expense
        {
            Console.Clear();
            Console.WriteLine("=== Add New Expense ===\n");

            Console.Write("Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());

            Console.Write("Category: ");
            string category = Console.ReadLine() ?? "Uncategorized";

            Console.Write("Description: ");
            string description = Console.ReadLine() ?? "";

            Console.Write("Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine() ?? "0");

            Expense newExpense = new Expense
            {
                Date = date,
                Category = category,
                Description = description,
                Amount = amount
            };

            expenses.Add(newExpense); // add to list
            repo.SaveExpenses(expenses); // save updated list

            Console.WriteLine("\nExpense added successfully!");
        }

        private void ViewSummary() // show totals and breakdowns
        {
            Console.Clear();
            Console.WriteLine("=== Expense Summary ===\n");

            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses to summarize.");
                return;
            }

            decimal total = expenses.Sum(e => e.Amount); // total of all expenses
            Console.WriteLine($"Total spent: ${total:F2}\n");

            var byCategory = expenses // group by category
                .GroupBy(e => e.Category)
                .Select(g => new { Category = g.Key, Total = g.Sum(e => e.Amount) });

            Console.WriteLine("By Category:");
            foreach (var group in byCategory)
                Console.WriteLine($"{group.Category, -15} ${group.Total, 8:F2}");
        }
    }
}