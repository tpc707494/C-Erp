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
    public partial class ChenBenJinCangMake : Office2007Form
    {

        //string LEIBIE = "产量登记";
        public lck.LckBarSearch.DoubleList doublelist;

        private string jihao = Settings.Default.DLjihao;
        private ClsPLCdl plcDL = new ClsPLCdl();
        private List<ClsCheng> cheng = new List<ClsCheng>();
        public SqlSugarClient db;
        long _SN = -1L;
        
        public ChenBenJinCangMake()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            db = SqlBase.GetInstance();
            init();
        }
        private void init()
        {
            EmptyInput(0);
            lblGH.txt.TextChanged += Txt_TextChanged;
            lblGH.txt.KeyPress += Textbox1_KeyPress;
            
        }

        public void Textbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                Txt_TextChanged(sender, e);
            }
        }
        private void Txt_TextChanged(object sender, EventArgs e)
        {
            if (lblGH.txt.Text.Length < 8)
            {
                EmptyInput(1);
                return;
            }
            Query(lblGH.txt.Text);
        }
        private void Query(string sn)
        {
            try
            {
                var baseIList = db.Queryable<CP_TABLE>()
                    .Where(aa => aa.ganghao == sn && aa.status == "1")
                    .First();
                if (baseIList != null)
                {
                    lblRKDH.txt.Text = baseIList.rukudanhao;
                    lblKH.txt.Text = baseIList.kehu;
                    riqi.Value = baseIList.riqi;
                    lblPM.txt.Text = baseIList.pinming;
                    lblCW.txt.Text = baseIList.cangwei;
                    lblTxt1.txt.Text = baseIList.yewuyuan;
                    lblDDH.txt.Text = baseIList.dingdanhao;
                    lblPS.txt.Text = baseIList.pishu;
                    lblJCY.cobodgv.Text = baseIList.jincangyuan;
                    lblZL.txt.Text = baseIList.zhongliang;
                    lblBZ.txt.Text = baseIList.beizu;
                }
                else
                {
                    var a = db.Queryable<LCKA>()
                        .Where(it => int.Parse(it.liushuihao) <= int.Parse(sn))
                        .OrderBy(it => it.liushuihao, OrderByType.Desc)
                        .First();
                    if (a == null) return;
                    //lblRKDH.txt.Text = a.rukudanhao;
                    lblKH.txt.Text = a.kehu;
                    riqi.Value = DateTime.Now;
                    lblPM.txt.Text = a.peiming;
                    lblCW.txt.Text = a.cangwei;
                    lblTxt1.txt.Text = a.yewuyuan;
                    //lblDDH.txt.Text = a.dingdanhao;
                    lblPS.txt.Text = a.peishu;
                    //lblJCY.cobodgv.Text = a.jincangyuan;
                    //lblZL.txt.Text = a.zhongliang;
                    //lblBZ.txt.Text = a.beizu;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
                return;
            }
        }

        private void EmptyInput(int index)
        {
            lblRKDH.txt.Text = "";
            lblKH.txt.Text = "";
            riqi.Value = DateTime.Now;
            lblPM.txt.Text = "";
            lblCW.txt.Text = "";
            lblTxt1.txt.Text = "";
            lblDDH.txt.Text = "";
            lblPS.txt.Text = "";
            lblJCY.cobodgv.Text = "";
            lblZL.txt.Text = "";
            lblBZ.txt.Text = "";
        }
        private bool Edit()
        {
            var asd = db.Queryable<CP_TABLE>().Where(it => it.SN == _SN).First();
            if (asd == null)
            {
                MessageBoxEx.Show("这没有发现可以修改的重新选择");
                return false;
            }
            else
            {
                /*
                asd.item0 = lblGH.txt.Text;
                asd.kehu = lblKH.txt.Text;
                asd.riqi = riqi.Value;
                asd.pingmin = lblPM.txt.Text;
                //asd.seming = lblSM.txt.Text;
               /// asd.sehao = lblSH.txt.Text;
                asd.menfu = lblMF.txt.Text;
                asd.pishu = lblPS.txt.Text;
                asd.kezong = lblCW.txt.Text;
                asd.zongliang = lblZL.txt.Text;
                asd.item1 = lblBZ.txt.Text;
                db.Updateable<CP_TABLE>(asd).ExecuteCommand();
                */
                return true;
            }
        }
        private bool Save()
        {
            var all1 = db.Queryable<LCKA>()
                    .Where(it => int.Parse(it.liushuihao) <= int.Parse(lblGH.txt.Text))
                    .OrderBy(it => it.liushuihao, OrderByType.Desc)
                    .First();
            if (all1 == null)
            {
                MessageBoxEx.Show("这没有发现此缸号重新选择");
                return false;
            }
            else
            {
                var aa = db.Queryable<CP_TABLE>().Where(it => it.kehu == lblGH.txt.Text).First();
                if (aa != null)
                {
                    MessageBoxEx.Show("缸号已在码单，请重新选择", "提示");
                    return false;
                }
                CP_TABLE a = new CP_TABLE()
                {
                    /*
                    item0 = lblGH.txt.Text,
                    kehu = lblKH.txt.Text,
                    riqi = riqi.Value,
                    pingmin= lblPM.txt.Text,
                    //seming = lblSM.txt.Text,
                    //sehao = lblSH.txt.Text,
                    menfu = lblMF.txt.Text,
                    pishu = lblPS.txt.Text,
                    kezong = lblCW.txt.Text,
                    zongliang = lblZL.txt.Text,
                    item1 = lblBZ.txt.Text,
                    item2 = lblDDH.txt.Text,
                    leibie = "码单",
                    */
                };
                db.Insertable<CP_TABLE>(a).ExecuteCommand();
                return true;
            }
        }
        public void SetData(object index)
        {
            init();
            long asd = (long)index;
            if (asd != -1L)
            {
                _SN = asd;
                var asd2 = db.Queryable<BaseIList>().Where(it => it.SN == _SN).First();
                //InitValue(asd2);
            }
            else
            {
                _SN = -1L;
                EmptyInput(0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doublelist(this, -1L);
            Close();
        }

        private void InitValue(CP_TABLE baseIList)
        {
            /*
            lblGH.txt.Text = baseIList.item0;
            lblKH.txt.Text = baseIList.kehu;
            riqi.Value = baseIList.riqi;
            lblPM.txt.Text = baseIList.pingmin;

            //lblSM.txt.Text = baseIList.seming;
            //lblSH.txt.Text = baseIList.sehao;
            lblMF.txt.Text = baseIList.menfu;
            lblPS.txt.Text = baseIList.pishu;
            lblCW.txt.Text = baseIList.kezong;
            lblZL.txt.Text = baseIList.zongliang;
            lblBZ.txt.Text = baseIList.item1;
            lblDDH.txt.Text = baseIList.item2;
            */
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(_SN == -1L)
            {
                if (Save())
                {
                    if (MessageBox.Show(this, "保存成功,是否退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.No)
                    {
                        doublelist(this, -1L);
                        Close();
                    }
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
    }
}
