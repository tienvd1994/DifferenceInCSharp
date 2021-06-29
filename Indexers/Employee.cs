using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public string this[int EmployeeId]
        {
            get
            {
                return "this";
            }
        }
    }
    
    public class Company
    {
        List<Employee> listEmployees;

        public Company()
        {
            listEmployees.Add(new Employee
            { EmployeeId = 1, Name = "Mike", Gender = "Male" });
            listEmployees.Add(new Employee
            { EmployeeId = 2, Name = "Pam", Gender = "Female" });
            listEmployees.Add(new Employee
            { EmployeeId = 3, Name = "John", Gender = "Male" });
            listEmployees.Add(new Employee
            { EmployeeId = 4, Name = "Maxine", Gender = "Female" });
            listEmployees.Add(new Employee
            { EmployeeId = 5, Name = "Emiliy", Gender = "Female" });
            listEmployees.Add(new Employee
            { EmployeeId = 6, Name = "Scott", Gender = "Male" });
            listEmployees.Add(new Employee
            { EmployeeId = 7, Name = "Todd", Gender = "Male" });
            listEmployees.Add(new Employee
            { EmployeeId = 8, Name = "Ben", Gender = "Male" });
        }

        public string this[int EmployeeId]
        {
            get
            {
                return listEmployees.FirstOrDefault(m => m.EmployeeId == EmployeeId).Name;
            }

            set
            {
                listEmployees.FirstOrDefault(m => m.EmployeeId == EmployeeId).Name = value;
            }
        }
    }
}
