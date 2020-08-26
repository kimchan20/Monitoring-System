using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using mon_app1.Class;
namespace mon_app1
{
    public partial class Main : Form
    {

        //for edit project
        int prjid = 0;
        public DataTable weekReport = new DataTable();
        public DataTable materialreport = new DataTable();
        public DataTable laborreport = new DataTable();



        int matid = 0;
        int labid = 0;


        public Main()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        public int months(string month)
        {
            int monthint = 0;
            if (month == "January")
            {
                monthint = 1;
            }
            else if (month == "Febuary")
            {
                monthint = 2;
            }
            else if (month == "March")
            {
                monthint = 3;
            }
            else if (month == "April")
            {
                monthint = 4;
            }
            else if (month == "May")
            {
                monthint = 5;
            }
            else if (month == "June")
            {
                monthint = 6;
            }
            else if (month == "July")
            {
                monthint = 7;
            }
            else if (month == "August")
            {
                monthint = 8;
            }
            else if (month == "September")
            {
                monthint = 9;
            }
            else if (month == "October")
            {
                monthint = 10;
            }
            else if (month == "November")
            {
                monthint = 11;
            }
            else if (month == "December")
            {
                monthint = 12;
            }
            return monthint;
        }
        private void Main_Load(object sender, EventArgs e)
        {
	        comboBox2.SelectedIndex = 0;
            projectcombo.SelectedIndex = 0;
            WeeklyCombo.SelectedItem = 0;
            getPrjlist();

            loadData(projectcombo.SelectedItem.ToString());
            loadmat(projectcombo.SelectedItem.ToString());



            panel1.BackColor = Color.FromArgb(180, 51, 110, 123);
            panel2.BackColor = Color.FromArgb(180, 197, 239, 247);

            panel1.Hide();
            overtotal();
            button1.Visible = false;
            comboBox1.SelectedIndex = 0;

        }

        public void overtotal()
        {
            double n1 = Convert.ToDouble(totalMat());
            double n2 = Convert.ToDouble(totallab());
            double tt = n1 + n2;
            label25.Text = n1.ToString("#,##0.00");
            label27.Text = n2.ToString("#,##0.00");
            label23.Text = tt.ToString("#,##0.00");
        }
        public void getPrjlist()
        {
            Connection connection = new Connection();

            DataTable dt = (DataTable)connection.getData("select *from Project");

            foreach (DataRow dr in dt.Rows)
            {
                comboBox4.Items.Add(dr.ItemArray[1]);
                prjlabor.Items.Add(dr.ItemArray[1]);
                projectcombo.Items.Add(dr.ItemArray[1]);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadData(projectcombo.SelectedItem.ToString());
            loadmat(projectcombo.SelectedItem.ToString());
          
        }
        DataTable material = new DataTable();
        DataTable labor = new DataTable();


        //Date Started : Febuary 2020
        //Date Modify : Aug. 24 2020
        //Generate Weekly 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
	            WeeklyCombo.Visible = true;
                DateTime start = new DateTime(2020, months(comboBox1.SelectedItem.ToString()), 1);

                var month = months(comboBox1.SelectedItem.ToString());//get months
                var year = Int16.Parse(comboBox2.SelectedItem.ToString());//get year
                var ssd = DateTime.DaysInMonth(year, month);
                DateTime from = DateTime.Now;
                DateTime to = DateTime.Now;

                DataTable dtweek = new DataTable();
                dtweek.Columns.Add("Week");       dtweek.Columns.Add("from");        dtweek.Columns.Add("to");
                var datesss = 0;
                for (int i = 1; i <= ssd; i++)
                {
                    DateTime dt1 = new DateTime(year, month, i);
                    if (month == 2 && ssd == 29)
                    {

                        if (dt1.DayOfWeek.ToString() == "Monday")
                        {
                            from = dt1.AddDays(-1);
                            to = dt1.AddDays(5);
                            TimeSpan ts = from.Subtract(to);
                            datesss = (1 + (dt1.Day / 7));
                            dtweek.Rows.Add(datesss, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"));
                            i += 6;

                        }
                        else if (dt1.DayOfWeek.ToString() == "Tuesday")
                        {
                            from = dt1.AddDays(-2);
                            to = dt1.AddDays(4);
                            TimeSpan ts = from.Subtract(to);
                            datesss = (1 + (dt1.Day / 7));
                            dtweek.Rows.Add(datesss, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"));
                            i += 6;
                        }
                        else if (dt1.DayOfWeek.ToString() == "Wednesday")
                        {
                            from = dt1.AddDays(-3);
                            to = dt1.AddDays(3);
                            TimeSpan ts = from.Subtract(to);
                            datesss = (1 + (dt1.Day / 7));
                            dtweek.Rows.Add(datesss, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"));
                            i += 6;
                        }
                        else if (dt1.DayOfWeek.ToString() == "Thursday")
                        {
                            from = dt1.AddDays(-4);
                            to = dt1.AddDays(2);
                            TimeSpan ts = from.Subtract(to);
                            datesss = (1 + (dt1.Day / 7));
                            dtweek.Rows.Add(datesss, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"));
                            i += 6;
                        }
                        else if (dt1.DayOfWeek.ToString() == "Friday")
                        {
                            from = dt1.AddDays(-5);
                            to = dt1.AddDays(1);
                            TimeSpan ts = from.Subtract(to);
                            datesss = (1 + (dt1.Day / 7));
                            dtweek.Rows.Add(datesss, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"));
                            i += 6;
                        }
                        else if (dt1.DayOfWeek.ToString() == "Saturday")
                        {
                            from = dt1.AddDays(-6);
                            to = dt1.AddDays(0);
                            TimeSpan ts = from.Subtract(to);
                            datesss = (1 + (dt1.Day / 7));
                            dtweek.Rows.Add(datesss, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"));
                            i += 6;
                        }
                        else if (dt1.DayOfWeek.ToString() == "Sunday")
                        {
                            from = dt1.AddDays(0);
                            to = dt1.AddDays(6);
                            TimeSpan ts = from.Subtract(to);
                            datesss = (1 + (dt1.Day / 7));
                            dtweek.Rows.Add(datesss, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"));
                            i += 6;
                        }

                    }
                    else
                    {
                        if (datesss < 4)
                        {
                            if (dt1.DayOfWeek.ToString() == "Monday")
                            {
                                from = dt1.AddDays(-1);
                                to = dt1.AddDays(5);
                                TimeSpan ts = from.Subtract(to);
                                datesss = (1 + (dt1.Day / 7));
                                dtweek.Rows.Add(datesss, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"));
                                i += 6;

                            }
                            else if (dt1.DayOfWeek.ToString() == "Tuesday")
                            {
                                from = dt1.AddDays(-2);
                                to = dt1.AddDays(4);
                                TimeSpan ts = from.Subtract(to);
                                datesss = (1 + (dt1.Day / 7));
                                dtweek.Rows.Add(datesss, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"));
                                i += 6;
                            }
                            else if (dt1.DayOfWeek.ToString() == "Wednesday")
                            {
                                from = dt1.AddDays(-3);
                                to = dt1.AddDays(3);
                                TimeSpan ts = from.Subtract(to);
                                datesss = (1 + (dt1.Day / 7));
                                dtweek.Rows.Add(datesss, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"));
                                i += 6;
                            }
                            else if (dt1.DayOfWeek.ToString() == "Thursday")
                            {
                                from = dt1.AddDays(-4);
                                to = dt1.AddDays(2);
                                TimeSpan ts = from.Subtract(to);
                                datesss = (1 + (dt1.Day / 7));
                                dtweek.Rows.Add(datesss, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"));
                                i += 6;
                            }
                            else if (dt1.DayOfWeek.ToString() == "Friday")
                            {
                                from = dt1.AddDays(-5);
                                to = dt1.AddDays(1);
                                TimeSpan ts = from.Subtract(to);
                                datesss = (1 + (dt1.Day / 7));
                                dtweek.Rows.Add(datesss, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"));
                                i += 6;
                            }
                            else if (dt1.DayOfWeek.ToString() == "Saturday")
                            {
                                from = dt1.AddDays(-6);
                                to = dt1.AddDays(0);
                                TimeSpan ts = from.Subtract(to);
                                datesss = (1 + (dt1.Day / 7));
                                dtweek.Rows.Add(datesss, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"));
                                i += 6;
                            }
                            else if (dt1.DayOfWeek.ToString() == "Sunday")
                            {
                                from = dt1.AddDays(0);
                                to = dt1.AddDays(6);
                                TimeSpan ts = from.Subtract(to);
                                datesss = (1 + (dt1.Day / 7));
                                dtweek.Rows.Add(datesss, from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"));
                                i += 6;
                            }
                        }
                    }
                }
                DataTable dt2 = dtweek.AsEnumerable().Distinct(DataRowComparer.Default).CopyToDataTable();
                WeeklyCombo.Items.Clear();
                WeeklyCombo.Items.Add("-- Select Week --");
                foreach (DataRow items in dt2.Rows)
                {
	                WeeklyCombo.Items.Add(items["from"] + " - " + items["to"]);
                }

                WeeklyCombo.SelectedIndex = 0;
                //load labor and materials
                string concatt = "";
              
                weekReport = dt2;//report week 
                DataTable monthlyMAT = material.Clone();
                DataTable monthlLAB = material.Clone();
                Double total = 0.0;
                Double total1 = 0.0;
                foreach (DataRow dr in dt2.Rows)
                {
                    DateTime FromORGdate = Convert.ToDateTime(dr.ItemArray[1].ToString());
                    DateTime toORGdate = Convert.ToDateTime(dr.ItemArray[2].ToString());
                    foreach (DataRow dr1 in material.Rows)
                    {
                        DateTime matDate = Convert.ToDateTime(dr1.ItemArray[1].ToString());
                        if (matDate >= FromORGdate && matDate <= toORGdate)
                        {
                            total += Convert.ToDouble(dr1.ItemArray[4].ToString());
                            monthlyMAT.Rows.Add(dr1.ItemArray[0].ToString(), dr1.ItemArray[1].ToString(), dr1.ItemArray[2].ToString(), dr1.ItemArray[3].ToString(), dr1.ItemArray[4].ToString(), dr1.ItemArray[5].ToString());
                        }
                    }
                }

                foreach (DataRow dr in dt2.Rows)
                {
                    DateTime FromORGdate = Convert.ToDateTime(dr.ItemArray[1].ToString());
                    DateTime toORGdate = Convert.ToDateTime(dr.ItemArray[2].ToString());
                    foreach (DataRow dr1 in labor.Rows)
                    {
                        DateTime matDate1 = Convert.ToDateTime(dr1.ItemArray[1].ToString());
                        DateTime matDate2 = Convert.ToDateTime(dr1.ItemArray[2].ToString());
                        if (matDate1 >= FromORGdate && matDate1 <= toORGdate)
                        {

                            total1 += Convert.ToDouble(dr1.ItemArray[3].ToString());

                            monthlLAB.Rows.Add(dr1.ItemArray[0].ToString(), dr1.ItemArray[1].ToString(), dr1.ItemArray[2].ToString(), dr1.ItemArray[3].ToString(), dr1.ItemArray[4].ToString());
                        }
                    }
                }

                dataGridView1.DataSource = monthlyMAT;
                dataGridView2.DataSource = monthlLAB;



                label19.Text = total.ToString("#,##0.00");
                label31.Text = total1.ToString("#,##0.00");

                label36.Text = (total1 + total).ToString("#,##0.00");

                label34.Text = comboBox1.SelectedItem.ToString() + " " + comboBox2.SelectedItem.ToString();

                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;

            }

            //foreach (DataRow dr in dt2.Rows)
            //{
            //    concatt += "Week : " + dr.ItemArray[0].ToString() + " " + dr.ItemArray[1] + " to " + dr.ItemArray[2] + "\n";
            //}
            //   label2.Text = concatt;

        }



        public void loadData(string project)
        {
            dataGridView2.DataSource = null;
            Connection conn = new Connection();

            if (project != "--Select Project--")
            {
                labor = conn.getData("Select *from Labor where Project = '" + project + "'");
            }
            else
            {
                labor = conn.getData("Select *from Labor");
            }


            dataGridView2.DataSource = labor;
            laborreport = labor;

        }
        public void loadmat(string project)
        {
            dataGridView1.DataSource = null;
            Connection conn = new Connection();
            if (project != "--Select Project--")
            {
                material = conn.getData("Select *from Material where Project = '" + project + "'");
            }
            else
            {
                material = conn.getData("Select *from Material");

            }
            dataGridView1.DataSource = material;
            materialreport = material;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Save Labor")
            {
                Connection conn = new Connection();
                Main main = new Main();
                string[] prj = daterange(dateTimePicker2.Value).Split('-');
                conn.addlabor(prj[0], prj[1], amount.Text, prjlabor.Text);
                loadData(projectcombo.SelectedItem.ToString());
                overtotal();
            }
            else if (button3.Text == "Edit Labor")
            {
                button3.Text = "Save Labor";
                button12.Visible = false;
            }
        }
        public string daterange(DateTime pickdate)
        {
            var date = pickdate.DayOfWeek.ToString();
            DateTime from = DateTime.Now;
            DateTime to = DateTime.Now;

            if (date == "Monday")
            {
                from = pickdate.AddDays(-1);
                to = pickdate.AddDays(5);
            }
            else if (date == "Tuesday")
            {
                from = pickdate.AddDays(-2);
                to = pickdate.AddDays(4);
            }
            else if (date == "Wednesday")
            {
                from = pickdate.AddDays(-3);
                to = pickdate.AddDays(3);
            }
            else if (date == "Thursday")
            {
                from = pickdate.AddDays(-4);
                to = pickdate.AddDays(2);
            }
            else if (date == "Friday")
            {
                from = pickdate.AddDays(-5);
                to = pickdate.AddDays(1);
            }
            else if (date == "Saturday")
            {
                from = pickdate.AddDays(-6);
                to = pickdate.AddDays(0);
            }
            else if (date == "Sunday")
            {
                from = pickdate.AddDays(0);
                to = pickdate.AddDays(6);
            }

            return from.ToString("MM/dd/yyyy") + "-" + to.ToString("MM/dd/yyyy");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string[] date = daterange(dateTimePicker2.Value).Split('-');
            label2.Text = date[0] + " to " + date[1];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if (button4.Text == "Save Material")
            {
                button4.Text = "Please Wait...";
                conn.addmaterial(matDate.Value.ToString(), Mator.Text, Matpo.Text, MAtta.Text, comboBox4.SelectedItem.ToString());
                button4.Enabled = false;
            }
            else if (button4.Text == "Edit Material")
            {
                button4.Text = "Please Wait...";
                var res = conn.EDITmaterial(matid, matDate.Value.ToString("MM/dd/yyyy"), Mator.Text, Matpo.Text, MAtta.Text, comboBox4.SelectedItem.ToString());
                button4.Enabled = false;
               
            }
            Thread.Sleep(1500);
            button4.Enabled = true;
            loadmat(projectcombo.SelectedItem.ToString());
            overtotal();
            hideeditbtn();
        }

        public void hideeditbtn()
        {
            button3.Text = "Save Labor";
            button4.Text = "Save Material";
            button11.Visible = false;
            button12.Visible = false;
            panel1.Hide();

            comboBox4.Text = "";
            matDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            Mator.Text = "";
            Matpo.Text = "";
            MAtta.Text = "";
        }

        private void weekGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
	        try
	        {

	        }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public void MatAndLabor(string date1, string date2)
        {
            DateTime FromORGdate = Convert.ToDateTime(date1);
            DateTime toORGdate = Convert.ToDateTime(date2);
            TimeSpan t1 = new TimeSpan();
            TimeSpan t2 = new TimeSpan();
            DataTable dts1 = material.Clone();
            DataTable dts2 = labor.Clone();


            foreach (DataRow dr in material.Rows)
            {
                DateTime matdt = Convert.ToDateTime(dr.ItemArray[1].ToString());

                if (matdt >= FromORGdate && matdt <= toORGdate)
                {
                    dts1.Rows.Add(dr.ItemArray[0], dr.ItemArray[1], dr.ItemArray[2], dr.ItemArray[3], dr.ItemArray[4], dr.ItemArray[5]);
                }


            }

            foreach (DataRow dr in labor.Rows)
            {
                DateTime labdt1 = Convert.ToDateTime(dr.ItemArray[1].ToString());
                DateTime labdt2 = Convert.ToDateTime(dr.ItemArray[2].ToString());

                if (labdt1 >= FromORGdate && labdt2 <= toORGdate)
                {
                    dts2.Rows.Add(dr.ItemArray[0].ToString(), dr.ItemArray[1].ToString(), dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString());
                }
            }

            dataGridView1.DataSource = dts1;
            dataGridView2.DataSource = null;
            dataGridView1.DataSource = dts1;
            dataGridView2.DataSource = dts2;

            Double total = 0;
            Double total1 = 0;

            foreach (DataRow dr in dts1.Rows)
            {
                total += Convert.ToDouble(dr.ItemArray[4].ToString());
            }

            label1.Text = total.ToString("#,##0.00");


            foreach (DataRow dr in dts2.Rows)
            {
                total1 += Convert.ToDouble(dr.ItemArray[3].ToString());
            }

            label15.Text = total1.ToString("#,##0.00");
            label17.Text = (total + total1).ToString("#,##0.00");

        }
        public string totalMat()
        {
            double total = 0;
            foreach (DataRow dr in material.Rows)
            {
                total += Convert.ToDouble(dr.ItemArray[4].ToString());
            }
            return total.ToString("#,##0.00");
        }
        public string totallab()
        {
            double total = 0;
            foreach (DataRow dr in labor.Rows)
            {
                total += Convert.ToDouble(dr.ItemArray[3].ToString());
            }
            return total.ToString("#,##0.00");
        }
        public string totalmonth()
        {
            string mmth = comboBox1.SelectedItem.ToString();
            string yyr = comboBox2.SelectedItem.ToString();
            return "";

        }

        private void weekGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(weekGrid.Rows[0].ToString());
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadmat(projectcombo.SelectedItem.ToString());
            loadData(projectcombo.SelectedItem.ToString());
            label45.Text = projectcombo.SelectedIndex == 0 ? "All Project" : projectcombo.SelectedItem.ToString();
            overtotal();
            //  totalmonth();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string prj = projectcombo.SelectedIndex == 0 ? projectcombo.SelectedItem.ToString() : "All Project";

            Report.Reports reports = new Report.Reports(laborreport, materialreport, weekReport, prj, comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString());

            reports.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            hideeditbtn();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Show();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                matid = (int)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                matDate.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                Mator.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                Matpo.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                MAtta.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                button4.Text = "Edit Material";
                button12.Visible = true;
                panel1.Show();
            }
            catch { }



        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void prjlabor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            Connection con = new Connection();
            dataGridView3.DataSource = con.getData("Select *from Project");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            if (this.button8.Text == "Add Project")
            {
                var res = conn.addprj(textBox1.Text);
                if (res == 1)
                {
                    //success 
                    MessageBox.Show("Project " + textBox1.Text + " has successfully added", "Add Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (res == 3)
                {
                    MessageBox.Show("Project " + textBox1.Text + " has already in the database", "Add Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    //
                    MessageBox.Show("Something went wrong. Please contact the developers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var res = conn.editprj(textBox1.Text, prjid);
                if (res == 1)
                {
                    MessageBox.Show("Project " + textBox1.Text + " has successfully updated. ", "Edit Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Something went wrong. Please contact the developers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                button9.Visible = false;
                button8.Text = "Add Project";
            }
            updateproject();
            textBox1.Text = "";
        }
        public void updateproject()
        {
            Connection con = new Connection();
            dataGridView3.DataSource = con.getData("Select *from Project");
            getPrjlist();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            prjid = Int32.Parse(dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString());
            textBox1.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            button9.Visible = true;
            button8.Text = "Edit Project";
        }


        //mouse panel 
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(panel3.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(panel1.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hideeditbtn();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            hideeditbtn();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

		private void WeeklyCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				var strwekk = WeeklyCombo.SelectedItem.ToString().Split('-');

				MatAndLabor(strwekk[0], strwekk[1]);
				label28.Text = strwekk[0] + " to " + strwekk[1];
            }
			catch (Exception ee)
			{

			}
        }
    }



}
