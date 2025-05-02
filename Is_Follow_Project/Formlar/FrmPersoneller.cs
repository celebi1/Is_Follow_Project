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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }
        DbİsTakipEntities db = new DbİsTakipEntities();
        void Personeller()
        {
            var degerler = (from d in db.TblPersonel
                            select new
                            {
                                d.ID,
                                d.Ad,
                                d.Soyad,
                                d.Mail,
                                d.Durum,
                               Departman= d.TblDepartmanlar.Ad,
                            }).ToList();
            gridControl1.DataSource = degerler.Where(x => x.Durum == true).ToList();
        }
        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            Personeller();
            var departmanlar = (from x in db.TblDepartmanlar
                                select new
                                {
                                    x.ID,
                                    x.Ad
                                }).ToList();

            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DataSource = departmanlar;
            lookUpEdit1.Properties.DisplayMember = "Ad";
        }

       

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TblPersonel t = new TblPersonel();
            t.Ad = txtAd.Text;
            t.Soyad = txtSoyad.Text;
            t.Mail = txtmail.Text;
            t.Gorsel = txtGorsel.Text;
            t.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            db.TblPersonel.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Personel Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Personeller();


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var x = int.Parse(txtId.Text);
            var deger = db.TblPersonel.Find(x);
            deger.Durum = false;
            db.SaveChanges();
            XtraMessageBox.Show("Personel Silindi,silinen personeller listesinden tüm silinmiş personel bilgilerine ulaşabilirsiniz...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Personeller();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            txtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            txtmail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            //txtGorsel.Text = gridView1.GetFocusedRowCellValue("Gorsel").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Departman").ToString();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtId.Text);
            var deger = db.TblPersonel.Find(x);
            deger.Ad = txtAd.Text;
            deger.Soyad = txtSoyad.Text;
            deger.Mail = txtmail.Text;
            deger.Gorsel = txtGorsel.Text;
            deger.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            XtraMessageBox.Show("Personel Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question);
            Personeller();
        }
    }
}
