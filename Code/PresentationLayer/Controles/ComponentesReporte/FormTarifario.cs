using MinLab.Code.EntityLayer.ETarifario;
using MinLab.Code.LogicLayer.LogicaTarifario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.Controles.ComponentesReporte
{
    public partial class FormTarifario : Form
    {
        DataTable tablaDataTarifario=null;
        private Dictionary<int, Tarifario> tarifarios = new Dictionary<int, Tarifario>();
        private string valorPrecioSelectedTemp;
        private int IdTarifarioSelected;
        private bool changeState = false;
        private bool isLoading = false;


        public FormTarifario()
        {
            InitializeComponent();
            InicializarTablaTarifario();
            CargarDatos();
            DGVTar.CellBeginEdit += DGVTar_CellBeginEdit;
            DGVTar.CellEndEdit += DGVTar_CellEndEdit;
            DGVTar.DataError += DGVTar_DataError;
            DGVTar.CellValidating += DGVTar_CellValidating;
        }

        private void DGVTar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!Regex.IsMatch(DGVTar.Rows[e.RowIndex].Cells[2].Value.ToString(), @"^[\d]+([.][\d])?$"))
            {
                DGVTar.Rows[e.RowIndex].Cells[2].Value = valorPrecioSelectedTemp;
            }
            
        }

        private void DGVTar_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2 && DGVTar.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
            {
                if (!Regex.IsMatch(e.FormattedValue.ToString(), @"^[\d]+([.][\d])?$"))
                {
                    MessageBox.Show("Ingresa el precio de forma correcta.");
                }
                //else
                //{
                //    NumberFormatInfo nfi = new NumberFormatInfo();
                //    nfi.NumberDecimalSeparator = ".";
                //    double es= double.Parse(e.FormattedValue.ToString(), nfi);
                //    DGVTar.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = es;
                //}
            }
        }

        private void DGVTar_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void DGVTar_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (DGVTar.SelectedCells.Count > 0)
                {
                    valorPrecioSelectedTemp = DGVTar.Rows[e.RowIndex].Cells[2].Value.ToString();
                    changeState = true;
                }
            }
            catch(DataException ex)
            {
                MessageBox.Show("asdad");
            }
        }
        

        private void InicializarTablaTarifario()
        {

            this.SuspendLayout();
            ModeEditar(false);
            tablaDataTarifario = new DataTable();
            tablaDataTarifario.Columns.Add("id",typeof(int));
            tablaDataTarifario.Columns.Add("nombre", typeof(string));
            tablaDataTarifario.Columns.Add("precio", typeof(string));


            this.DGVTar.Columns[0].DataPropertyName = "id";
            this.DGVTar.Columns[0].ReadOnly = true;


            this.DGVTar.Columns[1].DataPropertyName = "nombre";
            this.DGVTar.Columns[1].ReadOnly = true;


            this.DGVTar.Columns[2].DataPropertyName = "precio";
            this.DGVTar.Columns[2].ReadOnly = true;

            BindingSource bindingSource = new BindingSource();
            this.DGVTar.DataSource = bindingSource;
            bindingSource.DataSource = tablaDataTarifario;
            
            DGVTar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVTar.MultiSelect = false;
            this.ResumeLayout();
        }


        private void ModeEditar(bool valor)
        {
            BtnSave.Visible = valor;
            BtnCerrar.Visible = valor;
            BtnModificar.Visible = !valor;
            ComboBoxAno.Enabled = !valor;
            DGVTar.Columns[2].ReadOnly = !valor;
        }


        private void HabilBoton(bool valor)
        {
            BtnCerrar.Visible = valor;
            BtnCerrar.Visible = valor;
            BtnModificar.Visible = valor;
            BtnSave.Visible = valor;
        }

        private void CargarDatos()
        {
            isLoading = true;
            BLTarifario enlace = new BLTarifario();
            tarifarios = enlace.ObtenerTarifarios();
            
            tablaDataTarifario.Rows.Clear();

            if (tarifarios.Count != 0)
            {
                ComboBoxAno.DataSource = new BindingSource(enlace.ObtenerListadoAno(tarifarios), null);
                ComboBoxAno.DisplayMember = "Value";
                ComboBoxAno.ValueMember = "Key";

                DGVTar.Enabled = true;
                ComboBoxAno.Enabled = true;
                
                HabilBoton(true);
                ModeEditar(false);
                this.CargarDatosEnDGVTar();
            }
            else
            {
                BtnVigente.Visible = false;
                DGVTar.Enabled = false;
                ComboBoxAno.Enabled = false;
                HabilBoton(false);
            }
            isLoading = false;
        }
        

        private void nuevoTarifarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void deExistenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCopiarTarifario form = new FormCopiarTarifario();
            form.Tarifarios = this.tarifarios;
            form.CargarDatos();
            form.MostarForm();
            this.CargarDatos();
        }

        private void enBlancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCrearTarifario form = new FormCrearTarifario();
            form.CargarDatos();
            form.MostarForm();
            this.CargarDatos();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            ModeEditar(true);
        }
        

        private void BtnSave_Click(object sender, EventArgs e)
        {
            BLTarifario enlace = new BLTarifario();
            Tarifario tar = new Tarifario();
            tar.Año = tarifarios[IdTarifarioSelected].Año;
            tar.FechaRegistro = tarifarios[IdTarifarioSelected].FechaRegistro;
            tar.IdData = tarifarios[IdTarifarioSelected].IdData;
            tar.Vigente = tarifarios[IdTarifarioSelected].Vigente;
            Dictionary<int, TarifarioDetalle> listado = new Dictionary<int, TarifarioDetalle>();
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            foreach (DataRow row in tablaDataTarifario.Rows)
            {
                TarifarioDetalle det = new TarifarioDetalle();
                det.IdData = (int)row[0];
                det.IdPaquete = tarifarios[IdTarifarioSelected].Listado[det.IdData].IdPaquete;
                det.IdTarifarioCab = tarifarios[IdTarifarioSelected].Listado[det.IdData].IdTarifarioCab;
                double es = double.Parse(row[2].ToString(), nfi);
                det.Precio = es;
                listado.Add(det.IdData,det);
            }
            tar.Listado = listado;
            enlace.ActualizarTarifario(tar);
            changeState = false;
            this.CargarDatos();
            this.CargarDatosEnDGVTar();
        }
        

        private void ComboBoxAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!isLoading)
                CargarDatosEnDGVTar();
        }

        private void CargarDatosEnDGVTar()
        {
            BLTarifario enlace = new BLTarifario();
            IdTarifarioSelected = (int)ComboBoxAno.SelectedValue;
            CampRegistro.Text = tarifarios[IdTarifarioSelected].FechaRegistro.ToShortDateString();
            BtnVigente.Visible = !tarifarios[IdTarifarioSelected].Vigente;
            foreach (TarifarioDetalle det in tarifarios[IdTarifarioSelected].Listado.Values)
            {
                DataRow row = tablaDataTarifario.NewRow();
                row[0] = det.IdData;
                row[1] = enlace.ObtenerAnalisis(det.IdPaquete).Nombre.ToUpper();
                row[2] = det.Precio.ToString();
                tablaDataTarifario.Rows.Add(row);
            }
        }

        private void BtnVigente_Click(object sender, EventArgs e)
        {
            BLTarifario enlace = new BLTarifario();
            enlace.ActualizarVigenteTarifario(tarifarios[IdTarifarioSelected]);
            this.BtnVigente.Visible = false;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            if (changeState)
            {
                DialogResult resul = MessageBox.Show("Desea Guardar los cambios realizados?", "Advertencia", MessageBoxButtons.YesNo);
                if (resul == DialogResult.Yes)
                {
                    BtnSave.PerformClick();
                }
                else
                {
                    CargarDatosEnDGVTar();
                }
                changeState = false;
            }
            ModeEditar(false);
        }
    }
}
