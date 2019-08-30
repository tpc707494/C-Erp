using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBarProject.view.custom.Models
{
    [SugarTable("BaseList")]
    class BaseList
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SN")]
        public long SN { get; set; }
        public string leibie { get; set; }
        public string bianhao { get; set; }
        public string itemkey { get; set; }
        public string itemname { get; set; }

    }
}
