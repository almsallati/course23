
using Amazon.Data;
using Amazon.Domain;
using System.Text.Json;

namespace MigrationApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            LoadDefaultEmployeesData();

        }

        private static void LoadDefaultEmployeesData()
        {
            // Read the Data.Json File
            string contentsAsString = File.ReadAllText("Data.json");
            // Change the String into a List<Employee> (Deserialize)
            var employees = JsonSerializer.Deserialize<List<Employee>>(contentsAsString);
            // Call Context to AddRange the new employees

            using (var context = new AmazonContext())
            {
                // Add Bulk employees 
                context.Employees.AddRange(employees);
                context.SaveChanges();
            }

        }
    }
}
