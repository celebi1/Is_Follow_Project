using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Is_Follow_Project.Entitiy;

namespace Is_Follow_Project.Formlar
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        DbİsTakipEntities db = new DbİsTakipEntities();

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblGorevler
                                       select new
                                       {
                                           x.Acıklama,
                                           Personel = x.TblPersonel.Ad + " " + x.TblPersonel.Soyad,
                                           x.Durum
                                       }).Where(y => y.Durum == true).ToList();
            gridView1.Columns["Durum"].Visible = false;
            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            //Bugun yaoulan görevler
            gridControl2.DataSource = (from x in db.TblGorevDetaylar
                                       where x.Tarih == DateTime.Today
                                       select new
                                       {
                                           Gorev = x.TblGorevler.Acıklama,
                                           x.Aciklama,
                                           x.Tarih,
                                       }).Where(x => x.Tarih == bugun).ToList();
            //Aktif Çagrı Listesi   
            gridControl3.DataSource = (from x in db.TblCagrilar
                                       select new
                                       {
                                           x.TblFirmalar.Ad,
                                           x.Konu,
                                           x.Tarih,
                                           x.Durum
                                       }).Where(y => y.Durum == true).ToList();
            gridView3.Columns["Durum"].Visible = false;

        }
    }
}