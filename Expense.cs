using System: // basically like an import, gives access to basic C# functionalities

namespace ExpenseTrackerApp // groups classes together under one namespace
{
    public class Expense 
    {
        public DateTime Date { get; set; } // getter/setter methods, property can be read and modified
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public override string ToString() // string representation of an expense
        {
            return $"{Date.ToShortDateString(), -12} | {Category, -10} | {Description, -20} | ${Amount, 8:F2}";
        }
    }
}