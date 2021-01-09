using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_3
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup frk = new FrmKulup();
            frk.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDersler frd = new FrmDersler();
            frd.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenci frm = new FrmOgrenci();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSınavNotlar frm = new FrmSınavNotlar();
            frm.Show();
        }
    }
}
