using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace dbsk5_2018.Models
{
    public class StudentsModel
    {
        private string connectionString = "Server=localhost;Database=dbskdemo;User ID=ENTER_DB_USER;Password=ENTER_DB_USER_PWD;Pooling=false;";

        public StudentsModel(string connectionName)
        {
            //connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public DataTable GetAllStudents()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Student;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable studentsTable = ds.Tables["result"];
            dbcon.Close();

            return studentsTable;
        }

        public void DeleteStudent(int id)
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            string deleteString = "DELETE FROM Student WHERE id=@ID;";
            MySqlCommand sqlCmd = new MySqlCommand(deleteString, dbcon);
            sqlCmd.Parameters.AddWithValue("@ID", id);
            int rows = sqlCmd.ExecuteNonQuery();
            dbcon.Close();
        }

        public void ResetDB()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            string truncateTableString = "TRUNCATE TABLE Student;";
            MySqlCommand sqlCmd = new MySqlCommand(truncateTableString, dbcon);
            sqlCmd.ExecuteNonQuery();

            string[] names = { "Kalle Karlsson", "Eva Svensson", "Olle Andersson", "Anna Larsson" };
            string[] studyPrograms = { "DVP", "KVP", "DVP", "SVP" };
            int[] scores = { 100, 89, 78, 98 };

            for (int i = 0; (i < names.Length) && (i < studyPrograms.Length) && (i < scores.Length); i++)
            {
                sqlCmd = new MySqlCommand("INSERT INTO Student(name,studyProgram,score) VALUES(@NAME,@SPROGRAM,@SCORE)", dbcon);
                sqlCmd.Parameters.AddWithValue("@NAME", names[i]);
                sqlCmd.Parameters.AddWithValue("@SPROGRAM", studyPrograms[i]);
                sqlCmd.Parameters.AddWithValue("@SCORE", scores[i]);
                sqlCmd.ExecuteNonQuery();
            }
            dbcon.Close();
        }
    }
}
