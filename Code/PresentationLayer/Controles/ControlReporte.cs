using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using MinLab.Code.LogicLayer.LogicaTarifario;
using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer.EPlantilla;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.PresentationLayer.Controles.ComponentesReporte;
using OfficeOpenXml;
using System.IO;
using MinLab.Code.LogicLayer;

namespace MinLab.Code.PresentationLayer.Controles
{
    public partial class ControlReporte : UserControl
    {
        

        public ControlReporte()
        {
            InitializeComponent();

            ComboBoxMesEcono.DataSource = new BindingSource(DiccionarioGeneral.GetInstance().Mes, null);
            ComboBoxMesEcono.DisplayMember = "Value";
            ComboBoxMesEcono.ValueMember = "Key";


            ComboBoxMesResult.DataSource = new BindingSource(DiccionarioGeneral.GetInstance().Mes, null);
            ComboBoxMesResult.DisplayMember = "Value";
            ComboBoxMesResult.ValueMember = "Key";

            ComboBoxEcono.SelectedIndex = 0;
            ComboBoxResult.SelectedIndex = 0;
        }
        

        private void BtnExportResult_Click(object sender, EventArgs e)
        {
            BLReporte bl = new BLReporte();
            //REPORTE RESULTADO GENERAL
            DialogFolderBuscar.SelectedPath = null;
            DialogFolderBuscar.ShowDialog();
            bool band = bl.GenerarReporteResultados((BLReporte.FiltroReporteResultados)ComboBoxResult.SelectedIndex, (int)NumericUDResult.Value, (int)ComboBoxMesResult.SelectedValue+1, DialogFolderBuscar.SelectedPath);
            if (band)
                MessageBox.Show("Generacion de Reporte Finalizado");
        }


        private void BtnExportEcono_Click(object sender, EventArgs e)
        {
            BLReporte bl = new BLReporte();
            //REPORTE ECONOMICO GENERAL
            DialogFolderBuscar.SelectedPath = null;
            DialogFolderBuscar.ShowDialog();
            bool band=bl.GenerarReporteEconomico((BLReporte.FiltroReporteEconomico)ComboBoxEcono.SelectedIndex,(int)NumericUDEcono.Value,(int)ComboBoxMesEcono.SelectedValue+1, DialogFolderBuscar.SelectedPath);
            if (band)
                MessageBox.Show("Generacion de Reporte Finalizado");
        }


        private void LinkLabelTarifario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormTarifario form = new FormTarifario();
            form.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
