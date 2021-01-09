using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_3
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-FEPGLU4;Initial Catalog=EOkulPorje;Integrated Security=True");
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
             baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Kulupler ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulup.DisplayMember = "KULUPAD";
            cmbkulup.ValueMember = "KULUPID";
            cmbkulup.DataSource = dt;
            baglanti.Close();

        }
        string c = "";
        private void btnekle_Click(object sender, EventArgs e)
        {
          

            ds.OgrenciEkle(txtad.Text, txtsoyad.Text, byte.Parse(cmbkulup.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtid.Text));
            MessageBox.Show("Öğrenci Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbkulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(txtad.Text,txtsoyad.Text,byte.Parse(cmbkulup.SelectedValue.ToString()),c,int.Parse(txtid.Text));
            MessageBox.Show("Öğrenci Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rbtkız_CheckedChanged(object sender, EventArgs e)
        {
            if (rbterkek.Checked == true)
            {
                c = "Erkek";
            }
            if (rbtkız.Checked == true)
            {
                c = "Kız";
            }
        }

        private void rbterkek_CheckedChanged(object sender, EventArgs e)
        {
            if (rbterkek.Checked == true)
            {
                c = "Erkek";
            }
            if (rbtkız.Checked == true)
            {
                c = "Kız";
            }
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=   ds.OgrenciGetir(txtara.Text);
        }
    }
}
