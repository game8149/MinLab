using MinLab.Code.EntityLayer.ArchivoPrueba;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.ComponentesPrueba
{
    partial class ControlGrupo
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private int Y_Posicion = 0;
        private int X_Posicion = 0;
        private int camp_Heigth = 25;
        private int SEPARADOR_HEIGTH = 5;
        
        private List<ControlTextBox> itemTexts = new List<ControlTextBox>();
        private List<ControlComboBox> itemCombos = new List<ControlComboBox>();
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
        private void InitializeComponent()
        {
            
            this.grupoBox = new GroupBox();
            components = new System.ComponentModel.Container();
            this.grupoBox.SuspendLayout();
            this.SuspendLayout();
            

            this.grupoBox.Location = new System.Drawing.Point(0, Y_Posicion);
            this.grupoBox.TabIndex = 0;
            this.grupoBox.AutoSize = false;

            this.AutoSize = false;
            this.Size = new System.Drawing.Size(this.Width, this.Height);
            
            
            grupoBox.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private GroupBox grupoBox;
        #endregion
    }
}
