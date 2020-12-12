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


namespace MedBlok
{
    class dal
    {
        static string path = AppDomain.CurrentDomain.BaseDirectory;
        string connectionString = System.IO.File.ReadAllText(path + "connect.txt");

        public ArrayList GetNazn()
        {
            ArrayList allSotr = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select * from naznach order by nazvn asc");
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                        {
                            allSotr.Add(result);
                        }
                }
                catch { }
            }
            return allSotr;
        }

        public ArrayList GetNaznCombo()
        {
            ArrayList allSotr = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select nazvn from naznach order by nazvn asc");
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        allSotr.Add(dr[0]);
                    }
                }
                catch { }
            }
            return allSotr;
        } 

        public bool saveNewNazn(string nazvn, string opis)
        {
            bool flag = false;
            string query = string.Format("insert into naznach(nazvn, opisn) values('{0}', '{1}')", nazvn, opis);
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

        public bool updateNazn(string nazvn, string opis, string id_nazn)
        {
            bool flag = false;
            string query = string.Format("update naznach set [nazvn]='{0}', [opisn]='{1}' where id_nazn={2}", nazvn, opis, id_nazn);
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

        public bool deleteNazn(string id_nazn)
        {
            bool flag = false;
            string query = string.Format("delete from naznach where id_nazn={0}", id_nazn);
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
        
        public ArrayList GetDoza()
        {
            ArrayList allSotr = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select * from doza order by doza asc");
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                        {
                            allSotr.Add(result);
                        }
                }
                catch { }
            }
            return allSotr;
        }


        public ArrayList GetDozaCombo()
        {
            ArrayList allSotr = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select doza from doza order by doza asc");
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        allSotr.Add(dr[0]);
                    }
                }
                catch { }
            }
            return allSotr;
        }

        public bool saveNewDoza(string doza)
        {
            bool flag = false;
            string query = string.Format("insert into doza(doza) values('{0}')", doza);
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

        public bool deletedoza(string id_doza)
        {
            bool flag = false;
            string query = string.Format("delete from doza where id_doza={0}", id_doza);
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

        public ArrayList Getdlit()
        {
            ArrayList allSotr = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select * from dlit order by dlit asc");
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                        {
                            allSotr.Add(result);
                        }
                }
                catch { }
            }
            return allSotr;
        }

        public ArrayList GetdlitCombo()
        {
            ArrayList allSotr = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select dlit from dlit order by dlit asc");
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        allSotr.Add(dr[0]);
                    }
                }
                catch { }
            }
            return allSotr;
        } 
        

        public bool saveNewDlit(string dlit)
        {
            bool flag = false;
            string query = string.Format("insert into dlit(dlit) values('{0}')", dlit);
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

        public bool deleteDlit(string id_dlit)
        {
            bool flag = false;
            string query = string.Format("delete from dlit where id_dlit={0}", id_dlit);
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


         public ArrayList GetUser()
        {
            ArrayList allSotr = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select * from users order by fio asc");
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                        {
                            allSotr.Add(result);
                        }
                }
                catch { }
            }
            return allSotr;
        }

         public string CheckUser(string login, string pass)
         {
             string allSotr="0";
             using (SqlConnection con = new SqlConnection(connectionString))
             {
                 string SQL = string.Format("select count(fio) from users where login='{0}' and pass='{1}'", login, pass);
                 SqlCommand com = new SqlCommand(SQL, con);
                 try
                 {
                     con.Open();
                     SqlDataReader dr = com.ExecuteReader();
                     dr.Read();
                     
                         allSotr=dr[0].ToString();
                 }
                 catch { }
             }
             return allSotr;
         }


         public bool saveNewUser(string fio, string login, string pass, string status)
        {
            bool flag = false;
            string query = string.Format("insert into users(fio, login, pass, status) values('{0}', '{1}', '{2}', '{3}')", fio, login, pass, status);
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


         public bool updateUser(string fio, string login, string pass, string status, string id_user)
        {
            bool flag = false;
            string query = string.Format("update users set [fio]='{0}', [login]='{1}', [pass]='{2}', [status]='{3}' where id_user={4}", fio, login, pass, status, id_user);
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

        public bool deleteUser(string id_user)
        {
            bool flag = false;
            string query = string.Format("delete from users where id_user={0}", id_user);
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

        
        public ArrayList GetDiag()
        {
            ArrayList allSotr = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select * from diag order by nazv asc");
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                        {
                            allSotr.Add(result);
                        }
                }
                catch { }
            }
            return allSotr;
        }


        public ArrayList GetDiagCombo()
        {
            ArrayList allSotr = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select nazv from diag order by nazv asc");
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        allSotr.Add(dr[0]);
                    }
                }
                catch { }
            }
            return allSotr;
        } 


        public bool saveNewDiag(string nazv, string opis)
        {
            bool flag = false;
            string query = string.Format("insert into diag(nazv, opis) values('{0}', '{1}')", nazv, opis);
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
        
        public bool updateDiag(string nazv, string opis, string id_diag)
                {
                    bool flag = false;
                    string query = string.Format("update diag set [nazv]='{0}', [opis]='{1}' where id_diag={2}", nazv, opis, id_diag);
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
        
                public bool deleteDiag(string id_diag)
                {
                    bool flag = false;
                    string query = string.Format("delete from diag where id_diag={0}", id_diag);
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

                public ArrayList GetBufer(string diag)
                {
                    ArrayList allSotr = new ArrayList();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string SQL = string.Format("select * from diag d, naznach n, bufer b where b.id_diagnoz={0} and b.id_diagnoz=d.id_diag and n.id_nazn=b.id_napravlenie order by b.ocherednost", diag);
                        SqlCommand com = new SqlCommand(SQL, con);
                        try
                        {
                            con.Open();
                            SqlDataReader dr = com.ExecuteReader();
                            if (dr.HasRows)
                                foreach (DbDataRecord result in dr)
                                {
                                    allSotr.Add(result);
                                }
                        }
                        catch { }
                    }
                    return allSotr;
                }

                public bool saveNewBufer(string id_diagnoz, string id_napravlenie, string ocherednost)
                {
                    bool flag = false;
                    string query = string.Format("insert into bufer(id_diagnoz, id_napravlenie, ocherednost) values({0}, {1}, {2})", id_diagnoz, id_napravlenie, ocherednost);
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

                public bool deleteBufer(string id_bufer)
                {
                    bool flag = false;
                    string query = string.Format("delete from bufer where id_bufer={0}", id_bufer);
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

                public ArrayList GetKarta(string id_kart, string fio, string down, string up, string diag, string ponaz, string arhiv)
        {
            ArrayList allSotr = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select * from karta k where id_kart like '%{0}%' and fiopac like '%{1}%' and vozrastnapriem between {2} and {3}  and id_kart IN (SELECT k.id_kart FROM karta k, buferkart b, diag d, bufer w, naznachkart n where b.id_kart=k.id_kart and id_diagnozkart=d.id_diag and d.nazv like '%{4}%' and  n.id_diagnaz=d.id_diag and n.id_kartnaz=k.id_kart and n.nazvn like '%{5}%')  and arhiv={6} order by k.ochered asc, k.id_kart asc", id_kart, fio, down, up, diag, ponaz, arhiv);
                    SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                        {
                            allSotr.Add(result);
                        }
                }
                catch { }
            }
            return allSotr;
        }

         public ArrayList GetKartaArh()
         {
             ArrayList allSotr = new ArrayList();
             using (SqlConnection con = new SqlConnection(connectionString))
             {
                 string SQL = string.Format("select * from karta k where arhiv=1 order by k.ochered asc, k.id_kart asc");
                 SqlCommand com = new SqlCommand(SQL, con);
                 try
                 {
                     con.Open();
                     SqlDataReader dr = com.ExecuteReader();
                     if (dr.HasRows)
                         foreach (DbDataRecord result in dr)
                         {
                             allSotr.Add(result);
                         }
                 }
                 catch { }
             }
             return allSotr;
         }

        
        public bool saveNewKarta(string fiopac, string kontdan, string datar, string vozrastnapriem, string vozrastnapriemmes, string rost, string ves, string statuskart, string ochered, string arhiv)
        {
            bool flag = false;
            string query = string.Format("insert into karta(fiopac, kontdan, datar, vozrastnapriem, vozrastnapriemmes, rost, ves, statuskart, ochered, arhiv) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", fiopac, kontdan, datar, vozrastnapriem, vozrastnapriemmes, rost, ves, statuskart, ochered, arhiv);
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

        public bool updateKarta(string fiopac, string kontdan, string datar, string rost, string ves, string statuskart, string ochered, string id_kart)
                {
                    bool flag = false;
                    string query = string.Format("update karta set [fiopac]='{0}', [kontdan]='{1}', [datar]='{2}', [rost]={3}, [ves]={4}, [statuskart]='{5}', [ochered]={6} where id_kart={7}", fiopac, kontdan, datar, rost, ves, statuskart, ochered, id_kart);
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

        public bool updateKartatoArh(string id_kart)
        {
            bool flag = false;
            string query = string.Format("update karta set [arhiv]={0} where id_kart={1}", "1", id_kart);
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

        public bool updateKartatoNorm(string id_kart)
        {
            bool flag = false;
            string query = string.Format("update karta set [arhiv]={0} where id_kart={1}", "0", id_kart);
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
        
        public bool deletekarta(string id_kart)
                {
                    bool flag = false;
                    string query = string.Format("delete from karta where id_kart={0}", id_kart);
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

        
                public ArrayList Getbuferkart(string id_kart)
                {
                    ArrayList allSotr = new ArrayList();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string SQL = string.Format("select * from diag d, buferkart b where b.id_diagnozkart=d.id_diag and b.id_kart={0} order by d.nazv asc", id_kart);
                        SqlCommand com = new SqlCommand(SQL, con);
                        try
                        {
                            con.Open();
                            SqlDataReader dr = com.ExecuteReader();
                            if (dr.HasRows)
                                foreach (DbDataRecord result in dr)
                                {
                                    allSotr.Add(result);
                                }
                        }
                        catch { }
                    }
                    return allSotr;
                }


                public bool saveNewbuferkart(string id_diagnozkart, string id_kart)
                {
                    bool flag = false;
                    string query = string.Format("insert into buferkart(id_diagnozkart, id_kart) values({0}, {1})", id_diagnozkart, id_kart);
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

                public bool deletebuferkart(string id_bufkarta)
                {
                    bool flag = false;
                    string query = string.Format("delete from buferkart where id_bufkarta={0}", id_bufkarta);
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

        
                public ArrayList GetBuferT(string id_kartnaz, string diag)
                {
                    ArrayList allSotr = new ArrayList();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string SQL = string.Format("select * from diag d, naznach n, bufer b where b.id_diagnoz={0} and b.id_diagnoz=d.id_diag and n.id_nazn=b.id_napravlenie order by b.ocherednost", diag);
                        SqlCommand com = new SqlCommand(SQL, con);
                        try
                        {
                            con.Open();
                            SqlDataReader dr = com.ExecuteReader();
                            while (dr.Read())
                                {
                                    string query = string.Format("insert into naznachkart(id_kartnaz, id_diagnaz, nazvn, opisn, dozirovka, status, dlitelnost, ochered, dnaz) values({0}, {1}, '{2}', '{3}', '0', 'Назначено', '0', 1, '{4}')", id_kartnaz, diag, dr["nazvn"], dr["opisn"], DateTime.Now.ToShortDateString());
                                    using (SqlConnection combo = new SqlConnection(connectionString))
                                    {
                                        SqlCommand cos = new SqlCommand(query, combo);
                                        try
                                        {
                                            combo.Open();
                                            cos.ExecuteNonQuery();
                                        }
                                        catch { }
                                    }
                                }
                        }
                        catch { }
                    }
                    return allSotr;
                }


        
        public ArrayList GetNaznKart(string id_kartnaz, string id_diagnaz)
        {
            ArrayList allSotr = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select * from naznachkart where id_kartnaz={0} and id_diagnaz={1} order by ochered, nazvn asc", id_kartnaz, id_diagnaz);
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                        {
                            allSotr.Add(result);
                        }
                }
                catch { }
            }
            return allSotr;
        }



        public bool saveNaznKart(string id_kartnaz, string diag, string nazvn, string opisn, string dozirovka, string status, string dlitelnost, string ochered, string dnaz)
        {
            bool flag = false;
            string query = string.Format("insert into naznachkart(id_kartnaz, id_diagnaz, nazvn, opisn, dozirovka, status, dlitelnost, ochered, dnaz) values({0}, {1}, '{2}', '{3}', '{4}', '{5}', '{6}', {7}, '{8}')", id_kartnaz, diag, nazvn, opisn, dozirovka, status, dlitelnost, ochered, dnaz);
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


        public bool updateNaznKart(string nazvn, string opisn, string dozirovka, string status, string dlitelnost, string ochered, string id_nazn, string dnaz)
        {
            bool flag = false;
            string query = string.Format("update naznachkart set [nazvn]='{0}', [opisn]='{1}', [dozirovka]='{2}', [status]='{3}', [dlitelnost]='{4}', [ochered]={5}, dnaz='{6}'  where id_nazn={7}", nazvn, opisn, dozirovka, status, dlitelnost, ochered, dnaz, id_nazn);
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

        public bool deleteNaznKart(string id_nazn)
        {
            bool flag = false;
            string query = string.Format("delete from naznachkart where id_nazn={0}", id_nazn);
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

        
         public ArrayList Getkoment(string id_packart)
        {
            ArrayList allSotr = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select * from koment where id_packart={0} order by id_koment asc", id_packart);
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                        {
                            allSotr.Add(result);
                        }
                }
                catch { }
            }
            return allSotr;
        }

         public bool saveNewkoment(string text, string data, string tema, string id_packart)
        {
            bool flag = false;
            string query = string.Format("insert into koment(text, data, tema, id_packart) values('{0}', '{1}', '{2}', {3})", text, data, tema, id_packart);
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



         public bool updatekoment(string text, string tema, string id_koment)
       {
           bool flag = false;
           string query = string.Format("update koment set [text]='{0}', [tema]='{1}' where id_koment={2}", text, tema, id_koment);
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

         public bool deletekoment(string id_koment)
       {
           bool flag = false;
           string query = string.Format("delete from koment where id_koment={0}", id_koment);
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

         public bool saveNewzvukkoment(string id_packart, string path, string data)
         {
             bool flag = false;
             string query = string.Format("insert into zvukkoment(id_packart, path, data) values({0}, '{1}', '{2}')", id_packart, path, data);
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


         public ArrayList Getzvukkoment(string id_packart)
         {
             ArrayList allSotr = new ArrayList();
             using (SqlConnection con = new SqlConnection(connectionString))
             {
                 string SQL = string.Format("select * from zvukkoment where id_packart={0} order by id_zvukkoment asc", id_packart);
                 SqlCommand com = new SqlCommand(SQL, con);
                 try
                 {
                     con.Open();
                     SqlDataReader dr = com.ExecuteReader();
                     if (dr.HasRows)
                         foreach (DbDataRecord result in dr)
                         {
                             allSotr.Add(result);
                         }
                 }
                 catch { }
             }
             return allSotr;
         }

         public bool deletezvukkoment(string id_zvukkoment)
        {
            bool flag = false;
            string query = string.Format("delete from zvukkoment where id_zvukkoment={0}", id_zvukkoment);
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

        public bool saveNewFirstPoseshenie()
         {
            string rtz= "";
            string rtz2 = "";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select max(id_kart) as mkart from karta");
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    dr.Read();
                    rtz=dr[0].ToString();
                    
                }
                catch { }
            }


            using (SqlConnection con2 = new SqlConnection(connectionString))
            {
                string SQL2 = string.Format("select ves from karta where id_kart={0}", rtz);
                SqlCommand com2 = new SqlCommand(SQL2, con2);
                try
                {
                    con2.Open();
                    SqlDataReader dr2 = com2.ExecuteReader();
                    dr2.Read();
                    rtz2 = dr2[0].ToString();

                }
                catch { }
            }
 

             bool flag = false;
             string query = string.Format("insert into poseshenie(id_packartx, datapos, dadasled, ves, firstpos) values({0}, '{1}', '{2}', '{3}', '{4}')", rtz, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString(), rtz2, "1");
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


        public ArrayList GetzPos(string id_packartx)
        {
            ArrayList allSotr = new ArrayList();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string SQL = string.Format("select * from poseshenie where id_packartx={0} order by id_poseshenie asc", id_packartx);
                SqlCommand com = new SqlCommand(SQL, con);
                try
                {
                    con.Open();
                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.HasRows)
                        foreach (DbDataRecord result in dr)
                        {
                            allSotr.Add(result);
                        }
                }
                catch { }
            }
            return allSotr;
        }

        public bool saveNewposeshenie(string id_packartx, string dadasled, string ves)
        {
            bool flag = false;
            string query = string.Format("insert into poseshenie(id_packartx, datapos, dadasled, ves, firstpos) values({0}, '{1}', '{2}', {3}, 0)", id_packartx, DateTime.Now.ToShortDateString(), dadasled, ves);
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

        public bool deleteposeshenie(string id_poseshenie)
        {
            bool flag = false;
            string query = string.Format("delete from poseshenie where id_poseshenie={0}", id_poseshenie);
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

        public bool updateposeshenie(string dadasled, string ves, string id_poseshenie)
        {
            bool flag = false;
            string query = string.Format("update poseshenie set [dadasled]='{0}', [ves]={1} where id_poseshenie={2}", dadasled, ves, id_poseshenie);
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
