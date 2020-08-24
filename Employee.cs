using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_proj
{
    class Employee
    {
        //fields for employee id, name, pay rate and hours worked
        private string employeeId;
        private string employeeName;
        private decimal payRate;
        private decimal hoursWorked;

        //setter/getter property for employeeId var
        public string EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }
        //setter/getter property for employeeName var
        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }
        //setter/getter property for payRate var
        public decimal PayRate
        {
            get { return payRate; }
            set { payRate = value; }
        }
        //setter/getter property for hoursWorked var
        public decimal HoursWorked
        {
            get { return hoursWorked; }
            set { hoursWorked = value; }
        }
        //method to calc amount of pay as product of payRate and hoursWorked
        public decimal PayAmount()
        {
            decimal amount = 0.0m;
            amount = PayRate * HoursWorked;
            return amount;
        }
        //Employee ctor
        public Employee(string employeeId, string employeeName, decimal payRate)
        {
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.payRate = payRate;
        }
        //2nd Employee ctor
        public Employee(string employeeId, string employeeName, decimal payRate, decimal hoursWorked)
        {
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.payRate = payRate;
            this.hoursWorked = hoursWorked;
        }
        //override of Employee's ToString method
        public override string ToString()
        {
            string str;
            str = string.Format("Employee Id: {0} Employee Name: {1} Pay Amount: {2:C}", EmployeeId, EmployeeName, PayAmount());
            return str;
        }
    }
}
