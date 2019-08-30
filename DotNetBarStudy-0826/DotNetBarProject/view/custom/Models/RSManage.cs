using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetBarProject.view.custom.Models
{
    [SugarTable("RSManage")]
    class RSManage
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SN")]
        public long SN { get; set; }
        public string Name { get; set; }
        public string Yixiang { get; set; }
        public string Addr { get; set; }
        public string phone { get; set; }
        public string EMail { get; set; }
        public string born { get; set; }
        public string JiGuan { get; set; }
        public string Xingbie { get; set; }


        public string JiaoYu { get; set; }
        public string gzjy { get; set; }
        public string JiNeng { get; set; }
        public string Ziwopngjia { get; set; }

    }
}
