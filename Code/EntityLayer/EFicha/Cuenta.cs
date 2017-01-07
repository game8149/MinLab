using static MinLab.Code.ControlSistemaInterno.Sesion;

namespace MinLab.Code.EntityLayer.EFicha
{
    public class Cuenta:FichaBasica
    {
        private string dni;
        private string clave;
        private string autorizacion;
        private SesionNivel nivel;
        
        public SesionNivel Nivel { get { return nivel; } set { this.nivel = value; } }

        public string Especialidad { get; set; }
        public string CodigoPro { get; set; }
        public string Dni { get { return dni; } set { this.dni = value; } }
        public string Clave { get { return clave; } set { this.clave = value; } }

        public string Autorizacion { get { return autorizacion; } set { this.autorizacion = value; } }

    }
}
