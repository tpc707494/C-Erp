using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBarProject.view.custom.Models
{
    [SugarTable("T_BaseQX")]
    class T_BaseQX
    {
        [SugarColumn(IsIdentity = true, ColumnName = "SN")]
        public long SN { get; set; }
        public long SNuser { get; set; }
        public string menuText { get; set; }
        public string QuanXian { get; set; }
    }
}
