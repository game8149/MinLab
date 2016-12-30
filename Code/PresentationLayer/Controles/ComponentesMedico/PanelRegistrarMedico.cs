using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MinLab.Code.LogicLayer;
using MinLab.Code.EntityLayer.EFicha;

namespace MinLab.Code.PresentationLayer.Controles.ComponentesMedico
{
    public partial class PanelRegistrarMedico : UserControl
    {
        public PanelRegistrarMedico()
        {
            InitializeComponent();
        }

        public void limpiarCampos()
        {
            campNombre.Text = "";
            CampSegundoApellido.Text = "";
            CampPrimerApellido.Text = "";
            CampColegiatura.Text = "";
            CampEspecialidad.Text = "";
            CheckBoxHabil.Checked = false;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            BLMedico enlace = new BLMedico();
            try
            {
                Medico med = new Medico();
                med.Nombre = campNombre.Text;
                med.SegundoApellido = CampSegundoApellido.Text;
                med.PrimerApellido = CampPrimerApellido.Text;
                med.Colegiatura = CampColegiatura.Text;
                med.Especialidad = CampEspecialidad.Text;
                med.Habil = CheckBoxHabil.Checked;

                enlace.CrearMedico(med);
                MessageBox.Show("Registro Existoso");
                limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia");
            }
        }
    }
}
