using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Mession1
{
    public class AccountToken
    {


        public  class SQLAPI
        {
            public enum SqlApi
            {
                REGISTER, LOGIN, CHECKPOINT, POINGLOGS, TRANSFERPOINT
            }

            public static String CallSQL(SqlApi sqlApi, String PostValue)
            {
                switch (sqlApi)
                {
                    case SqlApi.REGISTER:
                        return "Data" + PostValue + "這是REGISTER";
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

        public class LoginToken
        {
            //登入並產生tolken
            [AcceptVerbs("Post")]
            public String AccountToken(String Account, String Password)
            {

                Login_Action login_Action = new Login_Action();
                TokenClass tokenClass = TokenClass.getTokenClass();
                tokenClass.Account = Account;
                tokenClass.Password = Password;
                tokenClass.LoginTime = DateTime.Now.AddMinutes(15);
                tokenClass.Token = login_Action.login(tokenClass);
                return "登入成功" + tokenClass.Token;

            }

            public String AutoAccount()
            {

                Login_Action login_Action = new Login_Action();
                TokenClass tokenClass = TokenClass.getTokenClass();
                bool AutoCheck = login_Action.LoginCheck(tokenClass);
                if (AutoCheck == true)
                {
                    return "自動登入成功";
                }
                else
                {
                }
                return "請重新登入";
            }

        }

        public class TokenClass
        {
            public static TokenClass tokenClass = new TokenClass();
            public String Account { get; set; }
            public String Password { get; set; }
            public DateTime LoginTime { get; set; }
            public String Token { get; set; }

            private TokenClass() { }
            public static TokenClass getTokenClass()
            {
                return tokenClass;
            }
        }

        //產生token
        public class Login_Action
        {
            public String login(TokenClass tokenClass)
            {
                StringBuilder builder = new StringBuilder();
                String MergeData = string.Format("{0},{1},{2}", tokenClass.Account, tokenClass.Password, tokenClass.LoginTime);
                var hash = SHA256.Create();
                var StringHash = hash.ComputeHash(Encoding.UTF8.GetBytes(MergeData));

                for (int i = 0; i < StringHash.Length; i++)
                {
                    builder.Append(StringHash[i].ToString("X2"));
                }

                return builder.ToString();

            }




            //時間比較與token比對回傳bool
            public bool LoginCheck(TokenClass tokenClass)
            {
                int x = DateTime.Now.CompareTo(tokenClass.LoginTime);
                if (x < 0)
                {
                    StringBuilder builder = new StringBuilder();
                    String MergeData = string.Format("{0},{1},{2}", tokenClass.Account, tokenClass.Password, tokenClass.LoginTime);
                    var hash = SHA256.Create();
                    var StringHash = hash.ComputeHash(Encoding.UTF8.GetBytes(MergeData));
                    for (int i = 0; i < StringHash.Length; i++)
                    {
                        builder.Append(StringHash[i].ToString("X2"));
                    }
                    if (builder.ToString().Equals(tokenClass.Token)) { return true; }
                    else { return false; }
                }
                else
                {
                    return false;
                }


            }



        }
    }
}