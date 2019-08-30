using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetBarProject.view.custom.Models
{
    [SugarTable("T_PFcheng")]
    class T_PFcheng
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SN")]
        public long SN { get; set; }
        public string danhao { get; set; }
        public short cishu { get; set; }
        public long SNdata { get; set; }
        public string ranliao { get; set; }
        public decimal chengliang { get; set; }
        public decimal chengmian { get; set; }
        public decimal chengpi { get; set; }
        public string chengliangdanwei { get; set; }
        public DateTime riqicheng { get; set; }
        public string beizhu { get; set; }
    }
}
