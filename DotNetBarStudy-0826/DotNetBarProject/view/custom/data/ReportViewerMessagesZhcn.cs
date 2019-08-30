

using Microsoft.Reporting.WinForms;

namespace DotNetBarProject.view.custom.data
{
    public class ReportViewerMessage : IReportViewerMessages
    {
        #region   IReportViewerMessages   Members 
        public string BackButtonToolTip
        {
            get { return ("后退 "); }
        }
        public string ChangeCredentialsText
        {
            get { return ("更改 "); }
        }
        public string ChangeCredentialsToolTip
        {
            get { return ("ChangeCredentialsToolTip. "); }
        }
        public string CurrentPageTextBoxToolTip
        {
            get { return ("当前页 "); }
        }
        public string DocumentMap
        {
            get { return ("文档视图 "); }
        }
        public string DocumentMapButtonToolTip
        {
            get { return ("文档视图. "); }
        }
        public string ExportButtonText
        {
            get { return ("导出 "); }
        }
        public string ExportButtonToolTip
        {
            get { return ("导出 "); }
        }
        public string ExportFormatsToolTip
        {
            get { return ("选择格式. "); }
        }
        public string FalseValueText
        {
            get { return ("不正确的值. "); }
        }
        public string FindButtonText
        {
            get { return ("查找 "); }
        }
        public string FindButtonToolTip
        {
            get { return ("查找 "); }
        }
        public string FindNextButtonText
        {
            get { return ("下一个 "); }
        }
        public string FindNextButtonToolTip
        {
            get { return ("查找下一个 "); }
        }
        public string FirstPageButtonToolTip
        {
            get { return ("第一页 "); }
        }
        public string InvalidPageNumber
        {
            get { return ("页面数不对 "); }
        }
        public string LastPageButtonToolTip
        {
            get { return ("最后一页 "); }
        }
        public string NextPageButtonToolTip
        {
            get { return ("下一页 "); }
        }
        public string NoMoreMatches
        {
            get { return ("无匹配项 "); }
        }
        public string NullCheckBoxText
        {
            get { return ("空值 "); }
        }
        public string NullValueText
        {
            get { return ("空值 "); }
        }
        public string PageOf
        {
            get { return ("页 "); }
        }
        public string ParameterAreaButtonToolTip
        {
            get { return ("参数设置 "); }
        }
        public string PasswordPrompt
        {
            get { return ("PasswordPrompt "); }
        }
        public string PreviousPageButtonToolTip
        {
            get { return ("上一页 "); }
        }
        public string PrintButtonToolTip
        {
            get { return ("打印 "); }
        }
        public string ProgressText
        {
            get { return ("正在生成报表...... "); }
        }
        public string RefreshButtonToolTip
        {
            get { return ("刷新 "); }
        }
        public string SearchTextBoxToolTip
        {
            get { return ("查找 "); }
        }
        public string SelectAValue
        {
            get { return ("SelectAValue "); }
        }
        public string SelectAll
        {
            get { return ("全选 "); }
        }
        public string SelectFormat
        {
            get { return ("选择格式 "); }
        }
        public string TextNotFound
        {
            get { return ("未找到 "); }
        }
        public string TodayIs
        {
            get { return ("TodayIs "); }
        }
        public string TrueValueText
        {
            get { return ("TrueValueText "); }
        }
        public string UserNamePrompt
        {
            get { return ("UserNamePrompt "); }
        }
        public string ViewReportButtonText
        {
            get { return ("查看报表 "); }
        }
        public string ZoomControlToolTip
        {
            get { return ("缩放 "); }
        }
        public string ZoomToPageWidth
        {
            get { return ("页宽 "); }
        }
        public string ZoomToWholePage
        {
            get { return ("整页 "); }
        }

        public string PrintLayoutButtonToolTip
        {
            get { return "打印布局"; }
        }

        public string PageSetupButtonToolTip
        {
            get { return "页面设置"; }
        }

        public string NullCheckBoxToolTip
        {
            get { return "Null"; }
        }

        public string TotalPagesToolTip
        {
            get { return "全部页"; }
        }

        public string StopButtonToolTip
        {
            get { return "停止呈现"; }
        }

        public string DocumentMapMenuItemText
        {
            get { return "文档结构图(D)"; }
        }

        public string BackMenuItemText
        {
            get { return "上一步(B)"; }
        }

        public string RefreshMenuItemText
        {
            get { return "刷新(R)"; }
        }

        public string PrintMenuItemText
        {
            get { return "打印(P)"; }
        }

        public string PrintLayoutMenuItemText
        {
            get { return "打印布局(L)"; }
        }

        public string PageSetupMenuItemText
        {
            get { return "页面设置(A)"; }
        }

        public string ExportMenuItemText
        {
            get { return "导出(E)"; }
        }

        public string StopMenuItemText
        {
            get { return "停止(S)"; }
        }
        public string ZoomMenuItemText
        {
            get { return "缩放(Z)"; }
        }

        public string ViewReportButtonToolTip
        {
            get { return "查看报表"; }
        }
        #endregion
    }
}
