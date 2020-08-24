using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mon_app1.Report
{
    public partial class Reports : Form
    {
        Main main;
        DataTable labrep = new DataTable();
        DataTable matrep = new DataTable();
        DataTable weekrep = new DataTable();
        string project = string.Empty;
        string month = string.Empty;
        string year = string.Empty;
        public Reports(DataTable labrep, DataTable matrep, DataTable weekrep, string project, string month, string year)
        {
            InitializeComponent();
            this.labrep = labrep;
            this.matrep = matrep;
            this.weekrep = weekrep;
            this.project = project;
            this.month = month;
            this.year = year; 
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            var lab = (DataTable)labrep;
            var mat = (DataTable)matrep;
            var wek = (DataTable)weekrep;

            DateTime wk1 = Convert.ToDateTime(weekrep.Rows[0].ItemArray[1].ToString());
            DateTime wk11 = Convert.ToDateTime(weekrep.Rows[0].ItemArray[2].ToString());

            DateTime wk2 = Convert.ToDateTime(weekrep.Rows[1].ItemArray[1].ToString());
            DateTime wk22 = Convert.ToDateTime(weekrep.Rows[1].ItemArray[2].ToString());

            DateTime wk3 = Convert.ToDateTime(weekrep.Rows[2].ItemArray[1].ToString());
            DateTime wk33 = Convert.ToDateTime(weekrep.Rows[2].ItemArray[2].ToString());

            DateTime wk4 = Convert.ToDateTime(weekrep.Rows[3].ItemArray[1].ToString());
            DateTime wk44 = Convert.ToDateTime(weekrep.Rows[3].ItemArray[2].ToString());


            DataTable m1 = new DataTable(); DataTable m2 = new DataTable();
            DataTable m3 = new DataTable(); DataTable m4 = new DataTable();
            DataTable m5 = new DataTable();
            m1.TableName = "matFinalReport1"; m2.TableName = "matFinalReport2";
            m3.TableName = "matFinalReport3"; m4.TableName = "matFinalReport4";

            m1.Columns.Add("date"); m1.Columns.Add("or"); m1.Columns.Add("po"); m1.Columns.Add("amount");
            m2.Columns.Add("date1"); m2.Columns.Add("or1"); m2.Columns.Add("po1"); m2.Columns.Add("amount1");
            m3.Columns.Add("date2"); m3.Columns.Add("or2"); m3.Columns.Add("po2"); m3.Columns.Add("amount2");
            m4.Columns.Add("date3"); m4.Columns.Add("or3"); m4.Columns.Add("po3"); m4.Columns.Add("amount3");

            DataTable l1 = new DataTable(); DataTable l2 = new DataTable();
            DataTable l3 = new DataTable(); DataTable l4 = new DataTable();
            DataTable l5 = new DataTable();

            l1.Columns.Add("week1"); l1.Columns.Add("week2"); l1.Columns.Add("amount");
            l2.Columns.Add("week1"); l2.Columns.Add("week2"); l2.Columns.Add("amount");
            l3.Columns.Add("week1"); l3.Columns.Add("week2"); l3.Columns.Add("amount");
            l4.Columns.Add("week1"); l4.Columns.Add("week2"); l4.Columns.Add("amount");

            double matotal1 = 0.0, matotal2 = 0.0, matotal3 = 0.0, matotal4 = 0.0, matotal5 = 0.0;
            double labtotal1 = 0.0, labtotal2 = 0.0, labtotal3 = 0.0, labtotal4 = 0.0, labtotal5 = 0.0;

            foreach (DataRow dr in matrep.Rows)
            {
                DateTime matdt = Convert.ToDateTime(dr.ItemArray[1].ToString());

                if (wek.Rows.Count <= 4)
                {
                    if (matdt >= wk1 && matdt <= wk11)
                    {
                        m1.Rows.Add(dr.ItemArray[1], dr.ItemArray[2], dr.ItemArray[3], dr.ItemArray[4]);
                        matotal1 += Convert.ToDouble(dr.ItemArray[4]);
                    }
                    else if (matdt >= wk2 && matdt <= wk22)
                    {
                        m2.Rows.Add(dr.ItemArray[1], dr.ItemArray[2], dr.ItemArray[3], dr.ItemArray[4]);
                        matotal2 += Convert.ToDouble(dr.ItemArray[4]);
                    }
                    else if (matdt >= wk3 && matdt <= wk33)
                    {
                        m3.Rows.Add(dr.ItemArray[1], dr.ItemArray[2], dr.ItemArray[3], dr.ItemArray[4]);
                        matotal3 += Convert.ToDouble(dr.ItemArray[4]);
                    }
                    else if (matdt >= wk4 && matdt <= wk44)
                    {
                        m4.Rows.Add(dr.ItemArray[1], dr.ItemArray[2], dr.ItemArray[3], dr.ItemArray[4]);
                        matotal4 += Convert.ToDouble(dr.ItemArray[4]);
                    }
                }
                else if (wek.Rows.Count == 5)
                {
                    DateTime wk5 = Convert.ToDateTime(weekrep.Rows[4].ItemArray[1].ToString());
                    DateTime wk55 = Convert.ToDateTime(weekrep.Rows[4].ItemArray[2].ToString());
                    if (matdt >= wk4 && matdt <= wk44)
                    {
                        m5.Rows.Add(dr.ItemArray[1], dr.ItemArray[2], dr.ItemArray[3], dr.ItemArray[4]);
                        matotal5 += Convert.ToDouble(dr.ItemArray[4]);
                    }
                }
            }

            foreach (DataRow dr in labrep.Rows)
            {
                DateTime labdt1 = Convert.ToDateTime(dr.ItemArray[1].ToString());
                DateTime labdt2 = Convert.ToDateTime(dr.ItemArray[2].ToString());
                if (wek.Rows.Count <= 4)
                {
                    if (labdt1 >= wk1 && labdt2 <= wk11)
                    {
                        l1.Rows.Add(dr.ItemArray[1].ToString(), dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString());
                        labtotal1 += Convert.ToDouble(dr.ItemArray[3].ToString());
                    }
                    else if (labdt1 >= wk2 && labdt2 <= wk22)
                    {
                        l2.Rows.Add(dr.ItemArray[1], dr.ItemArray[2], dr.ItemArray[3]);
                        labtotal2 += Convert.ToDouble(dr.ItemArray[3].ToString());
                    }
                    else if (labdt1 >= wk3 && labdt2 <= wk33)
                    {
                        l3.Rows.Add(dr.ItemArray[1], dr.ItemArray[2], dr.ItemArray[3]);
                        labtotal3 += Convert.ToDouble(dr.ItemArray[3].ToString());
                    }
                    else if (labdt1 >= wk4 && labdt2 <= wk44)
                    {
                        l4.Rows.Add(dr.ItemArray[1], dr.ItemArray[2], dr.ItemArray[3]);
                        labtotal4 += Convert.ToDouble(dr.ItemArray[3].ToString());
                    }
                }
                else
                {
                    DateTime wk5 = Convert.ToDateTime(weekrep.Rows[4].ItemArray[1].ToString());
                    DateTime wk55 = Convert.ToDateTime(weekrep.Rows[4].ItemArray[2].ToString());
                    if (labdt1 >= wk4 && labdt2 <= wk44)
                    {
                        l1.Rows.Add(dr.ItemArray[1], dr.ItemArray[2], dr.ItemArray[3], dr.ItemArray[4]);
                        matotal5 += Convert.ToDouble(dr.ItemArray[4]);
                    }
                }

            }

            this.reportViewer1.RefreshReport();
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + "\\Report\\Summary.rdlc";


            Double tt1 = (matotal1 + labtotal1);
            Double tt2 = (matotal2 + labtotal2);
            Double tt3 = (matotal3 + labtotal3);
            Double tt4 = (matotal4 + labtotal4);
            Double grandtotal = tt1 + tt2 + tt3 + tt4;
            Double grandmattotal = matotal1 + matotal2 + matotal3 + matotal4;
            Double grandlabortotal = labtotal1 + labtotal2 + labtotal3 + labtotal4;

            ReportParameter[] parameter = new ReportParameter[] {
                new ReportParameter("week1", weekrep.Rows[0].ItemArray[1].ToString() + " to " + weekrep.Rows[0].ItemArray[2].ToString()),
                new ReportParameter("week2", weekrep.Rows[1].ItemArray[1].ToString() + " to " + weekrep.Rows[1].ItemArray[2].ToString()),
                new ReportParameter("week3", weekrep.Rows[2].ItemArray[1].ToString() + " to " + weekrep.Rows[2].ItemArray[2].ToString()),
                new ReportParameter("week4", weekrep.Rows[3].ItemArray[1].ToString() + " to " + weekrep.Rows[3].ItemArray[2].ToString()),
                new ReportParameter("TotalMat", grandtotal.ToString()),
                new ReportParameter("MonthandYear", month + " " + year),
                new ReportParameter("Project", project),

                new ReportParameter("matotalwk1", matotal1.ToString()),
                new ReportParameter("matotalwk2", matotal2.ToString()),
                new ReportParameter("matotalwk3", matotal3.ToString()),
                new ReportParameter("matotalwk4", matotal4.ToString()),

                new ReportParameter("labtotalwk1", labtotal1.ToString()),
                new ReportParameter("labtotalwk2", labtotal2.ToString()),
                new ReportParameter("labtotalwk3", labtotal3.ToString()),
                new ReportParameter("labtotalwk4", labtotal4.ToString()),

                new ReportParameter("total1", tt1.ToString()),
                  new ReportParameter("total2", tt2.ToString()),
                  new ReportParameter("total3", tt3.ToString()),
                  new ReportParameter("total4", tt4.ToString()),

                  new ReportParameter("gtotalmat", tt4.ToString()),
                  new ReportParameter("gtotallab", tt4.ToString()),

        };


            ReportDataSource report1 = new ReportDataSource("m1", m1); //week 1
            ReportDataSource report2 = new ReportDataSource("m2", m2); //week 2
            ReportDataSource report3 = new ReportDataSource("m3", m3); //week 3
            ReportDataSource report4 = new ReportDataSource("m4", m4); //week 4

            ReportDataSource labreport1 = new ReportDataSource("l1", l1); //week 1
            ReportDataSource labreport2 = new ReportDataSource("l2", l2); //week 2
            ReportDataSource labreport3 = new ReportDataSource("l3", l3); //week 3
            ReportDataSource labreport4 = new ReportDataSource("l4", l4); //week 4

            this.reportViewer1.LocalReport.SetParameters(parameter);

            this.reportViewer1.LocalReport.DataSources.Add(report1);
            this.reportViewer1.LocalReport.DataSources.Add(report2);
            this.reportViewer1.LocalReport.DataSources.Add(report3);
            this.reportViewer1.LocalReport.DataSources.Add(report4);

            this.reportViewer1.LocalReport.DataSources.Add(labreport1);
            this.reportViewer1.LocalReport.DataSources.Add(labreport2);
            this.reportViewer1.LocalReport.DataSources.Add(labreport3);
            this.reportViewer1.LocalReport.DataSources.Add(labreport4);
            this.reportViewer1.RefreshReport();
        }
    }
}
