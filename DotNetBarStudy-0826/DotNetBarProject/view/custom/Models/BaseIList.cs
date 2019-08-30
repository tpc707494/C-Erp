using SqlSugar;
using System;

namespace DotNetBarProject.view.custom.Models
{
    [SugarTable("BaseIList")]
    class BaseIList
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SN")]
        public long SN { get; set; }
        public long SNka { get; set; }
        public string leibie { get; set; }
        public string item0 { get; set; }
        public string item1 { get; set; }
        public string item2 { get; set; }
        public string item3 { get; set; }
        public DateTime riqi { get; set; }


        public string kehu { get; set; }
        public string pingmin { get; set; }
        public string seming { get; set; }
        public string sehao { get; set; }
        public string pishu { get; set; }
        public string zongliang { get; set; }
        public string dingdanhao { get; set; }
        public string menfu { get; set; }
        public string kezong { get; set; }

    }
}
