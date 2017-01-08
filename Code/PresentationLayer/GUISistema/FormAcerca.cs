using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.GUISistema
{
    public partial class FormAcerca : Form
    {
        public FormAcerca()
        {
            InitializeComponent();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            LabelVersion.Text= fvi.FileVersion;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string pdfPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Docs\\NotaVer.pdf";

                Process.Start(pdfPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reinstale el Programa: " + ex.Message, "Advertencia");
            }


        }
    }
}
