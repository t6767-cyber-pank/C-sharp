using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.Sql;
using System.IO;
using System.Threading.Tasks;

namespace t1
{
    public class DAL
    {
        // static string path = AppDomain.CurrentDomain.BaseDirectory;
        // string connectionString = System.IO.File.ReadAllText(path + "connect.txt");
        string connectionString = "Data Source=t777;Initial Catalog=ttt;Integrated Security=True;";

        public bool saveNewCategory(string catalog)
        {
            bool flag = false;
            string query = string.Format("insert into catalog(catalog) values('{0}')", catalog);
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

        public List<List<string>> GetcatalogLB()
        {
            List<List<string>> allCat = new List<List<string>>();
            List<string> row1 = new List<string>();
            List<string> row2 = new List<string>(); 
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select catalog, id_catalog from catalog order by catalog asc");
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        row1.Add(dr[0].ToString());
                        row2.Add(dr[1].ToString());         
                    }
                    allCat.Add(row1);
                    allCat.Add(row2);
                }
                catch { }
            }
            return allCat;
        }

        public bool deleteCatalog(string catalog)
        {
            bool flag = false;
            string query = string.Format("delete from catalog where id_catalog={0}", catalog);
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

        public string GetCatalogByCB(string catalog)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select id_catalog from catalog where catalog='{0}'", catalog);
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    dr.Read();
                    return dr[0].ToString();
                }
                catch { return "0"; }
            }
        }

        public bool saveNewTovar(string tableName, string tovar, string cena, string kolvo, string dataprih, string category)
        {
            bool flag = false;
            string query = string.Format("insert into {0}(tovar, cena, kolvo, dataprih, category) values('{1}', {2}, {3}, '{4}', {5})", tableName, tovar, cena, kolvo, dataprih, category);
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

        public List<List<string>> GetTovar(string cat, bool all)
        {
            List<List<string>> allCat = new List<List<string>>();
            List<string> row1 = new List<string>();
            List<string> row2 = new List<string>();
            List<string> row3 = new List<string>();
            List<string> row4 = new List<string>();
            List<string> row5 = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = "";
                if (all == true)
                { SQL = string.Format("select tovar, cena, kolvo, dataprih, id_tovar from tovar order by tovar asc"); }
                else
                {
                    SQL = string.Format("select tovar, cena, kolvo, dataprih, id_tovar from tovar where category={0} order by tovar asc", cat); 
                    
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
                        row4.Add(dr[2].ToString());
                        row5.Add(dr[2].ToString());
                    }
                    allCat.Add(row1);
                    allCat.Add(row2);
                    allCat.Add(row3);
                    allCat.Add(row4);
                    allCat.Add(row5);
                }
                catch { }
            }
            return allCat;
        }

    }
}