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
    public partial class RegisterFormTeacher : Form
    {
        TeacherClass teacher = new TeacherClass();
        public RegisterFormTeacher()
        {
            InitializeComponent();
        }


        
        

        bool verify()
        {
            if ((textBox_Fname.Text == "") || (textBox_Lname.Text == "") ||
                    (textBox_phone.Text == "") || (textBox_address.Text == "") ||
                    (pictureBox_teacher.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        

        private void RegisterFormTeacher_Load(object sender, EventArgs e)
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

        private void button_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox_teacher.Image = Image.FromFile(opf.FileName);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            // add new teacher
            string fname = textBox_Fname.Text;
            string lname = textBox_Lname.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = textBox_phone.Text;
            string address = textBox_address.Text;
            string gender = radioButton_male.Checked ? "Male" : "Female";
            // to get photo from picture box
            MemoryStream ms = new MemoryStream();
            pictureBox_teacher.Image.Save(ms, pictureBox_teacher.Image.RawFormat);
            byte[] img = ms.ToArray();

            // age
            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;
            if ((this_year - born_year) < 18 || (this_year - born_year) > 100)
            {
                MessageBox.Show("The teacher age must be between 18 and 100", "Invalid Birthdate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verify())
            {
                try
                {
                    /*MemoryStream ms = new MemoryStream();
                    pictureBox_teacher.Image.Save(ms, pictureBox_teacher.Image.RawFormat);
                    byte[] img = ms.ToArray(); */
                    if (teacher.insertTeacher(fname, lname, bdate, gender, phone, address, img))
                    {
                        showTable();
                        MessageBox.Show("New Teacher Added", "Add Teacher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Add Teacher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_Fname.Clear();
            textBox_Lname.Clear();
            textBox_phone.Clear();
            textBox_address.Clear();
            pictureBox_teacher.Image = null;
        }
    }
}
