using MinLab.Code.EntityLayer.ArchivoPrueba;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.ComponentesPrueba
{
    partial class ControlTextBox
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private int etiqueta_width_constant = 150;
        private int separador_width_constant = 30;
        private int camp_width_constant = 150;
        private int POINT_INIT = 0;
        
        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent(Item item,string respuesta)
        {
            camp=new TextBox();
            components = new System.ComponentModel.Container();
           
            this.SuspendLayout();


            //Etiqueta
            this.etiqueta = new Label();
            this.etiqueta.Location = new System.Drawing.Point(POINT_INIT, 0);
            this.etiqueta.Size = new System.Drawing.Size(etiqueta_width_constant, Alto);
            this.etiqueta.TabIndex = 0;
            this.etiqueta.Text = item.Nombre;
            this.etiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //Separador
            this.separador = new Label();
            this.separador.Location = new System.Drawing.Point(POINT_INIT + etiqueta_width_constant, 0);
            this.separador.Size = new System.Drawing.Size(separador_width_constant, Alto);
            this.separador.TabIndex = 0;
            this.separador.Text = ":";
            this.separador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //Campo
            this.camp.Location = new System.Drawing.Point(POINT_INIT + etiqueta_width_constant + separador_width_constant, 0);
            this.camp.Name = "campo";
            this.camp.Size = new System.Drawing.Size(camp_width_constant, Alto);
            this.camp.TabIndex = 0;
            this.camp.Text = respuesta;
            

            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.None;
            this.Controls.Add(this.etiqueta);
            this.Controls.Add(this.separador);
            this.Controls.Add((this.camp));


            this.AutoSize = false;
            this.Name = item.Nombre;
            this.Size = new System.Drawing.Size(this.Width, this.Height);
            this.ResumeLayout(false);
            //this.PerformLayout();

        }

        private Label etiqueta;
        private Label separador;
        private TextBox camp;
        #endregion

    }
}
