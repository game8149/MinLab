using static MinLab.Code.ControlSistemaInterno.Sesion;

namespace MinLab.Code.EntityLayer
{
    public class Cuenta
    {
        private int id;
        private string nombre;
        private string apellidos;
        private string dni;
        private string codigoAcceso;
        private string autorizacion;
        private SesionNivel nivel;

        

        public int IdData { get { return id; } set { this.id = value; } }


        public string Nombre { get { return nombre; } set {this.nombre=value; } }
        public SesionNivel Nivel { get { return nivel; } set { this.nivel = value; } }

        public string Apellidos { get { return apellidos; } set { this.apellidos = value; } }
        public string Dni { get { return dni; } set { this.dni = value; } }
        public string Clave { get { return codigoAcceso; } set { this.codigoAcceso = value; } }

        public string Autorizacion { get { return autorizacion; } set { this.autorizacion = value; } }

    }
}
