using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mession1
{
    public class MissonClass
    {


        public class loginClass
        {
            private String account;
            //回傳
            private String playUrl;
            public loginClass() { }
            public void setaccount(String account)
            {
                this.account = account;
            }
            public void setplayUrl(String playUrl)
            {
                this.playUrl = playUrl;
            }
            public String getaccount()
            {
                return account;
            }
            public String getplayUrl()
            {
                return playUrl;
            }
        }



        public class chePoinClass
        {

            private String account;
            private int userBalance;

            public void setaccount(String account)
            {
                this.account = account;
            }
            public void setuserBalance(int userBalance)
            {
                this.userBalance = userBalance;
            }

            public String getaccount()
            {
                return account;
            }

            public int getuserBalance()
            {
                return userBalance;
            }

        }


        public class poinLogClass
        {
            private String account;
            private String page;
            private String limit;
            ///回傳
            private int total;
            private String data;


            public void setaccount(String account)
            {
                this.account = account;
            }

            public void setPage(String page)
            {
                this.page = page;
            }

            public void setlimit(String limit)
            {
                this.limit = limit;
            }
            public void settotal(int total)
            {
                this.total = total;
            }
            public void setdata(String data)
            {
                this.data = data;
            }


            public String getaccount()
            {
                return account;
            }
            public String getpage()
            {
                return page;

            }
            public String getlimit()
            {
                return limit;

            }
            public int gettotal()
            {
                return total;

            }
            public String getdata()
            {
                return data;

            }
            //
        }


        public class transpClass
        {
            private String account;
            private int balance;
            ///回傳資料
            private int userBalance;
            public void setaccount(String account)
            {
                this.account = account;
            }

            public void setbalance(int balance)
            {
                this.balance = balance;
            }
            public void setuserBalance(int userBalance)
            {
                this.userBalance = userBalance;
            }

            public String getaccount()
            {
                return account;
            }
            public int getbalance()
            {
                return balance;
            }
            public int getuserBalance()
            {
                return userBalance;
            }
        }
    }
}