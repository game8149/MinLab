using MinLab.Code.EntityLayer.EOrden;
using MinLab.Code.LogicLayer.LogicaTarifario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using MinLab.Code.EntityLayer;
using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.LogicLayer;

namespace MinLab.Code.PresentationLayer.Controles.ComponentesOrden
{
    public partial class FormModificarOrden : Form
    {
        private DataTable tabla;
        private BindingSource bindingSource;
        private Orden orden;
        private int idUniqueRowCount = 0;
        private Paciente perfil;

        private List<int> IndexExist = new List<int>();
        private List<int> IndexInsert = new List<int>();
        private List<int> IndexDelete = new List<int>();


        Dictionary<int, OrdenDetalle> detalleInsert = new Dictionary<int, OrdenDetalle>();
        Dictionary<int, OrdenDetalle> detalleDeleted = new Dictionary<int, OrdenDetalle>();
        Dictionary<int, OrdenDetalle> detalleUpdate = new Dictionary<int, OrdenDetalle>();

        public Paciente Perfil
        {
            set { this.perfil = value; }
            get { return this.perfil; }
        }
        public Orden Orden
        {
            set { this.orden = value; }
            get { return this.orden; }
        }

        public FormModificarOrden()
        {
            InitializeComponent();
            this.SuspendLayout();

            BLConsultorio enlaceConsultorio = new BLConsultorio();
            BLMedico enlaceMedico = new BLMedico();

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

            tabla = new DataTable("Lista");
            //DeshabilitarFormulario();
            //Si existen tarifas en el Tarifario BD
            if (ControlSistemaInterno.ListaAnalisis.GetInstance().Coleccion.Count > 0)
                InicializarTablaOrdenDetalle();
            DeshabilitarFormulario();
            //CampFecha.Text = DateTime.Now.ToShortDateString();
            this.ResumeLayout(false);
        }

        public void InicializarDatosFormulario()
        {
            try
            {
                this.SuspendLayout();
                CampDireccion.Text = perfil.Direccion;
                CampDni.Text = perfil.Dni;
                CampHistoria.Text = perfil.Historia;
                CampSexo.Text = DiccionarioGeneral.GetInstance().TipoSexo[(int)Perfil.Sexo];
                CampNombre.Text = perfil.Nombre + " " + perfil.PrimerApellido + " " + perfil.SegundoApellido;
                CampBoleta.Text = orden.Boleta;
                ComboBoxConsultorio.SelectedValue = orden.IdConsultorio;
                ComboBoxMedico.SelectedValue = orden.IdMedico;
                if (Perfil.Sexo == Sexo.Mujer)
                {
                    CheckBoxGestante.Visible = true;
                    CheckBoxGestante.Checked = orden.EnGestacion;
                }
                else CheckBoxGestante.Visible = false;
                PickerTime.Text = orden.FechaRegistro.ToShortDateString();
                tabla.Clear();
                foreach (OrdenDetalle ordet in Orden.Detalle.Values)
                {
                    EntityLayer.Analisis p = ControlSistemaInterno.ListaAnalisis.GetInstance().GetAnalisisById(ordet.IdDataPaquete);
                    DataRow row = tabla.NewRow();
                    row[0] = ordet.IdDataPaquete;
                    row[1] = p.Codigo;
                    row[2] = p.Nombre;
                    row[3] = ordet.Cobertura;
                    row[4] = ordet.IdData;

                    if (idUniqueRowCount < ordet.IdData)
                        idUniqueRowCount = ordet.IdData;
                    IndexExist.Add(ordet.IdData);
                    tabla.Rows.Add(row);
                }
                this.ResumeLayout(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia");
                ComboExamen.Focus();
                ComboExamen.SelectedIndex = 0;
            }
        }


        private void InicializarTablaOrdenDetalle()
        {

            this.SuspendLayout();

            BtnEliminar.Visible = false;
            ComboExamen.Enabled = true;
            BtnAgregar.Enabled = true;

            ComboExamen.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComboExamen.DataSource = new BindingSource(ControlSistemaInterno.ListaAnalisis.GetInstance().Coleccion, null);
            ComboExamen.DisplayMember = "Value";
            ComboExamen.ValueMember = "Key";
            

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
            ((DataGridViewComboBoxColumn)this.dataGridView.Columns[3]).DataSource = new BindingSource(DiccionarioGeneral.GetInstance().TipoCobertura, null);
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
            LabelNombreExamen.Visible = false;
            ComboExamen.Visible = false;
            CampHistoria.Text = "";
            CampNombre.Text = "";
            CampDni.Text = "";
            CampBoleta.Text = "";
            CampDireccion.Text = "";
            CampSexo.Text = "";
            CheckBoxGestante.Checked = false;
        }


        public void HabilitarFormulario()
        {
            BtnAgregar.Visible = true;
            ComboExamen.Visible = true;
            LabelNombreExamen.Visible = true;
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
                IndexInsert.Add(idUniqueRowCount);
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
                
                foreach (DataGridViewRow k in dataGridView.SelectedRows)
                {
                    int idUnique = (int)k.Cells[4].Value;
                    foreach (DataRow r in tabla.Rows)
                        if ((int)r[4] == idUnique)
                        {
                            if (existInOrdenActual(idUnique))
                            {
                                OrdenDetalle detalle = new OrdenDetalle();
                                detalle.IdData = (int)r[4];
                                detalle.IdDataPaquete = (int)r[0];
                                detalle.Cobertura = (int)r[3];
                                detalleDeleted.Add(detalle.IdData, detalle);
                                IndexDelete.Add(idUnique);
                                IndexExist.Remove(idUnique);
                            }
                            r.Delete();
                            break;
                        }
                }
        }


        private bool existInOrdenActual(int id)
        {
            foreach (int idtemp in IndexExist)
            {
                if (idtemp == id) return true;
            }
            return false;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabla.Rows.Count == 0)
                    throw new Exception("Listado de Examenes: La lista esta vacia.");

                Orden ordenTemp = new Orden();
                ordenTemp.IdData = orden.IdData;
                ordenTemp.Estado = orden.Estado;
                ordenTemp.Boleta = CampBoleta.Text;
                ordenTemp.FechaRegistro = PickerTime.Value;
                ordenTemp.IdPaciente = Perfil.IdData;
                ordenTemp.UltimaModificacion = DateTime.Now;
                ordenTemp.IdConsultorio=(int)ComboBoxConsultorio.SelectedValue;
                ordenTemp.IdMedico=(int)ComboBoxMedico.SelectedValue;
                if (Perfil.Sexo == Sexo.Mujer)
                {
                    ordenTemp.EnGestacion = CheckBoxGestante.Checked;
                }
                
                
                OrdenDetalle detalle = null;
                
                //CREANDO DETALLE UPDATE
                foreach (int idUnique in IndexExist)
                {
                    foreach (DataRow r in tabla.Rows)
                    {
                        if ((int)r[4] == idUnique)
                        {
                            detalle = new OrdenDetalle();
                            detalle.IdData = (int)r[4];
                            detalle.IdDataPaquete = (int)r[0];
                            detalle.Cobertura = (int)r[3];
                            detalleUpdate.Add(detalle.IdData, detalle);
                        }
                    }
                }

                //CREANDO DETALLE INSERT
                foreach (int idUnique in IndexInsert)
                {
                    foreach (DataRow r in tabla.Rows)
                    {
                        if ((int)r[4] == idUnique)
                        {
                            detalle = new OrdenDetalle();
                            detalle.IdData = (int)r[4];
                            detalle.IdDataPaquete = (int)r[0];
                            detalle.Cobertura = (int)r[3];
                            detalleInsert.Add(detalle.IdData, detalle);
                        }
                    }
                }
                
                LogicaOrden enlaceOrden = new LogicaOrden();
                enlaceOrden.ActualizarOrden(ordenTemp);

                ordenTemp.Detalle = detalleUpdate;
                enlaceOrden.ActualizarOrdenDetalle(ordenTemp);

                ordenTemp.Detalle = detalleInsert;
                enlaceOrden.AgregarOrdenDetalle(ordenTemp);

                ordenTemp.Detalle = detalleDeleted;
                enlaceOrden.EliminarOrdenDetalle(ordenTemp);

                MessageBox.Show("Orden: Se han actualizado correctamente los datos.", "Confirmación");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia");
            }
        }
    }
}
