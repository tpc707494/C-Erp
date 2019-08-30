using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetBarProject.view.custom.Models
{
    [SugarTable("T_PFshijian")]
    class T_PFshijian
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SN")]
        public long SN { get; set; }
        public string danhao { get; set; }
        public string shijian { get; set; }
        public string prnOK { get; set; }
        public DateTime? riqiSJ { get; set; }
        public DateTime? riqiPRN { get; set; }
    }
}
