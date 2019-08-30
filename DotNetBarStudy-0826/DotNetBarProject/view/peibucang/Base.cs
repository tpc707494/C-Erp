using DevComponents.DotNetBar;
using DotNetBarProject.view.custom.data;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetBarProject.view.peibucang
{
    public partial class Base : Office2007Form
    {
        public SqlSugarClient db;
        public Base()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.Location = new Point(0, 0);
            db = SqlBase.GetInstance();
        }
    }
}
