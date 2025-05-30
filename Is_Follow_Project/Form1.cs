﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Is_Follow_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmDepartmanlar frm = new Formlar.FrmDepartmanlar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmPersoneller frm2 = new Formlar.FrmPersoneller();
            frm2.MdiParent = this;
            frm2.Show();
        }

        private void btnPersonelIstatıstıklerı_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmPersonelIstatistik frm3 = new Formlar.FrmPersonelIstatistik();
            frm3.MdiParent = this;
            frm3.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Formlar.FrmGorevListesi frm4;
        private void btnGorevListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            {
                frm4 = new Formlar.FrmGorevListesi();
                frm4.MdiParent = this;
                frm4.Show();
            }
            else
            {
                frm4.BringToFront();
            }
          

        }

        private void btnYeniGorevTanımı_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmGorev frm5 = new Formlar.FrmGorev();
            frm5.Show();

        }

        private void btnGorevDetayları_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmGorevDetay frm6 = new Formlar.FrmGorevDetay();
            frm6.Show();
        }
        Formlar.FrmAnaForm frm7;
        private void btnAnaForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm7 == null || frm7.IsDisposed)
            {
                frm7 = new Formlar.FrmAnaForm();
                frm7.MdiParent = this;
                frm7.Show();
            }
           
        }
    }
}
