using DevComponents.DotNetBar;
using DotNetBarProject.Properties;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using DotNetBarProject.view.custom.view;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetBarProject.view.peibucang
{
    public partial class JHBMake : Office2007Form
    {
        string LEIBIE = "计划表";
        public lck.LckBarSearch.DoubleList doublelist;

        private string jihao = Settings.Default.DLjihao;
        public SqlSugarClient db = null;
        long _SN = -1L;
        
        public JHBMake()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            if (db == null)
            {
                db = SqlBase.GetInstance();
            }
        }

        private void Rl()
        {
            lblTxt1.RefList(coboDGV.leibie.品名);
            lblTxt2.RefList(coboDGV.leibie.颜色);
            lblZPS.RefList(coboDGV.leibie.色号);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            doublelist(this, -1L);
            Close();
        }
        private void Empty()
        {
            lblPIH.txt.Text = "";
            lblBZ1.txt.Text = "";
            riqi.Value = DateTime.Now;
            lblTxt1.cobodgv.Text = "";
            lblTxt2.cobodgv.Text = "";
            lblZPS.cobodgv.Text = "";
            lblPS.txt.Text = "";
            lblZZ.txt.Text = "";
        }
        private void InitValue(LCKA asdf, int index, BaseIList baseIList)
        {
            if (index == 1)
            {
                lblDanh.txt.Text = asdf.liushuihao;
                lblPIH.txt.Text = baseIList.item0;
                lblBZ1.txt.Text = baseIList.item3;

            }
            riqi.Value = DateTime.Now;
            lblTxt1.cobodgv.Text = asdf.peiming;
            lblTxt2.cobodgv.Text = asdf.sebie;
            lblZPS.cobodgv.Text = asdf.sehao;
            lblPS.txt.Text = asdf.peishu;
            lblZZ.txt.Text = asdf.zhongliang;

        }
        private bool Save()
        {
            bool flag = false;
            try
            {
                var all = db.Queryable<LCKA>().Where(it => it.liushuihao == lblDanh.txt.Text).First();
                if(all == null)
                {
                    MessageBox.Show("这没有发现此缸号重新选择");
                    return flag;
                }
                var all1 = db.Queryable<BaseIList>().Where(it => it.dingdanhao == lblDanh.txt.Text && it.leibie == LEIBIE).First();
                if(all1 != null)
                {
                    MessageBox.Show("该缸号已登记");
                    return flag;
                }
                var sd = new BaseIList()
                {
                    dingdanhao = all.liushuihao,
                    kehu = all.kehu,
                    pingmin = lblTxt1.cobodgv.Text,
                    seming = lblTxt2.cobodgv.Text,
                    sehao = lblZPS.cobodgv.Text,
                    zongliang = lblZZ.txt.Text,
                    pishu = lblPS.txt.Text,
                    item0 = lblPIH.txt.Text,
                    item3 = lblBZ1.txt.Text,
                    riqi = DateTime.Now,
                    leibie = LEIBIE,

                };
                db.Insertable<BaseIList>(sd).ExecuteCommand();
                flag = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            return flag;
        }
        private Boolean Edit()
        {
            bool flag = false;
            
            if ((long)_SN == -1L)
            {
                return flag;
            }
            var all = db.Queryable<LCKA>().Where(it => it.liushuihao == lblDanh.txt.Text).First();
            if (all == null)
            {
                MessageBox.Show("这没有发现此缸号重新选择");
                return flag;
            }
            try
            {
                var all1 = db.Queryable<BaseIList>().Where(it => it.SN == _SN && it.leibie == LEIBIE).First();
                if (all1 != null)
                {
                    all1.dingdanhao = lblDanh.txt.Text;
                    all1.kehu = all.kehu;
                    all1.pingmin = lblTxt1.cobodgv.Text;
                    all1.seming = lblTxt2.cobodgv.Text;
                    all1.sehao = lblZPS.cobodgv.Text;
                    all1.zongliang = lblZZ.txt.Text;
                    all1.pishu = lblPS.txt.Text;
                    all1.item0 = lblPIH.txt.Text;
                    all1.item3 = lblBZ1.txt.Text;
                    all1.riqi = DateTime.Now;
                    
                    db.Updateable<BaseIList>(all1).ExecuteCommand();
                    flag = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            return flag;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(_SN == -1L)
            {
                if (Query(lblDanh.txt.Text, 0) == 0)
                {
                    if (Save())
                    {
                        var all = db.Queryable<LCKA>().Where(it => it.liushuihao == lblDanh.txt.Text).First();
                        if (all == null)
                        {
                            MessageBox.Show("缸号不存在,进度不能写入", "提示");
                            return;
                        }

                        var asdfg = db.Queryable<BaseIList>()
                            .Where(it => it.leibie == "产量登记" && it.item1 == "计划" && it.dingdanhao == lblDanh.txt.Text)
                            .First();
                        if (asdfg == null)
                        {
                            var sd = new BaseIList()
                            {
                                leibie = "产量登记",
                                dingdanhao = lblDanh.txt.Text,
                                pingmin = lblTxt1.cobodgv.Text,
                                seming = lblTxt2.cobodgv.Text,
                                sehao = lblZPS.cobodgv.Text,
                                item0 = ClsLogUser.XinMing,//操作人员
                                pishu = lblPS.txt.Text,
                                item1 = "计划",//工序
                                zongliang = lblZZ.txt.Text,
                                item2 = "0%",//百分比
                                riqi = DateTime.Now,
                                item3 = "计划",
                                kehu = all.kehu,
                            };
                            db.Insertable<BaseIList>(sd).ExecuteCommand();
                        }

                        if (MessageBox.Show(this, "保存成功,是否退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.No)
                        {
                            doublelist(this, -1L);
                            Close();
                        }
                    }
                }
                else if(Query(lblDanh.txt.Text, 0) == 1)
                {
                    MessageBox.Show("该工序已登记");
                }
                else
                {
                    MessageBox.Show("不存在此工序");
                }
            }
            else
            {
                if (Edit())
                {
                    if (MessageBox.Show(this, "修改成功,是否退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.No)
                    {
                        doublelist(this, -1L);
                        Close();
                    }
                }
            }
        }
        
        private void ChanLiangDjMake_Shown(object sender, EventArgs e)
        {
        }
        public void SetData(object LCK)
        {
            Rl();
            Empty();
            _SN = (long)LCK;
            if (_SN == -1L)
            {
                return;
            }
            Query1(_SN, 1);
        }
        private void ChanLiangDjMake_Load(object sender, EventArgs e)
        {
            lblDanh.txt.TextChanged += Txt_TextChanged;
            CoboInit();
        }
        private void CoboInit()
        {

        }
        private void Txt_TextChanged(object sender, EventArgs e)
        {
            Empty();
            if (lblDanh.txt.Text.Length < 8) return;
            int index = Query(lblDanh.txt.Text, 1);
        }
        private int Query1(long sn, int index1)
        {
            int index = -1;
            try
            {
                if (db == null)
                {
                    db = SqlBase.GetInstance();
                }
                var all = db.Queryable<BaseIList>().Where(it => it.SN == sn && it.leibie == LEIBIE).First();
                if (all != null)
                {
                    var all1 = db.Queryable<LCKA>().Where(it => it.liushuihao == all.dingdanhao).First();
                    if (all1 != null)
                    {
                        if (index1 == 1)
                            InitValue(all1, 1, all);
                        index = 1;
                    }
                    else
                    {
                        if (index1 == 1)
                            InitValue(all1, 0, null);
                        index = 0;
                    }
                }
                else
                {
                    if (MessageBox.Show(this, "数据查询错误", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.No)
                    {
                        //doublelist(this, -1L);
                        //Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                index = -1;
            }
            return index;
        }
        private int Query(string sn, int index1)
        {
            int index = -1;
            try
            {
                if (db == null)
                {
                    db = SqlBase.GetInstance();
                }
                var all = db.Queryable<LCKA>()
                    .Where(it => int.Parse(it.liushuihao) <= int.Parse(sn))
                    .OrderBy(it => it.liushuihao, OrderByType.Desc)
                    .First();
                if (all != null)
                {
                    if (sn.CompareTo(int.Parse(all.liushuihao) + int.Parse(all.peishu) + "") <= 0)
                    {
                        var all1 = db.Queryable<BaseIList>().Where(it => it.SNka == all.SN && it.leibie == LEIBIE).First();
                        if (all1 != null)
                        {
                            if (index1 == 1)
                                InitValue(all, 1, all1);
                            index = 1;
                        }
                        else
                        {
                            if (index1 == 1)
                                InitValue(all, 0, null);
                            index = 0;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                index = -1;
            }
            return index;
        }
    }
}
