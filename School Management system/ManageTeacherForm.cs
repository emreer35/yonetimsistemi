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

namespace School_Management_system
{
    public partial class ManageTeacherForm : Form
    {
        TeacherClass teacher = new TeacherClass();
        public ManageTeacherForm()
        {
            InitializeComponent();
        }

        private void ManageTeacherForm_Load(object sender, EventArgs e)
        {
            showTable();
        }
        // to show teacher list in datagrid view
        public void showTable()
        {
            DataGridView_teacher.DataSource = teacher.getTeacherList();
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_teacher.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

        }

        private void DataGridView_teacher_Click(object sender, EventArgs e)
        {
            textBox_tcId.Text = DataGridView_teacher.CurrentRow.Cells[0].Value.ToString();
            textBox_Fname.Text = DataGridView_teacher.CurrentRow.Cells[1].Value.ToString();
            textBox_Lname.Text = DataGridView_teacher.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Value = (DateTime)DataGridView_teacher.CurrentRow.Cells[3].Value;
            if (DataGridView_teacher.CurrentRow.Cells[4].Value.ToString() == "Male")
            {
                radioButton_male.Checked = true;
            }
            textBox_phone.Text = DataGridView_teacher.CurrentRow.Cells[5].Value.ToString();
            textBox_address.Text = DataGridView_teacher.CurrentRow.Cells[6].Value.ToString();
            byte[] img = (byte[])DataGridView_teacher.CurrentRow.Cells[7].Value;
            //MemoryStream mstream = new MemoryStream();
            //pictureBox_teacher.Image = Image.FromStream(mstream);

        }
    }
}
