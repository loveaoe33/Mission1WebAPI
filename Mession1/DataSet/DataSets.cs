using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mession1.DataSet
{
    public class DataSets
    {
            public class DataSet_ExternalAccountRegister
            {
                public string GameID { get; set; }
                public string UserID { get; set; }
                public string Account { get; set; }
                public string userName { get; set; }
                public string accounted_return { get; set; }
                public string maxbalance { get; set; }
            }

            public class DataSet_OperatePointRecord
            {
                public string account { get; set; }
                public string page { get; set; }
                public string limit { get; set; }
            }

            public class DataSet_TransPoints
            {
                public string account { get; set; }
                public string balance { get; set; }
            }


            public class ExcuteResult

            {
                public bool isSucess { get; set; }
                public string FeedbackMsg { get; set; }
            }
     }
}