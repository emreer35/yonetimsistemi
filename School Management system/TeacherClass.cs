using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace School_Management_system
{
    internal class TeacherClass
    {
        DBconnect connect = new DBconnect();

        public bool insertTeacher(string fname,string lname, DateTime bdate, string gender, string phone, string address, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `teacher`(`TchrFirstName`, `TchrLastName`, `Birthdate`, `Gender`, `Phone`, `Address`, `Photo`) VALUES (@fn,@ln,@bd,@gd,@ph,@adr,@img)", connect.GetConnection);
            // @fn,@ln,@bd,@gd,@ph,@adr,@img
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bd", MySqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;

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
        // to get Teacher table
        public DataTable getTeacherList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `teacher`", connect.GetConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        /* public DataTable getTeacherList()
         {
             MySqlCommand command = new MySqlCommand("SELECT * FROM `teacher`", connect.GetConnection);
             MySqlDataAdapter adapter = new MySqlDataAdapter(command);
             DataTable table = new DataTable();
             adapter.Fill(table);

             // Optional: Tarih/saat sütunlarına özel bir işlem yapmak istiyorsanız, aşağıdaki gibi bir döngü ile işlem yapabilirsiniz.
             foreach (DataRow row in table.Rows)
             {
                 // Örneğin, "Birthdate" sütununun indeksini doğru bir şekilde almak için sütun adını kullanabilirsiniz.
                 int birthdateColumnIndex = table.Columns["Birthdate"].Ordinal;
                 row[birthdateColumnIndex] = Convert.ToDateTime(row[birthdateColumnIndex]);
             }

             return table;
         } */
    }
}
