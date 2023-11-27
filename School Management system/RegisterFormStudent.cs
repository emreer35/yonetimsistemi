using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Management_system
{
    public partial class RegisterFormStudent : Form
    {
        studentClass student = new studentClass();
        public RegisterFormStudent()
        {
            InitializeComponent();
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        
        bool verify()
        {
            if ((textBox_stdFname.Text == "") || (textBox_stdLname.Text == "") ||
                textBox_stdAddress.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
        private void RegisterFormStudent_Load(object sender, EventArgs e)
        {
            showTable();
        }
        // To show student list in DataGridView
        public void showTable()
        {
            DataGridView_student.DataSource = student.getStudentList();
        }

        private void button_stdAdd_Click(object sender, EventArgs e)
        {
            string fname = textBox_stdFname.Text;
            string lname = textBox_stdLname.Text;
            DateTime bdate = dateTimePicker_std.Value;
            string address = textBox_stdAddress.Text;
            string gender = radioButton_stdMale.Checked ? "Male" : "Female";
            // student age between 5 100
            int born_year = dateTimePicker_std.Value.Year;
            int this_year = DateTime.Now.Year;
            if ((this_year - born_year) < 5 || (this_year - born_year) > 100)
            {
                MessageBox.Show("The student age must be between 5 and 100", "Invalid Birthdate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verify())
            {


                try
                {
                    if (student.insertStudent(fname, lname, bdate, gender, address))
                    {
                        showTable();
                        MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Empty Field", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button_stdClear_Click(object sender, EventArgs e)
        {
            textBox_stdFname.Clear();
            textBox_stdLname.Clear();
            textBox_stdAddress.Clear();
        }
    }
}
