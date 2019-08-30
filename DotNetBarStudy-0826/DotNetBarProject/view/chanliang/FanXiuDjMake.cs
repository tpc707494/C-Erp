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
    public partial class FanXiuDjMake : Office2007Form
    {

        string LEIBIE = "返修登记";
        public lck.LckBarSearch.DoubleList doublelist;

        private string jihao = Settings.Default.DLjihao;
        public SqlSugarClient db;
        long _SN = -1L;
        
        public FanXiuDjMake()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            db = SqlBase.GetInstance();
            lblPIH.txt.Leave += Txt_Leave;
            //EableInput(false);
            Empty();
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            
            if (lblPIH.txt.Text.Length == 0) lblPIH.txt.Text = "0";
            try
            {
                if (float.Parse(lblPIH.txt.Text) > 100)
                {
                    MessageBoxEx.Show("进度不超过100%");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
                return;
            }
            lblPIH.txt.Text = lblPIH.txt.Text.Replace("%", "") + "%";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doublelist(this, -1L);
            Close();
        }
        private void EableInput(bool flag)
        {
            lblYWY.cobodgv.Enabled = flag;
            lblCW.cobodgv.Enabled = flag;
            lblPIH.txt.Enabled = flag;
            lblBZ1.txt.Enabled = flag;

            //riqi.Enabled = true;
            //lblTxt1.txt.Enabled = false;
            //lblTxt2.txt.Enabled = false;
            //lblZPS.txt.Enabled = false;
            //lblPS.txt.Enabled = false;
            //lblZZ.txt.Enabled = false;
        }
        private void Empty()
        {
            lblYWY.cobodgv.Text = "";
            lblCW.cobodgv.Text = "";
            lblPIH.txt.Text = "";
            lblBZ1.txt.Text = "";
            riqi.Value = DateTime.Now;
            lblTxt1.txt.Text = "";
            lblTxt2.txt.Text = "";
            lblZPS.txt.Text = "";
            lblPS.txt.Text = "";
            lblZZ.txt.Text = "";
        }
        private void InitValue(LCKA lcka, int index, BaseIList baseIList)
        {
            if (index == 1)
            {
                lblDanh.txt.Text = baseIList.dingdanhao;
                lblYWY.cobodgv.Text = baseIList.item0;
                lblCW.cobodgv.Text = baseIList.item1;
                lblPIH.txt.Text = baseIList.item2;
                lblBZ1.txt.Text = baseIList.item3;
                lblTxt1.txt.Text = baseIList.pingmin;
                lblTxt2.txt.Text = baseIList.seming;
                lblZPS.txt.Text = baseIList.sehao;
                lblPS.txt.Text = baseIList.pishu;
                lblZZ.txt.Text = baseIList.zongliang;
                riqi.Value = baseIList.riqi;
                lblKH.cobodgv.Text = baseIList.kehu;

            }
            else
            {
                riqi.Value = DateTime.Now;
                //lblDanh.txt.Text = lcka.dingdanhao;
                //lblYWY.cobodgv.Text = lcka.item0;
                //lblCW.cobodgv.Text = lcka.item1;
                //lblPIH.txt.Text = lcka.item2;
                //lblBZ1.txt.Text = lcka.item3;
                lblTxt1.txt.Text = lcka.peiming;
                lblTxt2.txt.Text = lcka.sebie;
                lblZPS.txt.Text = lcka.sehao;
                lblPS.txt.Text = lcka.peishu;
                lblZZ.txt.Text = lcka.zhongliang;
                lblKH.cobodgv.Text = lcka.kehu;
                //lblPS.txt.Text = lcka.;
            }

        }
        private bool Save()
        {
            bool flag = false;
            try
            {
                var all = db.Queryable<LCKA>().Where(it => it.liushuihao == lblDanh.txt.Text).First();
                if(all == null)
                {
                    MessageBoxEx.Show("这没有发现此缸号重新选择");
                    return flag;
                }
                var all1 = db.Queryable<BaseIList>().Where(it => it.dingdanhao == lblDanh.txt.Text && it.leibie== LEIBIE && it.item1 == lblCW.cobodgv.Text).First();
                if(all1 != null)
                {
                    MessageBoxEx.Show("该工序已返修");
                    return flag;
                }
                var sd = new BaseIList()
                {
                    dingdanhao = lblDanh.txt.Text,
                    pingmin = lblTxt1.txt.Text,
                    seming = lblTxt2.txt.Text,
                    sehao = lblZPS.txt.Text,
                    item0 = lblYWY.cobodgv.Text,
                    pishu = lblPS.txt.Text,
                    item1 = lblCW.cobodgv.Text,
                    zongliang = lblZZ.txt.Text,
                    item2 = lblPIH.txt.Text,
                    item3 = lblBZ1.txt.Text,
                    leibie = LEIBIE,
                    kehu = lblKH.cobodgv.Text,
                    /*
                    SNka = all.SN,
                    leibie = LEIBIE,
                    item0 = lblYWY.cobodgv.Text,
                    item1 = lblCW.cobodgv.Text,
                    item2 = lblPIH.txt.Text,
                    item3 = lblBZ1.txt.Text,
                    */
                    riqi = riqi.Value,

                };
                db.Insertable<BaseIList>(sd).ExecuteCommand();
                flag = true;
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
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
            try
            {
                var all = db.Queryable<LCKA>().Where(it => it.liushuihao == lblDanh.txt.Text).First();
                if (all == null)
                {
                    MessageBoxEx.Show("这没有发现此缸号重新选择");
                    return flag;
                }
                var all1 = db.Queryable<BaseIList>().Where(it => it.SN != _SN && it.leibie == LEIBIE/* && it.item1 == lblCW.cobodgv.Text*/).First();
                if (all1 != null)
                {
                    all.kehu = lblKH.cobodgv.Text;
                    all.dingdanhao = lblDanh.txt.Text;
                    all1.pingmin = lblTxt1.txt.Text;
                    all1.seming = lblTxt2.txt.Text;
                    all1.sehao = lblZPS.txt.Text;
                    all1.item0 = lblYWY.cobodgv.Text;
                    all1.pishu = lblPS.txt.Text;
                    all1.item1 = lblCW.cobodgv.Text;
                    all1.zongliang = lblZZ.txt.Text;
                    all1.item3 = lblBZ1.txt.Text;
                    all1.item2 = lblPIH.txt.Text;
                    /*
                    all1.item0 = lblYWY.cobodgv.Text;
                    all1.item1 = lblCW.cobodgv.Text;
                    all1.item2 = lblPIH.txt.Text;
                    all1.item3 = lblBZ1.txt.Text;
                    */
                    all1.riqi = DateTime.Now;
                    db.Updateable<BaseIList>(all1).ExecuteCommand();
                    flag = true;
                }

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
                flag = false;
            }
            return flag;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(_SN == -1L)
            {
                //if (Query(lblDanh.txt.Text, 0) == 0)
                //{
                    if (Save())
                    {
                        if (MessageBox.Show(this, "保存成功,是否退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.No)
                        {
                            doublelist(this, -1L);
                            Close();
                        }
                    }
                //}
                
                //else if(Query(lblDanh.txt.Text, 0) == 1)
                //{
                //    MessageBoxEx.Show("该工序已登记");
                //}
                //else
                //{
                //    MessageBoxEx.Show("不存在此工序");
                //}
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
            _SN = (long)LCK;
            if (_SN == -1L)
            {
                return;
            }
            //EableInput(false);
            Empty();
            Query1(_SN, 1);
        }
        private void ChanLiangDjMake_Load(object sender, EventArgs e)
        {
            lblDanh.txt.TextChanged += Txt_TextChanged;
            CoboInit();
        }
        private void CoboInit()
        {
            lblYWY.RefList(coboDGV.leibie.员工);
            lblCW.RefList(coboDGV.leibie.生产工序);
            lblKH.RefList(coboDGV.leibie.客户);
        }
        private void Txt_TextChanged(object sender, EventArgs e)
        {
            Empty();
            if (lblDanh.txt.Text.Length < 8) return;
            int index = Query(lblDanh.txt.Text, 1);
            if (index!=-1)
            {
                //EableInput(true);
            }
            else
            {
                //EableInput(false);
            }
        }
        private int Query1(long sn, int index1)
        {
            int index = -1;
            try
            {
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
                MessageBoxEx.Show(ex.Message);
                index = -1;
            }
            return index;
        }
        private int Query(string sn, int index1)
        {
            int index = -1;
            try
            {
                var all = db.Queryable<LCKA>().Where(it => it.liushuihao == sn).First();
                if (all != null)
                {
                    var all1 = db.Queryable<BaseIList>().Where(it => it.dingdanhao == all.liushuihao && it.leibie == LEIBIE).First();
                    if (all1 != null)
                    {
                        if(index1 == 1)
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
            catch(Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
                index = -1;
            }
            return index;
        }
    }
}
