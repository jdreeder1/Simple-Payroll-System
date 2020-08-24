using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //contains messagebox
using System.IO; //used for file writing/reading
using System.Web;

namespace final_proj
{
    public partial class Form2 : Form //aka add employee hours
    {
        //creates list to store Employee objects
        List<Employee> allEmployees = new List<Employee>();
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load_1(object sender, EventArgs e)
        {

            if (File.Exists("employee.txt"))
            {
                //read from employee.txt file if it exists
                using (StreamReader sr = new StreamReader("employee.txt"))
                {
                    //create string variable for each line in employee.txt
                    string employeeId = "";
                    //while not to end of employee.txt...
                    while ((employeeId = sr.ReadLine()) != null)
                    {
                        //create new instance of Employee class w data from file
                        Employee emp = new Employee(employeeId, sr.ReadLine(), decimal.Parse(sr.ReadLine()));
                        sr.ReadLine();
                        //add each new instance to allEmployees list
                        allEmployees.Add(emp);
                    }
                    if (allEmployees.Count > 0) //if allEmployees list not empty...
                    {
                        //display 1st employee id and name in list
                        idLabel.Text = allEmployees[0].EmployeeId;
                        nameLabel.Text = allEmployees[0].EmployeeName;
                    }
                    else
                    {
                        //if allEmployees list is empty, display error msg
                        string msg = "No employee records. Add employee record(s) from Add New Employee form.";
                        string title = "No Employee Records";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(msg, title, buttons);
                        if (result == DialogResult.OK)
                        {
                            Close();
                            
                        }
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Missing employee.txt.");
                Close();
            }
        }
        int count = 1;
        private void Next_Click(object sender, EventArgs e) //next button
        {
            //if no textboxes are left blank, proceed 
            if (!((string.IsNullOrWhiteSpace(idLabel.Text)) ||
                    (string.IsNullOrWhiteSpace(nameLabel.Text)) ||
                    (string.IsNullOrWhiteSpace(hoursWorkedTextBox.Text))))
            {
                //each time next button hit, parse hours entered and add to corresp Employee in list,
                allEmployees[count - 1].HoursWorked = decimal.Parse(hoursWorkedTextBox.Text);
                if (count < allEmployees.Count)
                {
                    //show employee id and name of Employee instance from list who
                    //you're adding HoursWorked to 
                    idLabel.Text = allEmployees[count].EmployeeId;
                    nameLabel.Text = allEmployees[count].EmployeeName;
                    //then iterate to the next Employee...
                    count++;
                }
                else
                {
                    //if count = size of list (i.e., no more employees), 
                    //display messagebox that gives the user the option to save and close
                    string msg2 = "No more employees. Save & close?";
                    string title2 = "No More Employees";
                    MessageBoxButtons buttons2 = MessageBoxButtons.YesNo;

                    DialogResult result2 = MessageBox.Show(msg2, title2, buttons2);
                    //reuse save and close method created below 
                    if (result2 == DialogResult.Yes)
                        Save_Click(sender, e);

                }
            }
            else
            {
                //if a textbox is left blank, display error msg
                string error = "All fields must be filled.";
                string title = "Error";
                MessageBox.Show(error, title);
            }

        }

        private void Save_Click(object sender, EventArgs e) //save and close button
        {
            //use streamwriter object to write to employee.txt
            using (StreamWriter sw = File.CreateText("employee.txt"))
            {
                //for every Employee instance in list,
                //write id, name, payrate and hoursworked on a separate line
                foreach (Employee emp in allEmployees)
                {
                    sw.WriteLine(emp.EmployeeId);
                    sw.WriteLine(emp.EmployeeName);
                    sw.WriteLine(emp.PayRate);
                    sw.WriteLine(emp.HoursWorked);
                }
            }
            Close();
        }

        private void Clear_Click(object sender, EventArgs e) //clear button
        {
            idLabel.Clear();
            nameLabel.Clear();
            hoursWorkedTextBox.Clear();
            idLabel.Focus();
        }
        private void GroupBox1_Enter(object sender, EventArgs e)
        { }

        private void Label1_Click(object sender, EventArgs e)
        { }
    }
}
