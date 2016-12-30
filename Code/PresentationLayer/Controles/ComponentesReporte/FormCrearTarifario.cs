using MinLab.Code.LogicLayer.LogicaTarifario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.Controles.ComponentesReporte
{
    public partial class FormCrearTarifario : Form
    {

        public bool OK { get; set; }

        public FormCrearTarifario()
        {
            InitializeComponent();
            CargarDatos();
        }


        public void CargarDatos()
        {
            BLTarifario enlace = new BLTarifario();
            OK = enlace.ObtenerListadoAnalisis().Count > 0;
            
            BtnCrear.Enabled = OK;
            NumericUDAño.Enabled = OK;
            OK = OK;
            BtnCrear.Visible = OK;
            
        }

        public void MostarForm()
        {
            if (OK)
                this.ShowDialog();
            else
            {
                MessageBox.Show("No existen Analisis en registro.", "Mensaje");
                this.Dispose();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BLTarifario enlace = new BLTarifario();
                enlace.CrearTarifario((int)NumericUDAño.Value, CheckBoxVigente.Checked);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia");
            }
        }
    }
}
