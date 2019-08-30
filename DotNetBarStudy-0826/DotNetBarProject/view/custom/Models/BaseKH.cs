using SqlSugar;

namespace DotNetBarProject.view.custom.Models
{
    [SugarTable("BaseKH")]
    class BaseKH
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SN")]
        public long SN { get; set; }
        public string bianhao { get; set; }
        public string jianchen { get; set; }
        public string quanchen { get; set; }
        public string addr { get; set; }
        public string lianxiren { get; set; }
        public string tel { get; set; }
        public string fax { get; set; }
        public string beizhu { get; set; }
        
    }
}
