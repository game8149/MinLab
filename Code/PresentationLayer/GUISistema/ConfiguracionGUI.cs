using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.ControlSistemaInterno.Configuracion;
using MinLab.Code.PresentationLayer.ComponenteGeneral;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.GUISistema
{
    public partial class ConfiguracionGUI : Form
    {
        public enum VistaConfig
        {
            General,
            Sonido,
            Accesibilidad
        }

        private Dictionary<VistaConfig, ButtonUI> botones = new Dictionary<VistaConfig, ButtonUI>();
        private VistaConfig VistaActual;
        private Panel PanelActual;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public void IniciarInterfaz()
        {
            BtnUIConfig1.ComponenteUI.Click += ComponenteUI_Click;
            BtnUIConfig2.ComponenteUI.Click += ComponenteUI_Click1;
            BtnUIConfig3.ComponenteUI.Click += ComponenteUI_Click2;
            BtnUIConfig4.ComponenteUI.Click += ComponenteUI_Click3;
            BtnUIConfig5.ComponenteUI.Click += ComponenteUI_Click4;
            BtnUIConfig6.ComponenteUI.Click += ComponenteUI_Click5;

            botones.Add(VistaConfig.General, BtnUIConfig1);
            botones.Add(VistaConfig.Sonido, BtnUIConfig2);
            botones.Add(VistaConfig.Accesibilidad, BtnUIConfig3);


            BtnUIConfig1.Tipo = ButtonUI.ButtonTipo.Item;
            BtnUIConfig2.Tipo = ButtonUI.ButtonTipo.Item;
            BtnUIConfig3.Tipo = ButtonUI.ButtonTipo.Item;
            BtnUIConfig4.Tipo = ButtonUI.ButtonTipo.Ok;
            BtnUIConfig5.Tipo = ButtonUI.ButtonTipo.Cancel;
            BtnUIConfig6.Tipo = ButtonUI.ButtonTipo.Ok;

            foreach (Control con in this.Controls)
            {
                CambiartStyle(con);
            }

            VistaActual = VistaConfig.General;
            PanelActual = PanelGeneral;

            PanelAccesibilidad.Visible = false;
            PanelSonido.Visible = false;

            MostrarVista(VistaActual);
        }

        private void ComponenteUI_Click5(object sender, EventArgs e)
        {
            ConfiguracionSystem.Daltonic = CheckBoxDaltonic.Checked;
            ConfiguracionSystem.Sound = CheckBoxSoundSesion.Checked;
            this.Close();
        }

        private void ComponenteUI_Click4(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComponenteUI_Click3(object sender, EventArgs e)
        {
            LlenarDatosDefault(VistaConfig.Accesibilidad);
            LlenarDatosDefault(VistaConfig.Sonido);
        }

        private void ComponenteUI_Click2(object sender, EventArgs e)
        {
            MostrarVista(VistaConfig.Accesibilidad);
        }

        private void ComponenteUI_Click1(object sender, EventArgs e)
        {
            MostrarVista(VistaConfig.Sonido);
        }

        private void ComponenteUI_Click(object sender, EventArgs e)
        {
            MostrarVista(VistaConfig.General);
        }

        public void CambiartStyle(Control c)
        {
            if (c is ButtonUI)
            {
                Decorator e = new Decorator();
                e.FormatButton((ButtonUI)c);
                string temp = RecursosUI.ResourceManager.GetString(c.Name,RecursosUI.Culture);
                if (temp != String.Empty) ((ButtonUI)c).ComponenteUI.Text = temp;
            }
            if (c.Controls.Count == 0) ;
            else
                foreach (Control con in c.Controls)
                {
                    CambiartStyle(con);
                }
            return;
        }

        public ConfiguracionGUI()
        {
            InitializeComponent();
            IniciarInterfaz();

            LlenarDatos(VistaConfig.General);
            LlenarDatos(VistaConfig.Accesibilidad);
            LlenarDatos(VistaConfig.Sonido);
        }

        public void setBotonColorSelect(VistaConfig id)
        {
            botones[id].ComponenteUI.BackColor = StylesGeneral.ButtonItem.BackGroundLight;
            botones[id].ComponenteUI.FlatAppearance.BorderColor = StylesGeneral.ButtonItem.BordeColor;
            botones[id].ComponenteUI.FlatAppearance.BorderSize = StylesGeneral.ButtonItem.BordeSize;
            botones[id].ComponenteUI.FlatAppearance.MouseDownBackColor = StylesGeneral.ButtonItem.BackGroundLight;
        }

        public void setBotonColorOriginal(VistaConfig id)
        {
            botones[id].ComponenteUI.BackColor = StylesGeneral.ButtonItem.BackGroundNormal;
            botones[id].ComponenteUI.FlatAppearance.BorderColor = StylesGeneral.ButtonItem.BordeColor;
            botones[id].ComponenteUI.FlatAppearance.BorderSize = StylesGeneral.ButtonItem.BordeSize;
            botones[id].ComponenteUI.FlatAppearance.MouseDownBackColor = StylesGeneral.ButtonItem.BackGroundLight;
        }

        private void MostrarVista(VistaConfig vista)
        {

            if (VistaActual != vista)
            {
                PanelActual.Visible = false;
                setBotonColorOriginal(VistaActual);

                VistaActual = vista;

                switch (VistaActual)
                {
                    case VistaConfig.General:
                        PanelActual = PanelGeneral;
                        break;
                    case VistaConfig.Sonido:
                        PanelActual = PanelSonido;
                        break;
                    case VistaConfig.Accesibilidad:
                        PanelActual = PanelAccesibilidad;
                        break;
                }
                setBotonColorSelect(VistaActual);

                PanelActual.Location = new Point(22, 12);
                PanelActual.Visible = true;
            }
        }
        
        public void LlenarDatos(VistaConfig vista)
        {

            switch (VistaActual)
            {
                case VistaConfig.General:
                    
                    break;
                case VistaConfig.Sonido:
                    CheckBoxSoundSesion.Checked = ConfiguracionSystem.Sound;
                    break;
                case VistaConfig.Accesibilidad:
                    CheckBoxDaltonic.Checked = ConfiguracionSystem.Daltonic;
                    break;
            }
        }

        public void LlenarDatosDefault(VistaConfig vista)
        {

            switch (VistaActual)
            {
                case VistaConfig.General:

                    break;
                case VistaConfig.Sonido:
                    CheckBoxSoundSesion.Checked =ConfiguracionSystem.SoundDefault;
                    break;
                case VistaConfig.Accesibilidad:
                    CheckBoxDaltonic.Checked = ConfiguracionSystem.DaltonicDefault;
                    break;
            }
        }

    }
}
