using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Mession1.MissonClass;
using Newtonsoft.Json;
using System.Text;
using static Mession1.AccountToken;
using NiteenNity_Case_SQL_API.Controller;
using static Mession1.DataSet.DataSets;
using NiteenNity_Case_SQL_API.Mode.DataSet.DataSet;

namespace Mession1.Controllers
{


    public class CallAPIController : ApiController
    {
        private static readonly String strAesKey = "iwww.maoblog.comiwww.maoblog.com";//加密所需32位密匙
        private static readonly String strAesKey2 = "iwww.maoblog.comiwsw.maoblog.com";
        private static String EndValue = "";
        private static NiteenNityCaseController controller = NiteenNityCaseController.getIntance();

        [AcceptVerbs("Get")]
        public String test() {

            return "123";
        }

        [AcceptVerbs("Get")]
        public String Register(String GameID,String UserID,  String Account, String userName, String accounted_return, String maxbalance) {
            controller.initConn();
            controller.SetConnectionStr("Data Source=localhost;Initial Catalog=tw_Casino1;UID=loveaoe33;PWD=love20720");
            NiteenNity_Case_SQL_API.Mode.DataSet.DataSet.DataSet_ExternalAccountRegister accountRegister = new NiteenNity_Case_SQL_API.Mode.DataSet.DataSet.DataSet_ExternalAccountRegister();
            accountRegister.GameID = GameID;
            accountRegister.UserID = UserID;
            accountRegister.Account = Account;
            accountRegister.userName = userName;
            accountRegister.accounted_return = accounted_return;
            accountRegister.maxbalance = maxbalance;
            NiteenNity_Case_SQL_API.Mode.DataSet.DAO.ExcuteResult result = controller.ExternalAccountRegister(accountRegister);
            if (result.FeedbackMsg == "資料添加成功")
            {
                return "帳號新增成功";
            }
            else
            {
                return "帳號新增錯誤";
            }
        }
        [AcceptVerbs("Get")]
        public String Login(String account,String GameID)
        {
            controller.initConn();
            controller.SetConnectionStr("Data Source=localhost;Initial Catalog=tw_Casino1;UID=loveaoe33;PWD=love20720");
            DataSet_PlayerLogin Login = new DataSet_PlayerLogin();
            Login.Account = account;
            Login.GameID = GameID;
            NiteenNity_Case_SQL_API.Mode.DataSet.DAO.ExcuteResult result = controller.PlayerLogin(Login);
            if (result.FeedbackMsg == "驗證成功")
            {
                return result.FeedbackMsg+"!"+"遊戲網址"+"https://test";

            }
            else
            {
                return result.FeedbackMsg;

            }
        }

        [AcceptVerbs("Get")]
        public String CheckPoint(string account)
        {
            controller.initConn();
            controller.SetConnectionStr("Data Source=localhost;Initial Catalog=tw_Casino1;UID=loveaoe33;PWD=love20720");
            DataSet_CheckPoint CkPoint = new DataSet_CheckPoint();
            CkPoint.Account = account;
            NiteenNity_Case_SQL_API.Mode.DataSet.DAO.ExcuteResult result = controller.checkPoints(CkPoint);
            
            if (result.isSucess)
            {
                return result.ReturnData;

            }
            else 
            {
                return "查無此帳號餘額";
            }    

           /* String PostData = String.Format("會員帳號:{0}", account);
            String ChData = SQLAPI.CallSQL(SQLAPI.SqlApi.CHECKPOINT, PostData);
            return null;*/
        }
        [AcceptVerbs("Get")]
        public String TransPoint(string Account, string Reason, string Remark, string Balance, string Editor) {
            controller.initConn();
            controller.SetConnectionStr("Data Source=localhost;Initial Catalog=tw_Casino1;UID=loveaoe33;PWD=love20720");
            NiteenNity_Case_SQL_API.Mode.DataSet.DataSet.DataSet_TransferPoint transData = new NiteenNity_Case_SQL_API.Mode.DataSet.DataSet.DataSet_TransferPoint();
            /*下為必填參數*/
            transData.Account = "";
            transData.Balance = "";

            /*下可為空直*/
            transData.Editor = "";
            transData.Remark = "";
            transData.Reason = "";
            NiteenNity_Case_SQL_API.Mode.DataSet.DAO.ExcuteResult result = controller.TransPoint(transData);
            if (result.FeedbackMsg == "")
            {
                return result.FeedbackMsg;
            }
            else
            {
                return result.FeedbackMsg;

            }


        }


        [AcceptVerbs("Get")]
        public String Encrypt_AES(String Str)
        {
            System.Security.Cryptography.RijndaelManaged rDel = new System.Security.Cryptography.RijndaelManaged();
            String Nenc = strAesKey + Str;
            /*    Byte[] keyArray = System.Text.UTF8Encoding.UTF8.GetBytes(strAesKey);
                Byte[] toEncryptArray = System.Text.UTF8Encoding.UTF8.GetBytes(Str);*/

            /*         rDel.Key = keyArray;
                     rDel.Mode = System.Security.Cryptography.CipherMode.ECB;
                     rDel.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
                     System.Security.Cryptography.ICryptoTransform cTransForm = rDel.CreateDecryptor();*/
            Byte[] resultArray = System.Text.UTF8Encoding.UTF8.GetBytes(Nenc);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }

        //加密
        [AcceptVerbs("Get")]
        public String Encrypt_AES_Byte(String Str)
        {
        Byte[] keyArray = System.Text.UTF8Encoding.UTF8.GetBytes(strAesKey);
        Byte[] toEncryptArray = System.Text.UTF8Encoding.UTF8.GetBytes(Str);
               
            System.Security.Cryptography.RijndaelManaged rDel = new System.Security.Cryptography.RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = System.Security.Cryptography.CipherMode.ECB;
            rDel.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            System.Security.Cryptography.ICryptoTransform cTransForm = rDel.CreateEncryptor();
            Byte[] resultArray = cTransForm.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            EndValue = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            return EndValue;

        }

        //解密
        [AcceptVerbs("Get")]
        public string Decrypt_AES_Byte() {
            Byte[] KeyArrary = System.Text.UTF8Encoding.UTF8.GetBytes(strAesKey2);
            Byte[] toEncryptArray = Convert.FromBase64String(EndValue);
            System.Security.Cryptography.RijndaelManaged rDel = new System.Security.Cryptography.RijndaelManaged();
            rDel.Key = KeyArrary;
            rDel.Mode = System.Security.Cryptography.CipherMode.ECB;
            rDel.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            System.Security.Cryptography.ICryptoTransform cTransForm = rDel.CreateDecryptor();
            Byte[] resultArrary = cTransForm.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return System.Text.UTF8Encoding.UTF8.GetString(resultArrary);
   
        }


    [AcceptVerbs("Get")]
        public byte[] StringToByte()
        {
            String TestValue;
            String Result;
            byte[] StB;
            StB = Encoding.ASCII.GetBytes("123");


            return StB;
        }

        [AcceptVerbs("Get")]
        public Object test2() {

            var x = ss();
            return x;
        }

        [AcceptVerbs("Get")]  //不能直接呼叫
        public static dynamic ss()
        {
            dynamic Result = new System.Dynamic.ExpandoObject();
            Result.Status = 0;
            Result.data = new { Token = "123", Url = "https://test" };
            String JsonDate = JsonConvert.SerializeObject(Result);

            return JsonDate;
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