using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //used for file writing/reading

namespace final_proj
{
    public partial class Form1 : Form //aka new employee form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Clear_Click(object sender, EventArgs e) //clear event handler
        {
            idTextBox.Clear();
            nameTextBox.Clear();
            rateTextBox.Clear();
            idTextBox.Focus();
        }
        
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        } 

        private void Save_Click(object sender, EventArgs e) //save employee info
        {
            //if no textboxes are left blank, proceed to next Employee in list
            if (!((string.IsNullOrWhiteSpace(idTextBox.Text)) ||
                    (string.IsNullOrWhiteSpace(nameTextBox.Text)) ||
                    (string.IsNullOrWhiteSpace(rateTextBox.Text))))
            {
                //create new Employee class from instance id, name and payrate entered in textboxes
                Employee emp = new Employee(idTextBox.Text, nameTextBox.Text, decimal.Parse(rateTextBox.Text));

                //use streamwriter object to append data to employee.txt
                using (StreamWriter sw = File.AppendText("employee.txt"))
                {

                    //write employee id, name and pay rate on separate lines
                    sw.WriteLine(emp.EmployeeId);
                    sw.WriteLine(emp.EmployeeName);
                    sw.WriteLine(emp.PayRate);
                    sw.WriteLine(0);
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
    }
}
