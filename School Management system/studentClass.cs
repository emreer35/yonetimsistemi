using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace School_Management_system
{
    internal class studentClass
    {
        DBconnect connect = new DBconnect();
        public bool insertStudent(string fname, string lname, DateTime bdate, string gender, string address)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `student`(`stdFirstName`, `stdLastName`, `birthDate`, `Gender`, `Address`) VALUES (@fn,@ln,@bd,@gd,@adr)", connect.GetConnection);
            command.Parameters.Add("fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("bd", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("gd", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("adr", MySqlDbType.VarChar).Value = address;
            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }
        // get student table
        public DataTable getStudentList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student`", connect.GetConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public string exeCount(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connect.GetConnection);
            connect.openConnect();
            string count = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return count;
               
        }
        // to get the total students
        public string totalStudent()
        {
            return exeCount("SELECT COUNT(*) FROM student;");
        }
        // to get the male studen count 
        public string maleStudent()
        {
            return exeCount("SELECT COUNT(*) FROM student WHERE Gender ='Male'");
        }
        // to get the female studen count 
        public string femaleStudent()
        {
            return exeCount("SELECT COUNT(*) FROM student WHERE Gender ='Female'");
        }
    }
}
