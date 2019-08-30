using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBarProject.view.custom.data
{
    public class leibie
    {
        public enum enumLB
        {
            客户,
            纱种,
            员工,
            颜色,
            色号,
            色号类别,
            染化类别,
            染料名称,
            机台浴量,
            生产工序,
            染料,
            助剂,
            助剂名称,
            用户刷卡,
            用户密码,
            称料设置,
            称料灯号,
            滴料机号,
            滴料头,
            仓位,
            小样单,
            胚客代号,
        }
        public enum enumPB
        {
            进仓,
        }
        public enum enumPFLB
        {
            生产单,
            小样单,
            计划表,
        }

        public enum exeMode
        {
            显示料单,
            显示加料,
            料单编辑,
            加料编辑,
        }

        public enum staPF
        {
            未审核,
            已审核,
            已删除,
        }
    }
}
