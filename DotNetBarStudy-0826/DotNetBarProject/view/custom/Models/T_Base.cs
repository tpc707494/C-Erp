using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBarProject.view.custom.Models
{
    [SugarTable("T_Base")]
    class T_Base
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SN")]
        public long SN { get; set; }
        [SugarColumn(IsPrimaryKey = true, ColumnName = "leibie")]
        public string leibie { get; set; }
        public string bianhao { get; set; }
        public string itemName { get; set; }
        public string item0 { get; set; }
        public string item1 { get; set; }
        public string item2 { get; set; }
        public string item3 { get; set; }
        public string item4 { get; set; }
        public string item5 { get; set; }
        public string item6 { get; set; }
        public string item7 { get; set; }
        public string item8 { get; set; }
        public string item9 { get; set; }
        public string beizhu { get; set; }
        public DateTime? riqi { get; set; }
    }
}
