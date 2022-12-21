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
namespace Mession1.Controllers
{
    public class GameAPIController : ApiController
    {


        [AcceptVerbs("Get")]
        public String ss()
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

        public String login(String account)
        {
            String PostData = String.Format("會員帳號:{0}", account);
            String LoData = SQLAPI.CallSQL(SQLAPI.SqlApi.LOGIN, PostData);
            return null;
        }

        public Object checkPoint(String account)
        {
            String PostData = String.Format("會員帳號:{0}",account);
            String ChData = SQLAPI.CallSQL(SQLAPI.SqlApi.CHECKPOINT, PostData);
            return null;
        }

        public Object pointLogs(String account, int page,int limit)
        {
            String PostData = String.Format("會員帳號:{0}*幾頁:{1}*資料數:{2}", account, page, limit);
            String PoData = SQLAPI.CallSQL(SQLAPI.SqlApi.CHECKPOINT, PostData);
            return null;
        }

        public Object transferPoint(String account, int balance)
        {
            String PostData = String.Format("會員帳號:{0}*點數:{1}", account, balance);
            String PoData = SQLAPI.CallSQL(SQLAPI.SqlApi.CHECKPOINT, PostData);
            return null;
        }


    }
}
