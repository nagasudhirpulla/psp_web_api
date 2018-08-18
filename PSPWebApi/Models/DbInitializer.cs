using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSPWebApi.Models
{
    public class DbInitializer
    {
        public static object[] GetSeeds()
        {
            object[] objs = new object[] {
                new { Label= "wr_demand", TableName="", TimeColName="", ValColName=""},
                new { Label= "gujarat_demand", TableName="", TimeColName="", ValColName=""}
            };
            return objs;
        }
    }
}
