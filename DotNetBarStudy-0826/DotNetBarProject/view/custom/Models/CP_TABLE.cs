using SqlSugar;
using System;

namespace DotNetBarProject.view.custom.Models
{
    [SugarTable("CP_TABLE")]
    class CP_TABLE
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SN")]
        public long SN { get; set; }
        public string dingdanhao { get; set; }
        public string jincangyuan { get; set; }
        public string beizu { get; set; }
        public string pishu { get; set; }
        public string zhongliang { get; set; }
        public string rukudanhao { get; set; }
        public string status { get; set; }
        public string yewuyuan { get; set; }
        public string ganghao { get; set; }
        public string kehu { get; set; }
        public string pinming { get; set; }
        public string cangwei { get; set; }

        public DateTime riqi { get; set; }

    }
}
