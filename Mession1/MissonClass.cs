using System;
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
            public String account { get; set; }
            public String playUrl { get; set; }
           

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