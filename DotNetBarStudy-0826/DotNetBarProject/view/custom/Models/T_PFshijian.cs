using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetBarProject.view.custom.Models
{
    [SugarTable("T_PFmain")]
    class T_PFmain
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SN")]
        public long SN { get; set; }
        public string leibie { get; set; }
        [SugarColumn(IsPrimaryKey = true, ColumnName = "danhao")]
        public string danhao { get; set; }
        public string ganghao { get; set; }
        public int JLci { get; set; }
        public string shazhong { get; set; }
        public string guige { get; set; }
        public string pihao { get; set; }
        public string kehu { get; set; }
        public string dingdan { get; set; }
        public string sehao { get; set; }
        public string yanse { get; set; }
        public string jihao { get; set; }
        public decimal shuiliang { get; set; }
        public decimal zhongliang { get; set; }
        public string jiagong { get; set; }
        public string yewuyuan { get; set; }
        public string dayang { get; set; }
        public string zhuche { get; set; }
        public string peifang { get; set; }
        public string fuhe { get; set; }
        public decimal mishu { get; set; }
        public string kezhong { get; set; }
        public decimal danjia { get; set; }
        public string beizhu { get; set; }
        public DateTime? riqiSave { get; set; }
        public DateTime? riqiShen { get; set; }
        public DateTime? riqiCheng { get; set; }
        public int JLciHJ { get; set; }
        public string sta { get; set; }
        public string editrec { get; set; }
    }
}
