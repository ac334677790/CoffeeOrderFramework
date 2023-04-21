using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpenOrderFramework
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Data_Binding();
            }
        }

        private void Data_Binding()
        {
            this.ReportViewer1.Reset();
            this.ReportViewer1.LocalReport.Dispose();
            this.ReportViewer1.LocalReport.DataSources.Clear();

            Microsoft.Reporting.WebForms.ReportDataSource reportDataSource
                = new Microsoft.Reporting.WebForms.ReportDataSource();
            reportDataSource.Name = "DataSet1";

            OpenOrderFramework.Models.OrderItems orderItem = new OpenOrderFramework.Models.OrderItems();
            reportDataSource.Value = orderItem.GetOrderItems();
            


            this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.ReportViewer1.LocalReport.Refresh();
           
        }
    }
}