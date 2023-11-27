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
    public partial class Form1 : Form
    {
        studentClass student = new studentClass();

        public Form1()
        {
            InitializeComponent();
            customizeDesign();
        }
        private void customizeDesign()
        {
            panel_tchrSubMenu.Visible = false;
            panel_stdsubmenu.Visible = false;
            panel_courseSubmenu.Visible = false;
            panel_scoreSubmenu.Visible = false;
        }
        private void hideSubmenu()
        {
            if (panel_tchrSubMenu.Visible == true)
            {
                panel_tchrSubMenu.Visible = false;
            }
            if (panel_stdsubmenu.Visible == true)
            {
                panel_stdsubmenu.Visible = false;
            }
            if (panel_courseSubmenu.Visible == true)
            {
                panel_courseSubmenu.Visible = false;
            }
            if (panel_scoreSubmenu.Visible == true)
            {
                panel_scoreSubmenu.Visible = false;
            }
        }
        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            studentCount();

        }
        private void studentCount()
        {
            // dsiplay the values
            label_totalStd.Text = "Total Students : " + student.totalStudent();
            label_maleStd.Text = "Male : " + student.maleStudent();
            label_femaleStd.Text = "Female : " + student.femaleStudent();
        }
   

      
        private void button_tchr_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_tchrSubMenu);
        }
        #region tchrSubmenu
        private void button_tchrRegistration_Click(object sender, EventArgs e)
        {
            openChildForm(new RegisterFormTeacher());
            //...
            //..Your Code
            //
            hideSubmenu();
        }

        private void button_manageTchr_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageTeacherForm());
            //...
            //..Your Code
            //
            hideSubmenu();
        }

        private void button_tchrStatus_Click(object sender, EventArgs e)
        {
            //...
            //..Your Code
            //
            hideSubmenu();
        }

        private void button_tchrprint_Click(object sender, EventArgs e)
        {
            //...
            //..Your Code
            //
            hideSubmenu();
        }



        #endregion tchrSubMenu

          private void button_std_Click_1(object sender, EventArgs e)
        {
            showSubmenu(panel_stdsubmenu);
        }
        #region StdSubmenu
        private void button_registration_Click(object sender, EventArgs e)
        {
            openChildForm(new RegisterFormStudent());
            //...
            //..Your Code
            //
            hideSubmenu();
        }

        private void button__manageStd_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageStudentForm());
            //...
            //..Your Code
            //
            hideSubmenu();
        }

        private void button_status_Click(object sender, EventArgs e)
        {
            //...
            //..Your Code
            //
            hideSubmenu();
        }

        private void button_stdPrint_Click(object sender, EventArgs e)
        {
            //...
            //..Your Code
            //
            hideSubmenu();
        }
        #endregion StdSubmenu

        private void button_course_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_courseSubmenu);
        }
        #region CourseSubMenu
        private void button_newCourse_Click(object sender, EventArgs e)
        {
            //...
            //..Your Code
            //
            hideSubmenu();
        }

        private void button_manageCourse_Click(object sender, EventArgs e)
        {
            //...
            //..Your Code
            //
            hideSubmenu();
        }

        private void button_coursePrint_Click(object sender, EventArgs e)
        {
            //...
            //..Your Code
            //
            hideSubmenu();
        }
        #endregion CourseSubMenu

        private void button_score_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_scoreSubmenu);
        }
        #region newScoreSubMenu
        private void button_newScore_Click(object sender, EventArgs e)
        {
            //...
            //..Your Code
            //
            hideSubmenu();
        }

        private void button_manageScore_Click(object sender, EventArgs e)
        {
            //...
            //..Your Code
            //
            hideSubmenu();
        }

        private void button_scorePrint_Click(object sender, EventArgs e)
        {
            //...
            //..Your Code
            //
            hideSubmenu();
        }
        #endregion newScoreSubMenu
        // to show register form in mainform
        private Form activeForm = null;
        private void openChildForm(Form ChildForm)
        {
            if (activeForm != null)           
                activeForm.Close();

            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(ChildForm);
            panel_main.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();

        }

        

        private void button_logOut_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            panel_main.Controls.Add(panel_cover);
            studentCount();
        }
    }

}
