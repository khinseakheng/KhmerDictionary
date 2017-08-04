using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace ILearn_Dictionary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private OleDbConnection cn;
        private OleDbDataReader reader;
        private OleDbCommand com;
        private DataSet rs;
        private DataSet rs1;
        private OleDbDataAdapter ad;
        private void myconnect()
        {
           

                //connect to database
               
                ad = new OleDbDataAdapter("SELECT * FROM tbkh ORDER BY Field1", cn);
                ad.Fill(rs, "tbkh");
                com = new OleDbCommand("SELECT khterm FROM tbkh ORDER BY Field1", cn);
                reader = com.ExecuteReader();

                //clear list
                lstview.Items.Clear();
                //clear txtresult
                txtresult.Text = "";
                while (reader.Read())
                {
                    lstview.Items.Add(reader[0].ToString());
                }
        }
        private void myconnecten()
        {
            //connect to database
            ad = new OleDbDataAdapter("SELECT * FROM tbIterms ORDER BY ID", cn);
            ad.Fill(rs1, "Tblterms");
            com = new OleDbCommand("SELECT Enterm FROM tbIterms ORDER BY ID", cn);
           reader = com.ExecuteReader();
            //clear list
            lstviewe.Items.Clear();
            //clear txtresult
            txtresult.Text = "";
            while (reader.Read())
            {
                lstviewe.Items.Add(reader[0].ToString());
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtlabel.Text = "វាយពាក្យកន្លឺះ";
            txtlang.Text = "ខ្មែរ-ខ្មែរ";
            lstview.Visible = true;
            lstviewe.Visible = false;
            txtsearchen.Visible = false;
            rs1 = new DataSet();
            rs = new DataSet();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\mydata.accdb; Jet OLEDB:Database Password=seakheng194");
            cn.Open();
            myconnect();
            myconnecten();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int index = lstview.FindString(this.txtsearchkh.Text);
            if (0 <= index)
            {
                lstview.SelectedIndex = index;
            }
        }

        private void lstview_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelvisible();
            DataRow dr;
            dr = rs.Tables[0].Rows[lstview.SelectedIndex];
            txtresult.Clear();   //clear result
            txtresult.Text = dr[3].ToString().Trim() + "  ៖ " + dr[4].ToString().Trim() + "   " + dr[6].ToString().Trim() + "   " + dr[7].ToString().Trim();
        }

        private void lstviewen_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelvisible();
            DataRow dr;
            dr= rs1.Tables[0].Rows[lstviewe.SelectedIndex];
            txtresult.Clear();   //clear result
            txtresult.Text = dr[3].ToString().Trim() + "  :  " +"("+ dr[4].ToString().Trim() +")"+ "   " + dr[6].ToString().Trim() + "   " + dr[7].ToString().Trim();
        }

        private void khmerKhmerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelvisible();
            txtlang.Text = "ខ្មែរ-ខ្មែរ";
            txtsearchkh.Visible = true;
            txtsearchen.Visible = false;
            lstviewe.Visible =false;
            lstview.Visible = true;
            txtlabel.Text = "វាយពាក្យកន្លឺះ";
            txtsearchkh.Focus();        }

        private void englishKhmerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelvisible();
            txtlang.Text = "អង់គ្លេស-ខ្មែរ";
            txtsearchen.Visible = true;
            txtsearchkh.Visible = false;
            lstviewe.Visible = true;
            lstview.Visible = false;
            txtlabel.Text = "Type A Keyword :";
            txtsearchen.Focus();
        }

        private void txtsearchen_TextChanged(object sender, EventArgs e)

        {
            labelvisible();
            int index = lstviewe.FindString(this.txtsearchen.Text);
            if (0 <= index)
            {
                lstviewe.SelectedIndex = index;
            }
        }

        private void lstviewen_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            labelvisible();
            DataRow dr;
            dr = rs1.Tables[0].Rows[lstviewe.SelectedIndex];
            txtresult.Clear();   //clear result
            txtresult.Text = dr[3].ToString().Trim() + "  :  " + dr[4].ToString().Trim() + "   " + dr[6].ToString().Trim() + "   " + dr[7].ToString().Trim();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void labelvisible()
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
        }

        private void developerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeveloper f2 = new frmDeveloper();
            f2.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmfeedback f3 = new frmfeedback();
            f3.ShowDialog();
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmapp f4 = new frmapp();
            f4.ShowDialog();
        }
    }
}
