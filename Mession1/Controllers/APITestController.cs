using DotLiquid.Tags;
using Lucene.Net.Support;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Mession1.Controllers
{


    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Account(String Name,String Password) {
            this.Name = Name;
            this.Password = Password;
        }
    }

    public class SQLConnect
    {


       private  string server;
        private string database;
        private string username;
        private string password;
        private  string constring;

        public SQLConnect() {
            this.server = "localhost";
            this.database = "mession1";
            this.username = "root";
            this.password = "love20720";
            this.constring = "SERVER=" + this.server + ";" + "DATABASE=" + this.database + ";" +
                "UID=" + this.username + ";" + "password=" + this.password + ";";
        }

        public string getConstring() {
            return constring;
        }
    }
    public class Single{
        private static SQLConnect sQLConnect;
        public SQLConnect Return() {
            if (sQLConnect == null) {
                sQLConnect = new SQLConnect();
                return sQLConnect;
            }
            else
            {
                return sQLConnect;
            }

        }
    }
    public class SQLQuery {
        private String Name;
        private String Password;
        public SQLQuery() {

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

        public Account APIData() {

        
            return new Account(Name, Password);
        }
     }
    

    public class SQLInsert
{
    public SQLInsert(){
        Single single = new Single();
        SQLConnect sQLConnect = single.Return();

        MySqlConnection conn = new MySqlConnection(sQLConnect.getConstring());
        conn.Open();
        String sqlInsert = "Insert into mession1.connecttest(id,name,password) values (4,'sstss','s1235555')";
        MySqlCommand cmd = new MySqlCommand(sqlInsert, conn);
        int x=cmd.ExecuteNonQuery();
    }
  
        
    }

    public class APITestController : ApiController
    {
 
        [AcceptVerbs("Get")]
        public string SayHello(String values)
        {
            var data = new { Name = "Kevin", Age = 40 };
            return values;
        }

        [AcceptVerbs("Get")]
        public Object SayHello2(String values,String value2)
        {
            var data = new { Name = "Kevin", Age = 40 };
            Hashtable ht = new Hashtable();
            ht.Add("001",data);
            ht.Add("002", "Zara Ali");

            String name = (string)ht["002"];
        
            Console.WriteLine(data);
            return ht["001"];
        }


        [AcceptVerbs("Get")]
        public List<Account> JsonGet()
        {

            SQLInsert sQLInserts = new SQLInsert();
            SQLQuery sQLQuery = new SQLQuery();
            List<Account> Account = new List<Account>();
            Account account = sQLQuery.APIData();
            Account.Add(account);
            return Account;



        }

        [AcceptVerbs("Post")]
        public string PostTest(String svalue)
        { 
        
       return "222";
    }



    }
}