
using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.PresentationLayer.ComponentesExamen.ComponentesPrueba;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.ComponentesExamenEditor
{
    public  class ExamenEditorItem:Panel
    {
        private TipoCampo tipoCampo;
        private TipoDato tipoDato;

        private int id=0;
        private int ancho_campo;
        private int ancho_etiqueta;
        private int ancho_unidad;
        private int alto_campoTexto=50;
        private int alto_etiqueta=25;
        private int alto_unidad=25;
        private string regex;
        private Regex validador;

        private int margeDer = 15;

        
        private bool tieneUnidad=false;
        private Dictionary<int, string> diccionario;

        private Label nombre;
        private Label unidad;

        private ComboBox comboList;
        private TextBox texBoxInput;
        private TextBox texBoxTexto;
        private DateTimePicker pickerDate;

        public ExamenEditorItem(int Ancho,int Alto,bool tieneUnidad)
        {
            this.Height = Alto;
            this.Width = Ancho;
            this.tieneUnidad = tieneUnidad;
            if (this.tieneUnidad)
            {
                this.ancho_campo = ((((Ancho/2)- margeDer) *7)/10);
                this.ancho_unidad = ((((Ancho/2)- margeDer) *3)/10);
                this.ancho_etiqueta = (Ancho / 2);
            }
            else
            {
                this.ancho_campo = (Ancho / 2)- margeDer;
                this.ancho_etiqueta = (Ancho / 2);
            }
            DoubleBuffered = true;
            InicializarComponentes();

            comboList.SelectedIndexChanged += ComboList_SelectedIndexChanged;
            texBoxInput.KeyPress += TexBoxInput_KeyPress;
            texBoxTexto.KeyPress += TexBoxTexto_KeyPress;
        }

        private void TexBoxTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ConfiguracionExamen.GetInstance().Changed = true;
        }

        private void TexBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            ConfiguracionExamen.GetInstance().Changed = true;
        }

        private void ComboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfiguracionExamen.GetInstance().Changed = true;
        }

        public void redimensionarWidth(int Ancho)
        {
            this.Width = Ancho;

            if (this.tieneUnidad)
            {
                this.ancho_campo = ((((Ancho / 2) - margeDer) * 7) / 10);
                this.ancho_unidad = ((((Ancho / 2) - margeDer) * 3) / 10);
                this.ancho_etiqueta = (Ancho / 2);
            }
            else
            {
                this.ancho_campo = ((this.Width) / 2) - margeDer;
                this.ancho_etiqueta = ((this.Width) / 2);
            }
            

            this.comboList.Size = new System.Drawing.Size(ancho_campo, alto_etiqueta);
            this.texBoxInput.Size = new System.Drawing.Size(ancho_campo, alto_etiqueta);
            this.nombre.Location = new System.Drawing.Point(0, 0);
            this.nombre.Size = new System.Drawing.Size(ancho_etiqueta, alto_etiqueta);
            Point posicion;
            switch (this.tipoCampo)
            {
                case TipoCampo.Input:
                    this.texBoxInput.Name = "textBox";
                    posicion = new Point(ancho_etiqueta, 0);
                    this.texBoxInput.Location = posicion;
                    break;
                case TipoCampo.Lista:
                    this.comboList.Name = "comboBox";
                    posicion = new Point(ancho_etiqueta, 0);
                    this.comboList.Location = posicion;
                    break;
                case TipoCampo.Texto:
                    this.texBoxTexto.Name = "textBoxT";
                    posicion = new Point(0, alto_etiqueta + 5);//POr algun motivo nombre height cambia a 128
                    this.texBoxTexto.Width = this.Width-10;
                    break;
                case TipoCampo.Fecha:
                    this.pickerDate.Name = "picker";
                    posicion = new Point(ancho_etiqueta, 0);
                    this.pickerDate.Format = DateTimePickerFormat.Short;
                    this.pickerDate.Location = posicion;
                    break;
            }
            if (this.tieneUnidad)
            {
                this.unidad.Location = new System.Drawing.Point(5+ancho_etiqueta+ancho_campo, 0);
                this.unidad.Size = new System.Drawing.Size(ancho_unidad, alto_unidad);
            }
        }

        private void InicializarComponentes()
        {
            this.nombre = new Label();
            this.texBoxInput = new TextBox();
            this.texBoxTexto = new TextBox();
            this.pickerDate = new DateTimePicker();
            this.comboList = new ComboBox();
            this.unidad = new Label();
            
            this.texBoxInput.TextChanged += TexBoxInput_TextChanged;
           
            this.texBoxInput.MaxLength = 10;
            this.texBoxTexto.MaxLength = 100;


            this.texBoxTexto.Multiline = true;
            
            this.comboList.Size = new System.Drawing.Size(ancho_campo, Height);
            this.texBoxInput.Size = new System.Drawing.Size(ancho_campo, Height);

            this.pickerDate.Size = new System.Drawing.Size(ancho_campo, Height);
            this.pickerDate.Format = DateTimePickerFormat.Short;

            this.texBoxTexto.Size = new Size(this.Width,alto_campoTexto);
            this.texBoxInput.TextAlign = HorizontalAlignment.Center;

            this.unidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.nombre.Location = new System.Drawing.Point(0,0);
            this.nombre.Size = new System.Drawing.Size(ancho_etiqueta, Height-2);
            this.nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            
            if (this.tieneUnidad)
            {
                this.unidad.Size = new System.Drawing.Size(ancho_unidad, alto_unidad);
                this.unidad.Location = new System.Drawing.Point(5 + ancho_etiqueta + ancho_campo, 0);
                this.Controls.Add(unidad);
            }
            this.Controls.Add(nombre);
        }


        public static string DoFormat(double myNumber)
        {
            var s = string.Format("{0:0.000}", myNumber);

            if (s.EndsWith("00"))
            {
                return ((int)myNumber).ToString();
            }
            else
            {
                return s;
            }
        }

        private void TexBoxInput_TextChanged(object sender, EventArgs e)
        {
            if (validador != null)
                if (!validador.IsMatch(texBoxInput.Text))
                {
                    if (texBoxInput.TextLength > 0)
                        texBoxInput.Text.Remove(texBoxInput.TextLength - 1);
                }
                else
                {
                    if(this.TipoDato==TipoDato.Decimal)
                        this.texBoxInput.Text = DoFormat(Convert.ToDouble(texBoxInput.Text));
                }
        }

        //private void TexBoxInput_KeyPress1(object sender, KeyPressEventArgs e)
        //{
        //    if(validador!=null)
        //        if (validador.IsMatch(texBoxInput.Text+e.KeyChar))
        //        {

        //            MessageBox.Show("OK");
        //        }
        //        else
        //        {
        //            MessageBox.Show("error");
        //        }

        //    e.Handled = true;
        //}

        public TipoCampo TipoCampo
        {
            get
            {
                return this.tipoCampo;
            }
            set
            {
                
                this.tipoCampo = value;
                Point posicion;
                switch (this.tipoCampo)
                {
                    case TipoCampo.Input:
                        posicion = new Point( ancho_etiqueta, 0);
                        this.texBoxInput.Name = "textBox";
                        this.texBoxInput.Location = posicion;
                        this.Controls.Add(texBoxInput);
                        break;
                    case TipoCampo.Lista:
                        posicion = new Point(ancho_etiqueta, 0);
                        this.comboList.Name = "comboBox";
                        this.comboList.Location = posicion;
                        this.Controls.Add(comboList);
                        break;
                    case TipoCampo.Texto:
                        posicion = new Point(0, nombre.Height+5);
                        this.texBoxTexto.Name = "texBoxTexto";
                        this.texBoxTexto.Location = posicion;
                        this.Controls.Add(texBoxTexto);
                        break;
                    case TipoCampo.Fecha:
                        this.pickerDate.Name = "picker";
                        posicion = new Point(ancho_etiqueta, 0);
                        this.pickerDate.Location = posicion;
                        this.Controls.Add(pickerDate);
                        break;

                }
                
            }
        }

        public TipoDato TipoDato
        {
            get
            {
                return this.tipoDato;
            }
            set
            {
                this.tipoDato= value;
            }
        }

        public int IdItem
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre.Text;
            }
            set
            {
                this.nombre.Text = value;
            }
        }
        

        public string Value
        {
            get
            {
                if (this.TipoCampo == TipoCampo.Input)
                    return this.texBoxInput.Text;
                else if (this.TipoCampo == TipoCampo.Lista)
                    return Convert.ToString(this.comboList.SelectedIndex);
                else if (this.TipoCampo == TipoCampo.Texto)
                    return this.texBoxTexto.Text;
                else if (this.TipoCampo == TipoCampo.Fecha)
                    return this.pickerDate.Value.ToShortDateString();
                else return "";
            }
            set
            {
                if (this.TipoCampo == TipoCampo.Input)
                    this.texBoxInput.Text = value;
                else if (this.TipoCampo == TipoCampo.Lista)
                    ((BindingSource)this.comboList.DataSource).Position = Convert.ToInt32(value);
                else if (this.TipoCampo == TipoCampo.Texto)
                    this.texBoxTexto.Text = value;
                else if (this.TipoCampo == TipoCampo.Fecha)
                    this.pickerDate.Value = DateTime.Parse(value);
            }
        }


        public string RegEx
        {
            set
            {
                this.regex = value;
                validador = new System.Text.RegularExpressions.Regex(regex);
            }
        }

        public string Unidad
        {
            get
            {
                return this.unidad.Text;
            }
            set
            {
                this.unidad.Text = value;
            }
        }


        public Dictionary<int,string> Opciones
        {
            set
            {
                diccionario = value;
                this.comboList.DataSource = new BindingSource(diccionario, null);
                ((BindingSource)this.comboList.DataSource).Position=0; // select init
                this.comboList.DisplayMember = "Value";
                this.comboList.ValueMember = "Key";
                this.comboList.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        
    }
}
