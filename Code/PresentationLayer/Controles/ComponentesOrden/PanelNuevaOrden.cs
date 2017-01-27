using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MinLab.Code.EntityLayer.EOrden;
using MinLab.Code.LogicLayer.LogicaTarifario;
using MinLab.Code.PresentationLayer.Controles.GUIBuscarPaciente;

using MinLab.Code.EntityLayer;
using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.LogicLayer;
using MinLab.Code.LogicLayer.LogicaPaciente;

namespace MinLab.Code.PresentationLayer.Controles.ComponentesOrden
{
    public partial class PanelNuevaOrden : UserControl
    {
        private DataTable tabla;
        private BindingSource bindingSource;
        private Orden orden;
        private int idUniqueRowCount = 0;

        public Paciente Perfil { get; set; }


        public PanelNuevaOrden()
        {
            InitializeComponent();
            ToolTip tip = new ToolTip();

            this.SuspendLayout();
            tip.ShowAlways = true;
            tip.SetToolTip(BtnBuscarPaciente, "Buscar el perfil de un paciente.");
            tip.SetToolTip(BtnAgregar, "Agregar un examen al listado.");
            tip.SetToolTip(BtnEliminar, "Eliminar un examen del listado.");

            tabla = new DataTable("Lista");
            //DeshabilitarFormulario();
            //Si existen tarifas en el Tarifario BD
            if (ControlSistemaInterno.ListaAnalisis.GetInstance().Coleccion.Count > 0)
                InicializarTablaOrdenDetalle();
            DeshabilitarFormulario();
            //CampFecha.Text = DateTime.Now.ToShortDateString();
            this.ResumeLayout(false);

        }



        private void InicializarTablaOrdenDetalle()
        {
            BLMedico enlaceMedico = new BLMedico();
            BLConsultorio enlaceConsultorio = new BLConsultorio();
            this.SuspendLayout();

            BtnEliminar.Visible = false;
            ComboExamen.Enabled = true;
            BtnAgregar.Enabled = true;

            ComboExamen.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComboExamen.DataSource = new BindingSource(ControlSistemaInterno.ListaAnalisis.GetInstance().Coleccion, null);
            ComboExamen.DisplayMember = "Value";
            ComboExamen.ValueMember = "Key";

            ComboBoxConsultorio.DataSource = new BindingSource(enlaceConsultorio.ObtenerLista(), null);
            ComboBoxConsultorio.DisplayMember = "Value";
            ComboBoxConsultorio.ValueMember = "Key";

            ComboBoxMedico.DataSource = new BindingSource(enlaceMedico.ObtenerListaHabil(), null);
            ComboBoxMedico.DisplayMember = "Value";
            ComboBoxMedico.ValueMember = "Key";

            //CampFecha.Text = DateTime.Now.ToShortDateString();

            tabla.TableNewRow += Tabla_TableNewRow;
            tabla.RowDeleted += Tabla_RowDeleted;
            // Configuracion de Tablas


            tabla.Columns.Add("id", typeof(int));
            tabla.Columns.Add("codigo", typeof(string));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("cobertura", typeof(object));
            tabla.Columns.Add("idUnique", typeof(int));

            this.dataGridView.Columns[0].DataPropertyName = "id";
            this.dataGridView.Columns[0].Visible = false;
            this.dataGridView.Columns[0].ReadOnly = true;

            this.dataGridView.Columns[1].DataPropertyName = "codigo";
            this.dataGridView.Columns[1].ReadOnly = true;
            this.dataGridView.Columns[1].Resizable = DataGridViewTriState.False;

            this.dataGridView.Columns[2].DataPropertyName = "nombre";
            this.dataGridView.Columns[2].ReadOnly = true;
            this.dataGridView.Columns[2].Resizable = DataGridViewTriState.False;
            this.dataGridView.Columns[2].HeaderText = "Nombre";

            this.dataGridView.Columns[3].DataPropertyName = "cobertura";   // The DataTable column name.
            this.dataGridView.Columns[3].HeaderText = "Cobertura";
            ((DataGridViewComboBoxColumn)this.dataGridView.Columns[3]).DataSource = new BindingSource(DataEstaticaGeneral.CoberturaTipos, null);
            ((DataGridViewComboBoxColumn)this.dataGridView.Columns[3]).DisplayMember = "Value";
            ((DataGridViewComboBoxColumn)this.dataGridView.Columns[3]).ValueMember = "Key";
            this.dataGridView.Columns[3].Resizable = DataGridViewTriState.False;


            this.dataGridView.Columns[4].DataPropertyName = "idUnique";   // The DataTable column name.
            this.dataGridView.Columns[4].Visible = false;
            this.dataGridView.Columns[4].ReadOnly = true;


            bindingSource = new BindingSource();
            this.dataGridView.DataSource = bindingSource;
            bindingSource.DataSource = tabla;
            this.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.RowsAdded += DataGridView_RowsAdded;
            this.dataGridView.RowsRemoved += DataGridView_RowsRemoved;
            this.ResumeLayout(false);
        }


        private void DataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            BtnEliminar.Visible = (dataGridView.Rows.Count > 0);
        }

        private void DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            BtnEliminar.Visible = (dataGridView.Rows.Count > 0);
        }

        private void Tabla_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            if (tabla.Rows.Count == 0)
                BtnEliminar.Visible = false;
            else
                BtnEliminar.Visible = true;
        }

        private void Tabla_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            if (tabla.Rows.Count == 0)
                BtnEliminar.Visible = false;
            else
                BtnEliminar.Visible = true;
        }

        public void DeshabilitarFormulario()
        {
            tabla.Clear();
            Perfil = null;
            BtnEliminar.Visible = false;
            BtnAgregar.Visible = false;
            BtnRegistrar.Visible = false;
            LabelNombreExamen.Visible = false;
            ComboExamen.Visible = false;
            CampHistoria.Text = "";
            CampNombre.Text = "";
            CampDni.Text = "";
            CampBoleta.Text = "";
            CampUbicacion.Text = "";
            CampSexo.Text = "";
        }


        public void HabilitarFormulario()
        {
            BtnAgregar.Visible = true;
            ComboExamen.Visible = true;
            BtnRegistrar.Visible = true;
            LabelNombreExamen.Visible = true;
            CheckBoxGestante.Visible = false;
            CheckBoxGestante.Checked = false;
        }


        private void BtnBuscarPaciente_Click(object sender, EventArgs e)
        {
            FormBuscarPaciente formBuscarPaciente = new FormBuscarPaciente();
            formBuscarPaciente.ShowDialog();
            if (formBuscarPaciente.Perfil != null)
            {
                this.Perfil = formBuscarPaciente.Perfil;
                CampDni.Text = Perfil.Dni;
                CampHistoria.Text = Perfil.Historia;
                CampNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Perfil.Nombre + " " + Perfil.PrimerApellido + " " + Perfil.SegundoApellido);
                CampSexo.Text = DataEstaticaGeneral.SexoTipos[(int)Perfil.Sexo];
                CampUbicacion.Text = LogicaPaciente.FormatearUbicacion(Perfil);

                HabilitarFormulario();
                if (Perfil.Sexo == Sexo.Mujer)
                {
                    CheckBoxGestante.Visible = true;
                }

            }
            formBuscarPaciente.Dispose();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ComboExamen.SelectedItem == null)
                    throw new Exception("Listado de Examen: No se ha seleccionado ningun examen.");
                int id = ((KeyValuePair<int, string>)ComboExamen.SelectedItem).Key;
                EntityLayer.Analisis p = ControlSistemaInterno.ListaAnalisis.GetInstance().GetAnalisisById(id);
                this.SuspendLayout();
                DataRow row = tabla.NewRow();
                row[0] = p.IdData;
                row[1] = p.Codigo;
                row[2] = p.Nombre;
                row[3] = 0;
                row[4] = idUniqueRowCount;
                idUniqueRowCount++;
                tabla.Rows.Add(row);
                ComboExamen.SelectedIndex = 0;
                this.ResumeLayout(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia");
                ComboExamen.Focus();
                ComboExamen.SelectedIndex = 0;
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabla.Rows.Count == 0)
                    throw new Exception("Listado de Examenes: La lista esta vacia.");
                if (Perfil == null)
                    throw new Exception("Perfil: Se necesita un perfil de paciente.");

                orden = new Orden();
                orden.Boleta = CampBoleta.Text;
                orden.FechaRegistro = PickerTime.Value;
                orden.IdPaciente = Perfil.IdData;
                orden.UltimaModificacion = PickerTime.Value;
                orden.IdConsultorio = (int)ComboBoxConsultorio.SelectedValue;
                orden.IdMedico=(int)ComboBoxMedico.SelectedValue;
                if (Perfil.Sexo == Sexo.Mujer)
                {
                    orden.EstadoPaciente = (CheckBoxGestante.Checked ? PacienteEstado.Gestante:PacienteEstado.Normal);
                }
                else orden.EstadoPaciente = PacienteEstado.Normal;

                Dictionary<int, OrdenDetalle> detalles = new Dictionary<int, OrdenDetalle>();
                OrdenDetalle detalle = null;
                int i = 0;

                foreach (DataRow r in tabla.Rows)
                {
                    detalle = new OrdenDetalle();
                    detalle.IdDataPaquete = (int)r[0];
                    detalle.Cobertura = (int)r[3];
                    detalles.Add(i, detalle);
                    i++;
                }

                orden.Detalle = detalles;

                LogicaOrden enlaceOrden = new LogicaOrden();
                enlaceOrden.AgregarOrden(orden);
                MessageBox.Show("Orden: Se han registrado correctamente los datos.", "Confirmación");
                DeshabilitarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
                foreach (DataGridViewRow k in dataGridView.SelectedRows)
                {
                    int idUnique = (int)k.Cells[4].Value;
                    foreach (DataRow r in tabla.Rows)
                        if ((int)r[4] == idUnique)
                        {
                            r.Delete();
                            break;
                        }
                }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.DeshabilitarFormulario();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
