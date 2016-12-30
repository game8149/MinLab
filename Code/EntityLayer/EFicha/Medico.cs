using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.EntityLayer.EFicha
{
    public class Medico : FichaBasica
    {
        public string Colegiatura { get; set; }

        public string Especialidad { get; set; }

        public bool Habil { get; set; }
    }
}
