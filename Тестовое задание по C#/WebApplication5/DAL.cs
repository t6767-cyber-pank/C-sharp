using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Sql;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication5
{
    public class DAL
    {
        // static string path = AppDomain.CurrentDomain.BaseDirectory;
        // string connectionString = System.IO.File.ReadAllText(path + "connect.txt");
        string connectionString = "Data Source=t777;Initial Catalog=zadachi;Integrated Security=True;";

        public bool saveNewTask(string task)
        {
            bool flag = false;
            string query = string.Format("insert into task(task, status) values('{0}', 0)", task);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    if (com.ExecuteNonQuery() == 1) flag = true;
                }
                catch { }
            }
            return flag;
        }
        /*
        public List<List<string>> GetTask()
        {
            List<List<string>> allCat = new List<List<string>>();
            List<string> row1 = new List<string>();
            List<string> row2 = new List<string>();
            List<string> row3 = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select task, id_task, status from task order by task asc");
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        row1.Add(dr[0].ToString());
                        row2.Add(dr[1].ToString());
                        row3.Add(dr[2].ToString());
                    }
                    allCat.Add(row1);
                    allCat.Add(row2);
                    allCat.Add(row3);
                }
                catch { }
            }
            return allCat;
        }
         */ 

        public List<List<string>> GetTask(bool vis, bool all)
        {
            List<List<string>> allCat = new List<List<string>>();
            List<string> row1 = new List<string>();
            List<string> row2 = new List<string>();
            List<string> row3 = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL="";
                if (all == true)
                { SQL = string.Format("select task, id_task, status from task order by task asc"); }
                else
                {
                    if (vis == true)
                    { SQL = string.Format("select task, id_task, status from task where status=0 order by task asc"); }
                    else
                    { SQL = string.Format("select task, id_task, status from task where status>0 order by task asc"); }
                }
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        row1.Add(dr[0].ToString());
                        row2.Add(dr[1].ToString());
                        row3.Add(dr[2].ToString());
                    }
                    allCat.Add(row1);
                    allCat.Add(row2);
                    allCat.Add(row3);
                }
                catch { }
            }
            return allCat;
        }

        public bool deleteTask(string task)
        {
            bool flag = false;
            string query = string.Format("delete from task where id_task={0}", task);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    if (com.ExecuteNonQuery() == 1) flag = true;
                }
                catch { }
            }
            return flag;
        }

        public bool updateStatus(string task)
        {
            bool flag = false;
            string query = string.Format("update task set status=1 where id_task={0}", task);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    if (com.ExecuteNonQuery() == 1) flag = true;
                }
                catch { }
            }
            return flag;
        }

        public string selectTask(string task)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select task from task where id_task={0}", task);
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    dr.Read();
                    return dr[0].ToString();
                }
                catch { return "Не найдено"; }
            }
        }

        public bool updateTask(string task1, string idtask1)
        {
            bool flag = false;
            string query = string.Format("update task set task='{0}' where id_task={1}", task1, idtask1);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    if (com.ExecuteNonQuery() == 1) flag = true;
                }
                catch { }
            }
            return flag;
        }

    }
}