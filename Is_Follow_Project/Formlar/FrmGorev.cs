using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Is_Follow_Project.Entitiy;
namespace Is_Follow_Project.Formlar
{
    public partial class FrmGorev : Form
    {
        public FrmGorev()
        {
            InitializeComponent();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DbİsTakipEntities db = new DbİsTakipEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TblGorevler t = new TblGorevler();
            t.Acıklama = txtAcıklama.Text;
            t.Durum = true;
            t.Tarih = DateTime.Parse(txtTarih.Text);
            t.GorevAlan = int.Parse(lookUpEdit1.EditValue.ToString());
            db.TblGorevler.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Görev Tanımı Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            FrmGorevListesi fr = (FrmGorevListesi)Application.OpenForms["FrmGorevListesi"];

        }

        private void FrmGorev_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblPersonel
                                select new
                                {
                                    x.ID,
                                   AdSoyad= x.Ad +" "+ x.Soyad,

                                }).ToList();

            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DataSource = degerler;
            lookUpEdit1.Properties.DisplayMember = "AdSoyad";
        }
    }
}
// Compare this snippet from Is_Follow_Project/Formlar/FrmGorevListesi.cs: