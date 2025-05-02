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
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using Is_Follow_Project.Entitiy;
namespace Is_Follow_Project.Formlar
{
    public partial class FrmPersonelIstatistik : Form
    {
        public FrmPersonelIstatistik()
        {
            InitializeComponent();
        }
        DbİsTakipEntities db = new DbİsTakipEntities();
        private void FrmPersonelIstatistik_Load(object sender, EventArgs e)
        {
            lblToplamDepartman.Text = db.TblDepartmanlar.Count().ToString();
            lblToplamPersonel.Text = db.TblPersonel.Count().ToString();
            lblToplamFirma.Text = db.TblFirmalar.Count().ToString();
            lblAktifİsSayısı.Text = db.TblGorevler.Count(x => x.Durum == true).ToString();
            lblPasifİs.Text = db.TblGorevler.Count(x => x.Durum == false).ToString();
            lblSonGorev.Text = db.TblGorevler.OrderByDescending(x=>x.ID). Select(x => x.Acıklama).FirstOrDefault();
            lblSehirSayısı.Text = db.TblFirmalar.Select(x => x.İl).Distinct().Count().ToString();
            lblSektor.Text = (from x in db.TblFirmalar select x.Sektor).Distinct().Count().ToString();
            DateTime bugun = DateTime.Today;
            lblBugunAcılanGorevler.Text = db.TblGorevler.Count(x => x.Tarih == bugun).ToString();
            var d1 =db.TblGorevler.GroupBy(x=> x.GorevAlan).OrderByDescending(z=>z.Count()).Select(y => y.Key).FirstOrDefault();
            lblAyınPersoneli.Text = db.TblPersonel.Where(x => x.ID == d1).Select(y => y.Ad + " " + y.Soyad).FirstOrDefault(); 
            lblAyınDepartmanı.Text =db.TblDepartmanlar.Where(x => x.ID == db.TblPersonel.Where(t=>t.ID==d1).Select(z=>z.Departman).FirstOrDefault()).Select(y => y.Ad).FirstOrDefault();
            SonGorevTarıhı.Text = db.TblGorevler.OrderByDescending(x => x.ID).Select(x => x.Tarih).FirstOrDefault().ToString();
        }
    }
}
