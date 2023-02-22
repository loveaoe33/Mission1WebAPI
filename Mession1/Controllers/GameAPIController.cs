using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Mession1.MissonClass;
using Newtonsoft.Json;
using static Mession1.Controllers.CallAPIController;
using System.Text;
using System.Web.UI;
using System.Security.Principal;
using static Mession1.AccountToken;
using NiteenNity_Case_SQL_API.Controller;
using static Mession1.DataSet.DataSets;
using NiteenNity_Case_SQL_API.Mode.DataSet.DataSet;

namespace Mession1.Controllers
{
    public class GameAPIController : ApiController
    {
        [AcceptVerbs("Get")]
        public static dynamic ss()
        {

            dynamic Result = new System.Dynamic.ExpandoObject();
            Result.Status = 0;
            Result.data = new { Token = "123", Url = "https://test" };
            return Result;
        }

        [AcceptVerbs("Get")]
        public static String sss()
        {
         
            return "123";
        }

        [AcceptVerbs("Get")]
        public static String test()
        {

            return "123";
        }

        [AcceptVerbs("Get")]
        public String Register(String account, String userName, int accounted_return, int maxbalance)
        {
            String PostData = String.Format("會員帳號:{0}*帳號暱稱:{1}*退水比例:{2}*獲利線上:{3}", account, userName, accounted_return, maxbalance);
            String ReData = SQLAPI.CallSQL(SQLAPI.SqlApi.REGISTER, PostData);
            loginClass l = new loginClass();
            l.account = "12355";
            return l.account;

        }

        [AcceptVerbs("Get")]
        public String login(String account)
        {
            NiteenNityCaseController controller = NiteenNityCaseController.getIntance();
            controller.SetConnectionStr("Data Source=localhost;Initial Catalog=tw_Casino1;UID=loveaoe33;PWD=love20720");
            DataSet_PlayerLogin Login = new DataSet_PlayerLogin();
            Login.Account = "e1559cc2fca34ea09b28668c30c60ae6";
            Login.GameID = "1";
            var result = controller.PlayerLogin(Login);
            return result.FeedbackMsg;
        }

        [AcceptVerbs("Get")]
        public Object checkPoint(String account)
        {
            String PostData = String.Format("會員帳號:{0}",account);
            String ChData = SQLAPI.CallSQL(SQLAPI.SqlApi.CHECKPOINT, PostData);
            return null;
        }

        [AcceptVerbs("Get")]
        public Object pointLogs(String account, int page,int limit)
        {
            String PostData = String.Format("會員帳號:{0}*幾頁:{1}*資料數:{2}", account, page, limit);
            String PoData = SQLAPI.CallSQL(SQLAPI.SqlApi.CHECKPOINT, PostData);
            return null;
        }

        [AcceptVerbs("Get")]
        public Object transferPoint(String account, int balance)
        {
            String PostData = String.Format("會員帳號:{0}*點數:{1}", account, balance);
            String PoData = SQLAPI.CallSQL(SQLAPI.SqlApi.CHECKPOINT, PostData);
            return null;
        }


    }
}
