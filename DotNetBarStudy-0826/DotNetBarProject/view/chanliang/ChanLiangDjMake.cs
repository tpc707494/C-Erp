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
    public partial class ChanLiangDjMake : Office2007Form
    {

        string LEIBIE = "产量登记";
        public lck.LckBarSearch.DoubleList doublelist;

        private string jihao = Settings.Default.DLjihao;
        private ClsPLCdl plcDL = new ClsPLCdl();
        private List<ClsCheng> cheng = new List<ClsCheng>();
        public SqlSugarClient db;
        long _SN = -1L;
        

        public ChanLiangDjMake()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            db = SqlBase.GetInstance();
            lblPIH.txt.Text = "100%";
            lblPIH.txt.Leave += Txt_Leave;
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            
            if (lblPIH.txt.Text.Length == 0) lblPIH.txt.Text = "0";
            try
            {
                if (float.Parse(lblPIH.txt.Text.Replace("%", "")) > 100)
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
            //doublelist(this, -1L);
            Close();
        }
        private void Empty()
        {
            lblYWY.cobodgv.Text = "";
            lblCW.cobodgv.Text = "";
            lblPIH.txt.Text = "100%";
            lblBZ1.txt.Text = "";
            riqi.Value = DateTime.Now;
            lblTxt1.cobodgv.Text = "";
            lblTxt2.cobodgv.Text = "";
            lblZPS.cobodgv.Text = "";
            lblPS.txt.Text = "";
            lblZZ.txt.Text = "";
            lblKH.cobodgv.Text = "";
        }
        private void InitValue(LCKA lcka, int index, BaseIList baseIList)
        {
            if (index == 1)
            {
                lblDanh.txt.Text = baseIList.dingdanhao;
                // lblYWY.cobodgv.Text = baseIList.item0;
                // lblCW.cobodgv.Text = baseIList.item1;
                lblPIH.txt.Text = baseIList.item2;
                lblBZ1.txt.Text = baseIList.item3;
                lblTxt1.cobodgv.Text = baseIList.pingmin;
                lblTxt2.cobodgv.Text = baseIList.seming;
                lblZPS.cobodgv.Text = baseIList.sehao;
                lblPS.txt.Text = baseIList.pishu;
                lblZZ.txt.Text = baseIList.zongliang;
                lblKH.cobodgv.Text = baseIList.kehu;
                riqi.Value = baseIList.riqi;

            }
            else
            {
                riqi.Value = DateTime.Now;
                //lblDanh.txt.Text = lcka.dingdanhao;
                //lblYWY.cobodgv.Text = lcka.item0;
                //lblCW.cobodgv.Text = lcka.item1;
                //lblPIH.txt.Text = lcka.item2;
                //lblBZ1.txt.Text = lcka.item3;
                lblTxt1.cobodgv.Text = lcka.peiming;
                lblTxt2.cobodgv.Text = lcka.sebie;
                lblZPS.cobodgv.Text = lcka.sehao;
                lblPS.txt.Text = lcka.peishu;
                lblZZ.txt.Text = lcka.zhongliang;
                lblKH.cobodgv.Text = lcka.kehu;
                //lblPS.txt.Text = lcka.;
            }

        }
        private bool Save()
        {
            bool flag = false;
            if (lblDanh.txt.Text.Length == 0)
            {
                MessageBox.Show("缸号需要填写");
                lblDanh.txt.Focus();
                return flag;
            }
            
            if (lblYWY.cobodgv.Text.Length == 0)
            {
                MessageBox.Show("操作人员必须填写");
                lblYWY.cobodgv.txtbox.Focus();
                return flag;
            }
            if (lblCW.cobodgv.Text.Length == 0)
            {
                MessageBox.Show("生产工序必须填写");
                lblCW.cobodgv.txtbox.Focus();
                return flag;
            }
            try
            {
                var all = db.Queryable<LCKA>().Where(it => it.liushuihao == lblDanh.txt.Text).First();
                if(all == null)
                {
                    MessageBox.Show("这没有发现此缸号重新选择");
                    return flag;
                }
                var all1 = db.Queryable<BaseIList>()
                    .Where(it => it.leibie == LEIBIE && it.dingdanhao==lblDanh.txt.Text && /*it.item0 == lblYWY.cobodgv.Text &&*/ it.item1 == lblCW.cobodgv.Text)
                    .First();
                if(all1!=null)
                {
                    MessageBox.Show("该缸号<>生产工序已登记");
                    return flag;
                }
                var sd = new BaseIList()
                {
                    leibie = LEIBIE,
                    dingdanhao = lblDanh.txt.Text,
                    pingmin = lblTxt1.cobodgv.Text,
                    seming = lblTxt2.cobodgv.Text,
                    sehao = lblZPS.cobodgv.Text,
                    item0 = lblYWY.cobodgv.Text,//操作人员
                    pishu = lblPS.txt.Text,
                    item1 = lblCW.cobodgv.Text,//工序
                    zongliang = lblZZ.txt.Text,
                    item2 = lblPIH.txt.Text,//百分比
                    riqi = DateTime.Now,
                    item3 = lblBZ1.txt.Text,
                    kehu = lblKH.cobodgv.Text,
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
                var all1 = db.Queryable<BaseIList>().Where(it => it.SN == _SN && it.leibie == LEIBIE).First();
                if (all1 != null)
                {
                    all1.dingdanhao = lblDanh.txt.Text;
                    all1.pingmin = lblTxt1.cobodgv.Text;
                    all1.seming = lblTxt2.cobodgv.Text;
                    all1.sehao = lblZPS.cobodgv.Text;
                    all1.item0 = lblYWY.cobodgv.Text;//操作人员
                    all1.pishu = lblPS.txt.Text;
                    all1.item1 = lblCW.cobodgv.Text;//工序
                    all1.zongliang = lblZZ.txt.Text;
                    all1.item2 = lblPIH.txt.Text;//百分比
                    all1.riqi = DateTime.Now;
                    all1.item3 = lblBZ1.txt.Text;
                    all1.kehu = lblKH.cobodgv.Text;
                    /*
                    all1.item0 = lblYWY.cobodgv.Text;
                    all1.item1 = lblCW.cobodgv.Text;
                    all1.item2 = lblPIH.txt.Text;
                    all1.item3 = lblBZ1.txt.Text;
                    all1.riqi = DateTime.Now;
                    */
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
                {
                    if (Save())
                    {
                        MessageBox.Show(this, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        Empty();
                        lblDanh.txt.Text = "";
                    }
                }
                /*
                else if(Query(lblDanh.txt.Text, 0) == 1)
                {
                    MessageBoxEx.Show("该工序已登记");
                }
                */
                //else
                {
                //    MessageBoxEx.Show("不存在此工序");
                }
            }
            else
            {
                if (Edit())
                {
                    if (MessageBox.Show(this, "修改成功", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.No)
                    {
                        //doublelist(this, -1L);
                        //Close();
                    }
                }
            }
        }
        
        private void ChanLiangDjMake_Shown(object sender, EventArgs e)
        {
            
        }
        public void SetData(object LCK)
        {
            lblDanh.txt.Text = "";
            lblKH.cobodgv.Text = "";
            
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
            lblYWY.RefList(coboDGV.leibie.员工);
            lblCW.RefList(coboDGV.leibie.生产工序);
            lblTxt1.RefList(coboDGV.leibie.品名);
            lblTxt2.RefList(coboDGV.leibie.颜色);
            lblZPS.RefList(coboDGV.leibie.色号);
            lblKH.RefList(coboDGV.leibie.客户);
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
                var all = db.Queryable<BaseIList>().Where(it => it.SN == sn && it.leibie == LEIBIE).First();
                if (all != null)
                {
                    /*/var all1 = db.Queryable<LCKA>().Where(it => it.liushuihao == lblDanh.txt.Text).First();
                    if (all1 != null)
                    {
                        if (index1 == 1)
                            InitValue(all1,1, all);
                        index = 1;
                    }
                    */
                    //else
                    {
                        if (index1 == 1)
                            InitValue(null, 1, all);
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
                var all = db.Queryable<LCKA>().Where(it => it.liushuihao == lblDanh.txt.Text).First();
                if (all != null)
                {
                    var all1 = db.Queryable<BaseIList>().Where(it => it.dingdanhao == all.liushuihao && it.leibie == LEIBIE).First();
                    if (all1 != null)
                    {
                        if(index1 == 1)
                        {
                            InitValue(all, 1, all1);
                            lblBZ1.txt.Text = "";
                        }
                        index = 1;
                    }
                    else
                    {
                        if (index1 == 1)
                        {
                            InitValue(all, 0, null);
                            lblBZ1.txt.Text = "";
                        }
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
