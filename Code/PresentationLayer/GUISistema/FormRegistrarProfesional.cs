using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.LogicLayer;
using MinLab.Code.LogicLayer.LogicaControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.GUISistema
{
    public partial class FormRegistrarProfesional : Form
    {
        
        public FormRegistrarProfesional()
        {
            InitializeComponent();
        }
        
        private void BtnCancelar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRegistra_Click(object sender, EventArgs e)
        {
            BLMedico logica = new BLMedico();
            Medico med = new Medico();
            med.Nombre = CampNombre.Text;
            med.PrimerApellido = CampSegundoApellido.Text;
            med.SegundoApellido = CampColegiatura.Text.Trim(' ');
            med.Especialidad = CampEspecialidad.Text;
            med.Colegiatura = CampEspecialidad.Text;
            try
            {
                if (logica.CrearMedico(med))
                {
                    MessageBox.Show("Registro Finalizado","Mensaje");
                    this.Close();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Advertencia");
            }
        }
    }
}
