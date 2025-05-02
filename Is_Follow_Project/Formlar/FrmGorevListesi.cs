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
    public partial class FrmGorevListesi : Form
    {
        public FrmGorevListesi()
        {
            InitializeComponent();
        }
        DbİsTakipEntities db = new DbİsTakipEntities();
        private void FrmGorevListesi_Load(object sender, EventArgs e)
        {
            lblAktifGorev.Text = db.TblGorevler.Count(x => x.Durum == true).ToString();
            lblPasifGorev.Text = db.TblGorevler.Count(x => x.Durum == false).ToString();
            lblToplamDepartman.Text = db.TblDepartmanlar.Count().ToString();

            gridControl1.DataSource = (from x in db.TblGorevler
                                       select new
                                       {x.Acıklama,
                                       }
                                       ).ToList();

            chartControl1.Series["Durum"].Points.AddPoint("Aktif Görevler",int.Parse(lblAktifGorev.Text));
            chartControl1.Series["Durum"].Points.AddPoint("Pasif Görevler", int.Parse(lblPasifGorev.Text));

            //chartControl1.Series["Series 1"].Points.AddPoint(1, db.TblGorevler.Count(x => x.Durum == "0"));


        }

       
    }
}
