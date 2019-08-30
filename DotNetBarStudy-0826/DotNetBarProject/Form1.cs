using DevComponents.DotNetBar;
using DotNetBarProject.ChenLiao;
using DotNetBarProject.Properties;
using DotNetBarProject.view.about;
using DotNetBarProject.view.baseinfo;
using DotNetBarProject.view.custom.data;
using DotNetBarProject.view.custom.Models;
using DotNetBarProject.view.lck;
using DotNetBarProject.view.peibucang;
using DotNetBarProject.view.RanHuaCB;
using DotNetBarProject.view.RecipeManager.XiaoYangPeiF;
using DotNetBarProject.view.RenShiManager;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.view.baseinfo;

namespace DotNetBarProject
{
    public partial class Form1 : Office2007Form
    {

        private SqlSugarClient db;
        public Form1()
        {
            this.EnableGlass = false;
            db = SqlBase.GetInstance();
            InitializeComponent();
            this.DoubleBuffered = true;
            //将指定的标志设置为true或false
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //强制将分配的样式重新应用到控件
            this.UpdateStyles();
            string user_sn = Settings.Default.islogin;
            long UserSn = 0;
            try
            {
                UserSn = long.Parse(user_sn);
            }
            catch(Exception ex)
            {
                MessageBox.Show("登录数据丢失请重新登录");
                Settings.Default.islogin = "";
                Settings.Default.Save();
                return;
            }
            if (user_sn.Length == 0)
            {
                MessageBox.Show("登录数据丢失请重新登录");
                Settings.Default.islogin = "";
                Settings.Default.Save();
                return;
            }
            else
            {
                
                T_Base t_Base = db.Queryable<T_Base>()
                    .Where(it => it.SN == UserSn && it.leibie == ClsLogUser.LeiBie)
                    .First();
                if (t_Base == null)
                {
                    MessageBox.Show("登录数据丢失请重新登录");
                    Settings.Default.islogin = "";
                    Settings.Default.Save();
                    return;
                }
                else
                {
                    ClsLogUser.SNuser = t_Base.SN;
                    ClsLogUser.BianHao = t_Base.bianhao;
                    ClsLogUser.XinMing = t_Base.itemName;
                    ClsLogUser.PassWord = t_Base.item0;
                    ClsLogUser.QuanXian = db.Queryable<T_BaseQX>().Where(it => it.SNuser == ClsLogUser.SNuser).ToList();
                    labelItem1.Text = "当前用户名:" + ClsLogUser.XinMing + "  编号:" + ClsLogUser.BianHao;
                }
            }
            InitMunu();

        }
        List<string> QxString = new List<string>();//AllQx(ClsLogUser.QuanXian);
        private void InitMunu()
        {
            {

                QxString = AllQx(ClsLogUser.QuanXian);
                for (int i = 0; i < bar1.Items.Count; i++)
                {
                    if(bar1.Items[i].Text.Contains( "关于") || bar1.Items[i].Text.Contains("退出"))
                    {
                    }
                    else
                    {
                        foreach(string v in QxString)
                        {
                            Console.WriteLine(v + "-----------拥有权限");
                        }
                        if (!QxString.Contains(bar1.Items[i].Text))
                        {
                            bar1.Items[i].Visible = false;
                            Console.WriteLine(bar1.Items[i].Text+"-----------没有权限");
                        }
                        Console.WriteLine(bar1.Items[i].Text + "-----------用有权限");
                        Next(bar1.Items[i].SubItems);
                    }
                    
                }
            }
        }

        private void Next(SubItemsCollection sub)
        {
            for (int i = 0; i < sub.Count; i++)
            {
                if (!QxString.Contains(sub[i].Text))
                {
                    sub[i].Visible = false;
                    Console.WriteLine(sub[i].Text + "-----------没有权限");
                }
                Console.WriteLine(sub[i].Text + "-----------没有权限");
                Next(sub[i].SubItems);
            }
        }
        private List<string> AllQx(List<T_BaseQX> t_BaseQXes)
        {
            List<string> a = new List<string>();
            foreach(T_BaseQX t_BaseQX in t_BaseQXes)
            {
                a.Add(t_BaseQX.menuText);
            }
            return a;
        }
        /*
* 按钮点击生成面板
* 
* 
*/
        //将子窗口加入到面板
        private void SetTabShow(string tabName, Form form)
        {
            if (superTabControl1.Visible != true)
            {
                superTabControl1.Visible = true;
            }
            bool isOpen = false;
            foreach (SuperTabItem item in superTabControl1.Tabs)
            {
                //已打开
                if (item.Name == tabName)
                {
                    superTabControl1.SelectedTab = item;
                    isOpen = true;
                    break;
                }
            }
            if (!isOpen)
            {
                form.Visible = true;
                form.Dock = DockStyle.Fill;
                form.TopLevel = false;
                //创建一个tab
                SuperTabItem item = superTabControl1.CreateTab(tabName);
                item.Text = tabName;
                item.Name = tabName;
                form.FormBorderStyle = FormBorderStyle.None;
                //设置显示名和控件名
                form.TopLevel = false;
                //将子窗体添加到Tab中
                item.AttachedControl.Controls.Add(form);
                //选择该子窗体。
                superTabControl1.SelectedTab = item;
            }
        }
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            SetTabShow("客户名称", customer);
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            EmployeeName employeeName = new EmployeeName();
            SetTabShow("员工名称", employeeName);
        }
        private void buttonItem4_Click(object sender, EventArgs e)
        {
            GreigeName greigeName = new GreigeName();
            SetTabShow("胚布名称", greigeName);
        }


        private void buttonItem70_Click(object sender, EventArgs e)
        {
            Cangwei greigeName = new Cangwei();
            SetTabShow("仓位", greigeName);
        }
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            ColorName colorName = new ColorName();
            SetTabShow("颜色名称", colorName);
        }
        private void buttonItem6_Click(object sender, EventArgs e)
        {
            ColorType colorType = new ColorType();
            SetTabShow("色号类别", colorType);

        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            RanHuaType ranHuaType = new RanHuaType
            {
                TopLevel = false
            };
            SetTabShow("染化类别", ranHuaType);
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            RanHuaName ranHuaName = new RanHuaName();
            SetTabShow("染料名称", ranHuaName);
        }
        private void buttonItem26_Click(object sender, EventArgs e)
        {
            ZhujiName zhujiName = new ZhujiName();
            SetTabShow("助剂名称", zhujiName);
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            ShenChanGx shenChanGx = new ShenChanGx();
            SetTabShow("生产工序", shenChanGx);
        }
        private void buttonItem28_Click(object sender, EventArgs e)
        {
            ShenChanLc shenChanLc = new ShenChanLc();
            SetTabShow("生产流程", shenChanLc);
        }

        private void buttonItem29_Click(object sender, EventArgs e)
        {
            JiTaiYuL jiTaiYul = new JiTaiYuL();
            SetTabShow("机台浴量", jiTaiYul);
        }


        private void buttonItem30_Click(object sender, EventArgs e)
        {
            DiLiaoSet diLiaoSet = new DiLiaoSet();
            SetTabShow("滴料设置", diLiaoSet);
        }
        private void buttonItem31_Click(object sender, EventArgs e)
        {
            CiLiaoSet cLiaocSet = new CiLiaoSet();
            SetTabShow("称料设置", cLiaocSet);
        }
        private void buttonItem32_Click(object sender, EventArgs e)
        {
            FrmUser diLiaoSet = new FrmUser(bar1);
            SetTabShow("用户与权限", diLiaoSet);
            
        }
        private void buttonItem33_Click(object sender, EventArgs e)
        {
            FrmPSW diLiaoSet = new FrmPSW();
            SetTabShow("密码修改", diLiaoSet);
        }
        //人事管理
        private void buttonItem12_Click(object sender, EventArgs e)
        {
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            Tongxunlu diLiaoSet = new Tongxunlu();
            SetTabShow("通讯录", diLiaoSet);
        }
        private void lck_bar_search_Click(object sender, EventArgs e)
        {
            LckBarSearch lckBarSearch = new LckBarSearch();
            SetTabShow("流程卡查询", lckBarSearch);
            lckBarSearch.doublelist += DoubleList;

        }
        //胚布仓
        //胚布仓->胚布进仓新增
        private void buttonItem13_Click(object sender, EventArgs e)
        {
            PBJin lckBarSearch = new PBJin();
            SetTabShow("胚布进仓", lckBarSearch);
            //JinCangMake(-1L);

        }
        //胚布仓->胚布进仓查询
        private void buttonItem23_Click(object sender, EventArgs e)
        {
            PBJin lckBarSearch = new PBJin();
            SetTabShow("胚布进仓", lckBarSearch);
            //JinCangChaXun();
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            PBLin lckBarSearch = new PBLin();
            SetTabShow("胚布领用", lckBarSearch);
        }
        //配方管理->色号
        private void buttonItem41_Click(object sender, EventArgs e)
        {
            SHdj lckBarMake = new SHdj();
            SetTabShow("色号登记", lckBarMake);
        }
        //配方管理->色号
        private void buttonItem39_Click(object sender, EventArgs e)
        {
            SHdj lckBarMake = new SHdj();
            SetTabShow("色号管理", lckBarMake);
        }
        //配方管理->小样配方查询
        private void buttonItem44_Click(object sender, EventArgs e)
        {
            //XYsearchF();
            FrmXY frmXY = null;
            if (frmXY == null || frmXY.IsDisposed)
            {
                frmXY = new FrmXY();
                ///frmXY.doublelist += DoubleList;
            }
            SetTabShow("小样配方查询", frmXY);
            //frmXY.ReFlsh();
        }
        //配方管理->小样配方编辑

        private void buttonItem43_Click(object sender, EventArgs e)
        {
            //XYMakeF(-1L);
            FrmXY frmXY = null;
            if (frmXY == null || frmXY.IsDisposed)
            {
                frmXY = new FrmXY();
                ///frmXY.doublelist += DoubleList;
            }
            SetTabShow("小样配方编辑", frmXY);
        }
        //配方管理->生产配方
        private void buttonItem47_Click(object sender, EventArgs e)
        {
            view.RecipeManager.XiaoYangPeiF.SCSearch lckBarMake = new view.RecipeManager.XiaoYangPeiF.SCSearch();
            SetTabShow("生产配方", lckBarMake);
        }

        private void buttonItem46_Click(object sender, EventArgs e)
        {
            view.RecipeManager.XiaoYangPeiF.SCSearch lckBarMake = new view.RecipeManager.XiaoYangPeiF.SCSearch();
            SetTabShow("生产配方", lckBarMake);
        }
        //进度查询

        private void buttonItem58_Click(object sender, EventArgs e)
        {
            JinDuCha lckBarSearch = new JinDuCha();
            SetTabShow("进度查询", lckBarSearch);
            //lckBarSearch.doublelist += DoubleList;
        }
        private void DoubleList(Office2007Form office2007Form, Object lCKA)
        {
            if (office2007Form is LckBarSearch)
            {
                LckBarMake lckBarMake = new LckBarMake();
                SetTabShow("流程卡制作", lckBarMake);
                lckBarMake.SetData(lCKA);
            }
            /*
            else if (office2007Form is JInCangChaXun)
            {
                JinCangMake(lCKA);
            }

            else if (office2007Form is JinCangMake)
            {
                JinCangChaXun();
            }
            */
            else if (office2007Form is ChanLiangDjCha)
            {
                ChanLiangMake(lCKA);
            }
            else if (office2007Form is DuiZhangDanCha)
            {
                DuiZhangDanMake(lCKA);
            }
            else if (office2007Form is DuiZhangDanMake)
            {
                DuiZhangDanCha();
            }
            else if (office2007Form is ChanLiangDjMake)
            {
                ChanLiangDjCha();
            }
            else if (office2007Form is FanXiuDjCha)
            {
                FanXiuMake(lCKA);
            }
            else if (office2007Form is FanXiuDjMake)
            {
                FanXiuDjCha();
            }
            else if (office2007Form is JHBChaXun)
            {
                JHBMake(lCKA);
            }
            else if (office2007Form is JHBMake)
            {
                JHBCha();
            }
            else if (office2007Form is ChenBenJInCangChaXun)
            {
                ChenBenJinCangMake(lCKA);
            }
            else if (office2007Form is ChenBenJinCangMake)
            {
                ChenBenJinCangChaXun();
            }
            else if (office2007Form is view.RecipeManager.XiaoYangPeiF.Search)
            {
                XYMakeF(lCKA);
            }
            else if (office2007Form is view.RecipeManager.XiaoYangPeiF.Make)
            {
                XYsearchF();
            }
            else if (office2007Form is MaDanChaXun)
            {
                MaDanMakeF(lCKA);
            }
            else if (office2007Form is MaDanMake)
            {
                MDChaXunF();
            }

        }
        //
        //计划表
        //计划表->计划查询
        private void 计划查询_Click(object sender, EventArgs e)
        {
            JHBCha();
        }
        //计划表->计划查询
        private void 计划新增_Click(object sender, EventArgs e)
        {
            JHBMake(-1L);
        }
        private void lck_bar_make_Click(object sender, EventArgs e)
        {
            LckBarMake lckBarMake = new LckBarMake
            {
                TopLevel = false
            };
            SetTabShow("流程卡制作", lckBarMake);
            lckBarMake.SetData(-1L);
        }
        //关闭最后一个隐藏面板
        private void superTabControl1_TabItemClose(object sender, SuperTabStripTabItemCloseEventArgs e)
        {
            Console.WriteLine("关闭item操作" + superTabControl1.Tabs.Count);
            if (superTabControl1.Tabs.Count == 1)
            {
                superTabControl1.Visible = false;
            }
        }
        //滴料记录
        private void buttonItem50_Click(object sender, EventArgs e)
        {
            FrmDLJL lckBarMake = new FrmDLJL
            {
                TopLevel = false
            };
            SetTabShow("滴料记录", lckBarMake);
            //lckBarMake.SetData(-1L);
        }



        private void buttonItem49_Click(object sender, EventArgs e)
        {
            FrmRLRK lckBarMake = new FrmRLRK();
            SetTabShow("染料入库", lckBarMake);
            //lckBarMake.SetData(-1L);
        }
        private void buttonItem51_Click(object sender, EventArgs e)
        {
            FrmPFCB lckBarMake = new FrmPFCB
            {
                TopLevel = false
            };
            SetTabShow("配方成本", lckBarMake);
            //lckBarMake.SetData(-1L);
        }

        private void buttonItem52_Click(object sender, EventArgs e)
        {
            FrmRHLCB lckBarMake = new FrmRHLCB
            {
                TopLevel = false
            };
            SetTabShow("染化料成本", lckBarMake);
            //lckBarMake.SetData(-1L);
        }
        //产量登记
        private void buttonItem54_Click(object sender, EventArgs e)
        {
            ChanLiangMake(-1L);
        }
        //产量查询
        private void buttonItem55_Click(object sender, EventArgs e)
        {
            ChanLiangDjCha();
        }
        //返修查询
        private void buttonItem57_Click(object sender, EventArgs e)
        {
            FanXiuDjCha();
        }
        //返修登记
        private void buttonItem56_Click(object sender, EventArgs e)
        {
            FanXiuMake(-1L);
        }
        private void buttonItem14_Click(object sender, EventArgs e)
        {
            JinDuCha lckBarSearch = new JinDuCha
            {
                TopLevel = false
            };
            SetTabShow("进度查询", lckBarSearch);
            //lckBarSearch.doublelist += DoubleList;
        }
        //成品仓新增
        private void buttonItem60_Click(object sender, EventArgs e)
        {
            //ChenBenJinCangMake(-1L);
            //ChenBenJinCangMake chenBenJinCangMake = new ChenBenJinCangMake();
            ///chenBenJinCangMake.ShowDialog();
        }
        //成品仓查询
        private void buttonItem61_Click(object sender, EventArgs e)
        {
            ChenBenJinCangChaXun();
        }
        private void 成品出库_Click(object sender, EventArgs e)
        {
            ChenBenChuCangChaXun chenBenChuCangChaXun = new ChenBenChuCangChaXun();
            SetTabShow("成品出仓", chenBenChuCangChaXun);
            chenBenChuCangChaXun.ReFlsh();
        }
        //码单新建
        private void buttonItem66_Click(object sender, EventArgs e)
        {
            MaDanMakeF(-1L);
        }
        //码单查询
        private void buttonItem67_Click(object sender, EventArgs e)
        {
            MDChaXunF();
        }
        //关于
        private void buttonItem68_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }
        //小样单
        view.RecipeManager.XiaoYangPeiF.Make XYMake = null;
        private void XYMakeF(object lCKA)
        {

            if (XYMake == null || XYMake.IsDisposed)
            {
                XYMake = new view.RecipeManager.XiaoYangPeiF.Make();
                XYMake.doublelist += DoubleList;
            }
            XYMake.SetData(lCKA);
            XYMake.ShowDialog();
        }
        view.RecipeManager.XiaoYangPeiF.Search XYsearch = null;
        private void XYsearchF()
        {
            if (XYsearch == null || XYsearch.IsDisposed)
            {
                XYsearch = new view.RecipeManager.XiaoYangPeiF.Search();
                XYsearch.doublelist += DoubleList;
            }
            SetTabShow("计划表查询", XYsearch);
            XYsearch.ReFlsh();
        }

        //成品库
        ChenBenJinCangMake chenBenJinCangMake = null;
        //ChanLiangDjMake chanLiangDj = null;
        private void ChenBenJinCangMake(object lCKA)
        {

            if (chenBenJinCangMake == null || chenBenJinCangMake.IsDisposed)
            {
                chenBenJinCangMake = new ChenBenJinCangMake();
                chenBenJinCangMake.doublelist += DoubleList;
            }
            chenBenJinCangMake.SetData(lCKA);
            chenBenJinCangMake.ShowDialog();
        }
        ChenBenJInCangChaXun chenBenJinCangChaXun = null;
        private void ChenBenJinCangChaXun()
        {
            if (chenBenJinCangChaXun == null || chenBenJinCangChaXun.IsDisposed)
            {
                chenBenJinCangChaXun = new ChenBenJInCangChaXun();
                //chenBenJinCangChaXun.doublelist += DoubleList;
            }
            SetTabShow("成品仓查询", chenBenJinCangChaXun);
            chenBenJinCangChaXun.ReFlsh();
        }
        //码单新建
        MaDanMake maDanMake = null;
        //ChanLiangDjMake chanLiangDj = null;
        private void MaDanMakeF(object lCKA)
        {

            if (maDanMake == null || maDanMake.IsDisposed)
            {
                maDanMake = new MaDanMake();
                maDanMake.doublelist += DoubleList;
            }
            maDanMake.SetData(lCKA);
            maDanMake.ShowDialog();
        }
        //码单查询
        MaDanChaXun maDanChaXun = null;
        private void MDChaXunF()
        {
            if (maDanChaXun == null || maDanChaXun.IsDisposed)
            {
                maDanChaXun = new MaDanChaXun();
                //maDanChaXun.doublelist += DoubleList;
            }
            SetTabShow("码单查询", maDanChaXun);
            //maDanChaXun.ReFlsh();
        }


        //计划表
        JHBMake jHBMake = null;
        //ChanLiangDjMake chanLiangDj = null;
        private void JHBMake(object lCKA)
        {

            if (jHBMake == null || jHBMake.IsDisposed)
            {
                jHBMake = new JHBMake();
                jHBMake.doublelist += DoubleList;
            }
            jHBMake.SetData(lCKA);
            jHBMake.ShowDialog();
        }
        JHBChaXun jHBChaXun = null;
        private void JHBCha()
        {
            if (jHBChaXun == null || jHBChaXun.IsDisposed)
            {
                jHBChaXun = new JHBChaXun();
                jHBChaXun.doublelist += DoubleList;
            }
            SetTabShow("计划表查询", jHBChaXun);
            //jHBChaXun.ReFlsh();
        }

        //产量登记
        ChanLiangDjMake chanLiangDj = null;
        private void ChanLiangMake(object lCKA)
        {
            if (chanLiangDj == null || chanLiangDj.IsDisposed)
            {
                chanLiangDj = new ChanLiangDjMake();
                //chanLiangDj.doublelist += DoubleList;
            }
            else
            {
                chanLiangDj.Dispose();
                chanLiangDj = new ChanLiangDjMake();
            }
            chanLiangDj.SetData(lCKA);
            chanLiangDj.Show();//.ShowDialog();
        }

        DuiZhangDanMake   duiZhangDanMake = null;
        private void DuiZhangDanMake(object lCKA)
        {
            if (duiZhangDanMake == null || duiZhangDanMake.IsDisposed)
            {
                duiZhangDanMake = new DuiZhangDanMake();
                duiZhangDanMake.doublelist += DoubleList;
            }
            duiZhangDanMake.SetData(lCKA);
            duiZhangDanMake.ShowDialog();
        }

        ChanLiangDjCha chanLiangDjCha = null;
        private void ChanLiangDjCha()
        {
            
            if (chanLiangDjCha == null || chanLiangDjCha.IsDisposed)
            {
                chanLiangDjCha = new ChanLiangDjCha();
                chanLiangDjCha.doublelist += DoubleList;
            }
            SetTabShow("产量登记", chanLiangDjCha);
            chanLiangDjCha.ReFlsh();
        }
        DuiZhangDanCha  duiZhangDanCha = null;
        private void DuiZhangDanCha()
        {

            if (duiZhangDanCha == null || duiZhangDanCha.IsDisposed)
            {
                duiZhangDanCha = new DuiZhangDanCha();
                duiZhangDanCha.doublelist += DoubleList;
            }
            SetTabShow("对账单", duiZhangDanCha);
            duiZhangDanCha.ReFlsh();
        }

        //返修登记
        FanXiuDjMake fanXiuDjMake = null;
        private void FanXiuMake(object lCKA)
        {
            if (fanXiuDjMake == null || fanXiuDjMake.IsDisposed)
            {
                fanXiuDjMake = new FanXiuDjMake();
                fanXiuDjMake.doublelist += DoubleList;
            }
            fanXiuDjMake.SetData(lCKA);
            fanXiuDjMake.ShowDialog();
        }
        FanXiuDjCha fanXiuDjCha = null;
        private void FanXiuDjCha()
        {
            if (fanXiuDjCha == null || fanXiuDjCha.IsDisposed)
            {
                fanXiuDjCha = new FanXiuDjCha();
                fanXiuDjCha.doublelist += DoubleList;
            }
            SetTabShow("返修登记查询", fanXiuDjCha);
            fanXiuDjCha.ReFlsh();
        }
        /*
        //List
        JInCangChaXun jInCangChaXun = null;
        private void JinCangChaXun()
        {
            if (jInCangChaXun == null)
            {
                jInCangChaXun = new JInCangChaXun();
                jInCangChaXun.Dock = DockStyle.Fill;
                jInCangChaXun.doublelist += DoubleList;
            }
            SetTabShow("胚布进仓查询", jInCangChaXun);
            jInCangChaXun.ReFlsh();
        }
        //展示dialog

        JinCangMake jinCangMake = null;
        private void JinCangMake(object lCKA)
        {
            if (jinCangMake == null)
            {
                jinCangMake = new JinCangMake();
            }
            jinCangMake.doublelist += DoubleList;
            jinCangMake.SetData(lCKA);
            jinCangMake.ShowDialog();
        }
        */

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBoxEx.Show("\n欢迎再次使用ERP印染管理系统   \n\n\n    确认是否退出(Y/N)", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                e.Cancel = false;
                this.Dispose();
                Settings.Default.islogin = "";
                Settings.Default.Save();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void buttonItem53_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem100_Click(object sender, EventArgs e)
        {
        
        }
        private void buttonItem101_Click(object sender, EventArgs e)
        {
            DuiZhangDanMake(-1L);
        }
        private void buttonItem102_Click(object sender, EventArgs e)
        {
            DuiZhangDanCha();
        }
        //退出
        private void buttonItem69_Click(object sender, EventArgs e)
        {
            Close();
        }
        AutoSizeFormClass asc = new AutoSizeFormClass();
        private void Form1_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
        //来样登记
        private void buttonItem11_Click(object sender, EventArgs e)
        {
            Frm_LYDJ frm_LYDJ = new Frm_LYDJ();
            SetTabShow("来样登记", frm_LYDJ);
        }
        //受样登记
        private void buttonItem12_Click_1(object sender, EventArgs e)
        {
            Frm_SYDJ frm_SYDJ = new Frm_SYDJ();
            SetTabShow("送样登记", frm_SYDJ);
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            frmCL f = new frmCL();
            f.ShowDialog();
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            FrmRLLY frmRLLY = new FrmRLLY();
            SetTabShow("染料领用", frmRLLY);
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            PKDH pKDH = new PKDH();
            SetTabShow("客胚代号", pKDH);

        }
    }
}