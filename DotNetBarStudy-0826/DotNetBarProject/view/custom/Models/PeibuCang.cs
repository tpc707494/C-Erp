using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetBarProject.view.custom.Models
{
    [SugarTable("PeibuCang")]
    class PeibuCang
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SN")]
        public long SN { get; set; }
        public string danhao { get; set; }
        public string liushuihao { get; set; }
        public string kehu { get; set; }
        public string pinming { get; set; }
        public string cangwei { get; set; }
        public string zongpishu { get; set; }
        public string yewuyuan { get; set; }
        public string pihao { get; set; }
        public string beizhu1 { get; set; }
        public string beizhu2 { get; set; }
        public DateTime riqimake { get; set; }
        public string zongzhong { get; set; }
        public string pishu { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string item0 { get; set; }
    }
}
