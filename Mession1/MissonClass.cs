﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mession1
{
    public class MissonClass
    {

        public class registerClass {
            public String account { get; set; }
            public String userName { get; set; }
            public short accounted_return { get; set; }
            public int maxbalance { get; set; }
            //回傳
            public String playUrl { get; set; }

           
        }

        public class loginClass
        {
<<<<<<< HEAD
            public String account { get; set; }
            public String playUrl { get; set; }
           
=======
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
>>>>>>> a86137cd8b9d330cee56ba8c5953d062d0a7a01b
        }



        public class chePoinClass
        {

            public String account { get; set; }
            //回傳
            public int userBalance { get; set; }

       
        }


        public class poinLogClass
        {
            public String account { get; set; }
            public int page;
            public String limit { get; set; }
            ///回傳
            public int total { get; set; }
            public String data { get; set; }


           
            
        }


        public class transpClass
        {
            public String account { get; set; }
            public int balance { get; set; }
            ///回傳資料
            public int userBalance { get; set; }

        }
    }
}