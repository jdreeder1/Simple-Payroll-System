using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace final_proj
{
    public partial class Form3 : Form //aka display all employees
    {
        //create a list that includes all instances of Employee class
        List<Employee> allEmployees = new List<Employee>();
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            if (File.Exists("employee.txt"))
            {
                //using streamreader object, read from employee.txt
                using (StreamReader sr = new StreamReader("employee.txt"))
                {
                    string employeeId = "";
                    //while not to the end of employee.txt...
                    while((employeeId = sr.ReadLine()) != null)
                    {
                        //create a new Employee instance from data within employee.txt
                        Employee emp = new Employee(employeeId, sr.ReadLine(), decimal.Parse(sr.ReadLine()),
                            decimal.Parse(sr.ReadLine()));
                        //add each Employee instance to listbox and allEmployees list
                        employeeListBox.Items.Add(emp);
                        allEmployees.Add(emp);
                    }
                }
            }
            else
            {
                employeeListBox.Items.Add("No employees entered yet.");
            }

        }

        private void Print_Click(object sender, EventArgs e) //print button
        {
            printDocument1.Print();
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //used for x and y-axis of print - printing starts 
            //75 px from left, 75 px from top of pg
            int x = 75, y = 75;
            foreach(Employee emp in allEmployees)
            {
                e.Graphics.DrawString(emp.ToString(), new Font("Courier", 10, FontStyle.Regular), Brushes.Black, x, y);
                //add 14 px to vertical distance from top so no line overlap
                y += 14;
            }
        }

        private void Close_Click(object sender, EventArgs e) //close button
        {
            Close();
        }
    }
}
