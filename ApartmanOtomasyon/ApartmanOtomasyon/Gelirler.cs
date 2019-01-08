using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApartmanOtomasyon
{
    public partial class Gelirler : Form
    {
        
        public Gelirler()
        {
            InitializeComponent();
        }
        SQLHelper sqlhlp = new SQLHelper();

        private void Gelirler_Load(object sender, EventArgs e)
        {
            GelirleriGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int daire=(int)numericUpDown1.Value;
            DateTime tarih= dateTimePicker1.Value;
            decimal  tutar =Convert.ToDecimal( textBox1.Text);
            SqlParameter p1 = new SqlParameter("DaireNo", daire);
            SqlParameter p2 = new SqlParameter("GelirTutarı", tutar);
            SqlParameter p3 = new SqlParameter("GelirTarihi", tarih);
            sqlhlp.ExecuteProc("GelirEkle", p1, p2, p3);
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            GelirleriGetir();
        }
        void GelirleriGetir()
        {
            DataTable dt = sqlhlp.GetTable("Select * from Gelirler");

            foreach (DataRow row in dt.Rows)
            {

                listBox1.Items.Add(row[1].ToString());
                listBox2.Items.Add(row[2].ToString());
                listBox3.Items.Add(row[3]);

            }
        }
    }
}
