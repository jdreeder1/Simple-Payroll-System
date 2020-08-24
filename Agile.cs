using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_proj
{
    public partial class Agile : Form
    {
        public Agile()
        {
            InitializeComponent();
        }

        private void Agile_Load(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e) //exit app
        {
            Close();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void AddEmployee_Click(object sender, EventArgs e) //add employee
        {
            //creates instance of Form1 (add employee) when clicked
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void AddHours_Click(object sender, EventArgs e) //add hours
        {
            //creates instance of Form2 (add hours) when clicked
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void DisplayEmployees_Click(object sender, EventArgs e) //display form
        {
            //creates instance of Form3 (display employees) when clicked
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
