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
    public partial class Giderler : Form
    {
        public Giderler()
        {
            InitializeComponent();
        }
        SQLHelper sqlhlp = new SQLHelper();
        private void button1_Click(object sender, EventArgs e)
        {
            decimal tutar=Convert.ToDecimal(textBox1.Text);
            DateTime tarih = dateTimePicker1.Value;
            string giderler = "";
            foreach (Control item in groupBox1.Controls)
            {
                if(item is CheckBox && ((CheckBox )item ).Checked)
                { 
                    giderler+=","+item.Text;
                }
            }
           giderler= giderler.Remove(0, 1);
            SqlParameter p1 = new SqlParameter("Giderler", giderler);
            SqlParameter p2 = new SqlParameter("GiderTutarı",tutar);
            SqlParameter p3 = new SqlParameter("GiderTarihi", tarih);
            sqlhlp.ExecuteProc("GiderEkle",p1,p2,p3);
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            GiderleriGetir();
                      
        }
        private void Giderler_Load(object sender, EventArgs e)
        {
            GiderleriGetir();

        }
        void GiderleriGetir()
        {
            DataTable dt = sqlhlp.GetTable("Select * from Giderler");

            foreach (DataRow row in dt.Rows)
            {

                listBox1.Items.Add(row[1].ToString());
                listBox2.Items.Add(row[2].ToString());
                listBox3.Items.Add(row[3]);

            }
        }
    }
}
