using System;
using System.Collections.Generic; // gives access to collections like List
using System.IO; // for reading and writing files
using System.Text.Json; // for converting objects to/from JSON

namespace ExpenseTrackerApp
{
    public class ExpenseRepo
    {
        public string filepath = "expenses.json"; // data storage file

        // loads all expenses from the JSON file
        public List<Expense> LoadExpenses()
        {
            // if file doesnt exist, return empty list
            if (!File.Exists(filepath))
            {
                return new List<Expense>();
            }

            string json = File.ReadAllText(filepath); // reads text from file
            return JsonSerializer.Deserialize<List<Expense>>(json) ?? new List<Expense>(); // converts JSON back to objects
        }

        // saves the list of expenses to the JSON file
        public void SaveExpenses(List<Expense> expenses)
        {
            string json = JsonSerializer.Serialize(expenses, new JsonSerializerOptions { WriteIndented = true }); // converts list to formatted JSON
            File.WriteAllText(filepath, json); // writes it to file
        }
    }
}