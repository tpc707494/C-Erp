using SqlSugar;
using System;

namespace DotNetBarProject.view.custom.Models
{
    [SugarTable("lcka")]
    public class LCKA
    { 
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SN")]
        public long SN { get; set; }

        public string liushuihao { get; set; }
        public DateTime riqiZhidan { get; set; }

        public string kehu { get; set; }

        public string peiming { get; set; }
        public string peishu { get; set; }
        public string daihao { get; set; }
        public string sebie { get; set; }
        public string sehao { get; set; }
        public string fukuan { get; set; }
        public string kezhong { get; set; }
        public string cangwei { get; set; }
        public string zonggangshu { get; set; }


        public string shengchanlc { get; set; }
        public string beizhu { get; set; }
        public string jiagongyaoqiu { get; set; }
        public string zhongliang { get; set; }
        public string zongpishu { get; set; }
        public string dingdanhao { get; set; }
        public string shougan { get; set; }
        public string suoshuilv { get; set; }
        public string selaodu { get; set; }
        public string michang { get; set; }
        public string taose { get; set; }
        public string yewuyuan { get; set; }
        public string shengchangongxu { get; set; }
        public string jihao { get; set; }
        public string ransegongyi { get; set; }
        public string dingxinggongyi { get; set; }
        public string baozhuanggongyi { get; set; }
        public string mizhong { get; set; }
    }
}
