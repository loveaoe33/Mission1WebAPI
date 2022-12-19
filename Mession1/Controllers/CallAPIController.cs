using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Mession1.MissonClass;
using Newtonsoft.Json;


namespace Mession1.Controllers
{

    public class CallAPIController : ApiController
    {

        [AcceptVerbs("Get")]
        public String test() {
     
            return "123";
        }

        [AcceptVerbs("Get")]
        public Object Register(String account, String userName, int accounted_return, int maxbalance)
        {

            try
            {
               
                
                SQLInsert sQLInserts = new SQLInsert();
                bool InserCheck = sQLInserts.InsertCheck(account, userName, accounted_return, maxbalance);
                SortedList<string, Object> JsonBackData = new SortedList<string, Object>();
                if (InserCheck == true)
                {
                    var BackData = new { playUrl = "testUrl" };
                    JsonBackData.Add("data", BackData);
                    return JsonBackData;
                }
               
      

            } 
            catch (Exception e) {
                SortedList<string, Object> JsonErrorData = new SortedList<string, Object>();
                var BackData = new { errorCode = "0003" };
                JsonErrorData.Add("data", BackData);
                return JsonErrorData;    

            }

            return null;


        }

        [AcceptVerbs("Get")]
        public Object Enum()
        {
            var y=CallSQL(SqlApi.REGISTER);
 
            return y;
        }




        public String login(String account)
        {
            return null;
        }

        public Object checkPoint(String account,int page,int limit)
        {
            return null;
        }

        public Object pointLogs(String account,int balance)
        {
            return null;
        }

        public Object transferPoint() {
            return null;
        }



        public class SQLConnect
        {


            private string server;
            private string database;
            private string username;
            private string password;
            private string constring;

            public SQLConnect()
            {
                this.server = "localhost";
                this.database = "mession1";
                this.username = "root";
                this.password = "love20720";
                this.constring = "SERVER=" + this.server + ";" + "DATABASE=" + this.database + ";" +
                    "UID=" + this.username + ";" + "password=" + this.password + ";";
            }

            public string getConstring()
            {
                return constring;
            }
        }


        public class Single
        {
            private static SQLConnect sQLConnect;
            public SQLConnect Return()
            {
                if (sQLConnect == null)
                {
                    sQLConnect = new SQLConnect();
                    return sQLConnect;
                }
                else
                {
                    return sQLConnect;
                }

            }
        }
        public class SQLQuery
        {
            private String Name;
            private String Password;
            public SQLQuery()
            {

                Single single = new Single();
                SQLConnect sQLConnect = single.Return();
                MySqlConnection conn = new MySqlConnection(sQLConnect.getConstring());
                conn.Open();
                string query = "select * from connecttest";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    this.Name = (string)reader["name"];
                    this.Password = (string)reader["password"];

                }
            }

            public Account APIData()
            {


                return new Account(Name, Password);
            }
        }


        public class SQLInsert
        {

    
            Single single = new Single();
            SQLConnect sQLConnect;
            public SQLInsert()
            {
                 sQLConnect = single.Return();
            }

            public bool InsertCheck(String account, String userName, int accounted_return, int maxbalance) {
                MySqlConnection conn = new MySqlConnection(sQLConnect.getConstring());
                conn.Open();
                //String sqlInsert = "Insert into mession1.connecttest(id,name,password) values (4,'sstss','s1235555')";//
                String sqlInsert = "Insert into mession1.accounttest(account,userName,accounted_return,maxbalance) values (@account,@userName,@accounted_return,@maxbalance)";
                MySqlCommand cmd = new MySqlCommand(sqlInsert, conn);
                cmd.Parameters.AddWithValue("@account", account);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@accounted_return", accounted_return);
                cmd.Parameters.AddWithValue("@maxbalance", maxbalance);
                int count = cmd.ExecuteNonQuery();
                conn.Close();
                if (count>0) { return true; } else { return false; }
             
            }

    

        }


        public enum SqlApi {
            REGISTER,LOGIN,CHECKPOINT,POINGLOGS,TRANSFERPOINT
        }


        public String CallSQL(SqlApi sqlApi) {
            switch (sqlApi) {
                case SqlApi.REGISTER:
 
                    break;
                case SqlApi.LOGIN:
                   
                    break;
                case SqlApi.CHECKPOINT:
                    
                    break;
                case SqlApi.POINGLOGS:
                   
                    break;
                case SqlApi.TRANSFERPOINT:

                    break;
                default:
                    break;
            }
            return null;
        }
    }



   

    
    

}