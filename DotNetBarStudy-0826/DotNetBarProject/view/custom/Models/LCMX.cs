using SqlSugar;
using System;

namespace DotNetBarProject.view.custom.Models
{
    [SugarTable("lcmx")]
    class LCMX
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SN")]
        public long SN { get; set; }

        public long SNka { get; set; }
        public string gongxu { get; set; }
        public string canchehao { get; set; }
        public string caozuoyuan { get; set; }
        public DateTime riqi { get; set; }
    }
}
