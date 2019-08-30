using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetBarProject.view.custom.Models
{
    [SugarTable("T_PFdata")]
    class T_PFdata
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SN")]
        public long SN { get; set; }
        [SugarColumn(IsPrimaryKey = true, ColumnName = "danhao")]
        public string danhao { get; set; }
        public string gongxu { get; set; }
        public string ranliao { get; set; }
        public string ranliaoBZ { get; set; }
        public decimal bili { get; set; }
        public string biliDW { get; set; }
        public decimal yongliang { get; set; }
        public string yongliangDW { get; set; }
        public string yaoqiu { get; set; }
        public decimal JLbili { get; set; }
        public decimal JLyongliang { get; set; }
        public string JLyongliangDW { get; set; }
        public long SNld { get; set; }
    }
}
