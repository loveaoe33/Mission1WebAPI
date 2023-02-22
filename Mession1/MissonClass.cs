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
<<<<<<< HEAD
            public String account { get; set; }
            public String playUrl { get; set; }
           
=======
            private String account{ get;set;}
            //回傳
            private String playUrl{ get;set;}
>>>>>>> 8e62b136a1701f44801a579ee7a6587ae9f3dde8

        }



        public class chePoinClass
        {

<<<<<<< HEAD
            public String account { get; set; }
            //回傳
            public int userBalance { get; set; }
=======
            private String account{ get;set;}
            //回傳
            private decimal userBalance{ get;set;}

           
>>>>>>> 8e62b136a1701f44801a579ee7a6587ae9f3dde8

       
        }


        public class poinLogClass
        {
<<<<<<< HEAD
            public String account { get; set; }
            public int page;
            public String limit { get; set; }
            ///回傳
            public int total { get; set; }
            public String data { get; set; }


           
            
=======
            private String account{ get;set;}
            private int page{ get;set;}
            private int limit{ get;set;}
            ///回傳
            private int total{ get;set;}
            private String data{ get;set;}


          
>>>>>>> 8e62b136a1701f44801a579ee7a6587ae9f3dde8
        }


        public class transpClass
        {
<<<<<<< HEAD
            public String account { get; set; }
            public int balance { get; set; }
            ///回傳資料
            public int userBalance { get; set; }

=======
            private String account{ get;set;}
            private decimal balance{ get;set;}
            ///回傳資料
>>>>>>> 8e62b136a1701f44801a579ee7a6587ae9f3dde8
        }
    }
}