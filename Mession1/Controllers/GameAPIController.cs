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

namespace Mession1.Controllers
{
    public class GameAPIController : ApiController
    {

        public Object Register(String account, String userName, int accounted_return, int maxbalance)
        {
            StringBuilder RegisterString = new StringBuilder("帳號:"+account+"使用這名稱:"+ userName+"回饋:"+accounted_return+"點數:"+maxbalance);
            String PostData = RegisterString.ToString();
            String ReData = CallSQL(SqlApi.REGISTER, PostData);
            return null;

        }

        public String login(String account)
        {
            StringBuilder RegisterString = new StringBuilder("帳號:" + account );
            String PostData = RegisterString.ToString();
            String LoData = CallSQL(SqlApi.LOGIN, PostData);
            return null;
        }

        public Object checkPoint(String account, int page, int limit)
        {
            StringBuilder RegisterString = new StringBuilder("帳號:" + account+"頁數:"+page+"內容:"+limit);
            String PostData = RegisterString.ToString();
            String ChData = CallSQL(SqlApi.CHECKPOINT, PostData);
            return null;
        }

        public Object pointLogs(String account, int balance)
        {
            StringBuilder RegisterString = new StringBuilder("帳號:" + account + "點數:" + balance );
            String PostData = RegisterString.ToString();
            String PoData = CallSQL(SqlApi.CHECKPOINT, PostData);
            return null;
        }

        public Object transferPoint(String account, int balance)
        {
            StringBuilder RegisterString = new StringBuilder("帳號:" + account + "點數:" + balance);
            String PostData = RegisterString.ToString();
            String PoData = CallSQL(SqlApi.CHECKPOINT, PostData);
            return null;
        }

        public enum SqlApi
        {
            REGISTER, LOGIN, CHECKPOINT, POINGLOGS, TRANSFERPOINT
        }

        public String CallSQL(SqlApi sqlApi,String PostValue)
        {
            switch (sqlApi)
            {
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
