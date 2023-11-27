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
    public partial class ManageStudentForm : Form
    {
        studentClass student = new studentClass();
        public ManageStudentForm()
        {
            InitializeComponent();
        }

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            showTable();
        }
        // To show student list in DataGridView
        public void showTable()
        {
            DataGridView_student.DataSource = student.getStudentList();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView_student_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // display student data from student to texbox
        private void DataGridView_student_Click(object sender, EventArgs e)
        {
            textBox_StId.Text = DataGridView_student.CurrentRow.Cells[0].Value.ToString();
            textBox_stdFname.Text = DataGridView_student.CurrentRow.Cells[1].Value.ToString();
            textBox_stdLname.Text = DataGridView_student.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker_std.Value = (DateTime)DataGridView_student.CurrentRow.Cells[3].Value;
            if (DataGridView_student.CurrentRow.Cells[4].Value.ToString() == "Male")
            {
                radioButton_stdMale.Checked = true;
            }
            textBox_stdAddress.Text = DataGridView_student.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
