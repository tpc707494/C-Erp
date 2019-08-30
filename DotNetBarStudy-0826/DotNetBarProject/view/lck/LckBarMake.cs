using BarcodeLib;
using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using DotNetBarProject.view.custom.view;
using Microsoft.Reporting.WinForms;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace DotNetBarProject.view.lck
{
    public partial class LckBarMake : Office2007Form
    {

        List<LCKA> getByWhere = null;
        bool ShowFlag = true;
        long SN = -1L;
        SqlSugarClient db = null;
        public LckBarMake()
        {
            InitializeComponent();
            btnExe.Enabled = false;
            btnCancel.Enabled = false;
            //dgvLC.BackgroundColor = SystemColors.Window;
            //dgvLC.AllowUserToAddRows = false;//删除最后一条空白
            show_ReadOnly = true;
            this.TopLevel = false;
            this.Location = new Point(0, 0);
            db = SqlBase.GetInstance();
            SetTextNull();

            //dgvLC.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView1_RowsAdded);

            lbDaih.txt.Enabled = false;
            lblCKDH.txt.TextChanged += Txt_TextChanged;
            txtKehu.cobodgv.doublelist += Testdoublelist;
            lblSH.cobodgv.doublelist += SHdoublelist;

        }

        public void Testdoublelist(string asd, string cou2)
        {
            Console.WriteLine(asd);
            var da = db.Queryable<T_Base>().Where(it => it.bianhao == (asd)).First();
            if (da != null)
            {
                lbDaih.txt.Text = da.bianhao + "";
                lblYWY.cobodgv.Text = da.item5;
            }
        }
        public void SHdoublelist(string asd, string cou2)
        {
            var da = db.Queryable<BaseIList>().Where(it => it.item3 == cou2).First();
            if (da != null)
            {
                txtSebie.cobodgv.Text = da.seming;
            }
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            var all1 = db.Queryable<PeibuCang>()
                    .Where(it => it.danhao == lblCKDH.txt.Text)
                    .First();
            if (all1 != null)
            {
                txtKehu.cobodgv.Text = all1.kehu;
                txtPinming.cobodgv.Text = all1.pinming;
                lblYWY.cobodgv.Text = all1.yewuyuan;
                lblCW.cobodgv.Text = all1.cangwei;
                lbDaih.txt.Text = all1.item0;
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //for (int i = 0; i < e.RowCount; i++)
            //this.dgvLC.Rows[e.RowIndex + i].HeaderCell.Value = (e.RowIndex + i + 1).ToString();
        }
        private bool _show_readonly = false;

        private bool show_ReadOnly
        {
            get
            {
                return _show_readonly;
            }
            set
            {
                _show_readonly = value;
                btnNew.Enabled = this._show_readonly;
                btnNewNow.Enabled = (this._show_readonly && this.SN != -1L);
                btnEdit.Enabled = (this._show_readonly && this.SN != -1L);
                btnDel.Enabled = (this._show_readonly && this.SN != -1L);
                btnPrn.Enabled = (this._show_readonly && this.SN != -1L);


                txtKehu.cobodgv.Enabled = !this._show_readonly;
                txtPinming.cobodgv.Enabled = !this._show_readonly;
                txtSebie.cobodgv.Enabled = !this._show_readonly;
                txtLiuchen.cobodgv.Enabled = !this._show_readonly;
                btnExe.Enabled = !_show_readonly;
                btnCancel.Enabled = !_show_readonly;
                btnPrev.Enabled = _show_readonly;
                btnNext.Enabled = _show_readonly;

                Console.WriteLine("是否有事件" + _show_readonly);
                if (_show_readonly)
                {
                    txtLiuchen.cobodgv.AfterSelector -= new EventHandler(cobodgv_AfterSelector);
                }
                else
                {
                    Console.WriteLine("监听动画事件");
                    txtLiuchen.cobodgv.AfterSelector += new EventHandler(cobodgv_AfterSelector);
                }
            }
        }
        private void cobodgv_AfterSelector(object sender, EventArgs e)
        {
            Console.WriteLine("触发动画事件");
            var orderedQueryable = db.Queryable<BaseList>()
                                    .Where(it => it.itemkey == txtLiuchen.cobodgv.Text)
                                    .ToList();
            string sad = "";
            foreach (BaseList current in orderedQueryable)
            {
                sad += current.itemname + "->";
            }
            sad = sad.TrimEnd("->".ToCharArray());
            sclcgx.txt.Text = sad;
        }


        private void LckBarMake_VisibleChanged(object sender, EventArgs e)
        {
            ShowFlag = !ShowFlag;
            Console.WriteLine("是否可见" + ShowFlag);
        }
        public void SetData(Object o)
        {
            if (db == null)
            {
                return;
            }
            if ((long)o == -1L)
            {
                return;
            }


            getByWhere = db.Queryable<LCKA>().Where(it => it.SN == (long)o).ToList();
            if (getByWhere.Count != 1)
            {
                MessageBoxEx.Show("参数错误，请检查");
                return;
            }
            SN = (long)o;
            //客户，
            dateTimePicker1.Value = getByWhere[0].riqiZhidan;

            lblgh.txt.Text = getByWhere[0].liushuihao;
            txtKehu.cobodgv.Text = getByWhere[0].kehu;
            txtPinming.cobodgv.Text = getByWhere[0].peiming;
            txtSebie.cobodgv.Text = getByWhere[0].sebie;
            lblSH.cobodgv.Text = getByWhere[0].sehao;

            lblFUK.txt.Text = getByWhere[0].fukuan;
            lblKZ.txt.Text = getByWhere[0].kezhong;
            lblpishu.txt.Text = getByWhere[0].peishu;
            lblzhongliang.txt.Text = getByWhere[0].zhongliang;
            lblCW.cobodgv.Text = getByWhere[0].cangwei;

            lblZgs.txt.Text = getByWhere[0].zonggangshu;
            lblZps.txt.Text = getByWhere[0].zongpishu;
            lbDaih.txt.Text = getByWhere[0].daihao;
            lblDDH.txt.Text = getByWhere[0].dingdanhao;
            lblShouGan.txt.Text = getByWhere[0].shougan;

            lblSsl.txt.Text = getByWhere[0].suoshuilv;
            lblSld.txt.Text = getByWhere[0].selaodu;
            lblMC.txt.Text = getByWhere[0].michang;
            lblYWY.cobodgv.Text = getByWhere[0].yewuyuan;
            lblTS.txt.Text = getByWhere[0].taose;

            txtLiuchen.cobodgv.Text = getByWhere[0].shengchanlc;

            sclcgx.txt.Text = getByWhere[0].shengchangongxu;
            lblJGYQ.txt.Text = getByWhere[0].jiagongyaoqiu;
            lblBZ.txt.Text = getByWhere[0].beizhu;

            lblJH.cobodgv.Text = getByWhere[0].jihao;
            lblRSGY.txt.Text = getByWhere[0].ransegongyi;
            lblDXGY.txt.Text = getByWhere[0].dingxinggongyi;
            lblBZGY.txt.Text = getByWhere[0].baozhuanggongyi;
            lblMZ.txt.Text = getByWhere[0].mizhong;

            pictureBox1.Image = UserProc.GetBarcode(this.pictureBox1.Height, this.pictureBox1.Width, TYPE.CODE128, this.lblgh.txt.Text);
            this.pictureBox1.Tag = (object)this.lblgh.txt.Text;

            btnNewNow.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnPrn.Enabled = true;

        }
        public void SetTextNull()
        {
            dateTimePicker1.Value = DateTime.Now;

            lblgh.txt.Text = "";
            pictureBox1.Image = (Image)null;
            txtKehu.cobodgv.Text = "";
            txtPinming.cobodgv.Text = "";
            txtSebie.cobodgv.Text = "";
            lblSH.cobodgv.Text = "";

            lblFUK.txt.Text = "";
            lblKZ.txt.Text = "";
            lblpishu.txt.Text = "";
            lblzhongliang.txt.Text = "";
            lblCW.cobodgv.Text = "";

            lblZgs.txt.Text = "";
            lblZps.txt.Text = "";
            lbDaih.txt.Text = "";
            lblDDH.txt.Text = "";
            lblShouGan.txt.Text = "";

            lblSsl.txt.Text = "";
            lblSld.txt.Text = "";
            lblMC.txt.Text = "";
            lblYWY.cobodgv.Text = "";
            lblTS.txt.Text = "";

            txtLiuchen.cobodgv.Text = "";

            sclcgx.txt.Text = "";
            lblJGYQ.txt.Text = "";
            lblBZ.txt.Text = "";
            lblJH.cobodgv.Text = "";
            lblRSGY.txt.Text = "";
            lblDXGY.txt.Text = "";
            lblBZGY.txt.Text = "";
            lblMZ.txt.Text = "";
        }
        //第一次可见设置
        private void LckBarMake_Shown(object sender, EventArgs e)
        {
            ShowFlag = true;
        }
        private void ref_txt()
        {
            txtKehu.RefList(coboDGV.leibie.客户);
            txtPinming.RefList(coboDGV.leibie.品名);
            txtSebie.RefList(coboDGV.leibie.颜色);
            lblSH.RefList(coboDGV.leibie.色号);
            lblCW.RefList(coboDGV.leibie.仓位);
            txtLiuchen.RefList(coboDGV.leibie.流程);
            lblYWY.RefList(coboDGV.leibie.业务员);
            lblJH.RefList(coboDGV.leibie.机号);
        }

        private void Cobodgv_TextChanged(string sender)
        {
            lbDaih.txt.Text = sender;
        }

        //新建按钮
        private void button1_Click(object sender, EventArgs e)
        {
            SetTextNull();
            lblgh.txt.Text = LiuShuiHao();
            pictureBox1.Image = UserProc.GetBarcode(this.pictureBox1.Height, this.pictureBox1.Width, TYPE.CODE128, this.lblgh.txt.Text);
            this.pictureBox1.Tag = (object)this.lblgh.txt.Text;
            show_ReadOnly = false;
            ref_txt();
            btnExe.Text = "保存";
        }
        private int save_data()
        {
            var insertObj = new LCKA()
            {
                riqiZhidan = dateTimePicker1.Value,

                liushuihao = lblgh.txt.Text,
                kehu = txtKehu.cobodgv.Text,
                peiming = txtPinming.cobodgv.Text,
                sebie = txtSebie.cobodgv.Text,
                sehao = lblSH.cobodgv.Text,

                fukuan = lblFUK.txt.Text,
                kezhong = lblKZ.txt.Text,
                peishu = lblpishu.txt.Text,
                zhongliang = lblzhongliang.txt.Text,
                cangwei = lblCW.cobodgv.Text,

                zonggangshu = lblZgs.txt.Text,
                zongpishu = lblZps.txt.Text,
                daihao = lbDaih.txt.Text,
                dingdanhao = lblDDH.txt.Text,
                shougan = lblShouGan.txt.Text,

                suoshuilv = lblSsl.txt.Text,
                selaodu = lblSld.txt.Text,
                michang = lblMC.txt.Text,
                yewuyuan = lblYWY.cobodgv.Text,
                taose = lblTS.txt.Text,

                shengchanlc = txtLiuchen.cobodgv.Text,

                shengchangongxu = sclcgx.txt.Text,
                jiagongyaoqiu = lblJGYQ.txt.Text,
                beizhu = lblBZ.txt.Text,

                jihao = lblJH.cobodgv.Text,
                ransegongyi = lblRSGY.txt.Text,
                dingxinggongyi = lblDXGY.txt.Text,
                baozhuanggongyi = lblBZGY.txt.Text,
                mizhong = lblMZ.txt.Text,
            };
            try
            {
                var t2 = db.Insertable<LCKA>(insertObj).ExecuteReturnIdentity();

                string[] array = sclcgx.txt.Text.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < array.Length; i++)
                {
                    var insertObj1 = new LCMX
                    {
                        SNka = t2,
                        gongxu = array[i],
                        riqi = dateTimePicker1.Value,

                    };
                    db.Insertable<LCMX>(insertObj1).ExecuteCommand();
                }
                return t2;
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
                return -1;
            }
        }
        private bool edit_data()
        {
            bool result1;

            LCKA result = null;
            result = db.Queryable<LCKA>()
                    .Where(it => it.SN == SN)
                    .OrderBy(it => it.SN, OrderByType.Desc)
                    .First();
            if (result == null)
            {
                MessageBox.Show(this, "该行已不存在!请核对!", "提示");
                result1 = false;
            }
            else
            {
                result.liushuihao = lblgh.txt.Text;
                result.kehu = txtKehu.cobodgv.Text;
                result.peiming = txtPinming.cobodgv.Text;
                result.sebie = txtSebie.cobodgv.Text;
                result.sehao = lblSH.cobodgv.Text;

                result.fukuan = lblFUK.txt.Text;
                result.kezhong = lblKZ.txt.Text;
                result.peishu = lblpishu.txt.Text;
                result.zhongliang = lblzhongliang.txt.Text;
                result.cangwei = lblCW.cobodgv.Text;

                result.zonggangshu = lblZgs.txt.Text;
                result.zongpishu = lblZps.txt.Text;
                result.daihao = lbDaih.txt.Text;
                result.dingdanhao = lblDDH.txt.Text;
                result.shougan = lblShouGan.txt.Text;

                result.suoshuilv = lblSsl.txt.Text;
                result.selaodu = lblSld.txt.Text;
                result.michang = lblMC.txt.Text;
                result.yewuyuan = lblYWY.cobodgv.Text;
                result.taose = lblTS.txt.Text;

                result.shengchanlc = txtLiuchen.cobodgv.Text;

                result.shengchangongxu = sclcgx.txt.Text;
                result.jiagongyaoqiu = lblJGYQ.txt.Text;
                result.beizhu = lblBZ.txt.Text;
                result.jihao = lblJH.cobodgv.Text;
                result.ransegongyi = lblRSGY.txt.Text;
                result.dingxinggongyi = lblDXGY.txt.Text;
                result.baozhuanggongyi = lblBZGY.txt.Text;
                result.mizhong = lblMZ.txt.Text;


                //};
                try
                {
                    var t2 = db.Updateable<LCKA>(result).ExecuteCommand();

                    db.Deleteable<LCMX>().Where(it => it.SNka == result.SN).ExecuteCommand();
                    string[] array = sclcgx.txt.Text.Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < array.Length; i++)
                    {
                        var insertObj1 = new LCMX
                        {
                            SNka = result.SN,
                            gongxu = array[i],
                            riqi = dateTimePicker1.Value,

                        };
                        db.Insertable<LCMX>(insertObj1).ExecuteCommand();
                    }
                    result1 = true;

                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show(ex.Message);
                    result1 = false;
                }
            }

            return result1;

        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (!this.show_ReadOnly)
            {
                if (this.btnExe.Text == "保存")
                {
                    var t2 = save_data();
                    if (t2 != -1)
                    {
                        SN = t2;
                        show_ReadOnly = true;
                        SetData(SN);
                        MessageBoxEx.Show("添加成功");
                    }
                }
                else if (edit_data())
                {
                    this.show_ReadOnly = true;
                    SetData(SN);
                    MessageBox.Show(this, "修改成功!", "提示");
                }
            }


        }
        private LCKA Get_up()
        {

            LCKA result;
            if (this.SN < 0L)
            {
                result = db.Queryable<LCKA>()
                               //.Where(it => it.SN < SN)
                               .OrderBy(it => it.SN)
                               .First();
            }
            else
            {
                result = db.Queryable<LCKA>()
                               .Where(it => it.SN < SN)
                               .OrderBy(it => it.SN, OrderByType.Desc)
                               .First();
            }

            return result;
        }

        private LCKA Get_dn()
        {
            LCKA result;
            if (this.SN < 0L)
            {
                result = db.Queryable<LCKA>()
                               //.Where(it => it.SN < SN)
                               .OrderBy(it => it.SN)
                               .First();
            }
            else
            {
                result = db.Queryable<LCKA>()
                               .Where(it => it.SN > SN)
                               .OrderBy(it => it.SN, OrderByType.Asc)
                               .First();
            }
            return result;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show(this, "确认取消吗 ?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
            {
                show_ReadOnly = true;
                SetTextNull();
                SetData(SN);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            LCKA lcka = getByWhere[0];
            UserProc.WaitStart(this);
            string asd = lcka.riqiZhidan.ToString("yy-MM-dd HH:mm");
            //asd = asd.Replace("月", "-").Replace("日", "");
            Console.WriteLine("-------------" + asd);
            List<LCKA> list = new List<LCKA>();

            if (lcka == null)
            {
                MessageBox.Show(this, "该流程卡已不存在!请核对!", "提示");
                UserProc.WaitEnd(this);
            }
            else
            {
                var asdfg = db.Queryable<BaseIList>()
                    .Where(it => it.leibie == "产量登记" && it.item1 == "开卡" && it.dingdanhao == lcka.liushuihao)
                    .First();
                if (asdfg == null)
                {
                    var sd = new BaseIList()
                    {
                        leibie = "产量登记",
                        dingdanhao = lcka.liushuihao,
                        pingmin = lcka.peiming,
                        seming = lcka.sebie,
                        sehao = lcka.sehao,
                        item0 = ClsLogUser.XinMing,//操作人员
                        pishu = lcka.peishu,
                        item1 = "开卡",//工序
                        zongliang = lcka.zhongliang,
                        item2 = "0%",//百分比
                        riqi = DateTime.Now,
                        item3 = "开卡",
                        kehu = lcka.kehu,
                    };
                    db.Insertable<BaseIList>(sd).ExecuteCommand();
                }

                list.Add(lcka);
                /*
                if (lcka.zonggangshu == "" || !UserProc.IsInt(lcka.zonggangshu))
                {
                    list.Add(lcka);
                }
                else
                {
                    int num = Convert.ToInt32(lcka.zonggangshu);
                    for (int i = 0; i < num; i++)
                    {
                        LCKA asd1 = new LCKA();
                        asd1 = TransExpV2<LCKA, LCKA>.Trans(lcka);
                        asd1.liushuihao = string.Format("{0}", (int.Parse(lcka.liushuihao) + i));
                        list.Add(asd1);
                    }
                }
                */
                FrmPrn frmPrn = new FrmPrn();
                frmPrn.rptView.LocalReport.ReportEmbeddedResource = "DotNetBarProject.view.Report2.rdlc";

                string filename = Application.StartupPath + "\\imgLCK.Bmp";
                pictureBox1.Image.Save(filename, ImageFormat.Bmp);
                string str = "file:///" + filename.Replace("\\", "/");
                frmPrn.rptView.LocalReport.EnableExternalImages = true;
                ReportParameter reportParameter1 = new ReportParameter("LDH", str);

                ReportParameter parameters = new ReportParameter("p1", sclcgx.txt.Text);
                ReportParameter parameters1 = new ReportParameter("riqi", asd);

                string[] array = new string[30];
                var asde = db.Queryable<LCMX>().Where(it => it.SNka == lcka.SN).ToList();
                //string[] asdf = sclcgx.txt.Text.Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < asde.Count; i++)
                {
                    array[i] = asde[i].gongxu;
                }
                for (int i = asde.Count; i < 30; i++)
                {
                    array[i] = "";
                }
                ReportParameter parameters2 = new ReportParameter("p2", array);
                //BindingSource asdfds = new BindingSource();
                //asdfds.DataSource = asde;
                //ReportDataSource reportDataSource1 = new ReportDataSource();
                //reportDataSource1.Name = "lblcmx";
                //reportDataSource1.Value = asdfds;

                frmPrn.rptView.LocalReport.SetParameters(parameters);
                frmPrn.rptView.LocalReport.SetParameters(parameters1);
                frmPrn.rptView.LocalReport.SetParameters(reportParameter1);
                frmPrn.rptView.LocalReport.SetParameters(parameters2);
                frmPrn.rptView.LocalReport.DataSources.Clear();
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = list;
                frmPrn.rptView.LocalReport.DataSources.Clear();
                frmPrn.rptView.LocalReport.DataSources.Add(reportDataSource);
                //frmPrn.rptView.LocalReport.DataSources.Add(reportDataSource1);
                var a = frmPrn.rptView.LocalReport.DataSources;
                frmPrn.rptView.RefreshReport();
                frmPrn.ShowDialog();
                frmPrn.Close();
                UserProc.WaitEnd(this);
            }

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            LCKA up = this.Get_up();
            if (up == null)
            {
                MessageBox.Show(this, "已是第一张流程卡!", "提示");
            }
            else
            {
                SN = up.SN;
                SetData(SN);
                btnNewNow.Enabled = true;
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
                btnPrn.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            LCKA dn = this.Get_dn();
            if (dn == null)
            {
                MessageBox.Show(this, "已是最后一张流程卡!", "提示");
            }
            else
            {
                SN = dn.SN;
                SetData(SN);
                btnNewNow.Enabled = true;
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
                btnPrn.Enabled = true;
            }
        }
        private string LiuShuiHao()
        {
            string lsh;
            string yy = DateTime.Now.ToString("yy");
            string nian = yy.Substring(1)
                            + DateTime.Now.ToString("MM")
                            + DateTime.Now.ToString("dd");
            LCKA result = db.Queryable<LCKA>()
                            .OrderBy(it => it.SN, OrderByType.Desc)
                            .First();
            if (result == null)
            {
                lsh = nian + "001";
                return lsh;
            }
            string liushuihao = result.liushuihao;
            if (liushuihao.IndexOf(nian) == -1)
            {
                liushuihao = "001";
            }
            else
            {
                string liushuihao1 = liushuihao.Substring(5);
                int a = int.Parse(liushuihao1) + 1;
                liushuihao = a.ToString("000");

            }
            lsh = nian + liushuihao;
            return lsh;
        }
        private void btnNewNow_Click(object sender, EventArgs e)
        {
            this.show_ReadOnly = false;
            this.ref_txt();
            lblgh.txt.Text = LiuShuiHao();
            pictureBox1.Image = UserProc.GetBarcode(this.pictureBox1.Height, this.pictureBox1.Width, TYPE.CODE128, this.lblgh.txt.Text);
            this.pictureBox1.Tag = (object)this.lblgh.txt.Text;
            dateTimePicker1.Value = DateTime.Now.AddSeconds((double)(-(double)DateTime.Now.Second));
            //txtRiqijiaohuo.dtime.Value = DateTime.Today.AddDays(1.0);
            //txtKahao.txt.Focus();
            btnExe.Text = "保存";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            show_ReadOnly = false;
            ref_txt();
            btnExe.Text = "修改";
        }
        private bool del_data()
        {
            bool flag = false;
            try
            {
                LCKA result = db.Queryable<LCKA>()
                            .Where(it => it.SN == SN)
                            .First();
                if (result == null)
                {
                    MessageBox.Show(this, "该行已不存在!请核对!", "提示");
                    flag = false;
                }
                else
                {
                    int a = db.Deleteable<LCKA>().Where(it => it.SN == result.SN).ExecuteCommand();
                    db.Deleteable<LCMX>().Where(it => it.SNka == result.SN).ExecuteCommand();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                MessageBox.Show(this, ex.Message + "\r\n\r\n   删除失败,请再试一次!", "提示");
            }
            return flag;
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确定删除吗?删除后将不可恢复!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
            {
                if (del_data())
                {
                    this.SN = -1L;
                    SetTextNull();
                    this.btnNewNow.Enabled = false;
                    this.btnEdit.Enabled = false;
                    this.btnDel.Enabled = false;
                    this.btnPrn.Enabled = false;
                    MessageBox.Show(this, "删除成功!", "提示");
                }
            }
        }
        AutoSizeFormClass asc = new AutoSizeFormClass();
        private void LckBarMake_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void LckBarMake_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
    public static class TransExpV2<TIn, TOut>
    {

        private static readonly Func<TIn, TOut> cache = GetFunc();
        private static Func<TIn, TOut> GetFunc()
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();

            foreach (var item in typeof(TOut).GetProperties())
            {
                if (!item.CanWrite)
                    continue;

                MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }

            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
            Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[] { parameterExpression });

            return lambda.Compile();
        }

        public static TOut Trans(TIn tIn)
        {
            return cache(tIn);
        }
    }
}
