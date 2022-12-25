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
            private String account{ get;set;}
            //回傳
            private String playUrl{ get;set;}

        }



        public class chePoinClass
        {

            private String account{ get;set;}
            //回傳
            private decimal userBalance{ get;set;}

           

        }


        public class poinLogClass
        {
            private String account{ get;set;}
            private int page{ get;set;}
            private int limit{ get;set;}
            ///回傳
            private int total{ get;set;}
            private String data{ get;set;}


          
        }


        public class transpClass
        {
            private String account{ get;set;}
            private decimal balance{ get;set;}
            ///回傳資料
        }
    }
}