using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace mon_app1.Class
{
    class Connection
    {

        private static string sqlstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Database1.mdb";
        OleDbConnection connection = new OleDbConnection(sqlstr);
        private string str = string.Empty;
        public void db()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ee)
            {
                MessageBox.Show("something went wrong to database!");
            }

        }
        public int addprj(string projectname)
        {
            try
            {
                db();
                str = "SELECT COUNT(1) FROM Project WHERE prjname = '" + projectname + "'";
                OleDbCommand comms = new OleDbCommand(str, connection);
                var countExist = comms.ExecuteScalar();

                if (countExist.ToString() == "0")
                {
                    var ss = DateTime.Now.ToString("MM/dd/yyyy");
                    str = "Insert into Project (prjname,prjDateCreated) values('" + projectname + "','" + ss + "')";
                    OleDbCommand comm = new OleDbCommand(str, connection);
                    comm.ExecuteNonQuery();
                    return 1;
                }
                else
                {
                    return 3;
                }



            }
            catch
            {
                return 2;
            }

        }
        public int editprj(string prjname, int prjid)
        {
            try
            {
                db();

                str = "UPDATE Project SET prjname = '" + prjname + "', prjDateModified = '" + DateTime.Now.ToString("MM/dd/yyyy") + "' where ID =" + prjid;
                OleDbCommand comm = new OleDbCommand(str, connection);
                comm.ExecuteNonQuery();

                return 1;
            }
            catch
            {
                return 2;
            }

        }

        public int addlabor(string date1, string date2, string amount, string project)
        {
            db();

            str = "Insert into Labor (Week1,Week2,TotalAmount,Project) values('" + Convert.ToDateTime(date1).ToString("MM/dd/yyyy") + "','" + Convert.ToDateTime(date2).ToString("MM/dd/yyyy") + "','" + amount + "','" + project + "')";
            OleDbCommand comm = new OleDbCommand(str, connection);
            comm.ExecuteNonQuery();

            return 1;
        }
        public int addmaterial(string date1, string orNo, string poNo, string amount, string project)
        {
            db();

            str = "Insert into Material (orDate,orNo,poNo,TotalAmount,Project) values('" + Convert.ToDateTime(date1).ToString("MM/dd/yyyy") + "','" + orNo + "','" + poNo + "','" + amount + "','" + project + "')";
            OleDbCommand comm = new OleDbCommand(str, connection);
            comm.ExecuteNonQuery();

            return 1;
        }


        public int EDITmaterial(int id,string date1, string orNo, string poNo, string amount, string project)
        {
            try
            {
                db();
                str = "UPDATE Material SET orDate = '" + date1 + "', orNo = '" + orNo + "' ,poNo ='" + poNo + "', TotalAmount ='" + amount + "' ,Project ='" + project + "' where ID =" + id;
                OleDbCommand comm = new OleDbCommand(str, connection);
                comm.ExecuteNonQuery();

                return 1;
            }
            catch {

                return 2;
            }
           
        }

        public DataTable getData(string sql)
        {
            db();
            DataTable dt = new DataTable();

            OleDbCommand command = new OleDbCommand(sql, connection);
            command.ExecuteNonQuery();
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);

            dt.Reset();
            adapter.Fill(dt);

            return dt;
        }

    }
}
